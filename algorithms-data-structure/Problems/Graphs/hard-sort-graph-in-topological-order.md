## Problem

Sort a graph in topological order

## Technique

- Just travese via DFS and store retults in a stack

## Solution 

```javascript
class Node {
  constructor(value) {
    this.value = value 
    this.state = "unvisited"
    this.neighbors = []
  }
}

function topologicalSort(node, stack = []) {
  if (!node) return []
  
  node.state = "visiting" 
  stack.push(node.value)
  
  for (const nei of node.neighbors) {
    if (nei.state == "unvisited") {
      topologicalSort(nei, stack)
    }
  }
  
  node.state = 'visited'  
  return stack
}


const node = new Node(1)
node.neighbors[0] = new Node(2)
const node2 = node.neighbors[0]
node2.neighbors[0] = new Node(4)
const node4 = node2.neighbors[0]
node4.neighbors[0] = new Node(6)
const node6 = node4.neighbors[0]
node.neighbors[1] = new Node(3)
const node3 = node.neighbors[1]
node3.neighbors = [node4, new Node(5)]
const node5 = node3.neighbors[1]
node5.neighbors[0] = node6

topologicalSort(node) // ​​​​​[ 1, 2, 4, 6, 3, 5 ]​​​​​
```
