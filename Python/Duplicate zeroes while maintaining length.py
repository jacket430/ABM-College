def duplicate_zeros(arr):
    result = []
    for num in arr:
        if num == 0:
            result.append(0)
        result.append(num)
    return result[:len(arr)]

arr = [1,0,2,3,0,4,5,0]
print(duplicate_zeros(arr))