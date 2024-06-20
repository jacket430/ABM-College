def find_sender_with_max_word_count(messages, senders):
    word_count = {}
    for message, sender in zip(messages, senders):
        words = message.split()
        count = len(words)
        if sender not in word_count:
            word_count[sender] = count
        else:
            word_count[sender] += count
    max_sender = max(word_count, key=word_count.get)
    return max_sender

messages = ["Hello userTwooo", "Hi userThree", "Wonderful day Alice", "Nice day userThree"]
senders = ["Alice", "userTwo", "userThree", "Alice"]

result = find_sender_with_max_word_count(messages, senders)
print(result)