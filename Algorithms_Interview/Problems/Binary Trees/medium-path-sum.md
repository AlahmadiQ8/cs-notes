## Problem 

Print all paths equal to given sum

## Solution 

```javascript
function sumPath(node, V) {
  let arr = []

  function helper(node, sum, path=[], level=0) {
    if (!node) return 
    path[level] = node.val

    let t = 0
    for (let i = level; i >= 0; i--) {
      t += path[i]
      if (t == sum) {
        console.log(path.slice(i, level + 1))
      }
    }

    helper(node.left, sum, path, level + 1)
    helper(node.right, sum, path, level + 1)
  }

  helper(node, V)
}

//       4
//     /  \
//   2      6
//  / \    / \
// 1   3   5   7

sumPath(root, 5) // [2, 3], [5]
```
