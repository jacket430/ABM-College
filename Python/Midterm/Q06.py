def lengthOfLIS(nums):
    dp = []
    for i in range(len(nums)):
        dp.append(max([dp[j] for j in range(i) if nums[i] > nums[j]], key=len, default=[]) + [nums[i]])
    return max(dp, key=len, default=[])

nums = [10,9,2,3,7,101,18]
print(lengthOfLIS(nums))