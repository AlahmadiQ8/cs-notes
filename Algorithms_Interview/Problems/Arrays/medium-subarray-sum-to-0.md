Given an array of positive and negative integers, find the subarray that
that sums to zero

## Techniques

- Cumulative Sum

```javascript 
function zeroSumSubarray(arr) {
  if (!arr || arr.length == 0) return null
  const cSum = []

  for (let i = 0; i < arr.length; i++) {
    cSum[i] = i == 0 ? arr[i] : cSum[i - 1] + arr[i]
    if (cSum[i] == 0) {
      return [0, i]
    }
  }

  const map = new Map()
  for (let i = 0; i < cSum.length; i++) {
    if (map.has(cSum[i])) {
      return [map.get(cSum[i]) + 1, i]
    } else {
      map.set(cSum[i], i)
    }
  }

  return null
}

function zeroSumSubarray(arr) {
  if (!arr || arr.length === 0) return null

  let sum = 0
  const map = new Map()
  for (let i = 0; i < arr.length; i++) {
    sum += arr[i]
    if (sum === 0) return [0, i]
    if (map.has(sum)) return [map.get(sum) + 1, i]
    map.set(sum, i)
  }
  return null
}

expect(zeroSumSubarray([2, 4, -2, 1, -3, 5, -3])).to.deep.equal([1, 4])
```

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
