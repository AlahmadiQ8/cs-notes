## Problem

```
Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

For example, given n = 3, a solution set is:

[
  "((()))",
  "(()())",
  "(())()",
  "()(())",
  "()()()"
]
```

## Solution

| Complexity | Big O     |
| ---------- | --------- |
| Time       | Factorial |
| Space      | O(N)      |

```csharp
public IList<string> GenerateParenthesis(int n)
{
    var result = new List<string>();
    Dfs("(", 1, 0);
    return result;

    void Dfs(string buffer, int left, int right)
    {
        if (left == n && right == n)
        {
            result.Add(buffer);
            return;
        }

        if (left < n) Dfs(buffer + "(", left + 1, right);
        if (left > right) Dfs(buffer + ")", left, right + 1);
    }
}
```
