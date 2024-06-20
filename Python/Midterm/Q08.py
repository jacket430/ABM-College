def findLength(nums1, nums2):
    dp = [[0] * (len(nums2) + 1) for _ in range(len(nums1) + 1)]
    max_length = 0

    for i in range(1, len(nums1) + 1):
        for j in range(1, len(nums2) + 1):
            if nums1[i-1] == nums2[j-1]:
                dp[i][j] = dp[i-1][j-1] + 1
                max_length = max(max_length, dp[i][j])

    return max_length

nums1 = [1,2,3,2,1]
nums2 = [3,2,1,4,7]
print(f"The maximum length subarray in both arrays is {findLength(nums1, nums2)}")