## Problem 

```
Check if a string is rotation of another
```

## Solution

```typescript
function isRotation(a: string, b: string) : boolean { 
  if (a.length !== b.length) return false
  return (a + a).includes(b)
}

isRotation('abcdef', 'defabc') //?
```
