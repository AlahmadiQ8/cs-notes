## Problem 

```
Given​ ​a​ ​binary​ ​tree,​ ​determine​ ​if​ ​it​ ​is​ ​balanced
```

## Solution 

```javascript
function isBalanced(node) {
  if (!node) return true
  return isBalancedHelper(node)
}

function isBalancedHelper(node) {
  if (!node) return 0

  const leftHeight = isBalancedHelper(node.left)
  const rightHeight = isBalancedHelper(node.right)

  if (leftHeight == -1 || rightHeight == -1) return false

  if (Math.abs(rightHeight - leftHeight) > 1) return -1

  return Math.max(leftHeight, rightHeight) + 1 
}
```

