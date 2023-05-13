---
tags:
  - techniques/cumulative-sum
---

# Subarray Sum to Zero

Given an array of positive and negative integers, find the subarray that
that sums to zero

## Techniques

- Cumulative Sum

2, 4, -2, 1, -3, 5, -3
2  6   4  5   2

```csharp
int[] FindZeroSumSubarray(int[] arr)
{
    if (arr == null || arr.Length == 0) return null;

    var sum = 0;
    var sumsMap = new Dictionary<int, int>();

    for (var i = 0; i < arr.Length; i++)
    {
        sum += arr[i];
        if (sum == 0) return
            new [] { 0, i };
        if (sumsMap.ContainsKey(sum))
            return new [] { sumsMap[sum] + 1, i };
        sumsMap[sum] = i;
    }

    return null;
}
```
