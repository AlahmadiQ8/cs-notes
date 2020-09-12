## Problem 

```
Given a list of stock prices for a company, find the maximum amount of 
money you can make with TWO trade. A trade is a buy and sell. 
```

## Technique

- Compute Maximum Trade at i
```
max_i = arr[i] - min_val_from_0_to_i
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(n)  |
| Space      | O(n)  |

```javascript
const expect = require('chai').expect

function maxDiffTwoTrades(arr) {
  if (!arr || arr.length == 0) return null

  const bestTilli = []
  let minSoFar = Number.POSITIVE_INFINITY
  let maxDiff = 0
  for (let i = 0; i < arr.length; i++) {
    minSoFar = Math.min(arr[i], minSoFar)
    maxDiff = Math.max(maxDiff, arr[i] - minSoFar)
    bestTilli[i] = maxDiff
  }

  const bestFromi = []
  let maxSoFar = Number.NEGATIVE_INFINITYw
  maxDiff = 0
  for (let i = arr.length - 1; i >= 0; i--) {
    maxSoFar = Math.max(arr[i], maxSoFar)
    maxDiff = Math.max(maxDiff, maxSoFar - arr[i])
    bestFromi[i] = maxDiff
  }

  let answer = 0
  for (let i = 0; i < arr.length - 1; i++) {
    answer = Math.max(answer, bestTilli[i] + bestFromi[i+1])
  }
  return answer
}

7, 1, 5, 3, 6, 4
0  0  4  2  5  3
0  5  1  3  0  0
expect(maxDiffTwoTrades([8, 15, 2, 5, 7, 3, 10, 5])).to.equal(15)
//                       <-->   <----------->
//                        1st    2nd 
```
