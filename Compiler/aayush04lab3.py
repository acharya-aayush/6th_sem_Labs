def lexical_analyzer(code):
    tokens, current = [], ""
    for char in code:
        if char in [' ', '\t', '\n']:
            if current: tokens.append(current); current=""
        else:
            current += char
    if current: tokens.append(current)
    return tokens

# Source code with Aayush
source_code = """
int main() {
    int Aayush_age = 20;     
    printf("Hello, aayush! u r %d years old.", Aayush_age);    
    return 0;
}
"""

print("Tokens:", lexical_analyzer(source_code))
