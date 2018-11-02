## Problem 

Given an array of n positive integers and a positive integer s, find the minimal length of a contiguous subarray of which the sum ≥ s. If there isn't one, return 0 instead.

**Example:**
```
Input: s = 7, nums = [2,3,1,2,4,3]
Output: 2
Explanation: the subarray [4,3] has the minimal length under the problem constraint.
```

## Solution

```javascript
function minSubArrayLen(s, nums) {
  if (nums.length == 0) return 0
  let minLen = Number.POSITIVE_INFINITY
  let lo = 0
  let hi = 0
  let sum = nums[lo]
  while (hi < nums.length) {
    if (sum < s) {
      sum += nums[++hi]
    } else {
      minLen = Math.min(minLen, hi - lo + 1)
      sum -= nums[lo++]
    }
  }
  return minLen == Number.POSITIVE_INFINITY ? 0 : minLen
};

minSubArrayLen(7, [2, 3, 1, 2, 4, 3]) // 2
```
