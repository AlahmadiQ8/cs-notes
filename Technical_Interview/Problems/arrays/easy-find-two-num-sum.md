2 Sum Problem: Given a sorted array of integers, find two numbers in the array 
that sum to an integer X.For example, given a=[1,2,3,5,6,7] and X=11, the answer 
would be 5 and 6, which sum to 11

## Technique

- Two Pointers

## Notes

- Are there duplicates? 
- What to return if there is more than one answer? 

# Solution

```javascript 
function findSub(arr, t) {
  if (!arr || arr.length <= 1) return [-1, -1]

  let s = 0
  let e = arr.length - 1
  while(s < arr.length && e >= 0) {
    const sum = arr[s] + arr[e]
    if (sum === t) return [s, e]
    if (sum > t) e--
    if (sum < t) s++
  }
  return [-1, -1]
}
findSub([-10, 1, 2, 3, 4, 5, 6], 6)    //​​​​​[ 1, 5 ]​​​​​
findSub([-10, 1, 2, 3, 4, 5, 6], -4)   //​​​​​[ 0, 6 ]​​​​​
findSub([-10, 1, 2, 3, 4, 5, 6], 7)    //​​​​​[ 1, 6 ]​​​​​
```
