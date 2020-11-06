## Problem

```
Diameter of a Graph: Given a directed graph, find the length of the longest path in the graph
```

## Solution

* Strategy: Topological Sort

| Complexity | Big O |
|------------|-------|
| Time       | O(N)  |
| Space      | O(N)  |

```csharp
public int GraphDiameter(IEnumerable<Node> nodes, Node root)
{
    var visited = new HashSet<Node>();
    var longestAtPath = new Dictionary<Node, int>();
    foreach (var node in nodes)
        longestAtPath[node] = -1;

    longestAtPath[root] = 1;
    var diameter = int.MinValue;
    Dfs(root);
    return diameter;

    void Dfs(Node node)
    {
        visited.Add(node);
        diameter = Math.Max(diameter, longestAtPath[node]);

        foreach (var neighbor in node.neighbors)
            longestAtPath[neighbor] = Math.Max(longestAtPath[neighbor], longestAtPath[node] + 1);
        foreach (var neighbor in node.neighbors)
            if (!visited.Contains(neighbor))
                Dfs(neighbor);
    }
}

public override void Test()
{
    var n1 = new Node(1);
    var n2 = new Node(2);
    var n3 = new Node(3);
    var n4 = new Node(4);
    var n5 = new Node(5);
    var n6 = new Node(6);
    var n7 = new Node(7);
    var n9 = new Node(9);
    var n10 = new Node(10);

    n1.neighbors.Add(n2);
    n1.neighbors.Add(n5);
    n2.neighbors.Add(n3);
    n3.neighbors.Add(n4);
    n5.neighbors.Add(n10);
    n5.neighbors.Add(n6);
    n6.neighbors.Add(n7);
    n7.neighbors.Add(n4);
    n7.neighbors.Add(n9);

    var nodes = new[] {n1, n2, n3, n4, n5, n6, n7, n9, n10};
    GraphDiameter(nodes, n1).Should().Be(5);
}
```
