---
tags:
  - review
---

## [Find Minimum in Rotated Sorted Array](https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/description/)

Suppose an array of length n sorted in ascending order is rotated between `1` and `n` times. For example, the array `nums = [0,1,2,4,5,6,7]` might become:

* `[4,5,6,7,0,1,2]` if it was rotated 4 times.
* `[0,1,2,4,5,6,7]` if it was rotated 7 times.

Notice that rotating an array `[a[0], a[1], a[2], ..., a[n-1]]` 1 time results in the array `[a[n-1], a[0], a[1], a[2], ..., a[n-2]]`.

Given the sorted rotated array `nums` of unique elements, return the minimum element of this array.

You must write an algorithm that runs in `O(log n)` time.

## Technique

- Use last element as pivot

## Solution

```csharp
public class Solution
{
    public int FindMin(int[] nums)
    {
        int lo = 0, hi = nums.Length - 1, pivot = nums[^1];
        while (lo <= hi)
        {
            var mid = lo + (hi - lo) / 2;
            if (nums[mid] <= pivot && (mid == 0 || nums[mid - 1] > pivot))
                return nums[mid];
            if (nums[mid] > pivot)
                lo = mid + 1;
            else
                hi = mid - 1;
        }

        return -1;
    }
}
```
