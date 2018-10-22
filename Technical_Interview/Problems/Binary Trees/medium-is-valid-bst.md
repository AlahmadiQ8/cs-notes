## Problem

```
Is BST: Given a Binary Tree, determine if it is a Binary Search Tree (BST)
```

## Solution

```typescript
interface MinMaxPair {
  min: number
  max: number
}

class Node<T> {
  value: T
  left: Node<T>
  right: Node<T>

  constructor(value) {
    this.value = value
  }
}

function isBst(node: Node<number>): MinMaxPair {
  if (!node) {
    return { min: Number.POSITIVE_INFINITY, max: Number.NEGATIVE_INFINITY }
  }

  const left = isBst(node.left)
  const right = isBst(node.right)

  if (left.max > node.value || right.min < node.value) {
    return null
  }

  const min = left != null ? left.min : node.value
  const max = right != null ? right.max : node.value
  return { min, max }
}
}
```
