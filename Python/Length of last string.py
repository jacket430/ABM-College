def word_length(string):
    words = string.split()
    if len(words) == 0:
        return 0
    last_word = words[-1]
    return len(last_word)

input_string = "My name is Avery         "
length = word_length(input_string)
print(length)