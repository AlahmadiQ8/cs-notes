## Problem

```
Given a graph, find if it has a cycle or not
```

## Solution

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

function hasCycle(graph) {
  if (!graph) throw new Error("Message")
  if (graph.nodes.length == 0) return true

  graph.setAllUnvisited()
  for (const node of graph.nodes) {
    if (node.state == 'unvisited' && detectCycle(node)) {
      return true
    }
  }

  return false 
}

function detectCycle(node) {
  node.state = 'visiting'

  for (const nei of node.neighbors) {
    if (nei.state == "visiting" || (nei.state == "unvisited" && detectCycle(nei))) {
      return true
    }
  }

  node.state = 'visited'
  return false
}
```
