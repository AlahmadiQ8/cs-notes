---
tags:
  - techniques/cumulative-sum
  - review
---

## [Subarray Sum Equals K](https://leetcode.com/problems/subarray-sum-equals-k/)

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
public class Solution {
    public int SubarraySum(int[] nums, int k)
    {
        var dict = new Dictionary<int, int>();
        var sum = 0;
        var count = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            if (sum == k)
                count++;
            if (dict.ContainsKey(sum - k))
                count += dict[sum - k];
            if (!dict.ContainsKey(sum)) dict[sum] = 0;
            dict[sum]++;
        }

        return count;
    }
}
```
