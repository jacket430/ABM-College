def check_pattern(pattern, string):
    words = string.split()
    mapping = {}
    
    for p, w in zip(pattern, words):
        if p not in mapping:
            mapping[p] = w
        elif mapping[p] != w:
            return False
    
    return True

pattern = "abba"
string = "dog cat cat dog"
print(check_pattern(pattern, string))