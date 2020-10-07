## Problem 

Print all subsets of an array 

# Technique 

- Auxiliary Buffer

| Complexity | Big O                              |
| ---------- | ---------------------------------- |
| Time       | O(n^2)                             |
| Space      | O(X) for buffer size and recursion |

```javascript
function allSets(arr, buff, buffIndex, startIndex) {
  // termination case
  if (startIndex >= arr.length) return 

  // find candidates to go into the current buffer index
  for (let i = startIndex; i < arr.length; i++) {
    // place item into buffer
    buff[buffIndex] = arr[i]
    console.log(buff.slice(0, buffIndex + 1))

    // recurse to next buffer index 
    allSets(arr, buff, buffIndex + 1, i + 1)
  }
}

allSets([1, 2, 3], [], 0, 0)
// [ 1 ] 
// [ 1, 2 ] 
// [ 1, 2, 3 ] 
// [ 1, 3 ] 
// [ 2 ] 
// [ 2, 3 ] 
// [ 3 ]
```


```csharp
public IList<IList<int>> Subsets(int[] nums)
{
    var result = new List<IList<int>>();
    Backtrack(0, new List<int>());
    return result;

    void Backtrack(int startIndex, List<int> set)
    {
        result.Add(set);
        if (startIndex == nums.Length) return;

        for (var i = startIndex; i < nums.Length; i++)
        {
            set.Add(nums[i]);
            Backtrack(i + 1, set.ToList());
            set.RemoveAt(set.Count - 1);
        }
    }
}
```
