## Problem

https://leetcode.com/problems/maximum-depth-of-binary-tree/

```
Given a binary tree, find its maximum depth.

The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

Note: A leaf is a node with no children.

Example:

Given binary tree [3,9,20,null,null,15,7],

    3
   / \
  9  20
    /  \
   15   7
return its depth = 3.
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(N)  |
| Space      | O(log(N))  |

```csharp
// bottom-up approach
public int MaxDepth(TreeNode root) {
    if (root == null) return 0;
    
    return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
}

// top-down -approach
public int MaxDepth(TreeNode root) {
    var maxDepth = 0;        
    MaxDepthHelper(root, 0);
    return maxDepth;
    
    void MaxDepthHelper(TreeNode node, int level) {
        if (node == null) return;
        
        var depth = 1 + level;
        maxDepth = Math.Max(maxDepth, depth);
        
        MaxDepthHelper(node.left, depth);
        MaxDepthHelper(node.right, depth);
    }
}
```
