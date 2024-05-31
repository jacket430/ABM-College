def count_elements(input_list):
    element_count = {}
    
    for element in input_list:
        if element in element_count:
            element_count[element] += 1
        else:
            element_count[element] = 1
    
    for element, count in element_count.items():
        print(f"{element}: {count}")

input_list = [2, 4, 5, 6, 3, 4, 1, 3, 8, 6, 9, 6, 7, 5, 4, 2]
count_elements(input_list)
