## Problem

```
Given an array of integers and an integer k, you need to find the total
number of continuous subarrays whose sum equals to k.
```

## Notes

- What is the range? Are they all positive? 

## Technique

- Sliding window

```javascript
// WRONG
function subarraySum(arr, k) {
  if (!arr || arr.length == 0) return 0
  let count = 0
  const map = {}
  let sum = 0

  for (let i = 0; i < arr.length; i++) {
    sum += arr[i]
    if (sum == k) {
      count++
    }
    if (map[sum] != null) {
      const index = map[sum]
      count++
    } else if (map[sum + k] == null) {
      map[sum + k] = i
    }
  }

  return count
}


function xSumSubarray(arr, x) {
  if (!arr || arr.length === 0) return null
  let sum = arr[0]
  let i = 0,
    j = 0
  while (i < arr.length) {
    if (i > j) {
      j = i
      sum = arr[i]
    } else if (sum > x) {
      sum -= arr[i++]
    } else if (sum < x) {
      if (j + 1 < arr.length) {
        sum += arr[++j]
      } else {
        sum -= arr[i++]
      }
    } else {
      return [i, j]
    }
  }
  return null
}

xSumSubarray([1, 2, 3, 3, 0, 4, 6, 7], 10) // [2, 5]
xSumSubarray([13, 10, 1, 3, 4], 7) // [3, 4]
xSumSubarray([13, 10, 1, 3, 4], 100) // null
xSumSubarray([-2, -1, 0, 1, -2, 5, 6], 11) // [5, 6]
```

```csharp
public Result FindSubArraySum(int[] arr, int target) {
    if (arr == null || arr.Length == 0) return null;

    var s = 0;
    var e = 0;
    var sum = arr[0];

    while (s < arr.Length) {
        if (s > e) {
            e = s;
            sum = arr[e];
        } else if (sum > target) {
            sum -= arr[s++];
        } else if (sum < target) {
            if (e + 1 < arr.Length) {
                sum += arr[++e];
            } else {
                sum -= arr[s++];
            }
        } else {
            return new Result { Start = s, End = e};
        }
    }

    return null;
}

public class Result
{
    public int Start { get; set; }
    public int End { get; set; }
}

public override void Test()
{
    FindSubArraySum(new[] {1, 2, 3, 3, 0, 4, 6, 7}, 10).Should().BeEquivalentTo(new Result {Start = 2, End = 5});
    FindSubArraySum(new[] {13, 10, 1, 3, 4}, 7).Should().BeEquivalentTo(new Result {Start = 3, End = 4});
    FindSubArraySum(new[] {13, 10, 1, 3, 4}, 100).Should().BeNull();
    FindSubArraySum(new[] {-2, -1, 0, 1, -2, 5, 6}, 11).Should().BeEquivalentTo(new Result {Start = 5, End = 6});
}
```
