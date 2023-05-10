---
tags:
  - review
---

# [Robot Room Cleaner](https://leetcode.com/problems/robot-room-cleaner)

You are controlling a robot that is located somewhere in a room. The room is modeled as an m x n binary grid where 0 represents a wall and 1 represents an empty slot.

The robot starts at an unknown location in the room that is guaranteed to be empty, and you do not have access to the grid, but you can move the robot using the given API Robot.

You are tasked to use the robot to clean the entire room (i.e., clean every empty cell in the room). The robot with the four given APIs can move forward, turn left, or turn right. Each turn is 90 degrees.

When the robot tries to move into a wall cell, its bumper sensor detects the obstacle, and it stays on the current cell.

Design an algorithm to clean the entire room using the following APIs:

## Solution

```csharp
class Solution
{
    public void CleanRoom(Robot robot)
    {
        var directions = new[]
        {
            new[] { -1, 0 },
            new[] { 0, 1 },
            new[] { 1, 0 },
            new[] { 0, -1 },
        };
        var visited = new HashSet<(int row, int col)>();
        Backtrack(0, 0, 0);

        void Backtrack(int row, int col, int d)
        {
            visited.Add((row, col));
            robot.Clean();
            for (var i = 0; i < 4; i++)
            {
                var newD = (d + i) % 4;
                var newRow = row + directions[newD][0];
                var newCol = col + directions[newD][1];
                ;
                if (!visited.Contains((newRow, newCol)) && robot.Move())
                {
                    Backtrack(newRow, newCol, newD);
                    GoBack();
                }

                robot.TurnRight();
            }
        }

        void GoBack()
        {
            robot.TurnLeft();
            robot.TurnLeft();
            robot.Move();
            robot.TurnLeft();
            robot.TurnLeft();
        }
    }
}
```
