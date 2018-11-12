## Problem

Print all combinations of size x given an array 

## Technique

- Auxiliary Buffer


| Complexity | Big O                              |
| ---------- | ---------------------------------- |
| Time       | O(n^2)                             |
| Space      | O(X) for buffer size and recursion |


```javascript
function printCombinations(arr, length) {
  if (length > arr.length) throw Error("Invalid")
  const buffer = Array.from({ length }).fill(null)
  printCombos(arr, buffer, 0, 0)
}

function printCombos(arr, buff, buffIndex, startIndex) {
  // 1. termination case
  if (buffIndex == buff.length) {
    console.log(buff)
    return
  }
  if (startIndex == arr.length) {
    return 
  }

  // 2. find candidates to go into the current buffer index
  for (let i = startIndex; i < arr.length; i++) {
    // 3. place item into buffer
    buff[buffIndex] = arr[i]

    // 4. Recurse
    printCombos(arr, buff, buffIndex + 1, i + 1)
  }
}

printCombinations([1, 2, 3, 4], 3)
// [ 1, 2, 3 ]​​​​​
// ​​​​​[ 1, 2, 4 ]​​​​​
// ​​​​​[ 1, 3, 4 ]​​​​​
// ​​​​​[ 2, 3, 4 ]​​​​​
```
