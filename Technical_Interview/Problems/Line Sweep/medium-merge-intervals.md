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
