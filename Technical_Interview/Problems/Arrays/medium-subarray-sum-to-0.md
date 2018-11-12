Given an array of positive and negative integers, find the subarray that
that sums to zero

## Techniques

- Cumulative Sum

```javascript 
function zeroSumSubarray(arr) {
  if (!arr || arr.length == 0) return null
  const cSum = []

  for (let i = 0; i < arr.length; i++) {
    cSum[i] = i == 0 ? arr[i] : cSum[i - 1] + arr[i]
    if (cSum[i] == 0) {
      return [0, i]
    }
  }

  const map = new Map()
  for (let i = 0; i < cSum.length; i++) {
    if (map.has(cSum[i])) {
      return [map.get(cSum[i]) + 1, i]
    } else {
      map.set(cSum[i], i)
    }
  }

  return null
}
```
