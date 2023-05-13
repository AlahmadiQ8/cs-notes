---
tags:
  - review
---

## [Search a 2D Matrix II](https://leetcode.com/problems/search-a-2d-matrix-ii/)


Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:

Integers in each row are sorted in ascending from left to right.
Integers in each column are sorted in ascending from top to bottom.
Example:

Consider the following example:

```
[
  [1,   4,  7, 11, 15],
  [2,   5,  8, 12, 19],
  [3,   6,  9, 16, 22],
  [10, 13, 14, 17, 24],
  [18, 21, 23, 26, 30]
]
Given target = 5, return true.

Given target = 20, return false.
```

## Solution

| Complexity | Big O    |
| ---------- | -------- |
| Time       | O(M + N) |
| Space      | O(1)     |

```csharp
public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        var rLength = matrix.Length;
        if (rLength == 0)
            return false;
        var lLength = matrix[0].Length;

        var row = rLength - 1;
        var col = 0;
        while (row >= 0 && col < lLength)
        {
            if (matrix[row][col] > target)
                row--;
            else if (matrix[row][col] < target)
                col++;
            else
                return true;
        }

        return false;
    }
}
```
