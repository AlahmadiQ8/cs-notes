## Problem 

```
Given a graph, separate nodes into 2 groups, such that no 2 nodes in the same group have an edge.

Alternative Phrasing 1: 2 Color Problem: Given a graph, color its nodes with 2 colors - red and blue - such that no 2 neighbors have the same color.

Alternative Phrasing 2: Let's say you have invited a group of people to your house for a party. You make a graph where a node is a person and an edge between 2 people means that they know each other. You want to separate them into 2 groups such that in each group, no one knows each other. Determine if such a grouping is possible, and if so, make the 2 groups.
```

## Solution 

| Complexity | Big O    |
| ---------- | -------- |
| Time       | O(V + E) |
| Space      | O(V)     |

```javascript
class Node {
  constructor(value, dist = 0) {
    this.value = value
    this.neighbors = []
    this.state = "unvisited"
    this.dist = 0
  }
}

function bipartite(graph) {
  const group1 = []
  const group2 = [] 
  
  graph.setAllUnvisited()
  for (const node of graph.nodes) {
    if (node.state == "unvisited" && !bfs(node, group1, group2)) {
      throw new Error("Not a valid Graph") 
    }
  }
  return [group1, group2]
}

function bfs(node, even, odd) {
  node.state = "visiting" 
  node.level = 0
  const queue = [node]
  while (queue.length >= 0) {
    const cur = queue.unshift() 
    if (cur.level % 2 == 0) {
      even.push(cur.value)
    } else {
      odd.push(cur.value)
    }
    
    for (const nei of cur.neighbors) {
      if (nei.state == "unvisited") {
        queue.push(nei)
        nei.state = "visiting"
        nei.level = cur.level + 1
      } else if (nei.level == cur.level) {
        return false
      }
    }
    cur.state = "visited"
  }
}
```
