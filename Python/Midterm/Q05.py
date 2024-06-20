def reverseWords(s):
    words = ''.join(s).split(' ')
    words.reverse()
    return list(' '.join(words))

s = ["t","h","e"," ","s","k","y"," ","i","s"," ","b","l","u","e"]
print(reverseWords(s))