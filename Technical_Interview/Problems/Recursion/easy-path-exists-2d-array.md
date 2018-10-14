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
