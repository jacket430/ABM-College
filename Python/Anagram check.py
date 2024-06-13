def check_anagram(word1, word2):
    return sorted(word1) == sorted(word2)

word1 = "boglin"
word2 = "goblin"
result = check_anagram(word1, word2)
print(result)