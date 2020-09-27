## Problem 

https://leetcode.com/problems/balanced-binary-tree/

```
Given​ ​a​ ​binary​ ​tree,​ ​determine​ ​if​ ​it​ ​is​ ​balanced
```

## Solution I (height comparison)

```javascript
function isBalanced(node) {
  if (!node) return true
  return isBalancedHelper(node) > -1
}

function isBalancedHelper(node) {
  if (!node) return 0

  const leftHeight = isBalancedHelper(node.left)
  const rightHeight = isBalancedHelper(node.right)

  if (leftHeight == -1 || rightHeight == -1) return -1

  if (Math.abs(rightHeight - leftHeight) > 1) return -1

  return Math.max(leftHeight, rightHeight) + 1 
}
```

## Solution I (DFS)

```javascript
function isBalanced(treeRoot) {
  const depthSet = new Set();
  return isBalancedHelper(treeRoot);

  function isBalancedHelper(node, depth = 0) {
    if (!node) return true;

    if (!node.left && !node.right) {
      if (!depthSet.has(depth)) {
        depthSet.add(depth);
        const depthSetValues = Array.from(depthSet);
        if (
          depthSet.size > 2 ||
          (depthSet.size === 2 &&
            Math.abs(depthSetValues[0] - depthSetValues[1]) > 1)
        ) {
          return false;
        }
      }
    } else {
      return (
        isBalancedHelper(node.left, 1 + depth) &&
        isBalancedHelper(node.right, 1 + depth)
      );
    }
    return true;
  }
}

class BinaryTreeNode {
  constructor(value) {
    this.value = value;
    this.left = null;
    this.right = null;
  }

  insertLeft(value) {
    this.left = new BinaryTreeNode(value);
    return this.left;
  }

  insertRight(value) {
    this.right = new BinaryTreeNode(value);
    return this.right;
  }
}

// Tests

let desc = 'full tree';
let treeRoot = new BinaryTreeNode(5);
let leftNode = treeRoot.insertLeft(8);
leftNode.insertLeft(1);
leftNode.insertRight(2);
let rightNode = treeRoot.insertRight(6);
rightNode.insertLeft(3);
rightNode.insertRight(4);
assertEquals(isBalanced(treeRoot), true, desc);

desc = 'both leaves at the same depth';
treeRoot = new BinaryTreeNode(3);
leftNode = treeRoot.insertLeft(4);
leftNode.insertLeft(1);
rightNode = treeRoot.insertRight(6);
rightNode.insertRight(9);
assertEquals(isBalanced(treeRoot), true, desc);

desc = 'leaf heights differ by one';
treeRoot = new BinaryTreeNode(6);
leftNode = treeRoot.insertLeft(1);
rightNode = treeRoot.insertRight(0);
rightNode.insertRight(7);
assertEquals(isBalanced(treeRoot), true, desc);

desc = 'leaf heights differ by two';
treeRoot = new BinaryTreeNode(6);
leftNode = treeRoot.insertLeft(1);
rightNode = treeRoot.insertRight(0);
rightNode.insertRight(7).insertRight(8);
assertEquals(isBalanced(treeRoot), false, desc);

desc = 'three leaves total';
treeRoot = new BinaryTreeNode(1);
leftNode = treeRoot.insertLeft(5);
rightNode = treeRoot.insertRight(9);
rightNode.insertLeft(8);
rightNode.insertRight(5);
assertEquals(isBalanced(treeRoot), true, desc);

desc = 'both subtrees superbalanced';
treeRoot = new BinaryTreeNode(1);
leftNode = treeRoot.insertLeft(5);
rightNode = treeRoot.insertRight(9);
rightNode.insertLeft(8).insertLeft(7);
rightNode.insertRight(5);
assertEquals(isBalanced(treeRoot), false, desc);

desc = 'only one node';
treeRoot = new BinaryTreeNode(1);
assertEquals(isBalanced(treeRoot), true, desc);

desc = 'linked list tree';
treeRoot = new BinaryTreeNode(1);
treeRoot
  .insertRight(2)
  .insertRight(3)
  .insertRight(4);
assertEquals(isBalanced(treeRoot), true, desc);

function assertEquals(a, b, desc) {
  if (a === b) {
    console.log(`${desc} ... PASS`);
  } else {
    console.log(`${desc} ... FAIL: ${a} != ${b}`);
  }
}

```


```csharp
public bool IsBalanced(TreeNode root) {
    if (root == null) return true;
    
    return IsBalancedHelper(root) != -1 ? true : false;
    
    int IsBalancedHelper(TreeNode node) {
        if (node == null) return 0;
        
        var left = IsBalancedHelper(node.left);
        var right = IsBalancedHelper(node.right);
        
        if (left == -1 || right == -1 || Math.Abs(left - right) > 1) return -1;
        
        return 1 + Math.Max(left, right);
    }
}
```
