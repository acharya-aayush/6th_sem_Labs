def r(s):
    res = []
    if s=="" or all(c=='a' for c in s): res.append("a*")
    if s and s[-1]=='b' and all(c=='A' for c in s[:-1]): res.append("A*b+")
    if s=="abb": res.append("abb")
    return res or ["none"]

# Test
tests = ["", "a", "aa", "b", "bb", "AAb", "AAAb", "abb", "abc", "Ab", "aaaa", "ABb"]
for t in tests:
    print(f"{t!r} -> {r(t)}")
