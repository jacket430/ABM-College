def partitionCheck(nums):
    total_sum = sum(nums)
    print(f"Sum of array: {total_sum}")
    if total_sum % 2 != 0:
        print("Can't partition an array with an odd sum.")
        return False
    else:
        print("Valid array.")
    target = total_sum // 2
    dp = [False] * (target + 1)
    dp[0] = True

    for num in nums:
        for i in range(target, num - 1, -1):
            dp[i] = dp[i] or dp[i - num]

    return dp[target]

nums = [1, 5, 11, 5]
print(f"Can partition: {partitionCheck(nums)}")