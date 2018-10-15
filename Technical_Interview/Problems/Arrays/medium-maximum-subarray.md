## Problem

```
Given an integer array nums, find the contiguous subarray (containing 
at least one number) which has the largest sum and return its sum.
```

## Techniques

- Dynamic Programming: Kadane's algorithm
- Does it have negative values? if all positive, then the result would
  be the entire array 
- To find the subarray: 
  - Store the maximum endings in the array
  - Find the max value index (end)
  - from end, find the last non negative value index (start)
- Alternative Solution: Divide & concur

| Complexity | Big O |
| ---------- | ----- |
| Time       | O(n)  |
| Space      | O(1)  |

```javascript 
function maxSubArray(arr) {
  if (!arr || arr.length === 0) return null
  if (arr.length === 1) return arr[0]

  let maxSum = arr[0], maxEndingHere = arr[0]
  for (let i = 1; i < arr.length; i++) {
    maxEndingHere = Math.max(arr[i], maxEndingHere + arr[i])
    maxSum = Math.max(maxSum, maxEndingHere)
  }
  return maxSum
}

maxSubArray([-2, -3, 3, -1, -2, 1, 5, -1]) // 6
```

## Alternative Technique: Divide & Conquer

 | Complexity | Big O      |
 | ---------- | ---------- |
 | Time       | O(nlog(n)) |
 | Space      | O(1)       |

 ```javascript
function maxSubArray(arr) {
  return maxSubArrayHelper(arr, 0, arr.length - 1)
}

function maxSubArrayHelper(arr, low, high) {
  if (high <= low) return arr[low]
  const mid = low + Math.floor((high - low) / 2)
  const leftSum = maxSubArrayHelper(arr, low, mid)
  const rightSum = maxSubArrayHelper(arr, mid + 1, high)
  const crossSum = findMaxCrossing(arr, low, mid, high)
  if (leftSum >= rightSum && leftSum >= crossSum) return leftSum
  if (rightSum >= leftSum && rightSum >= crossSum) return rightSum
  return crossSum
}

function findMaxCrossing(arr, low, mid, high) {
  let leftSum = Number.NEGATIVE_INFINITY
  let sum = 0
  for (var i = mid; i >= low; i--) {
    sum += arr[i]
    if (sum > leftSum) {
      maxLeft = i
      leftSum = sum
    }
  }
  let rightSum = Number.NEGATIVE_INFINITY
  sum = 0
  for (var j = mid + 1; j <= high; j++) {
    sum += arr[j]
    if (sum > rightSum) {
      rightSum = sum
    }
  }
  return leftSum + rightSum
}
maxSubArray([-2, -3, 3, -1, -2, 1, 5, -1]) //?
 ```
