## Problem

```
Given​ ​an​ ​integer,​ ​count​ ​the​ ​number​ ​of​ ​bits​ ​in​ ​its​ ​binary​ ​representation.​ ​For​ ​example,

given​ ​6​ ​ ​=>​ ​Binary:​ ​000110​ ​->​ ​Result​ ​=​ ​2
given​ ​22​ ​=>​ ​Binary:​ ​010110​ ​->​ ​Result​ ​=​ ​3

Note:​ ​The​ ​number​ ​of​ ​bits​ ​is​ ​same​ ​as​ ​the​ ​number​ ​of​ ​1's​ ​in​ ​its​ ​binary​ ​representation
```

## Technique

- instead of shifting all numbers and counting the ones, 
  use LSB technique instead

```javascript
function numBits(n) {
  let count = 0
  while (n != 0) {
    count++
    n = n & (n - 1)
  }
  return count
}
```
