Given a sorted array that has duplicates, return the first occurance
of the target element

## Techniques

- Binary Search Tree

```csharp
public void FindFirstOccurence(int[] nums, int target) {
    var low = 0;
    var high = nums.Length - 1;
    while (low <= high)
    {
        var mid = low + (high - low) / 2;
        if (nums[mid] > target || (nums[mid] == target && mid > 0 && nums[mid - 1] == target))
            high = mid - 1;
        else if (nums[mid] < target)
            low = mid + 1;
        else
            return mid;
    }

    return -1;
}
```
