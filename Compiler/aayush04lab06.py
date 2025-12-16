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
# --------------------------------------------------
# THEORY:
# FIRST(X) is the set of terminals that can appear
# as the first symbol in any string derived from X.
# FIRST sets are used in predictive parsing.
#
# ALGORITHM:
# Step 1: Start
# Step 2: If symbol is terminal, FIRST = {symbol}
# Step 3: If symbol is non-terminal:
#         - For each production, compute FIRST
# Step 4: Add terminals excluding ε
# Step 5: If ε appears in all symbols, include ε
# Step 6: Repeat until no change
# Step 7: Display FIRST sets
# Step 8: Stop
# --------------------------------------------------
