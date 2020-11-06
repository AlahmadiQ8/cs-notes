## Problem

https://leetcode.com/problems/spiral-matrix-ii/

```
Given a positive integer n, generate a square matrix filled with elements from 1 to n2 in spiral order.

Example:

Input: 3
Output:
[
 [ 1, 2, 3 ],
 [ 8, 9, 4 ],
 [ 7, 6, 5 ]
]
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(n^2)  |
| Space      | O(N)  |

```csharp
public int[][] GenerateMatrix(int n)
{
    // Declaration
    int[][] matrix = new int[n][];
    for (var i = 0; i < n; i++) matrix[i] = new int[n];

    // Edge Case
    if (n == 0)
    {
        return matrix;
    }

    // Normal Case
    var rowStart = 0;
    var rowEnd = n - 1;
    var colStart = 0;
    var colEnd = n - 1;
    var num = 1; //change

    while (rowStart <= rowEnd && colStart <= colEnd)
    {
        for (var i = colStart; i <= colEnd; i++)
            matrix[rowStart][i] = num++; //change
        rowStart++;

        for (var i = rowStart; i <= rowEnd; i++)
            matrix[i][colEnd] = num++; //change
        colEnd--;

        for (var i = colEnd; i >= colStart; i--)
        {
            if (rowStart <= rowEnd)
                matrix[rowEnd][i] = num++; //change
        }
        rowEnd--;

        for (var i = rowEnd; i >= rowStart; i--)
        {
            if (colStart <= colEnd)
                matrix[i][colStart] = num++; //change
        }
        colStart++;
    }

    return matrix;
}
```
