## Problem

https://leetcode.com/problems/perfect-squares/

```
Given a positive integer n, find the least number of perfect square numbers (for example, 1, 4, 9, 16, ...) which sum to n.

Example 1:

Input: n = 12
Output: 3 
Explanation: 12 = 4 + 4 + 4.
Example 2:

Input: n = 13
Output: 2
Explanation: 13 = 4 + 9.
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(N^(..))  |
| Space      | O(Sqrt(N))  |


index = 1
    Min = 1
index = 2
    Min = 2
index = 3
    Min = 3
index = 4
    Min = 4
    Min = 1
index = 5
    Min = 2
    Min = 2
index = 6
    Min = 3
    Min = 3
index = 7
    Min = 4
    Min = 4
index = 8
    Min = 5
    Min = 2
index = 9
    Min = 3
    Min = 3
    Min = 1

```csharp
// DP
public class Solution {
    public int NumSquares(int n)
    {
        var dp = new int[n + 1];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;

        for (var i = 1; i <= n; i++)
        {
            for (var j = 1; j * j <= i; j++)
                dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
        }

        return dp[n];
    }
} 

for i = 1; i * i <= cur i++
    dp[i] = Math.Min(dp[cur - i * i] + 1, dp[i])


// Recursion
public class Solution {
    private HashSet<int> _squares = new HashSet<int>();


    public int NumSquares(int n)
    {
        for (var i = 0; i * i <= n; i++)
            _squares.Add(i * i);

        var count = 1;
        for (; count <= n; count++)
            if (CanBeDividedBy(n, count))
                return count;

        return count;
    }

    private bool CanBeDividedBy(int n, int count)
    {
        if (count == 1) return _squares.Contains(n);

        foreach (var sqr in _squares)
            if (CanBeDividedBy(n - sqr, count - 1))
                return true;

        return false;
    }
}
```
