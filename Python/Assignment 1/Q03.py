def move_zeroes_to_end(arr):
    non_zero_elements = [num for num in arr if num != 0]
    zero_count = arr.count(0)
    result = non_zero_elements + [0] * zero_count
    return result

numbers = [0, 2, 0, 1, 2, 3, 4, 0, 3, 0, 73, 0, 26, 0, 3, 57, 3, 236, 75, 0, 0, 2]
result = move_zeroes_to_end(numbers)
print(result)
