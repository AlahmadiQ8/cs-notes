## Problem

https://leetcode.com/problems/intersection-of-two-arrays-ii/description/

Given two arrays, write a function to compute their intersection.

Example 1:

```
Input: nums1 = [1,2,2,1], nums2 = [2,2]
Output: [2,2]
```

Example 2:

```
Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
Output: [4,9]
```

## Solution

```javascript 
function intersect(nums1, nums2) {
  const hash = {}
  function helper(nums1, nums2) {
    for (const n of nums1) {
      hash[n] = (hash[n] || 0) + 1
    }

    const result = []
    for (const n of nums2) {
      if (hash[n] && hash[n] > 0) {
        result.push(n)
        hash[n] -= 1
      }
    }
    return result
  }
  return helper(nums1, nums2)
}
```
