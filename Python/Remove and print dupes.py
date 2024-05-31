input_list = [2, 5, 2, 2, 7, 2, 5, "Avery", "Harman", 8, 2, 8, 9, 9, "Harman"]

## unique_list = list(set(input_list))

## print("List without duplicates:", unique_list)

loop_list = []
for item in input_list:
    if item not in loop_list:
        loop_list.append(item)

print("List without duplicates:", loop_list)