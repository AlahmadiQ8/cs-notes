## Problem

https://leetcode.com/problems/search-in-rotated-sorted-array/

```
You are given an integer array nums sorted in ascending order, and an integer target.

Suppose that nums is rotated at some pivot unknown to you beforehand (i.e., [0,1,2,4,5,6,7] might become [4,5,6,7,0,1,2]).

If target is found in the array return its index, otherwise, return -1.
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(Log(n))  |
| Space      | O(1)  |

```csharp
public int Search(int[] nums, int target)
{
    if (nums.Length == 0) return -1;

    var lo = 0;
    var hi = nums.Length - 1;

    while (lo <= hi)
    {
        var mid = lo + (hi - lo) / 2;
        if (nums[mid] == target) return mid;


        if (nums[mid] >= nums[0])
        {
            if (target >= nums[0] && nums[mid] > target) hi = mid - 1;
            else lo = mid + 1;
        }
        else
        {
            if (target <= nums[^1] && nums[mid] < target) lo = mid + 1;
            else hi = mid - 1;
        }
    }

    return -1;
}
```
