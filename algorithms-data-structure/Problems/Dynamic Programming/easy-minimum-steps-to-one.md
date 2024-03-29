```javascript
const memo = new Map();
function minimumStepsToOne(num) {
  let divBy3 = Number.POSITIVE_INFINITY;
  let divBy2 = Number.POSITIVE_INFINITY;
  let substractOne = Number.POSITIVE_INFINITY;

  if (num <= 1) return 0;

  if (num % 3 === 0) {
    divBy3 = memo.has(num / 3)
      ? memo.get(num / 3)
      : minimumStepsToOne(num / 3);
    memo.set(num / 3, divBy3);
  }
  if (num % 2 === 0) {
    divBy2 = memo.has(num / 2)
      ? memo.get(num / 2)
      : minimumStepsToOne(num / 2);
    memo.set(num / 2, divBy2);
  }

  
  substractOne = memo.has(num - 1)
    ? memo.get(num - 1)
    : minimumStepsToOne(num - 1);
  memo.set(num - 1, substractOne);
  

  return Math.min(1 + divBy3, 1 + divBy2, 1 + substractOne);
}

minimumStepsToOne(5678)

expect(minimumStepsToOne(10)).to.eq(3);
expect(minimumStepsToOne(4)).to.eq(2); 
expect(minimumStepsToOne(5)).to.eq(3);
expect(minimumStepsToOne(5678)).to.eq(14); 
expect(minimumStepsToOne(10000)).to.eq(14); 
```
