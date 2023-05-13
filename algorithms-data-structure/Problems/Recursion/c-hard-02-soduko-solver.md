---
tags:
  - techniques/backtracking
---

# [Sudoku Solver](https://leetcode.com/problems/sudoku-solver/description/)

```
Write a program to solve a Sudoku puzzle by filling the empty cells.

A sudoku solution must satisfy all of the following rules:

Each of the digits 1-9 must occur exactly once in each row.
Each of the digits 1-9 must occur exactly once in each column.
Each of the the digits 1-9 must occur exactly once in each of the 9 3x3 sub-boxes of the grid.
Empty cells are indicated by the character '.'.
```

## Technique

* Backtracing

| Complexity | Big O |
|------------|-------|
| Time       | O(9^n)  |
| Space      | O(n)  |

## Solution


```csharp
public class Solution
{
    public void SolveSudoku(char[][] board)
    {
        var solver = new SodukoSolver(board);
        Backtrack(0, 0);

        bool Backtrack(int i, int j)
        {
            if (i == 9) return true;

            var nextI = j == 8 ? i + 1 : i;
            var nextJ = j == 8 ? 0 : j + 1;

            if (board[i][j] != '.')
                return Backtrack(nextI, nextJ);

            for (var candidate = 1; candidate <= 9; candidate++)
            {
                var c = (char)(candidate + '0');
                if (solver.CanPlace(i, j, c))
                {
                    solver.Place(i, j, c);
                    board[i][j] = c;
                    if (Backtrack(nextI, nextJ)) return true;

                    solver.Remove(i, j, c);
                    board[i][j] = '.';
                }
            }

            return false;
        }
    }
}

class SodukoSolver
{
    private readonly HashSet<char>[] _rows = new HashSet<char>[9];
    private readonly HashSet<char>[] _cols = new HashSet<char>[9];
    private readonly HashSet<char>[] _boxes = new HashSet<char>[9];

    public SodukoSolver(char[][] board)
    {
        for (var i = 0; i < 9; i++)
        {
            for (var j = 0; j < 9; j++)
            {
                _rows[i] = new HashSet<char>();
                _cols[j] = new HashSet<char>();
                _boxes[GetBoxNumber(i, j)] = new HashSet<char>();
            }
        }

        for (var i = 0; i < 9; i++)
        {
            for (var j = 0; j < 9; j++)
                if (board[i][j] != '.')
                    Place(i, j, board[i][j]);
        }
    }

    public bool CanPlace(int i, int j, char c)
    {
        if (_rows[i].Contains(c)) return false;
        if (_cols[j].Contains(c)) return false;
        if (_boxes[GetBoxNumber(i, j)].Contains(c)) return false;
        return true;
    }

    public void Place(int i, int j, char c)
    {
        _rows[i].Add(c);
        _cols[j].Add(c);
        _boxes[GetBoxNumber(i, j)].Add(c);
    }

    public void Remove(int i, int j, char c)
    {
        _rows[i].Remove(c);
        _cols[j].Remove(c);
        _boxes[GetBoxNumber(i, j)].Remove(c);
    }

    private int GetBoxNumber(int i, int j)
    {
        return (i / 3) * 3 + j / 3;
    }
}
```
