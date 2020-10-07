## Problem

https://leetcode.com/problems/kth-smallest-element-in-a-bst/

```
Given a binary search tree, write a function kthSmallest to find the kth smallest element in it.

 

Example 1:

Input: root = [3,1,4,null,2], k = 1
   3
  / \
 1   4
  \
   2
Output: 1
Example 2:

Input: root = [5,3,6,2,4,null,null,1], k = 3
       5
      / \
     3   6
    / \
   2   4
  /
 1
Output: 3
Follow up:
What if the BST is modified (insert/delete operations) often and you need to find the kth smallest frequently? How would you optimize the kthSmallest routine?

 

Constraints:

The number of elements of the BST is between 1 to 10^4.
You may assume k is always valid, 1 ≤ k ≤ BST's total elements.
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(N)  |
| Space      | O(N)  |

```csharp
public int KthSmallest(TreeNode root, int k) {
    int answer = 0;
    int nthLargest = 0;
    InOrderTraveral(root);
    return answer;
    
    void InOrderTraveral(TreeNode node) {
        if (node == null) return;
        
        InOrderTraveral(node.left);
        nthLargest++;
        if (nthLargest == k) {
            answer = node.val;
            return;
        }
        InOrderTraveral(node.right);
    }
}
```

## Solution II - Iterative


| Complexity | Big O |
|------------|-------|
| Time       | O(N)  |
| Space      | O(H)  |

```csharp
public int KthSmallest(TreeNode root, int k) {
    var stack = new Stack<TreeNode>();
    var cur = root;
    while (stack.Count != 0 || cur != null) {
        if (cur != null) {
            stack.Push(cur);
            cur = cur.left;
        } else {
            cur = stack.Pop();
            if (--k == 0) return cur.val;
            cur = cur.right;
        }
    }
    
    return -1;
}
```
