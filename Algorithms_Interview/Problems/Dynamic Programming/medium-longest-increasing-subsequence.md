https://leetcode.com/problems/longest-increasing-subsequence/


```javascript
const expect = require('chai').expect;

function maxSequence(arr) {
  let maxRef = 1;
  helper(arr, arr.length);
  return maxRef;

  function helper(arr, len) {
    if (len == 1) return 1;

    let maxEndingHere = 1;

    for (let i = 1; i < len; i++) {
      const res = helper(arr, i);
      if (arr[i - 1] < arr[len - 1] && res + 1 > maxEndingHere) {
        maxEndingHere = res + 1;
      }
    }

    if (maxRef < maxEndingHere) {
      maxRef = maxEndingHere;
    }

    return maxEndingHere;
  }
}

function maxSequence(arr) {
  const maxEndings = [...arr].fill(1);
  for (let i = 1; i < maxEndings.length; i++) {
    const cur = maxEndings[i]
    for (let j = 0; j < i; j++) {
      if (arr[j] < arr[i] && maxEndings[j] + 1 > maxEndings[i]) {
        maxEndings[i] = maxEndings[j] + 1
      }
    }
  }
  return Math.max(...maxEndings)
}

expect(maxSequence([3, 1])).to.eq(1);
expect(maxSequence([3, 10, 2, 1, 20])).to.eq(3);
expect(maxSequence([50, 3, 10, 7, 40, 80])).to.eq(4);
expect(maxSequence([1, 2, 1, 4, 5])).to.eq(4);
```

```csharp
public int LengthOfLIS(int[] nums)
{
    if (nums.Length == 0) return 0;

    var longest = new int[nums.Length];
    var result = 1;

    for (var i = 0; i < nums.Length; i++)
    {
        longest[i] = 1;
        for (var j = 0; j < i; j++)
        {
            if (nums[i] > nums[j])
                longest[i] = Math.Max(longest[i], longest[j] + 1);
        }

        result = Math.Max(result, longest[i]);
    }

    return result;
}
```
