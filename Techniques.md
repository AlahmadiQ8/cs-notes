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
- [Permutations/Combinations](#permutationscombinations)
  - [Auxiliary Buffer](#auxiliary-buffer)

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


# Permutations/Combinations

## Auxiliary Buffer

1. Termination Cases
2. Find Candidates that go into the buffer index
3. Place each candidate into the buffer index
4. Recurse to next buffer index
