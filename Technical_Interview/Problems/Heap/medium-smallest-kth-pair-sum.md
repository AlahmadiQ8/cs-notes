## Problem 

```
You are given two integer arrays nums1 and nums2 sorted in ascending order and an integer k.

Define a pair (u,v) which consists of one element from the first array and one element from the second array.

Find the k pairs (u1,v1),(u2,v2) ...(uk,vk) with the smallest sums.

Example 1:

Input: nums1 = [1,7,11], nums2 = [2,4,6], k = 3
Output: [[1,2],[1,4],[1,6]] 
Explanation: The first 3 pairs are returned from the sequence: 
             [1,2],[1,4],[1,6],[7,2],[7,4],[11,2],[7,6],[11,4],[11,6]
Example 2:

Input: nums1 = [1,1,2], nums2 = [1,2,3], k = 2
Output: [1,1],[1,1]
Explanation: The first 2 pairs are returned from the sequence: 
             [1,1],[1,1],[1,2],[2,1],[1,2],[2,2],[1,3],[1,3],[2,3]
Example 3:

Input: nums1 = [1,2], nums2 = [3], k = 3
Output: [1,3],[2,3]
Explanation: All possible pairs are returned from the sequence: [1,3],[2,3]
```

## Solution 

- [Source](https://leetcode.com/explore/interview/card/google/63/sorting-and-searching-4/447/discuss/84551/simple-Java-O(KlogK)-solution-with-explanation)

![](Technical_Interview/Problems/Heap/medium-smallest-kth-pair-sum.png)

```javascript
function kSmallestPairs(nums1, nums2, k) {
  // min queue, sorted by pair sum
  const queue = new PriorityQueue((a, b) => (a[0] + a[1]) - (b[0] + b[1])
  )

  const result = []
  const len1 = nums1.length
  const len2 = nums2.length

  for (let i = 0; i < Math.min(k, len1); i++) {
    queue.push([nums1[i], nums2[0], 0])
  }

  for (let i = 0; i < Math.min(len1 * len2, k); i++) {
    // get the best paid
    const cur = queue.pop()
    result.push([cur[0], cur[1]])
    // next better pair could with be A: {after(num1), num2} or B: 
    // {num1. after(num2)}
    // for A, we've already added top possible k into queue, so A is 
    // either in the queue already, or not qualified
    // for B, it might be a better choice, so we offer it into queue
    if (cur[2] < len2 - 1) {
      let index = cur[2] + 1
      queue.push([cur[0], nums2[index], index])
    }
  }

  return result
}

kSmallestPairs([1, 7, 11], [2, 4, 6], 3) //?
```
