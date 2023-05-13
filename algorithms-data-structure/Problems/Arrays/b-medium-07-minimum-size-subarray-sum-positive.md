---
tags:
  - techniques/two-pointers
  - techniques/sliding-window
  - review
---

## [Minimum Size Subarray Sum](https://leetcode.com/problems/minimum-size-subarray-sum)

Given an array of positive integers nums and a positive integer target, return the
minimal length of a subarray whose sum is greater than or equal to target. If there
is no such subarray, return 0 instead.

```
Input: target = 7, nums = [2,3,1,2,4,3]
Output: 2
Explanation: The subarray [4,3] has the minimal length under the problem constraint.

Input: target = 4, nums = [1,4,4]
Output: 1

Input: target = 11, nums = [1,1,1,1,1,1,1,1]
Output: 0
```

## Notes

- What is the range? Are they all positive?

## Technique

- Sliding window

```csharp
public class Solution
{
    public int MinSubArrayLen(int target, int[] nums)
    {
        var min = int.MaxValue;
        var sum = nums[0];
        var start = 0;
        var end = 0;
        while (start < nums.Length)
        {
            if (start > end)
            {
                end = start;
                sum = nums[end];
            }

            if (sum >= target)
            {
                min = Math.Min(min, end - start + 1);
                sum -= nums[start++];
            }
            else
            {
                if (end + 1 < nums.Length)
                    sum += nums[++end];
                else
                    sum -= nums[start++];
            }
        }

        return min == int.MaxValue ? 0 : min;
    }
}
```
