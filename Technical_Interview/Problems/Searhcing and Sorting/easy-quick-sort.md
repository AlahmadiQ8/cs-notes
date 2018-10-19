## Quick Sort 

```javascript 
class Point {
  constructor(low, high) {
    this.low = low
    this.high = high
  }
}

function quickSort(arr) {
  if (!arr || arr.length <= 1) return 
  
  quickSortHelper(arr, 0, arr.length - 1)
}

function quickSortHelper(arr, start, end) {
  if (start >= end) return 
  
  const pivot = getRandomInt(start, end)
  const point = dnf(arr, pivot, start, end)
  quickSortHelper(arr, start, point.low)
  quickSortHelper(arr, point.high, end)
}

function dnf(arr, pivot, start, end) {
  if (start > end) return 
  
  let low = start, mid = start, high = end
  while (mid <= high) {
    if (arr[mid] < arr[pivot]) swap(arr, mid++, low++)
    else if (arr[mid] == arr[pivot]) mid++
    else swap(arr, mid, high--)
  }
  return new Point(low - 1, high + 1)
}
  
function getRandomInt(start, end) {
  return Math.floor(Math.random() * (end - start + 1)) + start
}

function swap(arr, i, j) {
  let temp = arr[i]
  arr[i] = arr[j]
  arr[j] = temp
}

const arr = [1, 4, 3, 5, 2, 0, 2, 6]
quickSort(arr)
arr // [ 0, 1, 2, 2, 3, 4, 5, 6 ]​​​​​
```
