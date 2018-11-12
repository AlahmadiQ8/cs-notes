---
tags: 
  - fundamental
---

You are given an array of integers and an index x. Rearrange the array such that
all integers less than integer at X are on the left side and all that are 
larger are on the right side:

a​​ = ​​[3,5,2,6,8,4,4,6,4,4,3]​​ and ​​i​​=​​5 ​​--> ​​result​​ = ​​[3,2,3,4,4,4,4,5,6,8,6]

## Alternative phrasing

Given an array with n objects colored red, white or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white and blue.

Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.

| Complexity | Big O |
|------------|-------|
| Time       | O(n)  |
| Space      | O(1)  |

```javascript
function dnf(arr, x) {
  if (!arr || arr.length <= 1) return
  if (x < 0 || x >= arr.length) throw Error('Out of bound')

  let pivot = arr[x]
  let lo = 0,
    mid = 0,
    hi = arr.length - 1
  while (mid <= hi) {
    if (arr[mid] < pivot) swap(arr, lo++, mid++)
    else if (arr[mid] > pivot) swap(arr, mid, hi--)
    else mid++
  }
}
function swap(arr, i, j) {
  let temp = arr[i]
  arr[i] = arr[j]
  arr[j] = temp
}

const arr = [3, 5, 2, 6, 8, 4, 4, 6, 4, 4, 3]
dnf(arr, 3) // [ 3, 5, 2, 3, 4, 4, 4, 4, 6, 6, 8 ]​​​​​
```

