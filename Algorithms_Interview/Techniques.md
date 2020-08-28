
<details><summary>Table of Contents</summary>
<p>

- [Arrays](#arrays)
  - [Benefits](#benefits)
  - [Techniques](#techniques)
  - [Sliding​​ Window](#sliding-window)
  - [Cumulative Sum](#cumulative-sum)
  - [Maximum Diff](#maximum-diff)
  - [2D Arrays](#2d-arrays)
  - [Special Tricks](#special-tricks)
- [Binary Search](#binary-search)
  - [Record & Move](#record--move)
  - [Special Tricks](#special-tricks-1)
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
  - [Bipartite Graph](#bipartite-graph)
- [Line Sweep](#line-sweep)
- [Selection Algorithm](#selection-algorithm)
- [Heaps](#heaps)
- [Sorting](#sorting)
  - [Merge Sort](#merge-sort)
  - [Quick Sort](#quick-sort)
  - [Tricks](#tricks)
  - [Array Stability](#array-stability)
  - [Soritng Large Data](#soritng-large-data)
- [Bit Manipulation](#bit-manipulation)
  - [LSB (Least Significant Bit)](#lsb-least-significant-bit)
  - [Most Significant 1 bit index in a number](#most-significant-1-bit-index-in-a-number)
  - [Count number of ones](#count-number-of-ones)
  - [Swap Bits](#swap-bits)
- [Binary Trees](#binary-trees)
  - [Lowest Common Ancestor (LCA)](#lowest-common-ancestor-lca)
- [Tries](#tries)
- [Union Find (Disjoint Set Union)](#union-find-disjoint-set-union)
  - [Applications](#applications)
- [Dynamic Programming (NOT REVIEWED YET)](#dynamic-programming-not-reviewed-yet)

</p>
</details>

# Arrays

## Benefits

- O(1) lookup time
- Fixed size
- Resizing is an expensive operation

## Techniques

* **Two pointers**
  - Reverse Array
  - Find two numbers that sum to an X in sorted array
  - Given a sorted array in non-decreasing order, return an array of squares of each number, alsoin non-decreasing order
  - Find the shortest subarray, that if sorted, results in the entire array being sorted
* **Dutch National Flag**
  - Quick Sort
  - Sort by three colors
  - Move all zeros to end of array
* **Kadane's algorithm**
- Maximum subarray sum

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
- To decrease the load factor, resize the size of the hash (larger array slots)
- Resizing Takes Time O(keys)
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

- Used to detect cycles
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

## Bipartite Graph 

- Graph where nodes can be separated into two groups where each
  node in a group cannot be connected to another node in the same
  group. 
- Solved using BFS and simplified version of Dikstra
- even distances go in one group and odd distances go to another
- if two nodes have the same distance and directly connected, then 
  this is NOT a bipartite graph.

# Line Sweep

- Given a list of time intervals, find if any of them overlap.
  Each interval has a start time and a stop time
- Given a list of time intervals, find the largest number of overlaps at any point
- [Skyline Problem](https://interviewcamp.io/courses/101687/lectures/3312866)
- Steps
  1. Extract start and end times into individual points
     `Point { isStart, time }`
  2. sort them in order
  3. iterate and keep track

# Selection Algorithm

- Uses QuickSort's partitioning step
- Used to find Kth smallest Element (or elements)
- It finds the K smallest elements in an unsorted array in O(n) time.
- O(n) Time on Average/ O(N^2) Worst time
- _Medians of Medians_ Algorithm gaurunties O(n) time worst case. but a bit complicated for interviews
- **How to find Median in O(n) Time complexity?** Find the (n/2)th element

# Heaps

- you can use it to find Kth Smallest in nlon(k) time. Although
  Selection algorithm performs better on average.

|                |       |
| -------------- | ----- |
| Lookup for min | nlogk |
| insert/remove  | logn  |

# Sorting

## Merge Sort

- Time Complexity: O(nlogn) worst time
- Space Complexity: O(n)

## Quick Sort

- Time Complexity: O(nlogn) Average, O(n^2) worst time
- Space Complexity: O(1)

## Tricks 

- If you have shortlimited range (0-9) utilize bucket sort for O(n) time 
  complexity  

## Array Stability

- Duplicated elements retain their order? Merge sort gaurauntees it. 
  but not quick sort.
- How to make sorting algorthim stable? use object elements with unique 
  indexes and add the index to the comparator

## Soritng Large Data 

- See https://interviewcamp.io/courses/101687/lectures/2652608

# Bit Manipulation

|                            |                                     |
| -------------------------  | ----------------------------------- |
| Set Value to 1             | `1<<n | number`                     |
| Set Value to 0             | `~(1<<n) & number`                  |
| Toggle Value               | `1<<n ^ number `                    |
| Get Bit                    | `(num,i) => ((num & (1 « i)) != 0)` or `(n>>i) & 1` |
| Get Same Value             | `x | 0 = x` or `x ^ 0 = x`          |
| Clear Bits in range i & j  | `~ ( 1<<(j+1) - 1) << i )`          |
| checks if n is a power of 2| `n & (n-1) == 0` |
|  |                           `// 00100 ==> true` |
|  |                           `// 10110 ==> false` |

## LSB (Least Significant Bit)

- **Memorize:** X & (X - 1) gives us X without the Least Significant Bit (LSB).
```
0101 => 0100 
0100 => 0000 
1111 => 1110 
1000 => 0000
```

## Most Significant 1 bit index in a number

- i = log2(n)

## Count number of ones

```javascript
function countOnes(n) {
  let count = 0
  while (n > 0) {
    n = n & (n - 1)
    count++
  }
  return count
}
```

## Swap Bits 

```javascript
function swapBits(n, i, j) {
  if (getBit(n, i) !== getBit(n, j)) {
    return n ^ ((1 << i) | (1 << j))
  }
}

function getBit(n, j) {
  return n >> j & 1
}
```

# Binary Trees

## Lowest Common Ancestor (LCA)

- if you have access to parent, calc hieghts of both, make 
  them from equal height from root, then travese up together
  untill they're the same 

# Tries 

- Check https://www.filepicker.io/api/file/KmFrMpJJQzyGeq1IfCd0
  
# Union Find (Disjoint Set Union)

- [Best Article](https://leetcode.com/articles/redundant-connection/)
- [Awesome Slide](https://www.cs.princeton.edu/~rs/AlgsDS07/01UnionFind.pdf)
- See [numbers of islands](https://leetcode.com/problems/number-of-islands/solution/)
- 

## Applications

- Node Connectivity
- number of disconnected set of nodes


# Dynamic Programming (NOT REVIEWED YET)
