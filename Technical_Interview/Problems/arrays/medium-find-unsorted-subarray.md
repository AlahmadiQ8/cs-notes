Given an array of integers, find the shortest sub-array, that if sorted, results
in the entire array being sorted.[1,2,4,5,3,5,6,7,9] --> [4,5,3] - If you sort
from indices 2 to 4, the entire array is sorted.
[1,3,5,2,6,4,7,8,9] --> [3,5,2,6,4] - indices 1 to 5

| Time Complexity  | O(n) |
| Space Complexity | O(1) |

```javascript
function findUnsortedSubArray(arr) {
  if (!arr || arr.length <= 1) return null

  let start = 1, end = arr.length - 2

  while (start < arr.length && arr[start] >= arr[start - 1]) {
    start++
  }

  while (end >= 0 && arr[end] <= arr[end + 1]) {
    end--
  }

  if (start >= arr.length || end >= 0) return null

  const min = Math.min(arr.slice(start, end + 1))
  const max = Math.max(arr.slice(start, end + 1))

  while(start > 0 && arr[start - 1] > min) {
    start--
  }

  while (end < arr.length - 1; && arr[end + 1] < max) {
    end++
  }

  return arr.slice(start, end + 1)
}

findUnsortedSubArray([1,2,4,5,3,5,6,7,9])
findUnsortedSubArray([1,3,5,2,6,4,7,8,9])
```
