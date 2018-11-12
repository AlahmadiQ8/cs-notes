## Problem

```
Find the kth largest element in an unsorted array. Note that it is the kth
largest element in the sorted order, not the kth distinct element.

Example 1:

Input: [3,2,1,5,6,4] and k = 2
Output: 5
Example 2:

Input: [3,2,3,1,2,4,5,5,6] and k = 4
Output: 4

Note: You may assume k is always valid, 1 ≤ k ≤ array's length.
```

# Technique

- Selection Algoriothm or DNF 

| Complexity | Big O                       |
| ---------- | --------------------------- |
| Time       | O(n)on average O(n^2) worst |
| Space      | O(n)                        |

```javascript
function findKthElement(arr, k) {
  if (!arr || arr.length == 0) return null

  // to get kth smallest element, set it to k - 1 
  return selectionSort(arr, arr.length - k, 0, arr.length - 1)
}

function selectionSort(arr, targetIndex, start, end) {
  if (end < start) return null

  const pivot = getRandomInt(start, end)
  const result = singlePlacementPartition(arr, pivot, start, end)
  if (targetIndex == result) {
    return arr[result]
  } else if (targetIndex < result) {
    return selectionSort(arr, targetIndex, start, result - 1)
  } else {
    return selectionSort(arr, targetIndex, result + 1, end)
  }
}

function singlePlacementPartition(arr, pivot, start, end) {
  swap(arr, start, pivot)
  let less = start
  for (let i = start + 1; i <= end; i++) {
    if (arr[i] <= arr[start]) {
      swap(arr, i, ++less)
    }
  }
  swap(arr, start, less)
  less
  return less
}

function getRandomInt(start, end) {
  return Math.floor(Math.random() * (end - start + 1)) + start
}


function swap(arr, i, j) {
  let temp = arr[i]
  arr[i] = arr[j]
  arr[j] = temp
}

const arr = () => [5, 6, 4, 7, 3, 8, 2, 9, 1]
findKthElement(arr(), 1) // 1
findKthElement(arr(), 2) // 2
findKthElement(arr(), 3) // 3
findKthElement(arr(), 4) // 4
findKthElement(arr(), 5) // 5
findKthElement(arr(), 6) // 6
findKthElement(arr(), 7) // 7
findKthElement(arr(), 8) // 8
findKthElement(arr(), 9) // 9

```
