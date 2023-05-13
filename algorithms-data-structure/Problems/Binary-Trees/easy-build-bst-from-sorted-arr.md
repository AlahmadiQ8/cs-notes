## Problem

Given a sorted array, build a balanced Binary Search Tree with the elements of
the array.

## Solution 

```csharp
public TreeNode SortedArrayToBST(int[] nums)
{
    return Helper(0, nums.Length - 1);

    TreeNode Helper(int start, int end)
    {
        if (start > end) return null;
        var mid = start + (end - start) / 2;
        var node = new TreeNode(nums[mid])
        {
            left = Helper(start, mid - 1),
            right = Helper(mid + 1, end)
        };
        return node;
    }
}
```
