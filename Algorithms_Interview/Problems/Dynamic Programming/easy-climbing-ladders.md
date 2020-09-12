## Problem

https://leetcode.com/problems/climbing-stairs/

```
You are climbing a stair case. It takes n steps to reach to the top.

Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

Example 1:

Input: 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps

```


## Technique 


| Complexity | Big O |
|------------|-------|
| Time       | O(n)  |
| Space      | O(n)  |

### Bottom up DP

```csharp
public int ClimbStairs(int n)
{
   if (n == 0) return 0;

   var table = new int[n + 1];
   table[0] = 1;

   for (var i = 0; i <= n; i++)
   {
       if (i + 1 <= n) table[i + 1] += table[i];
       if (i + 2 <= n) table[i + 2] += table[i];
   }

   return table[n];
}
```

### Bottom down DP

```csharp
public int ClimbStairs(int n)
{
   if (n == 1) return 1;

   var dp = new int[n + 1];
   dp[1] = 1;
   dp[2] = 2;

   for (var i = 3; i <= n; i++)
       dp[i] = dp[i - 1] + dp[i - 2];

   return dp[n];
}
```


