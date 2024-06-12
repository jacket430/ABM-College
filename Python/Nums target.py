def find_pairs(numbers, target):
    num_dict = {}
    results = []
    for i, num in enumerate(numbers):
        diff = target - num
        if diff in num_dict:
            results.append((num_dict[diff], i))
        num_dict[num] = i
    return results if results else "Unable to add to target."

numbers = [1, 3, 6, 8]
target = 9
print(find_pairs(numbers, target))