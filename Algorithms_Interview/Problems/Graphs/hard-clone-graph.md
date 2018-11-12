## Problem

```
Clone a graph
```

## Technique

- keep a hash to track copied/visited nodes

```javascript
function clone(node) {
  return new Node(node.value)
}

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
}

function cloneGraph(graph) {
  if (!graph || !graph.nodes || graph.nodes.length == 0) return null

  const hash = new Map()
  const copyGraph = new Graph()

  // set all nodes unvisited
  for (const node of graph.nodes) {
    node.state = "unvisited"
  }

  for (const node of graph.nodes) {
    if (node.state == "unvisited") {
      cloneNode(node, copyGraph, hash)
    }
  }

  return copyGraph
}

function cloneNode(node, copyGraph, hash) {
  if (!node) return

  node.state = "visiting"
  let copy = hash.get(node.value)
  if (!copy) {
    copy = clone(node)
    hash.set(node.value, copy)
    copyGraph.nodes.push(copy)
  }

  for (const nei of node.neighbors) {
    let neiCopy = hash.get(nei.value)
    if (!neiCopy) {
      neiCopy = clone(nei)
      hash.set(nei.value, neiCopy)
      copyGraph.nodes.push(neiCopy)
    }
    copy.neighbors.push(neiCopy)

    if (nei.state == "unvisited") {
      cloneNode(nei, copyGraph, hash)
    }
  }

  node.state = "visited"
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

const graph = new Graph([node, node2, node3, node4, node5, node6])

const copiedGraph = cloneGraph(graph)
copiedGraph.nodes[0] //? $.neighbors.map(n => n.value) = [2, 3]
```
