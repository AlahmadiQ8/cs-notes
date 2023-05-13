## Problem

https://leetcode.com/problems/graph-valid-tree/

```
Given n nodes labeled from 0 to n-1 and a list of undirected edges (each edge is a pair of nodes), write a function to check whether these edges make up a valid tree.

Example 1:

Input: n = 5, and edges = [[0,1], [0,2], [0,3], [1,4]]
Output: true
Example 2:

Input: n = 5, and edges = [[0,1], [1,2], [2,3], [1,3], [1,4]]
Output: false
Note: you can assume that no duplicate edges will appear in edges. Since all edges are undirected, [0,1] is the same as [1,0] and thus will not appear together in edges.
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(N + E)  |
| Space      | O(N + E)  |

```csharp
public bool ValidTree(int n, int[][] edges) {
    if (edges.Length == 0) return n <= 1;
    
    var visited = new HashSet<int>();
    var al = new Dictionary<int, IList<int>>();
    foreach (var nodeEdge in edges) {
        if (!al.ContainsKey(nodeEdge[0])) al[nodeEdge[0]] = new List<int>();
        if (!al.ContainsKey(nodeEdge[1])) al[nodeEdge[1]] = new List<int>();
        al[nodeEdge[0]].Add(nodeEdge[1]);
        al[nodeEdge[1]].Add(nodeEdge[0]);
    }
    
    if (!CheckCycle(edges[0][0])) return false;
    
    return visited.Count == n;
    
    bool CheckCycle(int node) {
        if (visited.Contains(node)) return false;
        visited.Add(node);
        
        foreach (var nei in al[node]) {
            al[nei].Remove(node);
            if (!CheckCycle(nei)) return false;
        }

        return true;
    }
}
```

