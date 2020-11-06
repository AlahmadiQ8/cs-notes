## Problem

```
Given a matrix of M x N elements (M rows, N columns), return all elements of the matrix in diagonal order as shown in the below image.

Example:

Input:
[
 [ 1, 2, 3 ],
 [ 4, 5, 6 ],
 [ 7, 8, 9 ]
]

Output:  [1,2,4,7,5,3,6,8,9]
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(M * N)  |
| Space      | O(1)  |

```csharp
public int[] FindDiagonalOrder(int[][] matrix)
{
    if (matrix == null || matrix.Length == 0)
    {
        return new int[0];
    }

    var M = matrix.Length;
    var N = matrix[0].Length;

    int[] result = new int[M * N];

    int row = 0, col = 0, d = 0;
    var dirs = new[,] {{-1, 1}, {1, -1}};

    for (var i = 0; i < M * N; i++)
    {
        result[i] = matrix[row][col];
        row += dirs[d, 0];
        col += dirs[d, 1];

        if (col >= N)
        {
            row += 2;
            col = N - 1;
            d ^= 1;
        }
        if (row >= M)
        {
            row = M - 1;
            col += 2;
            d ^= 1;
        }

        if (row < 0)
        {
            row = 0;
            d ^= 1;
        }

        if (col < 0)
        {
            col = 0;
            d ^= 1;
        }
    }

    return result;
}
```
