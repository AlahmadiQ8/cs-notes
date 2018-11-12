Given a sorted array that has duplicates, return the first occurance
of the target element

## Techniques

- Binary Search Tree

```javascript 
function firstOccurence(arr, target) {
  if (!arr || arr.length == 0) return -1
  let lo = 0,
    hi = arr.length - 1
  while (lo <= hi) {
    const mid = lo + ((hi - lo) >> 1)
    if (arr[mid] < target) {
      lo = mid + 1
    } else if (
      arr[mid] > target ||
      (arr[mid] == target && mid - 1 >= 0 && arr[mid - 1] == target)
    ) {
      hi = mid - 1
    } else {
      return mid
    }
  }
  return -1
}

firstOccurence([1, 3, 4, 6, 6, 6, 7], 6) // 3
```
