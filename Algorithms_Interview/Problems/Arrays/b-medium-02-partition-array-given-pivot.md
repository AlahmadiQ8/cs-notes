---
tags:
  - fundamental
  - techniques/dutch-national-flag
---

# [Partition Array According to Given Pivot](https://leetcode.com/problems/partition-array-according-to-given-pivot/)

You are given an array of integers and an index x. Rearrange the array such that
all integers less than integer at X are on the left side and all that are
larger are on the right side:

a​​ = ​​[3,5,2,6,8,4,4,6,4,4,3]​​ and ​​i​​=​​5 ​​--> ​​result​​ = ​​[3,2,3,4,4,4,4,5,6,8,6]

## Alternative phrasing

Given an array with n objects colored red, white or blue, sort them in-place so that
objects of the same color are adjacent, with the colors in the order red, white and blue.

Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue
respectively.

| Complexity | Big O |
|------------|-------|
| Time       | O(n)  |
| Space      | O(1)  |

```csharp
public void PivotArray(int[] nums, int pivot)
{
    var lo = 0;
    var i = 0;
    var hi = nums.Length - 1;
    while (i < hi)
    {
        if (nums[i] < pivot)
            nums.Swap(i++, lo++);
        else if (nums[i] > pivot)
            nums.Swap(i, hi--);
        else
            i++;
    }
}

public static class ArrayExtensions
{
    public static void Swap<T>(this T[] arr, int i, int j)
    {
        (arr[i], arr[j]) = (arr[j], arr[i]);
    }

    public static string AsString<T>(this IEnumerable<T> arr)
    {
        return string.Join(", ", arr.Select(s => s.ToString()));
    }
}
```

## Variation: Preserve Order

We'd have to use extra space O(n).

```csharp
public class Solution {
    public int[] PivotArray(int[] nums, int pivot) {
        var newNums = new int[nums.Length];
        var i = 0;
        foreach (var n in nums)
            if (n < pivot)
                newNums[i++] = n;
        foreach (var n in nums)
            if (n == pivot)
                newNums[i++] = n;
        foreach (var n in nums)
            if (n > pivot)
                newNums[i++] = n;
        i = 0;
        foreach (var n in newNums)
            nums[i++] = n;

        return nums;
    }
}
```
