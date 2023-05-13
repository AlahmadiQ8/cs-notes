## Problem

https://leetcode.com/problems/happy-number/

Write an algorithm to determine if a number is "happy".

A happy number is a number defined by the following process: Starting with any
positive integer, replace the number by the sum of the squares of its digits,
and repeat the process until the number equals 1 (where it will stay), or it
loops endlessly in a cycle which does not include 1. Those numbers for which
this process ends in 1 are happy numbers.

Example:

```
Input: 19
Output: true
Explanation:
12 + 92 = 82
82 + 22 = 68
62 + 82 = 100
12 + 02 + 02 = 1
```

## Techniques

either using a hash set or a fast and slow pointers


## Solution 1 (hash set)

```javascript
function isHappy(n) {
  const visited = new Set();
  while (n !== 1 && !visited.has(n)) {
    visited.add(n)
    n = digitSquareSum(n)
  }
  return n === 1
};

function digitSquareSum(num) {
  let sum = 0;
  while (num >= 1) {
    const digit = Math.floor(num % 10)
    sum += digit * digit;
    num /= 10
  }
  return sum
}
```

## Solution 2 (fast & slow pointers)

```javascript
function isHappy(n) {
  let slow = n, fast = n;
  slow = digitSquareSum(slow)
  fast = digitSquareSum(fast)
  fast = digitSquareSum(fast)
  while (slow !== 1 && slow !== fast) {
    slow = digitSquareSum(slow)
    fast = digitSquareSum(fast)
    fast = digitSquareSum(fast)
  }
  return slow === 1
};

function digitSquareSum(num) {
  let sum = 0;
  while (num >= 1) {
    const digit = Math.floor(num % 10)
    sum += digit * digit;
    num /= 10
  }
  return sum
}
```

