def rank_elements(arr):
    sorted_arr = sorted(arr)
    rank_dict = {v: i+1 for i, v in enumerate(sorted_arr)}
    return [rank_dict[num] for num in arr]

arr = [37, 42, 6, 11, 2, 86, 102, 53]
print (rank_elements(arr))