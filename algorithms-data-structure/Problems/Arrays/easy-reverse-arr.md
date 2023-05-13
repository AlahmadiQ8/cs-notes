Reverse an array in place. 

## Technique

- Two pointers


```javascript 
function reverse(arr) {
  let start = 0
  let end = arr.length - 1
  while (end > start) {
    swap(arr, start++, end--)
  }
}

function swap(arr, i, j) {
  const temp = arr[i]
  arr[i] = arr[j]
  arr[j] = temp
}
```
