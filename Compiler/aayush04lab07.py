# Grammar and Parsing Table
M = {
    "E": {"id":["T","E'"]},
    "E'":{"+":["+","T","E'"], "$":["ε"]},
    "T":{"id":["id"]}
}

def parse(tokens):
    stack = ["$", "E"]
    tokens.append("$")
    i = 0
    print(f"{'Stack':<20} {'Input':<20} {'Action'}")
    
    while stack:
        top = stack.pop()
        cur = tokens[i]
        print(f"{stack + [top]!s:<20} {tokens[i:]!s:<20}", end=" ")
        
        if top == cur:
            if top == "$": print("Accepted"); return True
            print(f"Match '{cur}'"); i += 1
        elif top == "ε":
            print("Pop ε"); continue
        elif top in M and cur in M[top]:
            prod = M[top][cur]
            print(f"{top} → {' '.join(prod)}")
            stack.extend(prod[::-1])
        else:
            print(f"Error: {top} with {cur}"); return False
    return False

# Test strings
tests = [["id"], ["id","+","id"], ["id","+","+"]]
for t in tests:
    print("\nParsing:", t)
    parse(t.copy())
