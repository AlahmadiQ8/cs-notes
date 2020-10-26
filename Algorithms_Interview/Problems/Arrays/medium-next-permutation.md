## Problem

```
Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.
If such an arrangement is not possible, it must rearrange it as the lowest possible order (i.e., sorted in ascending order).
The replacement must be in place and use only constant extra memory.

Example 1:

Input: nums = [1,2,3]
Output: [1,3,2]
Example 2:

Input: nums = [3,2,1]
Output: [1,2,3]
Example 3:

Input: nums = [1,1,5]
Output: [1,5,1]
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O( )  |
| Space      | O( )  |

```csharp
public void NextPermutation(int[] nums)
{
    if (nums.Length == 1) return;

    var i = nums.Length - 1;
    while (i - 1 >= 0 && nums[i] <= nums[i - 1])
        i--;
    if (i == 0)
    {
        Array.Reverse(nums);
        return;
    }

    var j = nums.Length - 1;
    while (nums[j] <= nums[i - 1]) j--;
    Swap(nums, j, i - 1);

    Array.Reverse(nums, i, nums.Length - i);
}

public void Swap(IList<int> arr, int i, int j)
{
    var buf = arr[i];
    arr[i] = arr[j];
    arr[j] = buf;
}
```
