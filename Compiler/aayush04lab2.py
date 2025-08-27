import re
kw = {"int", "float", "if", "else", "while", "return", "char", "for", "double", "break"}
op = {'+', '-', '*', '/', '=', '==', '!=', '<', '>', '<=', '>=', '&&', '||'}
dl = {';', ',', '(', ')', '{', '}'}
id_pat = r'^[A-Za-z_]\w*$'
const_pat = r'^\d+(\.\d+)?$'
code = input("Enter code: ")
tokens = re.findall(r'"[^"]*"|[A-Za-z_]\w*|\d+\.\d+|\d+|==|!=|<=|>=|&&|\|\||[+\-*/=<>;:,(){}]', code)
types = {k: [] for k in ["Keywords", "Identifiers", "Constants", "Operators", "Delimiters"]}
for t in tokens:
    types["Keywords"].append(t) if t in kw else \
    types["Constants"].append(t) if re.fullmatch(const_pat, t) else \
    types["Identifiers"].append(t) if re.fullmatch(id_pat, t) else \
    types["Operators"].append(t) if t in op else \
    types["Delimiters"].append(t) if t in dl else None
for k, v in types.items():
    print(f"{k} ({len(v)}): {', '.join(v)}" if v else f"{k} (0):")
print(f"Total Tokens: {len(tokens)}")
