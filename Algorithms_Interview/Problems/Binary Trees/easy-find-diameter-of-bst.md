# Problem 

Given a binary tree, you need to compute the length of the diameter of the tree. The diameter of a binary tree is the length of the longest path between any two nodes in a tree. This path may or may not pass through the root.

**Example:**

Given a binary tree 
```
          1
         / \
        2   3
       / \     
      4   5   
``` 
Return 3, which is the length of the path [4,2,1,3] or [5,2,1,3].

**Note:** The length of path between two nodes is represented by the number of edges between them.

## Solution

```javascript
function TreeNode(val) {
  this.val = val;
  this.left = this.right = null;
}

var root = new TreeNode(1);
root.left = new TreeNode(2);
root.right = new TreeNode(3);
root.left.left = new TreeNode(4);
root.left.right = new TreeNode(5);

/**
 * @param {TreeNode} root
 * @returns {number}
 */
function diameterOfBinaryTree(root) {
  let longestPath = 0;
  function helper(node) {
    if (!node) return 0;
    const leftHeight = helper(node.left);
    const rightHeight = helper(node.right);
    const pathLength = leftHeight + rightHeight;
    if (pathLength > longestPath) longestPath = pathLength;
    return 1 + Math.max(leftHeight, rightHeight);
  }
  helper(root);
  return longestPath;
}

diameterOfBinaryTree(root); // 3

```
