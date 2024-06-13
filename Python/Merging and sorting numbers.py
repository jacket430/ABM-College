list1 = [1, 3, 0, 5, 4]
list2 = [1, 2, 4, 7, 6]

combined_list = list1 + list2
combined_list = [num for num in combined_list if num != 0]

for i in range(len(combined_list)):
    for j in range(len(combined_list) - 1):
        if combined_list[j] > combined_list[j + 1]:
            combined_list[j], combined_list[j + 1] = combined_list[j + 1], combined_list[j]

print(combined_list)