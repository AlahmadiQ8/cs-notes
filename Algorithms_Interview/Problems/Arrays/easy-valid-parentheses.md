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
const obj = {
  '{': '}',
  '[': ']',
  '(': ')'
}

function isValid(code) {
  const stack = []
  const openers = new Set(['(', '[', '{']);
  const closers = new Set([')', ']', '}']);

  for (const bracket of code) {
    if (openers.has(bracket)) {
      stack.push(obj[bracket])
    } else if (closers.has(bracket)) {
      if (!stack.length) return false
      const lastUnclosedOpener = stack.pop()
      if (lastUnclosedOpener !== bracket) return false
    } 
  }

  return stack.length === 0
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
