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

```javascript
const open = {
  '(': ')',
  '{': '}',
  '[': ']',
}

function isValid(str) {
  if (str.length == 0) return true
  if (str.length % 2 != 0) return false
  const stack = [open[str[0]]]
  for (let i = 1; i < str.length; i++) {
    const top = stack[stack.length - 1]
    if (str[i] == top) {
      stack.pop()
    } else if (open[str[i]] != null) {
      stack.push(open[str[i]])
    } else  {
      return false
    }
  }
  return stack.length == 0
}

isValid('()[]{}') //?
isValid('((()))') //?
isValid('({[]})') //?
isValid('()') //?
isValid('') //?
isValid('') //?

isValid('{]') //?
isValid('[{]') //?
isValid('[(])') //?
```
