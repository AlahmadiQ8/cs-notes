```javascript
const memo = new Map();
function minimumStepsToOne(num) {
  const divBy3 = num % 3 === 0;
  const divBy2 = num % 2 === 0;
  if (num <= 1) return 0;

  let min = Number.POSITIVE_INFINITY;

  if (divBy3) {
    const val = memo.has(num / 3)
      ? memo.get(num / 3)
      : minimumStepsToOne(num / 3);
    min = Math.min(min, 1 + val);
    memo.set(num / 3, val);
  }
  if (divBy2) {
    const val = memo.has(num / 2)
      ? memo.get(num / 2)
      : minimumStepsToOne(num / 2);
    min = Math.min(min, 1 + val);
    memo.set(num / 2, val);
  }

  const val = memo.has(num - 1)
    ? memo.get(num - 1)
    : minimumStepsToOne(num - 1);
  min = Math.min(min, 1 + val);
  memo.set(num - 1, val);
  return min;
}

expect(minimumStepsToOne(10)).to.eq(3);
expect(minimumStepsToOne(4)).to.eq(2); 
expect(minimumStepsToOne(5)).to.eq(3);
expect(minimumStepsToOne(5678)).to.eq(14); 
expect(minimumStepsToOne(10000)).to.eq(14); 
```
