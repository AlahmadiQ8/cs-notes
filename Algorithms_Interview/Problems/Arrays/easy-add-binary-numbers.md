## Problem

Given two binary strings, return their sum (also a binary string).

The input strings are both non-empty and contains only characters 1 or 0.

Example 1:

```
Input: a = "11", b = "1"
Output: "100"
```

Example 2:

```
Input: a = "1010", b = "1011"
Output: "10101"
```

## Solution 

```typescript
function addBinary(a: string, b: string): string {
  const arrA = a.split("")
  const arrB = b.split("")
  const res = []
  let curry = 0
  while (arrA.length > 0 || arrB.length > 0) {
    const valA = arrA.pop() || 0
    const valB = arrB.pop() || 0
    let sum = Number(valA) + Number(valB) + curry
    curry = Math.floor(sum / 2)
    sum = sum % 2
    res.unshift(sum)
  }
  if (curry) res.unshift(curry)
  return res.join("")
}


addBinary("1", "11")      // 100
addBinary("1", "100")     // 101
addBinary("1001", "1011") // 10100
```
