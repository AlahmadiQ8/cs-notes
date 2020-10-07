## Problem

https://leetcode.com/problems/validate-binary-search-tree/

```
Given a binary tree, determine if it is a valid binary search tree (BST).

Assume a BST is defined as follows:

The left subtree of a node contains only nodes with keys less than the node's key.
The right subtree of a node contains only nodes with keys greater than the node's key.
Both the left and right subtrees must also be binary search trees.

```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(N)  |
| Space      | O(N)  |

```csharp
public bool IsValidBST(TreeNode root)
{
    return Helper(root, null, null);
}

private bool Helper(TreeNode? node, int? min, int? max)
{
    if (node == null) return true;

    if (min != null && node.val <= min) return false;
    if (max != null && node.val >= max) return false;

    if (!Helper(node.left, min, node.val)) return false;
    if (!Helper(node.right, node.val, max)) return false;

    return true;
}
```
