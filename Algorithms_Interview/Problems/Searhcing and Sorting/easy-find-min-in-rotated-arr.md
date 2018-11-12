## Problem

Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

(i.e.,  [0,1,2,4,5,6,7] might become  [4,5,6,7,0,1,2]).

Find the minimum element.

You may assume no duplicate exists in the array.

## Technique

- Use last element as pivot

```javascript 
function findMinimum(arr) {
  if (!arr || arr.length == 0) return null
  if (arr.length == 1) return arr[0]
  let lo = 0, hi = arr.length - 1
  const pivot = arr[arr.length - 1]
  while (lo <= hi) {
    const mid = lo + ((hi - lo) >> 1)
    if (arr[mid] <= pivot && (mid == 0 || arr[mid] < arr[mid-1])) {
      return arr[mid]
    } else if (arr[mid] > pivot) {
      lo = mid + 1
    } else {
      hi = mid - 1
    }
  }

  return null
}
```
