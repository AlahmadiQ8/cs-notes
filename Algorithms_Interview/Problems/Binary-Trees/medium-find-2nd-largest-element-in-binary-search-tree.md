
## Problem 

Write a function to find the 2nd largest element in a binary search tree

# Technique

- Iterative approach

| Complexity | Big O            |
|------------|------------------|
| Time       | O(h) - O(log(n)) |
| Space      | O(1)             |

- Recursive approach

| Complexity | Big O            |
|------------|------------------|
| Time       | O(h) - O(log(n)) |
| Space      | O(h) - O(log(n)) |

## Solution I (Iterative)

Case 1: If largest element does not have left subtree

- return its parent

Case 2: If largest element has left subtree

- return right most of its its parents left node

```javascript
function findSecondLargest(treeRoot) {
  if (treeRoot == null) throw new Error();
  let cur = treeRoot;
  while (cur.right != null) {
    if (cur.right.right == null && cur.right.left == null) {
      return cur.value;
    }
    if (cur.right.right == null && cur.right.left != null) {
      cur = treeRoot.right.left;
      while (cur.right != null) {
        cur = cur.right;
      }
      return cur.value;
    }
    cur = cur.right;
  }

  return cur.left.value;
}
```

## Solution I (Recursive)

```javascript
function findSecondLargest(treeRoot) {
  if (!treeRoot || (!treeRoot.left && !treeRoot.right)) {
    throw new Error('Tree must have at least 2 nodes');
  }

  if (treeRoot.left && !treeRoot.right) {
    return findLargest(treeRoot.left);
  }

  if (treeRoot.right && !treeRoot.right.left && !treeRoot.right.right) {
    return treeRoot.value;
  }

  return findSecondLargest(treeRoot.right);
}
```
