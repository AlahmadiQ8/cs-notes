# [Coin Change](https://leetcode.com/problems/coin-change/description/)

Coin Change Problem: Given a set of coin denominations, print out the
different ways you can make a target amont. You can use as many coins
of each denomination as you like.

For example, if coins are [1, 2, 5] and the target is 5, output will be:

```
[1,1,1,1,1]
[1,1,1,2]
[1,2,2]
[5]
```

## Technique

- Auxiliary Buffer
- Use map to eliminate duplicates

## Variation of the problem

```csharp
// Number of different ways we can get target amount
public int Change(int amount, int[] coins) {
    var dp = new int[amount + 1];
    dp[0] = 1;

    foreach (var coin in coins) {
        for (var i = 0; i <= amount && i + coin <= amount; i++) {
            dp[i + coin] += dp[i];
        }
    }

    return dp[amount];
}


// 1, 2, 3   =>    5
// [? ? ? ? ?]
// [2, 3 ? ? ?]
public IList<IList<int>> ChangePossibilities(int[] coins, int sum) {
    if (coins.Length == 0) return new List<IList<int>>();
    var buffer = new int[sum];
    var currentSum = 0;
    var result = new List<IList<int>>();
    Helper(0);
    return result;

    void Helper(int bufferIndex) {
        if (bufferIndex == buffer.Length) {
            if (currentSum == sum) result.Add(buffer.ToArray());
            return;
        }
        if (currentSum == sum) {
            result.Add(buffer[..bufferIndex]);
            return;
        }

        for (var i = 0; i < coins.Length; i++) {
            buffer[bufferIndex] = coins[i];
            currentSum += coins[i];
            Helper(bufferIndex + 1);
            currentSum -= coins[i];
        }
    }
}

// LeetCode
// https://leetcode.com/problems/coin-change/
// compute the fewest number of coins that you need to make up that amount
public int CoinChange(int[] coins, int amount) {
    if (amount == 0) return -1;
    var minLength = -1;
    Helper(0, 0);
    return minLength;

    void Helper(int currLength, int sum) {
        if (sum > amount) return;
        if (sum == amount) {
            if (minLength == -1) minLength = int.MaxValue;
            minLength = Math.Min(minLength, currLength);
            return;
        }

        for (var i = 0; i < coins.Length; i++) {
            Helper(currLength + 1, sum + coins[i]);
        }
    }
}
```


```csharp
// compute the fewest number of coins that you need to make up that amount
public int CoinChange(int[] coins, int amount)
{
    var dp = new int[amount + 1];
    Array.Fill(dp, amount + 1);
    dp[0] = 0;

    for (var i = 0; i <= amount; i++) {
        foreach (var coin in coins) {
            if (i - coin < 0)
                continue;
            dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
        }
    }

    return dp[amount] <= amount ? dp[amount] : -1;
}
```
