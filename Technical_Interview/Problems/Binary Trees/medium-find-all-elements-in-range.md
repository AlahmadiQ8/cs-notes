## Problem 

Range Querying: Given a Binary Search Tree, find all the elements in the range
[A..B], both A and B inclusive. For example, if we are looking for nodes in the
range [5,8] in the following tree:

![](./Technical_Interview/Problems/Binary&#32;Trees/medium-find-all-elements-in-range.png)

Output: [6, 7, 8]

# Solution 

Find A, or A's successor if A is not in the tree. Then keep finding successors until you exceed B.
