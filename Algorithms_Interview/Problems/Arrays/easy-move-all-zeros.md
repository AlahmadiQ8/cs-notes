Move all zeroes to end of array

# Technique

- Dutch national flag algorithm

| Complexity | Big O |
|------------|-------|
| Time       | O(n)  |
| Space      | O(1)  |

```javascript
function moveZeros(arr) {
  if (!arr || arr.length <= 1) return
  let lo = 0,
    mid = 0
  while (mid < arr.length) {
    if (arr[mid] !== 0) swap(arr, lo++, mid++)
    else mid++
  }
}
function swap(arr, i, j) {
  let temp = arr[i]
  arr[i] = arr[j]
  arr[j] = temp
}

const arr = [3, 0, 2, 0, 0, 4, 4, 6, 4, 4, 0]
moveZeros(arr) // ​​​​​[ 3, 2, 4, 4, 6, 4, 4, 0, 0, 0, 0 ]​​​​​
```

