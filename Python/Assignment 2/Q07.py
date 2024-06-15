def largestNumber(nums):
    nums = list(map(str, nums))
    nums.sort(key=lambda x: x*3, reverse=True)
    result = int(''.join(nums))
    return str(result)

nums = [10, 2]
result = largestNumber(nums)
print(result)