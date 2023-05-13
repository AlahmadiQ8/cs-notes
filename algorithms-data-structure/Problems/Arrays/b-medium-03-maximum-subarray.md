---
tags:
  - fundamental
  - techniques/kadane
---

## [Maximum Subarray](https://leetcode.com/problems/maximum-subarray/description/)

Given an integer array nums, find the subarray with the largest sum, and return its sum.

## Techniques

- Dynamic Programming: Kadane's algorithm
- Does it have negative values? if all positive, then the result would
  be the entire array
- To find the subarray:
  - Store the maximum endings in the array
  - Find the max value index (end)
  - from end, find the last non negative value index (start)
- Alternative Solution: Divide & concur

| Complexity | Big O |
| ---------- | ----- |
| Time       | O(n)  |
| Space      | O(1)  |

```csharp
public class Solution {
    public int MaxSubArray(int[] nums) {
        if (nums.Length == 0)
            return -1;

        var max = nums[0];
        var maxEndingHere = nums[0];
        for (var i = 1; i < nums.Length; i++) {
            maxEndingHere = Math.Max(nums[i], maxEndingHere + nums[i]);
            max = Math.Max(max, maxEndingHere);
        }

        return max;
    }
}
```
