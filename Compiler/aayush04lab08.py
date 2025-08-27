# Grammar
productions = [
    ("S", ["a","S","b"]),
    ("S", ["ε"])
]

def shift_reduce_parser(tokens):
    stack = []
    tokens.append("$")
    print(f"{'Stack':<20} {'Input':<20} {'Action'}")
    
    i = 0
    while True:
        reduced = False
        for lhs, rhs in productions:
            if rhs == ["ε"] and stack == []:
                print(f"{stack!s:<20} {tokens[i:]!s:<20} Reduce {lhs} → ε")
                stack.append(lhs)
                reduced = True
                break
            elif len(stack) >= len(rhs) and stack[-len(rhs):] == rhs:
                print(f"{stack!s:<20} {tokens[i:]!s:<20} Reduce {lhs} → {''.join(rhs)}")
                stack = stack[:-len(rhs)]
                stack.append(lhs)
                reduced = True
                break
        if reduced:
            continue

        if i < len(tokens):
            stack.append(tokens[i])
            print(f"{stack!s:<20} {tokens[i+1:]!s:<20} Shift '{tokens[i]}'")
            if tokens[i] == "$" and stack == ["S","$"]:
                print(f"{stack!s:<20} {tokens[i+1:]!s:<20} Accepted")
                return True
            i += 1
        else:
            print(f"{stack!s:<20} {tokens[i:]!s:<20} Error: Rejected")
            return False

# Test Inputs
inputs = [
    ["a","b"],      # Accepted
    ["a","b","b"]   # Rejected
]

for t in inputs:
    print("\nParsing:", t)
    shift_reduce_parser(t.copy())
