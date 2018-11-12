## Problem 

```
Given​ ​a​ ​number,​ ​reverse​ ​the​ ​order​ ​of​ ​its​ ​bits.​ ​For​ ​example:

A​ ​=>​ ​11110000,​ ​Result​ ​=>​ ​00001111 
A​ ​=>​ ​01001101,​ ​Result​ ​=>​ ​10110010 
```

## Solution

- **Assumption:** The index of the last bit is 31 because integers have 32 bits

```javascript
function reverseBits(n) {
  let i = 0, j = 31
  let result = null
  while (i < j) {
    result = swapBits(n, i++, j++)
  }
  return result
}

function swapBits(n, i, j) {
  if (getBit(n, i) !== getBit(n, j)) {
    return n ^ ((1 << i) | (1 << j))
  }
}

function getBit(n, j) {
  return n >> j & 1
}
```
