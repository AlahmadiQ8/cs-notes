# [Two Sum](https://leetcode.com/problems/two-sum/description/)

Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.

## Solution

```csharp
public class Solution {
    public int[]? TwoSum(int[] nums, int target)
    {
        if (nums.Length < 2)
            return null;

        var hash = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (hash.ContainsKey(target - nums[i]))
                return new[] { i, hash[target - nums[i]] };
            hash[nums[i]] = i;
        }
        return null;
    }
}
```
