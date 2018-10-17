## Problem 

```
Diameter of a Graph: Given a graph, find the length of the longest path among any two vertices
```

## Technique

- Tpological Order

## Solution 

- NOT WORKING 

```javascript
class Node {
  constructor(value) {
    this.value = value 
    this.state = "unvisited"
    this.neighbors = []
  }
}

class Graph {
  constructor(nodes = []) {
    this.nodes = nodes
  }
  
  setAllUnvisited() {
    for (const node of this.nodes) {
      node.state = "unvisited"
    }
  }
}

function findLongestPath(graph) {
  if (!graph || !graph.nodes || graph.nodes.length == 0) return false
  
  let longestPath = Number.NEGATIVE_INFINITY
  for (const node of graph.nodes) {
    graph.setAllUnvisited()
    longestPath = Math.maximum(longestPath, longestPathFromNode(node))
  }
  
  return longestPath
}

function longestPathFromNode(node) {
  const arr = topologicalSort(node)
  const dist = {}
  dist[node.value] = 1
  for (let i = 1; i < arr.length; i++) {
    dist[arr[i].value] = -1
  }
  
  let longest = 1
  for (let i = 0; i < arr.length; i) {
    const curNode = arr[i]
    if (const nei of curNode.neighbors) {
      dist[nei.value] = Math.max(dist[nei.value], dist[curNode.value] + 1)
      longest = Math.max(longest, dist[nei.value])
    }
  }
  return longest
}

function topologicalSort(node, stack = []) {
  if (!node) return []
  
  node.state = "visiting" 
  
  
  for (const nei of node.neighbors) {
    if (nei.state == "unvisited") {
      topologicalSort(nei, stack)
    }
  }
  
  node.state = 'visited' 
  stack.push(node) 
  return stack
}
```

