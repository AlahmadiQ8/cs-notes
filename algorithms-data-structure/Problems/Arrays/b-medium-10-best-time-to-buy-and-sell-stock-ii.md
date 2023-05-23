---
tags:
  - review
---

# [Best Time to Buy and Sell Stock II](https://leetcode.com/problems/b-medium-/description/)

You are given an integer array prices where prices[i] is the price of a given stock on the ith day.

On each day, you may decide to buy and/or sell the stock. You can only hold at most one share of the stock at any time. However, you can buy it then immediately sell it on the same day.

Find and return the maximum profit you can achieve.

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(n)  |
| Space      | O(1)  |

```csharp
// longer but easier to understand intuition behind it
public class Solution
{
    public int MaxProfit(int[] prices)
    {
        var result = 0;

        int valley = int.MaxValue, peak = int.MaxValue;

        foreach (var price in prices)
        {
            if (price < peak)
            {
                result += peak - valley;
                valley = price;
                peak = price;
            }
            else
                peak = price;
        }

        result += peak - valley;
        return result;
    }
}

// shorter code
public class Solution
{
    public int MaxProfit(int[] prices)
    {
        var result = 0;
        for (var i = 0; i < prices.Length - 1; i++)
        {
            if (prices[i] < prices[i + 1])
                result += prices[i + 1] - prices[i];
        }

        return result;
    }
}
```
