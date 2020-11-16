# Problem

Given an array of integers, find the highest product you can get from three of
the integers.

# Solution (Optimal - O(n) time - O(1) space)

```csharp
public int MaximumProduct(int[] nums)
{
    if (nums.Length < 3) return -1;
    var hiProd2 = nums[0] * nums[1];
    var loProd2 = nums[0] * nums[1];
    var hi = Math.Max(nums[0], nums[1]);
    var lo = Math.Min(nums[0], nums[1]);
    var result = nums[0] * nums[1] * nums[2];

    for (var i = 2; i < nums.Length; i++)
    {
        var num = nums[i];
        result = Math.Max(result, Math.Max(num * hiProd2, num * loProd2));
        
        hiProd2 = Math.Max(hiProd2, Math.Max(num * hi, num * lo));
        loProd2 = Math.Min(loProd2, Math.Min(num * hi, num * lo));
        
        hi = Math.Max(hi, num);
        lo = Math.Min(lo, num);
    }

    return result;
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

