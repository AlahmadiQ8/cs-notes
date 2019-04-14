# Problem

Given an array of integers, find the highest product you can get from three of
the integers.

# Solution (Optimal - O(n) time - O(1) space)

```javascript
function highestProductOf3(arr) {
  if (arr.length < 3) {
    throw new Error('Less than 3 items!');
  }

  let highest = Math.max(arr[0], arr[1]);
  let lowest = Math.min(arr[0], arr[1]);

  let highestProductOf2 = arr[0] * arr[1];
  let lowestProductOf2 = arr[0] * arr[1];

  let highestProductOf3 = arr[0] * arr[1] * arr[2];

  // Walk through items, starting at index 2
  for (let i = 2; i < arr.length; i++) {
    highestProductOf3 = Math.max(
      highestProductOf3,
      arr[i] * highestProductOf2,
      arr[i] * lowestProductOf2
    );

    highestProductOf2 = Math.max(
      highestProductOf2,
      arr[i] * highest,
      arr[i] * lowest
    );

    lowestProductOf2 = Math.min(
      lowestProductOf2,
      arr[i] * highest,
      arr[i] * lowest
    );

    highest = Math.max(highest, arr[i]);
    lowest = Math.min(lowest, arr[i]);
  }

  return highestProductOf3;
}
```

# Solution (Brute force recursion)

```javascript
function highestProductOf3V1(arrayOfInts) {
  if (arrayOfInts.length < 3) throw Error('');
  let maxProduct = Number.NEGATIVE_INFINITY;
  helper();
  return maxProduct;
  function helper(
    buffer = Array.from(3).fill(null),
    startIndex = 0,
    bufferIndex = 0
  ) {
    if (bufferIndex == 3) {
      const product = buffer
        .slice(0, bufferIndex)
        .reduce((acc, val) => acc * val);
      maxProduct = Math.max(maxProduct, product);
      return;
    }
    if (startIndex >= arrayOfInts.length) return;

    for (let i = startIndex; i < arrayOfInts.length; i++) {
      buffer[bufferIndex] = arrayOfInts[i];
      helper(buffer, i + 1, bufferIndex + 1);
    }
  }
}
```

