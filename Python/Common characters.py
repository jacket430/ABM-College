from collections import Counter

def common_chars(words):
    min_char_count = Counter(words[0])
    for word in words[1:]:
        word_counter = Counter(word)
        for char in min_char_count:
            if char in word_counter:
                min_char_count[char] = min(min_char_count[char], word_counter[char])
            else:
                min_char_count[char] = 0
    return sorted([char for char, count in min_char_count.items() for _ in range(count)])

words1 = ["bella", "label", "roller"]
words2 = ["cool", "lock", "cook"]

print(common_chars(words1))
print(common_chars(words2))
