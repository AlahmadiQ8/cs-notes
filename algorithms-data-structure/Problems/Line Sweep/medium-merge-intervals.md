## Problem 

```
Given a collection of intervals, merge all overlapping intervals
```

## Solution 


```javascript
function mergeIntervals(intervals) {
  if (intervals.length <= 1) return intervals
  intervals.sort((a, b) => a.start - b.start)

  const merged = []
  for (const inter of intervals) {
    if (merged.length == 0 || merged[merged.length - 1].end < inter.start) {
      merged.push(inter)
    } else {
      merged[merged.length - 1].end = Math.max(
        merged[merged.length - 1].end,
        inter.end
      )
    }
  }
  return merged
}
```

```csharp
public int[][] Merge(int[][] intervals)
{
    if (intervals.Length <= 1) return intervals;

    var result = new List<int[]>();

    Array.Sort(intervals, (a, b) => a[0] - b[0]);

    result.Add(intervals[0]);

    for (var i = 1; i < intervals.Length; i++)
    {
        var last = result.Last();
        if (intervals[i][0] <= last[1])
            last[1] = Math.Max(last[1], intervals[i][1]);
        else
            result.Add(intervals[i]);
    }

    return result.ToArray();
}
```
