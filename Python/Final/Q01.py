def maxProduct(nums):
    max_prod = min_prod = ans = nums[0]

    for num in nums[1:]:
        if num < 0:
            max_prod, min_prod = min_prod, max_prod
        max_prod = max(num, max_prod * num)
        min_prod = min(num, min_prod * num)
        ans = max(ans, max_prod)

    return ans

nums = [2,3,-2,4]
print(maxProduct(nums))