## Problem

https://leetcode.com/problems/subarray-sum-equals-k/

```
Given an array of integers and an integer k, you need to find the total number of continuous subarrays whose sum equals to k.

Example 1:

Input:nums = [1,1,1], k = 2
Output: 2

```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O( )  |
| Space      | O( )  |

```csharp
public int SubarraySum(int[] nums, int k)
{
    if (nums == null || nums.Length == 0) return 0;
    var count = 0;

    var sum = 0;
    var sumsMap = new Dictionary<int, int>();
    
    for (var i = 0; i < nums.Length; i++) {
        sum += nums[i];
        if (sum == k) count++;
        if (sumsMap.ContainsKey(sum - k)) count += sumsMap[sum - k];
        sumsMap[sum] = sumsMap.ContainsKey(sum) ? sumsMap[sum] + 1 : 1;
    }

    return count;
}
```
