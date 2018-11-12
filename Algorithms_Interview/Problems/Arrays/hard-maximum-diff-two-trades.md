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
    const maxi = arr[i] - minSoFar
    bestTilli[i] = Math.max(maxDiff, maxi)
  }

  const bestFromi = []
  let maxSoFar = Number.NEGATIVE_INFINITY
  maxDiff = 0
  for (let i = arr.length - 1; i >= 0; i--) {
    maxSoFar = Math.max(arr[i], maxSoFar)
    const maxi = maxSoFar - arr[i]
    bestFromi[i] = Math.max(maxDiff, maxi)
  }

  let answer = 0
  for (let i = 0; i < arr.length - 1; i++) {
    answer = Math.max(answer, bestTilli[i] + bestFromi[i+1])
  }
  return answer
}

expect(maxDiffTwoTrades([8, 15, 2, 5, 7, 3, 10, 5])).to.equal(15)
//                       <-->   <----------->
//                        1st    2nd 
```
