---
tags:
  - techniques/two-pointers
---

# [Squares of a Sorted Array](https://leetcode.com/problems/squares-of-a-sorted-array/)

Given an integer array nums sorted in non-decreasing order, return an array of the squares of each number sorted in non-decreasing order.

Example 1:

```
Input: nums = [-4,-1,0,3,10]
Output: [0,1,9,16,100]
Explanation: After squaring, the array becomes [16,1,0,9,100].
After sorting, it becomes [0,1,9,16,100].
```

Example 2:

```
Input: nums = [-7,-3,2,3,11]
Output: [4,9,9,49,121]
```

## Technique

* Two pointers
* Fill from end

## Solution

```csharp
public class Solution {
    public int[] SortedSquares(int[] nums) {
        var result = new int[nums.Length];

        var e = nums.Length - 1;
        var s = 0;
        var index = nums.Length - 1;

        for (var i = nums.Length - 1; i >= 0; i--) {
            int square;
            if (Math.Abs(nums[s]) > Math.Abs(nums[e]))
                square = nums[s++];
            else
                square = nums[e--];
            result[i] = square * square;
        }

        return result;
    }
}
```
