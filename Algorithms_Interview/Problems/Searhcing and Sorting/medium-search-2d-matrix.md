## Problem

https://leetcode.com/problems/search-a-2d-matrix-ii/

```
Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:

Integers in each row are sorted in ascending from left to right.
Integers in each column are sorted in ascending from top to bottom.
Example:

Consider the following matrix:

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

| Complexity | Big O |
|------------|-------|
| Time       | O(M + N)  |
| Space      | O(1)  |

```csharp
public bool SearchMatrix(int[,] matrix, int target)
{
    var r = matrix.GetLength(0);
    if (r == 0) return false;
    var c = matrix.GetLength(1);

    var row = r - 1;
    var col = 0;
    while (row >= 0 && col < c)
    {
        if (matrix[row, col] > target) row--;
        else if (matrix[row, col] < target) col++;
        else return true;
    }

    return false;
}
```
