Given Sorted array, find the target, if not found, find the closest. 

## Techniques

- Record and Move on

```javascript 
function closestElement(arr, target) {
  if (!arr || arr.length == 0) return -1
  let lo = 0,
    hi = arr.length - 1
  let result = null
  while (lo <= hi) {
    const mid = lo + ((hi - lo) >> 1)
    result = record(arr, mid, result, target)
    if (arr[mid] < target) {
      lo = mid + 1
    } else if (arr[mid] > target) {
      hi = mid - 1
    } else {
      return mid
    }
  }
  return result
}
function record(arr, mid, result, target) {
  if (result == null) return mid
  const diff = Math.abs(arr[mid] - target)
  return diff < Math.abs(arr[result] - target) ? mid : result
}

closestElement([1, 2, 4, 5, 7, 8, 9], 2.5) // 1
```
