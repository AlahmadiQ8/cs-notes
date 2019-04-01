---
tags: 
  - medium
---

## Problem

Given an array of integers, find the shortest subarray, that if sorted, 
results in theentire array being sorted.

```
[1,2,4,5,3,5,6,7,9] --> [4,5,3] - 
If you sort from indices 2 to 4, the entire array is sorted.

[1,3,5,2,6,4,7,8,9] --> [3,5,2,6,4] - indices 1 to 5
```

## Technicque

- Two pointers from each end 

| Complexity | Big O |
| ---------- | ----- |
| Time       | O(n)  |
| Space      | O(1)  |

## Solution

```javascript
const expect = require('chai').expect;

function shortestUnsortedSubarray(arr) {
  if (!arr || arr.length <= 1) return null;

  let dip = 0;
  for (dip = 0; dip < arr.length - 1; dip++) {
    if (arr[dip + 1] < arr[dip]) break
  }

  let bump = arr.length - 1;
  for (bump = arr.length - 1; bump >= 0; bump--) {
    if (arr[bump - 1] > arr[bump]) break
  }

  if (dip >= arr.length - 1 || bump <= 0) return null;

  let min = Number.POSITIVE_INFINITY;
  let max = Number.NEGATIVE_INFINITY;

  for (let i = dip; i <= bump; i++) {
    min = Math.min(min, arr[i])
    max = Math.max(max, arr[i])
  }

  let end = bump
  let start = dip
  while (end + 1 < arr.length && arr[end + 1] < max) end++
  while (start - 1 >= 0 && arr[start - 1] > min) start-- 
  return [start, end]
}

expect(shortestUnsortedSubarray([0, 1, 5, 4, 2, 3, 6, 7])).to.deep.equal([2, 5])
```
