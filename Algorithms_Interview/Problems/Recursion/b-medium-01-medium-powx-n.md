---
tags:
  - review
  - techniques/recursion
---

## [Pow(x, n)](https://leetcode.com/problems/powx-n)

Implement pow(x, n), which calculates x raised to the power n (i.e. xn).

```
Input: x = 2.00000, n = 10
Output: 1024.00000

Input: x = 2.10000, n = 3
Output: 9.26100

Input: x = 2.00000, n = -2
Output: 0.25000
Explanation: 2-2 = 1/22 = 1/4 = 0.25
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(log(n))  |
| Space      | O(log(n))  |

```csharp
public class Solution
{
    public double MyPow(double x, int n)
    {
        var N = n;
        if (N == 0) return 1;

        x = N < 0 ? 1 / x : x;
        if (n < 0)
        {
            if (n == int.MinValue) N = int.MaxValue;
            else N = -n;
        }

        return n == int.MinValue ? FastPow(x, N) * x : FastPow(x, N);
    }

    private double FastPow(double x, int n)
    {
        if (n == 0) return 1;

        var half = FastPow(x, n / 2);
        if (n % 2 != 0) return half * half * x;
        return half * half;
    }
}
```
