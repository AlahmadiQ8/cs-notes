## Problem

https://leetcode.com/problems/binary-tree-paths/submissions/

Given a binary tree, return all root-to-leaf paths.

**Example**:

```
Input:

   1
 /   \
2     3
 \
  5

Output: ["1->2->5", "1->3"]

Explanation: All root-to-leaf paths are: 1->2->5, 1->3
```

## Technique

- DFS

## Solution

```javascript
function TreeNode(val) {
  this.val = val
  this.left = this.right = null
}

var root = new TreeNode(1)
root.left = new TreeNode(2)
root.right = new TreeNode(3)
root.left.right = new TreeNode(5)

function binaryTreePaths(root) {
  const result = []
  function helper(node, path = '') {
    if (!node) return
    path += node.val
    if (!node.left && !node.right) result.push(path)
    else path += '->'
    helper(node.left, path)
    helper(node.right, path)
  }
  helper(root)
  return result
}

binaryTreePaths(root) // ['1->2->5', '1->3']​​​​​
```

```csharp
public IList<string> BinaryTreePaths(TreeNode root)
{
    var result = new List<string>();
    PreOrderTraversal(root, "");
    return result;

    void PreOrderTraversal(TreeNode node, string path)
    {
        if (node == null) return;

        path += node.val.ToString();
        if (node.left == null && node.right == null)
            result.Add(path);
        else
            path += "->";

        PreOrderTraversal(node.left, path);
        PreOrderTraversal(node.right, path);
    }
}
```
