## Problem

https://leetcode.com/problems/find-peak-element/

```
A peak element is an element that is greater than its neighbors.

Given an input array nums, where nums[i] ≠ nums[i+1], find a peak element and return its index.

The array may contain multiple peaks, in that case return the index to any one of the peaks is fine.

You may imagine that nums[-1] = nums[n] = -∞.

Example 1:

Input: nums = [1,2,3,1]
Output: 2
Explanation: 3 is a peak element and your function should return the index number 2.
Example 2:

Input: nums = [1,2,1,3,5,6,4]
Output: 1 or 5 
Explanation: Your function can return either index number 1 where the peak element is 2, 
             or index number 5 where the peak element is 6.
Follow up: Your solution should be in logarithmic complexity.
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(Log(N))  |
| Space      | O(Log(N))  |

```csharp
public int FindPeakElement(int[] nums)
{
    if (nums.Length == 0) return -1;
    if (nums.Length == 1) return 0;

    return Helper(0, nums.Length - 1);

    int Helper(int start, int end)
    {
        if (start == end) return start;

        var mid = start + (end - start) / 2;

        if (nums[mid] > nums[mid + 1]) return Helper(start, mid);
        return Helper(mid + 1, end);
    }
}
```
