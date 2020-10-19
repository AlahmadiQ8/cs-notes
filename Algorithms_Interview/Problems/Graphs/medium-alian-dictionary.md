## Problem

https://leetcode.com/problems/alien-dictionary/

```
There is a new alien language which uses the latin alphabet. However, the order among letters are unknown to you. You receive a list of non-empty words from the dictionary, where words are sorted lexicographically by the rules of this new language. Derive the order of letters in this language.

Example 1:

Input:
[
  "wrt",
  "wrf",
  "er",
  "ett",
  "rftt"
]

Output: "wertf"
Example 2:

Input:
[
  "z",
  "x"
]

Output: "zx"
Example 3:

Input:
[
  "z",
  "x",
  "z"
] 

Output: "" 

Explanation: The order is invalid, so return "".
Note:
- You may assume all letters are in lowercase.
- If the order is invalid, return an empty string.
- There may be multiple valid order of letters, return any one of them is fine.
```

## Solution

* Topological Order 

| Complexity | Big O |
|------------|-------|
| Time       | O( )  |
| Space      | O( )  |

```csharp
public string AlienOrder(string[] words)
{
    var adjList = new Dictionary<char, IList<char>>();
    var result = "";
    var state = new Dictionary<char, State>();

    // Step 0: add all letters to the graph
    foreach (var word in words)
    {
        foreach (var c in word)
        {
            adjList[c] = new List<char>();
            state[c] = State.Unvisited;
        }
    }

    // Step 1: add edges        
    for (var i = 0; i < words.Length - 1; i++)
    {
        var word1 = words[i];
        var word2 = words[i + 1];

        if (word1.Length > word2.Length && word1.StartsWith(word2))
            return "";

        for (var j = 0; j < Math.Min(word1.Length, word2.Length); j++)
        {
            if (word1[j] != word2[j])
            {
                adjList[word2[j]].Add(word1[j]);
                break;
            }
        }
    }

    // Step 2: Dfs
    foreach (var c in adjList.Keys)
        if (state[c] == State.Unvisited && !DepthFirst(c)) return "";
    
    return result;

    bool DepthFirst(char node)
    {
        state[node] = State.Visiting;

        foreach (var nei in adjList[node])
        {
            if (state[nei] == State.Visiting) return false;
            if (state[nei] == State.Unvisited && !DepthFirst(nei))
            {
                return false;
            }
        }

        result = result + node;
        state[node] = State.Visited;
        return true;
    }
}

private enum State
{
    Unvisited,
    Visited,
    Visiting
}
```
