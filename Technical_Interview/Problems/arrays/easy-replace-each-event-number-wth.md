Given an array of numbers, replace each even number with two of the same 
number. e.g, [1,2,5,6,8, , , ,] -> [1,2,2,5,6,6,8,8]. Assume that the array 
has the exact amount of space to accommodate the result.

```javascript
function duplicateEven(arr) {
  if (!arr || arr.length == 0) throw Error('invalid input')

  let i = arr.length - 1
  let j = getLastElement(arr)
  while (j >= 0) {
    if (arr[j] % 2 === 0) 
      arr[i--] = arr[j]
    arr[i--] = arr[j--]
  }
}
function getLastElement(arr) {
  let last = arr.length - 1
  while (arr[last] === -1) 
    last--
  return last
}

const arr = [1, 2, 5, 8, 6, -1, -1, -1]
duplicateEven(arr) // arr = ​​​​​[ 1, 2, 2, 5, 8, 8, 6, 6 ]​​​​​
```
