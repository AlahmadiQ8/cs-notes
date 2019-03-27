```
Given an array of integers, find the shortest sub-array, that if sorted,
results in the entire array being sorted.

[1,2,4,5,3,5,6,7,9] --> [4,5,3] 
If you sort from indices 2 to 4, the entire array is sorted.

[1,3,5,2,6,4,7,8,9] --> [3,5,2,6,4] 
indices 1 to 5
```

| Complexity | Big O |
|------------|-------|
| Time       | O(n)  |
| Space      | O(1)  |

```javascript
function findUnsortedSubArray(arr) {
  if (!arr || arr.length <= 1) return null

  let dip = 1
  let bump = arr.length - 2

  while (dip < arr.length && arr[dip] >= arr[dip - 1]) {
    dip++
  }
  while (bump >= 0 && arr[bump] <= arr[bump + 1]) {
    bump--
  }

  if (dip >= arr.length - 1 || bump <= 0) return null

  let min = Number.POSITIVE_INFINITY
  let max = Number.NEGATIVE_INFINITY
  let [i, j] = dip < bump ? [dip, bump] : [bump, dip]
  for (i; i < j + 1; i++) {
    if (arr[i] < min) min = arr[i]
    if (arr[i] > max) max = arr[i]
  }

  let lo = dip
  let hi = bump
  while (lo > 0 && arr[lo - 1] > min) {
    lo--
  }
  while (hi < arr.length - 1 && arr[hi + 1] < max) {
    hi++
  }

  return arr.slice(lo, hi + 1)
}

findUnsortedSubArray([1, 2, 4, 5, 3, 5, 6, 7, 9])  // ​​​​​[ 4, 5, 3 ]​​​​​ 
findUnsortedSubArray([1, 3, 5, 2, 6, 4, 7, 8, 9]) ​​ // ​​​[ 3, 5, 2, 6, 4 ]​​​​​ 
findUnsortedSubArray([1, 2, 3, 4, 5])              // null
findUnsortedSubArray([1])                          // null
```
