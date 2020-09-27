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
    if (node.state == "unvisited" && dfs(node, target)) {
      return true
    }
  }
  
  return false
}

function dfs(node, target) {
  if (!node) return 
  
  node.state = "visiting" 
  if (node.value === target) return true
  
  for (const nei of node.neighbors) {
    if (nei.state === "unvisited" && dfs(nei, target)) {
      return true
    }
  }
  
  node.state ="visited"
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
public bool SearchTarget(IList<Node> nodes, int target)
{
    var status = new Dictionary<Node, State>();

    foreach (var node in nodes) status[node] = State.UnVisited;

    return nodes.Any(node => status[node] == State.UnVisited && Dfs(node));

    bool Dfs(Node node)
    {
        status[node] = State.Visiting;

        if (node.val == target) return true;

        foreach (var neighbor in node.neighbors)
        {
            if (status[neighbor] == State.UnVisited && Dfs(neighbor)) return true;
        }

        status[node] = State.Visited;
        return false;
    }
}

public override void Test()
{
    var root = new Node(1);
    var node2 = new Node(2);
    var node3 = new Node(3);
    var node4 = new Node(4);
    var node5 = new Node(5);
    var node6 = new Node(6);

    root.neighbors.Add(node2);
    root.neighbors.Add(node3);
    node2.neighbors.Add(node4);
    node3.neighbors.Add(node4);
    node3.neighbors.Add(node5);
    node4.neighbors.Add(node6);
    node5.neighbors.Add(node6);

    var nodes = new List<Node>() {root, node2, node3, node4, node5, node6};

    SearchTarget(nodes, 1).Should().BeTrue();
    SearchTarget(nodes, 2).Should().BeTrue();
    SearchTarget(nodes, 3).Should().BeTrue();
    SearchTarget(nodes, 4).Should().BeTrue();
    SearchTarget(nodes, 5).Should().BeTrue();
    SearchTarget(nodes, 6).Should().BeTrue();
    SearchTarget(nodes, 7).Should().BeFalse();
}
```
