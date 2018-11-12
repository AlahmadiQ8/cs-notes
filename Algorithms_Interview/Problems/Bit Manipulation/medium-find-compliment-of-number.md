## Problem 

```
Find​ ​the​ ​complement​ ​of​ ​an​ ​integer.​ ​A​ ​complement​ ​has​ ​the​ ​number's​ ​bits​ ​flipped,​ ​starting​ ​from the​ ​most​ ​significant​ ​1.​ ​For​ ​example,  

A​ ​=>​ ​00010001,​ ​Complement​ ​=>​ ​00001110 
A​ ​=>​ ​00000111,​ ​Complement​ ​=>​ ​00000000 
```

## Solution 

```javascript
function complement(num) {
  const mask = (1 << (Math.log2(num) + 1)) - 1
}
```
