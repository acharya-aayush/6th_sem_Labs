# Grammar: S→Aa | b ; A→c
G = {'S': [['A','a'], ['b']], 'A': [['c']]}

def first(X, G, memo):
    if X not in G: return {X}              # terminal
    if X in memo:  return memo[X]
    F = set()
    for prod in G[X]:
        for sym in prod:
            f = first(sym, G, memo)
            F |= (f - {'ε'})
            if 'ε' not in f: break
        else:
            F.add('ε')
    memo[X] = F
    return F

memo = {}
FS, FA = first('S', G, memo), first('A', G, memo)
print("FIRST(A) =", FA)
print("FIRST(S) =", FS)
