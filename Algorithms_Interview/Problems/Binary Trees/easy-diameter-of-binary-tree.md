## Problem

https://leetcode.com/problems/diameter-of-binary-tree/submissions/

```
Given a binary tree, you need to compute the length of the diameter of the tree. The diameter of a binary tree is the length of the longest path between any two nodes in a tree. This path may or may not pass through the root.

Example:
Given a binary tree
          1
         / \
        2   3
       / \     
      4   5    
Return 3, which is the length of the path [4,2,1,3] or [5,2,1,3].

Note: The length of path between two nodes is represented by the number of edges between them.
```

## Solution

* Height of tree

| Complexity | Big O |
|------------|-------|
| Time       | O(N)  |
| Space      | O(N)  |

```csharp
public int DiameterOfBinaryTree(TreeNode root)
{
    if (root == null) return 0;
    var max = 0;
    GetHeight(root);

    return max - 1;

    int GetHeight(TreeNode node)
    {
        if (node == null) return 0;

        var left = GetHeight(node.left);
        var right = GetHeight(node.right);
        max = Math.Max(max, left + right + 1);

        return 1 + Math.Max(left, right);
    }
}
```
