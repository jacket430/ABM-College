def check_duplicates(numbers):
    count_dict = {}
    for num in numbers:
        if num in count_dict:
            return True
        count_dict[num] = 1
    return False

numbers = [1, 2, 3, 3, 4, 4, 5, 6, 7, 8, 9]
result = check_duplicates(numbers)
print(result)