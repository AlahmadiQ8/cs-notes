- [Arrays](#arrays)
  - [Benefits](#benefits)
  - [Two pointers](#two-pointers)
  - [Dutch National Flag](#dutch-national-flag)
  - [Kadane's algorithm](#kadanes-algorithm)
  - [Sliding​​ Window](#sliding-window)
  - [Cumulative Sum](#cumulative-sum)
- [Binary Search](#binary-search)
  - [Record & Move](#record--move)
  - [Special Tricks](#special-tricks)
- [Recursion](#recursion)
  - [Permutations/Combinations (Auxiliary Buffer)](#permutationscombinations-auxiliary-buffer)
  - [Backtracking](#backtracking)
- [Linked Lists](#linked-lists)
  - [Slow Pointer and Fast pointer](#slow-pointer-and-fast-pointer)
  - [Linked Hash Table](#linked-hash-table)

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
