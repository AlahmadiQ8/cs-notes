## Problem 

```
Given a list of stock prices for a company, find the maximum amount of 
money you can make with one trade. A trade is a buy and sell. 
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(n)  |
| Space      | O(1)  |

```javascript
function maxDiff(arr) {
  if (!arr || arr.length == 0) return null

  let minSoFar = Number.POSITIVE_INFINITY
  let maxDiff = 0
  for (let i = 0; i < arr.length; i++) {
    minSoFar = Math.min(minSoFar, arr[i])
    // max trade when sell at i = arr[i] - minSoFar
    maxDiff = Math.max(maxDiff, arr[i] - minSoFar)
  }

  return maxDiff
}

expect(maxDiff([8, 14, 2, 5, 7, 3, 10, 5]).to.equal(8)
```
