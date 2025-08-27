def dfa_even_0_1(s):
    state = 'q0'
    for c in s:
        if state=='q0':
            state = 'q2' if c=='0' else 'q1'
        elif state=='q1':
            state = 'q3' if c=='0' else 'q0'
        elif state=='q2':
            state = 'q0' if c=='0' else 'q3'
        elif state=='q3':
            state = 'q1' if c=='0' else 'q2'
    return state=='q0'

# Test
for t in ["", "0", "1", "01", "0011", "0101", "1100", "1111"]:
    print(f"{t!r} -> {dfa_even_0_1(t)}")
