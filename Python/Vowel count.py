vowels = ['a', 'e', 'i', 'o', 'u']
data = "Python course in ABM module"

vowel_count = {vowel: 0 for vowel in vowels}
data = data.lower()
for char in data:
    if char in vowels:
        vowel_count[char] += 1
for vowel, count in vowel_count.items():
    print(f"{vowel} - {count}")
