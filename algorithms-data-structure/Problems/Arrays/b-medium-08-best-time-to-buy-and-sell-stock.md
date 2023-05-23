---
tags:
  - review
---

# [Best Time to Buy and Sell Stock](https://leetcode.com/problems/best-time-to-buy-and-sell-stock/description/)

You are given an array prices where prices[i] is the price of a given stock on the ith day.

You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(n)  |
| Space      | O(1)  |

```csharp
public class Solution
{
    public int MaxProfit(int[] prices)
    {
        if (prices.Length <= 1)
            return 0;

        int result = int.MinValue, minSoFar = int.MaxValue;
        foreach (var price in prices)
        {
            minSoFar = Math.Min(minSoFar, price);
            result = Math.Max(result, price - minSoFar);
        }

        return result;
    }
}
```
