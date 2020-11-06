## Problem

```
Given a graph and a target number t, find if t exists in the graph
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
}

function searchTarget(graph, target) {
  if (!graph || !graph.nodes || graph.nodes.length == 0) return false
  
  // set all nodes unvisited
  for (const node of graph.nodes) {
    node.state = "unvisited"
  }
  
  for (const node of graph.nodes) {
    if (node.state == "unvisited" && bfs(node, target)) {
      return true
    }
  }
  
  return false
}

function bfs(node, target) {
  if (!node) return 
  
  const queue = [node] 
  node.state = "visiting"
  
  while (queue.length !== 0) {
    const cur = queue.shift()
    if (cur.value == target) return true
    for (const nei of cur.neighbors) {
      if (nei.state == "unvisited") {
        nei.state = "visiting"
        queue.push(nei)
      }
    }
    cur.state = 'visited'
  }
  
  return false
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
expect(searchTarget(graph, 1)).to.be.true 
expect(searchTarget(graph, 2)).to.be.true 
expect(searchTarget(graph, 3)).to.be.true 
expect(searchTarget(graph, 4)).to.be.true 
expect(searchTarget(graph, 5)).to.be.true 
expect(searchTarget(graph, 6)).to.be.true 
expect(searchTarget(graph, 7)).to.be.false
```

```csharp
public void BreadthFirstTraversal(IList<Node> nodes) {
    var states = new Dictionary<Node, State>();

    foreach (var node in nodes) states[node] = State.Unvisited;

    foreach (var node in nodes) if (states[node] == State.Unvisited) Bfs(node);

    void Bfs(Node node) {
        var queue = new Queue<Node>();
        queue.Enqueue(node);

        while (queue.Count > 0) {
            var current = queue.Dequeue();
            states[node] = State.Visiting;
            Console.WriteLine(current.val);

            foreach (var nei in current.neighbors) {
                if (states[nei] == State.Unvisited) {
                    states[nei] = State.Visiting;
                    queue.Enqueue(nei);
                }
            }
            
            states[current] = State.Visited;
        }
    }
}
```
