Given an array of positive and negative integers, find the subarray that
that sums to zero

## Techniques

- Cumulative Sum

2, 4, -2, 1, -3, 5, -3
2  6   4  5   2 

```csharp
public Indices FindZeroSumSubarray(int[] arr) {
    if (arr == null || arr.Length == 0) return null;

    var sum = 0;
    var sumsMap = new Dictionary<int, int>();

    for (var i = 0; i < arr.Length; i++) {
        sum += arr[i];
        if (sum == 0) return new Indices { Start = 0, End = i};
        if (sumsMap.ContainsKey(sum)) return new Indices { Start = sumsMap[sum] + 1, End = i};
        sumsMap[sum] = i;
    }

    return null;
}

public class Indices
{
    public int Start { get; set; }
    public int End { get; set; }
}

public override void Test()
{
    FindZeroSumSubarray(new[] {2, 4, -2, 1, -3, 5, -3}).Should().BeEquivalentTo(new Indices {Start = 1, End = 4});
    FindZeroSumSubarray(new[] {2, 4, -6, 1, -3, 5, -3}).Should().BeEquivalentTo(new Indices {Start = 0, End = 2});
}
```
