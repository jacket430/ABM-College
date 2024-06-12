def is_brackets_closed(string):
    stack = []
    opening_brackets = ['(', '[', '{']
    closing_brackets = [')', ']', '}']
    
    for char in string:
        if char in opening_brackets:
            stack.append(char)
        elif char in closing_brackets:
            if not stack:
                return False
            if opening_brackets.index(stack.pop()) != closing_brackets.index(char):
                return False
    
    return len(stack) == 0

string = input("Please enter a string: ")
if is_brackets_closed(string):
    print("Brackets are closed properly.")
else:
    print("Brackets are not closed properly.")