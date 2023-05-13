# [Search Insert Position](https://leetcode.com/problems/search-insert-position/description/)

Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.

You must write an algorithm with O(log n) runtime complexity.

```
Input: nums = [1,3,5,6], target = 5
Output: 2

Input: nums = [1,3,5,6], target = 2
Output: 1

Input: nums = [1,3,5,6], target = 7
Output: 4
```

# Solution

```csharp
public class Solution {
    public int SearchInsert(int[] nums, int target) {
        var lo = 0;
        var hi = nums.Length - 1;
        while (lo <= hi)
        {
            var mid = lo + (hi - lo) / 2;
            if (nums[mid] >= target)
                hi = mid - 1;
            else
                lo = mid + 1;
        }

        return lo;
    }
}
```
