## Problem

Given two binary trees, write a function to check if they are the same or not.

Two binary trees are considered the same if they are structurally identical and the nodes have the same value.

**Example 1**

```
Input:     1         1
          / \       / \
         2   3     2   3

        [1,2,3],   [1,2,3]

Output: true
```

**Example 2**

```
Input:     1         1
          /           \
         2             2

        [1,2],     [1,null,2]

Output: false
```

**Example 3**

```
Input:     1         1
          / \       / \
         2   1     1   2

        [1,2,1],   [1,1,2]

Output: false
```

## Technique

- Level Order Traversal
- Recursion

## Solution

**Level Order Traversal**

```javascript
function levelOrder(root) {
  const q = [root]
  let res = []
  while (q.length) {
    const subArr = []
    const len = q.length
    for (let i = 0; i < len; i++) {
      const cur = q.shift()
      cur ? subArr.push(cur.val) : subArr.push(null)
      if (!cur || (!cur.left && !cur.right)) continue
      cur.left ? q.push(cur.left) : q.push(null)
      cur.right ? q.push(cur.right) : q.push(null)
    }
    res = res.concat(subArr)
  }

  return res
}

function isSameTree(root1, root2) {
  const arr1 = root1 ? levelOrder(root1) : []
  const arr2 = root2 ? levelOrder(root2) : []
  if (arr1.length !== arr2.length) return false
  for (let i = 0; i < arr1.length; i++) {
    if (arr1[i] != arr2[i]) return false
  }
  return true
};
```

**Recursion**

```javascript
function isSameTree(p, q) {
  const traverse = (node1, node2) => {
    if (!node1 && !node2) {
      return true
    }
    if ((!node1 && node2) || (node1 && !node2) || node1.val !== node2.val) {
      return false
    }
    return (
      traverse(node1.left, node2.left) && traverse(node1.right, node2.right)
    )
  }
  return traverse(p, q)
}
```
