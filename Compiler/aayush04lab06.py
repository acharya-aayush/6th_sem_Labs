
# Grammar: S→Aa | b ; A→c
G = {'S': [['A','a'], ['b']], 'A': [['c']]}  # Define the grammar as a dictionary


def first(X, G, memo):  # Function to compute FIRST set for symbol X
    if X not in G:  # If X is not a non-terminal (not in grammar keys)
        return {X}  # It's a terminal, so FIRST(X) is itself
    if X in memo:   # If FIRST(X) is already computed
        return memo[X]  # Return the cached result
    F = set()  # Initialize an empty set for FIRST(X)
    for prod in G[X]:  # For each production of X
        for sym in prod:  # For each symbol in the production (from left to right)
            f = first(sym, G, memo)  # Recursively compute FIRST(sym)
            F |= (f - {'ε'})  # Add all elements of FIRST(sym) except epsilon to F
            if 'ε' not in f:  # If epsilon is not in FIRST(sym)
                break  # Stop checking further symbols in this production
        else:  # If we didn't break (all symbols can derive epsilon)
            F.add('ε')  # Add epsilon to FIRST(X)
    memo[X] = F  # Cache the computed FIRST(X)
    return F  # Return the FIRST set for X


memo = {}  # Dictionary to store computed FIRST sets
FS = first('S', G, memo)  # Compute FIRST(S)
FA = first('A', G, memo)  # Compute FIRST(A)
print("FIRST(A) =", FA)  # Print FIRST(A)
print("FIRST(S) =", FS)  # Print FIRST(S)
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
