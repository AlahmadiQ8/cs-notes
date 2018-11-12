## Problem 

```
​Multiply​ ​two​ ​numbers​ ​given​ ​as​ ​Big​ ​Integers. You​ ​are​ 
​given​ ​two​ ​arrays​ ​that​ ​represent​ ​Big​ ​Integers.​ ​That​ 
​means​ ​each​ ​element​ ​is​ ​a​ ​single digit​ ​number​ ​and​ ​index​ 
​0​ ​represents​ ​the​ ​lowest​ ​value.​ ​For​ ​example: 

a​ ​=​ ​[3,4,6,1]​ ​ ​ ​ ​ ​ ​ ​ ​ ​ ​ ​ ​ ​ ​(1643) 
b​ ​=​ ​[1,3,1]​ ​ ​ ​ ​ ​ ​ ​ ​ ​ ​ ​ ​ ​ ​ ​ ​ ​(131) 
Product​ ​=​ ​[3,3,2,5,1,2]​ ​ ​(215233) 
```

## Solution 

| Complexity | Big O |
| ---------- | ----- |
| Time       | O(n)  |
| Space      | O(n)  |

```javascript
function mult(a, b) {
  if (!a.length || !b.length) return

  let result = [0]

  for (let i = 0; i < a.length; i++) {
    let curry = 0
    let p = Array.from({ length: i }).fill(0)
    let j = 0
    while (j < b.length || curry != 0) {
      prod = a[i] * (j < b.length ? b[j] : 0) + curry
      curry = Math.floor(prod / 10)
      prod = prod % 10
      p.push(prod)
      j++
    }
    result = add(result, p)
  }
  return result
}

mult([4, 2, 3], [9, 1]) // [6, 5, 1, 6]

function add(num1, num2) {
  if (num1.length == 0 || num2.length == 0) return
  let larger = num1.length > num2.length ? num1 : num2
  let smaller = num1.length > num2.length ? num2 : num1

  const result = []
  let curry = 0
  for (let i = 0; i < larger.length; i++) {
    const curSmaller = i < smaller.length ? smaller[i] : 0
    let sum = larger[i] + curSmaller + curry
    curry = Math.floor(sum / 10)
    sum = sum % 10
    result.push(sum)
  }
  if (curry > 0) {
    result.push(curry)
  }
  return result
}
```
