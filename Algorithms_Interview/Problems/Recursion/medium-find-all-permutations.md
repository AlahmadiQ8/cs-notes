# Problem

Find all permutartions of the array 

## Technique

- Auxiliary Buffer
- User hash set to mark which indexes are visited 

| Complexity | Big O                              |
| ---------- | ---------------------------------- |
| Time       | O(n^2)                             |
| Space      | O(X) for buffer size and recursion |

```javascript
function permutations(arr, buff, buffIndex, isInBuff) {
  // termination case
  if (buffIndex == arr.length) {
    console.log(buff)
    return
  }

  // find candidates to go into the current buffer index
  for (let i = 0; i < arr.length; i++) {
    // place item into buffer
    if (!isInBuff.has(i)) {
      buff[buffIndex] = arr[i]
      isInBuff.add(i)
      // recurse to next buffer index 
      permutations(arr, buff, buffIndex + 1, isInBuff)
      isInBuff.delete(i)
    }
  }
}
permutations([1, 2, 3], [], 0, new Set())
// [ 1, 2, 3 ]
// [ 1, 3, 2 ]
// [ 2, 1, 3 ]
// [ 2, 3, 1 ]
// [ 3, 1, 2 ]
// [ 3, 2, 1 ]
```

```csharp
public IList<IList<int>> Permute(int[] nums)
{
    if (nums.Length == 0) return new List<IList<int>>();
    var isInBuffer = new HashSet<int>();
    var result = new List<IList<int>>();
    var buffer = new int[nums.Length];
    Helper(0);
    return result;

    void Helper(int bufferIndex)
    {
        if (bufferIndex == nums.Length)
        {
            result.Add(buffer.ToArray());
            return;
        }

        for (var i = 0; i < nums.Length; i++)
        {
            if (isInBuffer.Contains(nums[i])) continue;

            buffer[bufferIndex] = nums[i];
            isInBuffer.Add(nums[i]);
            Helper(bufferIndex + 1);
            isInBuffer.Remove(nums[i]);
        }
    }
}
```
