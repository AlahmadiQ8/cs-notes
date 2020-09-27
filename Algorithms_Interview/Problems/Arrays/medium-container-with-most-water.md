## Problem

https://leetcode.com/problems/container-with-most-water/

```
Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai). n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). Find two lines, which together with x-axis forms a container, such that the container contains the most water.

Note: You may not slant the container and n is at least 2.

Example:

Input: [1,8,6,2,5,4,8,3,7]
Output: 49
```

![](/assets/question_11.jpg)

## Solution

* Two pointer approach

| Complexity | Big O |
|------------|-------|
| Time       | O(N)  |
| Space      | O(1)  |

```csharp
public int MaxArea(int[] height) {

    var low = 0;
    var high = height.Length - 1;
    var max = 0;
    
    while (low < high) {
        var cur = Math.Min(height[low], height[high]) * (high - low);
        max = Math.Max(cur, max);
        if (height[low] < height[high]) low++;
        else high--;
    }
    
    return max;
}
```
