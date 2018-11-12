## Problem 

```
Add​ ​two​ ​numbers​ ​given​ ​as​ ​Big​ ​Integers. 
 
You​ ​are​ ​given​ ​two​ ​arrays​ ​that​ ​represent​ ​Big​ ​Integers.​ 
​That​ ​means​ ​each​ ​element​ ​is​ ​a​ ​single digit​ ​number​ ​and​ 
​index​ ​0​ ​represents​ ​the​ ​lowest​ ​value.​ ​For​ ​example: 
a​ ​=​ ​[3,4,6,1]​ ​ ​ ​ ​(1643) 
b​ ​=​ ​[1,3,1]​ ​ ​ ​ ​ ​ ​ ​(131) 
Sum​ ​=​ ​[4,7,7,1]​ ​ ​(1774) 
```

## Solution

| Complexity | Big O |
| ---------- | ----- |
| Time       | O(n)  |
| Space      | O(n)  |

```javascript
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
add([9, 2, 3],[3, 2]) // [2, 5, 3]
add([9], [3]) // [2, 1]  
```
