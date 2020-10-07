# Problem 

https://leetcode.com/problems/symmetric-tree/

# Solution 

```javascript
/**
 * @param {TreeNode} root
 * @return {boolean}
 */
var isSymmetric = function(root) {
  if (!root) return true;
  const stack = [root, root];
  while (stack.length > 1) {
    const node1 = stack.pop();
    const node2 = stack.pop();
    if (!node1 && !node2) continue;
    if (!node1 || !node2) return false;
    if (node1.val !== node2.val) return false;
    stack.push(node1.left);
    stack.push(node2.right);
    stack.push(node1.right);
    stack.push(node2.left);
  }

  return true;
};

function isSymmetric(root) {
  return isMirror(root, root);
}

function isMirror(t1, t2) {
  if (t1 == null && t2 == null) return true;
  if (t1 == null || t2 == null) return false;
  return (
    t1.val == t2.val &&
    isMirror(t1.right, t2.left) &&
    isMirror(t1.left, t2.right)
  );
}
```

```csharp
public bool IsSymmetric(TreeNode root) {
    if (root == null) return true;
    
    return Helper(root, root);
}

private bool Helper(TreeNode left, TreeNode right) {
    if (left == null && right == null) return true;
    
    if (left == null || right == null || left.val != right.val) return false;
    
    return Helper(left.right, right.left) && Helper(right.left, left.right);
}
```
