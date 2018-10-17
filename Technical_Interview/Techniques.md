- [Arrays](#arrays)
  - [Benefits](#benefits)
  - [Two pointers](#two-pointers)
  - [Dutch National Flag](#dutch-national-flag)
  - [Kadane's algorithm](#kadanes-algorithm)
  - [Sliding​​ Window](#sliding-window)
  - [Cumulative Sum](#cumulative-sum)
  - [Maximum Diff](#maximum-diff)
  - [2D Arrays](#2d-arrays)
  - [Special Tricks](#special-tricks)
- [Binary Search](#binary-search)
  - [Record & Move](#record--move)
  - [Special Tricks](#special-tricks)
- [Recursion](#recursion)
  - [Permutations/Combinations (Auxiliary Buffer)](#permutationscombinations-auxiliary-buffer)
  - [Backtracking](#backtracking)
- [Linked Lists](#linked-lists)
  - [Slow Pointer and Fast pointer](#slow-pointer-and-fast-pointer)
  - [Linked Hash Table](#linked-hash-table)
- [Stacks](#stacks)
  - [Expression Evaluation](#expression-evaluation)
- [Queue](#queue)
- [Hash Tables](#hash-tables)
  - [Rabin Karp Algorithm](#rabin-karp-algorithm)
- [Graphs](#graphs)
  - [Depth First Search (DFS)](#depth-first-search-dfs)
  - [Breadth First Search (DFS)](#breadth-first-search-dfs)
  - [Topological Sort](#topological-sort)
- [Line Sweep](#line-sweep)
- [Dynamic Programming (NOT REVIEWED YET)](#dynamic-programming-not-reviewed-yet)

# Arrays

## Benefits

- O(1) lookup time
- Fixed size
- Resizing is an expensive operation

## Two pointers

- Reverse Array
- Find two numbers that sum to an X in sorted array

## Dutch National Flag

- Quick Sort
- Sort by three colors
- Move all zeros to end of array

## Kadane's algorithm

- Maximum subarray

## Sliding​​ Window

- Subarray that sums to X in an array of **positive integers**

## Cumulative Sum

- Find subarray that sums to zero
  1. Create array with sums till i
  2. Create map and check if there are duplicated sums in the array
  3. return [prev + 1, i]

## Maximum Diff

- Similar to Kadane's algorithm

## 2D Arrays

- [Review Here](https://interviewcamp.io/courses/101687/lectures/2632010)
- Rotate Array
- Print Array ZigZag
- Print Array in Spiral Order

## Special Tricks

- Reverse words in array
- Check if string is rotation of another
- Longest palindrome in string

# Binary Search

## Record & Move

- Find Closest element to target

## Special Tricks

- Search in a rotated array
- Search Unknown Array Size


# Recursion

## Permutations/Combinations (Auxiliary Buffer)

1. Termination Cases
2. Find Candidates that go into the buffer index
3. Place each candidate into the buffer index
4. Recurse to next buffer index

## Backtracking

- Solving mazes
- Finding paths
- [Soduko Solver](https://www.geeksforgeeks.org/sudoku-backtracking-7/)
- [Placing N queens on a Chess Board](https://www.geeksforgeeks.org/n-queen-problem-backtracking-3/)


# Linked Lists

- Sort Linked List
  - Trick is to determine the range of values

## Slow Pointer and Fast pointer

- Find if list has a cycle in it
- Go to the middle node
- Find the 3rd to last element in a given linked list.

## Linked Hash Table

- Linked Lists provide O(n) lookup time, but preserve order
- Hash tables provide O(1) lookup time but no order preserve
- Combining the two gives us the following:
  - Preserved order
  - O(1) Lookup time
- Usages:
  - LRU Caching: Least Recently Used Cache
  - Given a doc, find smallest subarray containing all given words

# Stacks

## Expression Evaluation

- Postfix Expression: Use an operands stack
- Infix Expression: Use an operands stack and operator stack
- Infix with Parenthesis

# Queue

- Basic implementation: Circular Array
- Useful often in sliding windows
- Review implementing Queue with Max since it can be handy

# Hash Tables

- Load Factor = n / length of hash array (slots)
- Good Load Factor <= 0.75
- Characteristics of good hash function
  - Deterministic
  - Evenly distributed
  - Uses all input values
- Good hash function: Polynomial
  - `hash("boat") -> 'b'.x^3 + 'o'.x^2 + 'a'.x + 't'`
  - Implementation: [visit this link](https://interviewcamp.io/courses/101687/lectures/3312774)

## Rabin Karp Algorithm

- Find is string is substring of another
- Implement `contains(a, b)` to check if a contains b
- String search
- Super Simple: Sliding window!
- Use polynomial hash function where you can add and delete letter
  to move the window.
- See [example problem](https://interviewcamp.io/courses/101687/lectures/3312773)

# Graphs

- Directed vs undirected
- A clique is when each node has an edge to every other node in the
  graph.

## Depth First Search (DFS)

- Steps:
  1. Mark "VISITING"
  2. Process
  3. Visit each unvisited neighbor
  4. Mark "VISITED"

## Breadth First Search (DFS)

- Steps
  1. Initialize `queue = [node]` and mark the node as visiting
  2. while queue is not empty, unshift, process, push unvisited nodes
     to the queue and mark them as visiting
  3. mark the current node as visited

## Topological Sort

- Topological sorting arranges the nodes in order such that all edges
  are pointing forward.
- Implemented using Depth First Search (DFS)
- Only possible when there are no cycles
- Examples:
  - Find Longest Path
  - Find Minimum number of classes to take given prerequisites

# Line Sweep

- Given a list of time intervals, find if any of them overlap.
  Each interval has a start time and a stop time
- Given a list of time intervals, find the largest number of overlaps at any point
- Steps
  1. Extract start and end times into individual points
  `Point { isStart, time }`
  2. sort them in order
  3. iterate and keep track 

# Dynamic Programming (NOT REVIEWED YET)
