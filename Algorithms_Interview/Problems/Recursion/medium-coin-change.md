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
    const result = buff.slice(0, buffIndex)
    const key = getKey(result)
    if (map.has(key)) return 
    map.set(key, result)
    return
  }
  if (buffIndex == target) return

  for (let i = 0; i < arr.length; i++) {
    buff[buffIndex] = arr[i]
    coins(arr, buff, buffIndex + 1, sumSofar + arr[i], target)
  }
}

function getKey(arr) {
  const copy = [...arr]
  copy.sort((a, b) => a - b)
  return copy.join('')
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


# Variation of the problem

```javascript
// DP
function changePossibilities(amountLeft, denominations) {
  const arr = Array.from({ length: amountLeft + 1 }).fill(0);
  arr[0] = 1;
  const minStep = Math.min(...denominations);
  for (const val of denominations) {
    for (let i = 0; i <= amountLeft; i += minStep) {
      if (i + val < arr.length) {
        arr[i + val] = arr[i] + arr[i + val];
      }
    }
  }

  return arr[amountLeft];
}


function changePossibilities(amountLeft, denominations) {
  if (denominations.length == 0) return 0;
  return helper(0, 0);

  function helper(currentIndex, sum = 0) {
    let count = 0;
    if (sum > amountLeft) return 0;
    if (sum === amountLeft) return 1;

    if (currentIndex === denominations.length) return 0;

    while (sum <= amountLeft) {
      count += helper(currentIndex + 1, sum);
      sum += denominations[currentIndex];
    }

    return count;
  }
}
```
