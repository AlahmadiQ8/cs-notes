## Problem

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
public void SolveSudoku(char[][] board)
{
    var checker = new Checker(board);
    Helper(0, 0);

    bool Helper(int i, int j)
    {
        if (i == 9) return true;

        var next = Pair.Next(i, j);

        if (board[i][j] != '.') return Helper(next.I, next.J);

        for (var candidate = 1; candidate <= 9; candidate++)
        {
            var candidateChar = (char) (candidate + '0');
            if (checker.CanPlace(i, j, candidateChar))
            {
                checker.Place(i, j, candidateChar);
                board[i][j] = candidateChar;
                if (Helper(next.I, next.J)) return true;

                checker.Remove(i, j, candidateChar);
                board[i][j] = '.';
            }
        }

        return false;
    }
}

class Checker
{
    private readonly HashSet<char>[] _rows = new HashSet<char>[9];
    private readonly HashSet<char>[] _cols = new HashSet<char>[9];
    private readonly HashSet<char>[] _boxes = new HashSet<char>[9];

    public Checker(char[][] board)
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
            {
                if (board[i][j] != '.')
                    Place(i, j, board[i][j]);
            }
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

    public int GetBoxNumber(int i, int j)
    {
        return i / 3 * 3 + j / 3;
    }
}

class Pair
{
    public int I { get; }
    public int J { get; }

    private Pair(int i, int j)
    {
        I = i;
        J = j;
    }

    public static Pair Next(int i, int j)
    {
        return j == 8 ? new Pair(i + 1, 0) : new Pair(i, j + 1);
    }
}

public override void Test()
{
    var board = new[]
    {
        new[] {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
        new[] {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
        new[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
        new[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
        new[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
        new[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
        new[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
        new[] {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
        new[] {'.', '.', '.', '.', '8', '.', '.', '7', '9'}
    };

    SolveSudoku(board);
    foreach (var row in board)
    {
        row.LogArray();
    }
}
```
