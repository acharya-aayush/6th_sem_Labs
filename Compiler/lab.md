# DFA and Lexical Analyzer Programs

This document contains full working Python programs for DFA, identifier validation, operator validation, substring detection, and comment detection. Each program is standalone and corresponds to a specific question.

---

## SET A

### 1. Implement a DFA for even number of 0s and even number of 1s

**Algorithm:**

1. Define four states based on parity of 0s and 1s:

   * q0: even 0, even 1 (start and accept)
   * q1: odd 0, even 1
   * q2: even 0, odd 1
   * q3: odd 0, odd 1
2. Read input string symbol by symbol.
3. Transition between states based on input.
4. If final state is q0, accept. Else reject.

**Python Code:**

```python
def even_zeros_even_ones(s):
    state = "q0"  # even 0, even 1

    for ch in s:
        if ch not in "01":
            return False

        if state == "q0":
            state = "q1" if ch == "0" else "q2"
        elif state == "q1":
            state = "q0" if ch == "0" else "q3"
        elif state == "q2":
            state = "q3" if ch == "0" else "q0"
        elif state == "q3":
            state = "q2" if ch == "0" else "q1"

    return state == "q0"


s = input("Enter binary string: ")
print("Accepted" if even_zeros_even_ones(s) else "Rejected")
```

---

### 2. Program to test whether a given identifier is valid or not

**Rules:**

* Must start with letter or underscore
* Can contain letters, digits, underscore
* No spaces or symbols

**Python Code:**

```python
def is_valid_identifier(s):
    if len(s) == 0:
        return False

    if not (s[0].isalpha() or s[0] == "_"):
        return False

    for ch in s[1:]:
        if not (ch.isalnum() or ch == "_"):
            return False

    return True


s = input("Enter identifier: ")
print("Valid Identifier" if is_valid_identifier(s) else "Invalid Identifier")
```

---

## SET B

### 1. DFA accepting odd number of 0s and odd number of 1s

**Python Code:**

```python
def odd_zeros_odd_ones(s):
    state = "q0"

    for ch in s:
        if ch not in "01":
            return False

        if state == "q0":
            state = "q1" if ch == "0" else "q2"
        elif state == "q1":
            state = "q0" if ch == "0" else "q3"
        elif state == "q2":
            state = "q3" if ch == "0" else "q0"
        elif state == "q3":
            state = "q2" if ch == "0" else "q1"

    return state == "q3"


s = input("Enter binary string: ")
print("Accepted" if odd_zeros_odd_ones(s) else "Rejected")
```

---

### 2. Program to simulate lexical analyzer for validating operators

**Operators considered:** `+ - * / % = == < > <= >= !=`

**Python Code:**

```python
def is_operator(token):
    operators = {
        "+", "-", "*", "/", "%", "=",
        "==", "<", ">", "<=", ">=", "!="
    }
    return token in operators


token = input("Enter operator: ")
print("Valid Operator" if is_operator(token) else "Invalid Operator")
```

---

## SET C

### 1. Implement DFA for the substring 001 or 101 over input (0,1)

**Python Code:**

```python
def contains_001_or_101(s):
    state = 0

    for ch in s:
        if ch not in "01":
            return False

        if state == 0:
            state = 1 if ch == "0" else 4
        elif state == 1:
            state = 2 if ch == "0" else 4
        elif state == 2:
            if ch == "1":
                return True
            state = 2
        elif state == 4:
            state = 5 if ch == "0" else 4
        elif state == 5:
            if ch == "1":
                return True
            state = 1

    return False


s = input("Enter binary string: ")
print("Accepted" if contains_001_or_101(s) else "Rejected")
```

---

### 2. Program to identify whether a given line is a comment or not

**Rules:**

* Single-line comment starts with `//`
* Multi-line comment starts with `/*` and ends with `*/`

**Python Code:**

```python
def is_comment(line):
    line = line.strip()
    if line.startswith("//"):
        return True
    if line.startswith("/*") and line.endswith("*/"):
        return True
    return False


line = input("Enter a line: ")
print("Comment" if is_comment(line) else "Not a Comment")
```

---

## SET D

### 1. Program to build a DFA to accept strings that start and end with same character

**Python Code:**

```python
def start_end_same(s):
    if len(s) == 0:
        return False
    return s[0] == s[-1]


s = input("Enter string: ")
print("Accepted" if start_end_same(s) else "Rejected")
```

---

### 2. Program to test whether a given identifier is valid or not (again)

**Python Code:**

```python
def is_valid_identifier(s):
    if len(s) == 0:
        return False

    if not (s[0].isalpha() or s[0] == "_"):
        return False

    for ch in s[1:]:
        if not (ch.isalnum() or ch == "_"):
            return False

    return True


s = input("Enter identifier: ")
print("Valid Identifier" if is_valid_identifier(s) else "Invalid Identifier")
```
