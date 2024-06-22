def maxSubArray(nums):
    max_sum = current_sum = nums[0]
    for num in nums[1:]:
        current_sum = max(num, current_sum + num)
        max_sum = max(max_sum, current_sum)
    return max_sum

nums1 = [-2,1,-3,4,-1,2,1,-5,4]
nums2 = [1]

print(maxSubArray(nums1))
print(maxSubArray(nums2))