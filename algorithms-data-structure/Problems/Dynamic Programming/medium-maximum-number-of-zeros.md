https://www.geeksforgeeks.org/maximize-number-0s-flipping-subarray/

```javascript
/**
 * @param {number[]} arr
 * @return {number}
 */
function maxNumberOfZeros(arr) {
  let maxEndingHere = 0;
  let maxSum = 0;
  let zeroCount = 0
  for (let i = 0; i < arr.length; i++) {
    let val = 1;
    if (arr[i] === 0) {
      zeroCount += 1
      val = -1
    }
    maxEndingHere = Math.max(val, maxEndingHere + val)
    maxSum = Math.max(maxSum, maxEndingHere)
  }
  maxSum = Math.max(0, maxSum)
  return maxSum + zeroCount
};
```
