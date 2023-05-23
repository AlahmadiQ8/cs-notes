# [Longest Increasing Subsequence](https://leetcode.com/problems/longest-increasing-subsequence/)

## Solution

| Complexity | Big O  |
| ---------- | ------ |
| Time       | O(n^2) |
| Space      | O(n)   |

```csharp
public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        var longest = new int[nums.Length];
        var result = 1;

        for (var i = 0; i < nums.Length; i++)
        {
            longest[i] = 1;
            for (var j = 0; j < i; j++)
                if (nums[j] < nums[i])
                    longest[i] = Math.Max(longest[i], longest[j] + 1);
            result = Math.Max(result, longest[i]);
        }

        return result;
    }
}
```
