## Problem

Given an array nums and a target value k, find the maximum length of a subarray that sums to k. If there isn't one, return 0 instead.

**Note:**
The sum of the entire nums array is guaranteed to fit within the 32-bit signed integer range.

**Example 1:**

```
Input: nums = [1, -1, 5, -2, 3], k = 3
Output: 4 
Explanation: The subarray [1, -1, 5, -2] sums to 3 and is the longest.
```

**Example 2:**

```
Input: nums = [-2, -1, 2, 1], k = 1
Output: 2 
Explanation: The subarray [-1, 2] sums to 1 and is the longest.
```
## Technique

- Cummulative sum with hash table for O(n) performance

## Solution 

```javascript
function maxSubArrayLen(arr, k) {
  if (!arr || arr.length == 0) return 0;
  let max = 0;
  const map = new Map();
  let sum = 0;

  for (let i = 0; i < arr.length; i++) {
    sum += arr[i];
    if (sum == k) max = max = Math.max(i + 1, max);
    if (map.has(sum - k)) {
      const index = map.get(sum - k);
      max = Math.max(i - index, max);
    }
    if (!map.has(sum)) map.set(sum, i);
  }

  return max;
}
```
