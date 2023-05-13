## Problem

[link to question](https://interviewcamp.io/courses/101687/lectures/2643717)
You are given a 2D array that represents a maze. It can have 2 values -
0 and 1. 1 represents awall in the maze and 0 represents a path. The
objective of the maze is to reach the bottom right corner, or
A[A.length-1][A.length-1]. You start from A[0][0] and can only go right
or down. Find If a path exists to the bottom right of the maze from
A[0][0]

0 1 1 1
0 0 0 1
1 0 0 0
1 1 1 0

## Technique

- Recursion with backtracking
- Improve with memoization 

## Notes 

- What if you can go all 4 sides? 
  - then use a hash to track visited points


| Complexity | Big O                                                  |
| ---------- | ------------------------------------------------------ |
| Time       | O(n^2) with memoization where n is length of one side |
| Space      | O(n^2) on the recursion stack                          |

```csharp
public bool PathExists(int[,] grid)
{
    if (grid.GetLength(0) == 0 || grid.GetLength(1) == 0) return false;

    var gridState = new State[grid.GetLength(0), grid.GetLength(1)];
    for (var i = 0; i < grid.GetLength(0); i++)
    {
        for (var j = 0; j < grid.GetLength(1); j++)
            gridState[i, j] = State.NotVisited;
    }

    return Helper(0, 0);

    bool Helper(int i, int j)
    {
        if (OutOfBound(i, j) || grid[i, j] == 1) return false;
        if (i == grid.GetLength(0) - 1 && j == grid.GetLength(1) - 1) return true;
        if (gridState[i, j] == State.Visited || gridState[i, j] == State.Visiting) return false;

        gridState[i, j] = State.Visiting;
        var points = new[] {(i + 1, j), (i - 1, j), (i, j + 1), (i, j - 1)};
        foreach (var (ii, jj) in points)
        {
            if (Helper(ii, jj))
            {
                gridState[i, j] = State.PathFound;
                return true;
            }
        }

        gridState[i, j] = State.Visited;
        return false;
    }

    bool OutOfBound(int i, int j)
    {
        if (i >= grid.GetLength(0) || i < 0 || j >= grid.GetLength(1) || j < 0) return true;
        return false;
    }
}

private enum State
{
    Visiting,
    NotVisited,
    Visited,
    PathFound
}

public override void Test()
{
    PathExists(new[,]
    {
        {0, 0, 1},
        {0, 1, 1},
        {0, 0, 1},
        {1, 0, 0},
    }).Should().BeTrue();
    PathExists(new[,]
    {
        {0, 0, 1},
        {0, 1, 1},
        {0, 0, 1},
        {1, 0, 1},
    }).Should().BeFalse();
}
```
