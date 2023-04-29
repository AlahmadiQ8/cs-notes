# [Move Zeroes](https://leetcode.com/problems/move-zeroes/description/)

Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

Note that you must do this in-place without making a copy of the array.

```
Input: nums = [0,1,0,3,12]
Output: [1,3,12,0,0]
```

# Technique

- Dutch national flag algorithm

| Complexity | Big O |
|------------|-------|
| Time       | O(n)  |
| Space      | O(1)  |

```csharp
public class Solution {
    public void MoveZeroes(int[] nums) {
    var lo = 0;
    for (var i = 0; i < nums.Length; i++)
        if (nums[i] != 0)
            nums.Swap(i, lo++);
    }
}

public static class ArrayExtensions
{
    public static void Swap<T>(this T[] arr, int i, int j)
    {
        (arr[i], arr[j]) = (arr[j], arr[i]);
    }
}
```

## Variations

The following does not preserve the none-zero order

```csharp
public void MoveZerosStart(int[] arr)
{
    var lo = 0;
    for (var i = 0; i < arr.Length; i++)
        if (arr[i] == 0)
            arr.Swap(i, lo++);
}

public void MoveZerosEnd(int[] arr)
{
    var hi = arr.Length - 1;
    for (var i = arr.Length - 1; i >= 0; i--)
        if (arr[i] == 0)
            arr.Swap(i, hi--);
}
```

