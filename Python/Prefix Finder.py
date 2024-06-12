def find_common_prefix(strs):
    if not strs: 
        return "No input detected."
    
    prefix = min(strs, key=len)
    
    for word in strs:
        while not word.startswith(prefix):
            prefix = prefix[:-1]
    return f"The common prefix is '{prefix}'" if prefix else "There is no common prefix"

print(find_common_prefix(["flower", "flow", "flight"]))
print(find_common_prefix(["dog", "fish", "cat"]))