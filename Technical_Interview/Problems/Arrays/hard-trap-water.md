## Problem

- [leetcode](https://leetcode.com/problems/trapping-rain-water/description/)

```
Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it is able to trap after raining.


The above elevation map is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue section) are being trapped. Thanks Marcos for contributing this image!

Example:

Input: [0,1,0,2,1,0,1,3,2,1,2,1]
Output: 6

Input: [5, 3, 2, 1, 5]
Output: 9

#...#
#...#
##..#
###.#
#####

Input: [2, 4, 1, 5, 3]
Output: 3

   #
 #.#
 #.##
##.##
#####

Input: [2, 1, 5, 1, 3]
Output: 3
  #
  #
  #.#
#.#.#
#####
```

## Solution 

| Complexity | Big O |
| ---------- | ----- |
| Time       | O(n)  |
| Space      | O(1)  |

```javascript
var trap = function(heights) {
  let result = 0
  let left = 0
  let right = heights.length - 1
  let leftMax = 0
  let rightMax = 0
  while (left < right) {
    leftMax = Math.max(leftMax, heights[left])
    rightMax = Math.max(rightMax, heights[right])
    if (leftMax < rightMax) {
      result += leftMax - heights[left++]
    } else {
      result += rightMax - heights[right--]
    }
  }
  return result
};

trap([5, 3, 2, 1, 5]) // 9
trap([1, 2, 5, 2, 1]) // 0
```
