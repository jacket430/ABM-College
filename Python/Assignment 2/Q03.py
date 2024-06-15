# Changed the output format for clarity. Now it will print the largest number and its position.

def determine_largest(nums):
    max_num = max(nums)
    index_of_max = nums.index(max_num)
    for i in nums:
        if i != max_num and max_num < 2 * i:
            return -1
    return index_of_max, max_num

nums = [3,6,1,0]
index, max_num = determine_largest(nums)
if index != -1:
    print(f"The largest number is {max_num}, it is in array position {index}.")
else:
    print("No number is at least twice as much as every other number in the array.")