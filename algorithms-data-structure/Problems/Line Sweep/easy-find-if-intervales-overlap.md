## Problem

```
Given​ ​a​ ​list​ ​of​ ​time​ ​intervals,​ ​find​ ​if​ ​any​ ​of​ ​them​ ​overlap.​ ​For​ ​example, 
 
Intervals​ ​->​ ​[5,7],​ ​[1,3],​ ​[6,9]​ ​->​ ​Intervals​ ​[5,7]​ ​and​ ​[6,9]​ ​overlap,​ ​so​ ​we​ ​return​ ​true. 
```

## Technique

- Line Sweep

## Solution 1 (O(n) space complexity)

| Complexity | Big O                                |
| ---------- | ------------------------------------ |
| Time       | O(nlogn) if unsorted, otherwise O(n) |
| Space      | O(n)                                 |

```javascript
class Point {
  constructor(time, isStart) {
    this.time = time
    this.isStart = isStart
  }
}

function hasOverlap(intervals) {
  if (!intervals) throw new Error("Missing argument")
  if (intervals.length <= 1) return intervals
  
  const points = []
  for (let i = 0; i < intervals.length; i++) {
    const start = new Point(intervals[i][0], true)
    const end = new Point(intervals[i][1], false)
    points.push(start, end)
  }
  points.sort((a, b) => a.time - b.time)
  
  let count = 0
  for (let i = 0; i < points.length; i++) {
    if (points[i].isStart) count++
    if (count > 1) return true
    if (!points[i].isStart) count--
  }
  
  return false 
}

hasOverlap([[5, 7], [1, 3], [6, 9]]) // true
hasOverlap([[5, 7], [1, 3], [8, 9]]) // false 
hasOverlap([[5, 7], [1, 3], [8, 15], [9, 11]]) // true
```

## Solution 2 (O(1) space complexity)

| ---------- | ------------------------------------ |
| Time       | O(nlogn) if unsorted, otherwise O(n) |
| Space      | O(1)                                 |

```javascript
function hasOverlap(intervals) {
  if (!intervals) throw new Error("Missing argument")
  if (intervals.length <= 1) return intervals
  const sortedIntervals = [...intervals]
  sortedIntervals.sort((a, b) => a[0] - b[0])
  
  let lastEndTime = sortedIntervals[0][1]
  for (let i = 1; i < sortedIntervals.length; i++) {
    const startTime = sortedIntervals[i][0]
    if (startTime < lastEndTime) return true
    lastEndTime = sortedIntervals[i][1]
  }
  
  return false
}
```


## Alternative Solution with Line Sweer

**DOES NOT WORK**

Test it on [leatcode](https://leetcode.com/problems/merge-intervals/description/)

```javascript
class Point {
  constructor(time, isStart) {
    this.time = time
    this.isStart = isStart
  }
}
function Interval(start, end) {
  this.start = start
  this.end = end
}

var merge = function(intervals) {
  if (intervals.length <= 1) return intervals
  intervals.sort((a, b) => a.start - b.start)

  const points = []
  for (let i = 0; i < intervals.length; i++) {
    const start = new Point(intervals[i].start, true)
    const end = new Point(intervals[i].end, false)
    points.push(start, end)
  }
  points.sort((a, b) => {
    if (a.time - b.time == 0) {
      return b.isStart
    }
    return a.time - b.time
  })

  const result = []
  let i = 0
  let count = 0
  for (i = 0; i < points.length; i++) {
    const interval = new Interval()
    if (points[i].isStart) {
      count++
      interval.start = points[i].time
    }
    while (count > 0 && i + 1 < points.length) {
      if (points[i + 1].isStart) count++
      else count--
      i++
    }
    points[i]
    interval.end = points[i].time
    result.push(interval)
  }
  return result
}
```
