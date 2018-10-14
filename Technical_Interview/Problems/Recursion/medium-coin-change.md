Coin Change Problem: Given a set of coin denominations, print out the
different ways you can make a target amont. You can use as many coins
of each denomination as you like.

For example, if coins are [1, 2, 5] and the target is 5, output will be: 

```
[1,1,1,1,1]
[1,1,1,2]
[1,2,2]
[5]
```

## Technique

- Auxiliary Buffer
- Use map to eliminate duplicates

```javascript
const map = new Map()
function coins(arr, buff, buffIndex, sumSofar, target) {
  if (sumSofar === target) {
    map.set(buffIndex, buff.slice(0, buffIndex))
    return
  }
  if (buffIndex == target) return

  for (let i = 0; i < arr.length; i++) {
    buff[buffIndex] = arr[i]
    coins(arr, buff, buffIndex + 1, sumSofar + arr[i], target)
  }
}

coins([1, 2, 5], [], 0, 0, 5)
for (const val of map.values()) {
  console.log(val)
}
// ​​​​​[ 1, 1, 1, 1, 1 ]​​​​​
// ​​​​​[ 2, 1, 1, 1 ]​​​​​
// ​​​​​[ 2, 2, 1 ]​​​​​
// ​​​​​[ 5 ]​​​​​
```
