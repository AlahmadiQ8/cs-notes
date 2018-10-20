## Problem

```
Given​ ​an​ ​array​ ​with​ ​all​ ​numbers​ ​in​ ​[1,2,..,n]​ ​except​ ​one​ ​number,​ ​find​ ​the​ ​missing​ ​number. For​ ​example:

A​ ​=​ ​[1,2,5,4]​ ​and​ ​n​ ​=​ ​5,​ ​Missing​ ​Number​ ​=>​ ​3
A​ ​=​ ​[7,3,5,4,1,2]​ ​and​ ​n​ ​=​ ​7,​ ​Missing​ ​Number​ ​=>​ ​6
```

## Solution 

```javascript
function findMissingNumber(arr, n) {
  if (!arr || arr.length == 0) return null

  let result = 0
  for (let i = 1; i <= n; i++) {
    result ^= i
  }
  for (let i = 0; i < arr.length; i++) {
    result ^= arr[i]
  }
  return result
}
```
