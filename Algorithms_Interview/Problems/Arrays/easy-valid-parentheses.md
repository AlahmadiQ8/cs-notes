## Problem

Given a string containing just the characters '(', ')', '{', '}', '[' and ']',
determine if the input string is valid.

An input string is valid if:

1. Open brackets must be closed by the same type of brackets.
2. Open brackets must be closed in the correct order.

Note that an empty string is also considered valid.

**Example 1:**

```
Input: "()"
Output: true
```

**Example 2:**

```
Input: "()[]{}"
Output: true
```

**Example 3:**

```
Input: "(]"
Output: false
```

**Example 4:**

```
Input: "([)]"
Output: false
```

**Example 5:**

```
Input: "{[]}"
Output: true
```

## Solution

```csharp
private HashSet<char> _openers = new HashSet<char>(new[] {'(', '[', '{'});

private char GetMatchingOpener(char closer)
{
   return closer switch
   {
       ')' => '(',
       '}' => '{',
       ']' => '['
   };
}

public bool IsValid(string s)
{
   var stack = new Stack<char>();
   foreach (var c in s)
   {
       if (_openers.Contains(c)) stack.Push(c);
       else if (stack.Count > 0 && stack.Pop() != GetMatchingOpener(c)) return false;
   }

   return stack.Count == 0;
}
```
