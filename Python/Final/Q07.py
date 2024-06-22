def count_words(file_path, n):
    with open(file_path, 'r') as file:
        text = file.read()

    words = text.split()
    word_count = {}
    for word in words:
        word_count[word] = word_count.get(word, 0) + 1

    sorted_words = sorted(word_count.items(), key=lambda x: x[1], reverse=True)
    for word, count in sorted_words[:n]:
        print(f'{word}: {count}')


file_path = 'Test.txt'
n = 10
count_words(file_path, n)