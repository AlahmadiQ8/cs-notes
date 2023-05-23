## Problem

```
Given a list of stock prices for a company, find the maximum amount of
money you can make with TWO trade. A trade is a buy and sell.
```

## Technique

- Compute Maximum Trade at i
```
max_i = arr[i] - min_val_from_0_to_i
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(n)  |
| Space      | O(n)  |

```csharp
public int MaxProfit(int[] prices)
{
    if (prices.Length < 2) return 0;

    var bestTillI = new int[prices.Length];
    var minSoFar = int.MaxValue;
    var maxDiffI = 0;

    var bestFromI = new int[prices.Length];
    var maxSoFar = int.MinValue;
    var maxDiffJ = 0;

    for (var i = 0; i < prices.Length; i++)
    {
        var j = prices.Length - i - 1;

        minSoFar = Math.Min(minSoFar, prices[i]);
        maxDiffI = Math.Max(maxDiffI, prices[i] - minSoFar);
        bestTillI[i] = maxDiffI;

        maxSoFar = Math.Max(maxSoFar, prices[j]);
        maxDiffJ = Math.Max(maxDiffJ, maxSoFar - prices[j]);
        bestFromI[j] = maxDiffJ;
    }

    var result = int.MinValue;
    for (var i = 0; i < prices.Length; i++)
    {
        result = Math.Max(result, bestTillI[i]);
        if (i + 1 < prices.Length)
        {
            result = Math.Max(result, bestTillI[i] + bestFromI[i + 1]);
        }
    }

    return result;
}
```
