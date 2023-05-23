## [Climbing Stairs](https://leetcode.com/problems/climbing-stairs/)


You are climbing a stair case. It takes n steps to reach to the top.

Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

Example 1:

Input: 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps


## Technique


| Complexity | Big O |
|------------|-------|
| Time       | O(n)  |
| Space      | O(n)  |

## Solution

```csharp
// Bottom up DP O(1) space
public class Solution {
    public int ClimbStairs(int n) {
        int n1 = 1, n2 = 1, nth = 1;

        for (var i = 2; i <= n; i++)
        {
            nth = n1 + n2;
            n2 = n1;
            n1 = nth;
        }

        return nth;
    }
}

// Bottom up DP - tabulation O(n) space
public class Solution
{
    public int ClimbStairs(int n)
    {
        if (n == 0) return 0;

        var table = new int[n + 1];
        table[0] = 1;

        for (var i = 0; i <= n; i++)
        {
            if (i + 1 <= n)
                table[i + 1] += table[i];
            if (i + 2 <= n)
                table[i + 2] += table[i];
        }

        return table[n];
    }
}

// Top down DP - tabulation O(n) space
public class Solution
{
    public int ClimbStairs(int n)
    {
        if (n == 1) return 1;

        var dp = new int[n + 1];
        dp[0] = 1;

        for (var i = 1; i <= n; i++)
        {
            var iMinus1 = i - 1 < 0 ? 0 : dp[i - 1];
            var iMinus2 = i - 2 < 0 ? 0 : dp[i - 2];

            dp[i] = iMinus1 + iMinus2;
        }

        return dp[n];
    }
}
```


