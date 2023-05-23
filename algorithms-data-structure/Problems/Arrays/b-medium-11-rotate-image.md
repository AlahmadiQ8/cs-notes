---
tags:
  - review
---

# [Rotate Image](https://leetcode.com/problems/rotate-image/)

You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise).

You have to rotate the image in-place, which means you have to modify the input 2D matrix directly. DO NOT allocate another 2D matrix and do the rotation.

## Solution

[Best video explanation](https://www.youtube.com/watch?v=fMSJSS7eO1w)

```csharp
public class Solution
{
    public void Rotate(int[][] matrix)
    {
        var left = 0;
        var right = matrix.Length - 1;
        while (left < right)
        {
            for (var offset = 0; offset < right - left; offset++)
            {
                var top = left;
                var bottom = right;

                var temp = matrix[top][left + offset];
                matrix[top][left + offset] = matrix[bottom - offset][left];
                matrix[bottom - offset][left] = matrix[bottom][right - offset];
                matrix[bottom][right - offset] = matrix[top + offset][right];
                matrix[top + offset][right] = temp;
            }

            left++;
            right--;
        }
    }
}
```
