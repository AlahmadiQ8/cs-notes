## Problem

https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/

```
Say you have an array prices for which the ith element is the price of a given stock on day i.

Design an algorithm to find the maximum profit. You may complete as many transactions as you like (i.e., buy one and sell one share of the stock multiple times).

Note: You may not engage in multiple transactions at the same time (i.e., you must sell the stock before you buy again).

Example 1:

Input: [7,1,5,3,6,4]
Output: 7
Explanation: Buy on day 2 (price = 1) and sell on day 3 (price = 5), profit = 5-1 = 4.
             Then buy on day 4 (price = 3) and sell on day 5 (price = 6), profit = 6-3 = 3.
Example 2:

Input: [1,2,3,4,5]
Output: 4
Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
             Note that you cannot buy on day 1, buy on day 2 and sell them later, as you are
             engaging multiple transactions at the same time. You must sell before buying again.
Example 3:

Input: [7,6,4,3,1]
Output: 0
Explanation: In this case, no transaction is done, i.e. max profit = 0.
```

## Solution I - Brute force with memoization

| Complexity | Big O |
|------------|-------|
| Time       | O(n^2)  |
| Space      | O(n)  |


```csharp
public int MaxProfit(int[] prices) {
    var memo = new int[prices.Length];
    Array.Fill(memo, -1);
    
    return Helper(0);
    
    int Helper(int s) {
        if (s >= prices.Length) return 0;
        
        if (memo[s] > -1) return memo[s];
        
        var max = 0;
        var minSoFar = int.MaxValue;
        
        for (var start = s; start < prices.Length; start++) {
            minSoFar = Math.Min(minSoFar, prices[start]);
            var maxAti = prices[start] - minSoFar;
            var maxAtiPlus1 = Helper(start + 1);
            max = Math.Max(max, maxAti + maxAtiPlus1);
        }
        
        memo[s] = max;
        return max;
    }
}
```

## Solution II - One Pass

| Complexity | Big O |
|------------|-------|
| Time       | O(n)  |
| Space      | O(1)  |

```csharp
public int MaxProfit(int[] prices) {
    int maxprofit = 0;
    for (int i = 1; i < prices.Length; i++) {
        if (prices[i] > prices[i - 1])
            maxprofit += prices[i] - prices[i - 1];
    }
    return maxprofit;
}
```
