from collections import defaultdict
class LR:
    def __init__(s,l,r,d=0):s.l,s.r,s.d=l,r,d
    def n(s):return s.r[s.d]if s.d<len(s.r)else None
    def m(s):return LR(s.l,s.r,s.d+1)
    def __eq__(s,o):return(s.l,s.r,s.d)==(o.l,o.r,o.d)
    def __hash__(s):return hash((s.l,tuple(s.r),s.d))
def first(g,nt,t):
    f={**{n:set()for n in nt},**{x:{x}for x in t}};c=1
    while c:
        c=0
        for l,ps in g.items():
            for r in ps:
                if not r or r==['ε']:
                    if 'ε'not in f[l]:f[l].add('ε');c=1
                else:
                    b=len(f[l])
                    for sy in r:
                        if sy in t:f[l].add(sy);break
                        f[l]|=f[sy]-{'ε'}
                        if 'ε'not in f[sy]:break
                    else:f[l].add('ε')
                    if len(f[l])>b:c=1
    return f
def follow(g,nt,t,fs,start):
    fo={n:set()for n in nt};fo[start].add('$');c=1
    while c:
        c=0
        for l,ps in g.items():
            for r in ps:
                if not r or r==['ε']:continue
                for i,sy in enumerate(r):
                    if sy in nt:
                        bt=r[i+1:];b=len(fo[sy])
                        if not bt:fo[sy]|=fo[l]
                        else:
                            fb,ae=set(),1
                            for s in bt:
                                if s in t:fb.add(s);ae=0;break
                                fb|=fs[s]-{'ε'}
                                if 'ε'not in fs[s]:ae=0;break
                            fo[sy]|=fb-{'ε'}
                            if ae:fo[sy]|=fo[l]
                        if len(fo[sy])>b:c=1
    return fo
def cl(its,g):
    r=set(its);a=1
    while a:
        a=0
        for i in list(r):
            sy=i.n()
            if sy in g['n']:
                for p in g['p'][sy]:
                    nw=LR(sy,p,0)
                    if nw not in r:r.add(nw);a=1
    return r
def gt(its,sy,g):mv=[i.m()for i in its if i.n()==sy];return cl(mv,g)if mv else set()
g={'p':{},'n':set(),'t':set(),'s':'E'}
for l,r in[rule.split("->")for rule in["E->E + T|T","T->T * F|F","F->( E )|id"]]:g['n'].add(l);[g['p'].setdefault(l,[]).append(a.split())for a in r.split("|")]
g['n'].add(g['s']+"'");g['p'][g['s']+"'"]=[['E']]
for ps in g['p'].values():
    for p in ps:
        for sy in p:
            if sy!='ε'and sy not in g['n']:g['t'].add(sy)
ss=cl([LR(g['s']+"'",['E'],0)],g);sts,tr=[ss],{}
for i,s in enumerate(sts):
    for sy in g['t']|g['n']:
        nx=gt(s,sy,g)
        if nx:
            if nx not in sts:sts.append(nx)
            tr[(i,sy)]=sts.index(nx)
a,gt_t=defaultdict(dict),defaultdict(dict)
for i,s in enumerate(sts):
    for it in s:
        ns=it.n()
        if ns in g['t']:a[i][ns]=('shift',tr[(i,ns)])
        elif ns is None:
            if it.l=="E'":a[i]['$']=('accept',)
            else:
                fs=first(g['p'],g['n'],g['t']);fo=follow(g['p'],g['n'],g['t'],fs,g['s'])
                for t in fo[it.l]:a[i][t]=('reduce',it.l,it.r)
    for nt in g['n']:
        if(i,nt)in tr:gt_t[i][nt]=tr[(i,nt)]
pm={(l,tuple(r)):i+1 for i,(l,ps)in enumerate(g['p'].items())for r in ps};ts,nts=sorted(g['t'])+['$'],sorted(g['n']-{g['s']})
print("".join(h.ljust(8)for h in["States"]+ts+nts)+"\n"+"-"*(len(ts+nts+["States"])*8))
for s in sorted(set(a)|set(gt_t)):print("".join(c.ljust(8)for c in[f"I{s}"]+[f"s{a[s][t][1]}"if t in a[s]and a[s][t][0]=='shift'else"Accept"if t in a[s]and a[s][t][0]=='accept'else f"r{pm.get((a[s][t][1],tuple(a[s][t][2])),'?')}"if t in a[s]else""for t in ts]+[str(gt_t[s].get(nt,""))for nt in nts]))
stk,tks,idx=[0],input("Enter input: ").split()+['$'],0;print(f"\n{'Stack':<20}{'Input':<15}{'Action':<25}\n"+"-"*65)
while 1:
    st,tk=stk[-1],tks[idx]
    if tk not in a[st]:print(f"ERROR! {tk} in state {st}");break
    k=a[st][tk]
    if k[0]=='shift':print(f"{'S'+'S'.join(map(str,stk)):<20}{''.join(tks[idx:]):<15}Shift {tk} to {k[1]}");stk.append(k[1]);idx+=1
    elif k[0]=='reduce':l,r=k[1],k[2];print(f"{'S'+'S'.join(map(str,stk)):<20}{''.join(tks[idx:]):<15}Reduce {l} -> {' '.join(r)if r else'ε'}");[stk.pop()for _ in r];stk.append(gt_t[stk[-1]][l])
    elif k[0]=='accept':print(f"{'S'+'S'.join(map(str,stk)):<20}{''.join(tks[idx:]):<15}Accept");print('\nInput successfully parsed!');break
