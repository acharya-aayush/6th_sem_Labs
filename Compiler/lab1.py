import re

s = input("Enter a string to check if it's a valid identifier: ")
if re.match(r'^[A-Za-z][A-Za-z0-9_]*$',s):
    print(f"'{s}' is a valid indentifier")
else:
    print(f"'{s}' is not a valid identifier")   