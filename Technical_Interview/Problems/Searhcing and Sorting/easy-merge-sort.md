## Merge Sort 


```javascript 
function mergeSort(arr) {
  if (!arr || arr.length <= 1) return

  mergeSortHelper(arr, 0, arr.length - 1)
}

function mergeSortHelper(arr, start, end) {
  if (start >= end) return
  const mid = start + ((end - start) >> 1)
  mergeSortHelper(arr, start, mid)
  mergeSortHelper(arr, mid + 1, end) 
  merge(arr, start, mid, end)
}

function merge(arr, start, mid, end) {
  if (start >= end) return
  const result = [] 
  let i = start, j = mid + 1, pos = 0
  while (i <= mid || j <= end) {
    if ((i <= mid && arr[i] <= arr[j]) || (j > end)) {
      result[pos++] = arr[i++]
    } else {
      result[pos++] = arr[j++]
    }
  }
  for (let k = 0; k < result.length; k++) {
    arr[start + k] = result[k]
  }
}

const arr = [1, 4, 3, 5, 2, 0, 6]
mergeSort(arr)
arr // [ 0, 1, 2, 3, 4, 5, 6 ]​​​​​
```
