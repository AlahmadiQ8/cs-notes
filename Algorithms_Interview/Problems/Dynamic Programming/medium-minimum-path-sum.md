## Problem

https://leetcode.com/problems/minimum-path-sum/

```
Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right which minimizes the sum of all numbers along its path.

Note: You can only move either down or right at any point in time.

Example:

Input:
[
  [1,3,1],
  [1,5,1],
  [4,2,1]
]
Output: 7
Explanation: Because the path 1→3→1→1→1 minimizes the sum.
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(N)  |
| Space      | O(N)  |

```csharp
public int MinPathSum(int[][] grid)
{
    if (grid.Length == 0 || grid[0].Length == 0) return 0;

    var n = grid.Length;
    var m = grid[0].Length;

    var dp = new int[n, m];
    dp[0, 0] = grid[0][0];
    for (var i = 1; i < n; i++) dp[i, 0] = dp[i - 1, 0] + grid[i][0];
    for (var i = 1; i < m; i++) dp[0, i] = dp[0, i - 1] + grid[0][i];

    for (var i = 1; i < n; i++)
    for (var j = 1; j < m; j++)
        dp[i, j] = grid[i][j] + Math.Min(dp[i - 1, j], dp[i, j - 1]);
    
    return dp[n - 1, m - 1];
}
```
