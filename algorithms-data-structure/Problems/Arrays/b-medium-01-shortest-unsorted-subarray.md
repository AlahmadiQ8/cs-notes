## [Shortest Unsorted Continuous Subarray](https://leetcode.com/problems/shortest-unsorted-continuous-subarray/)

Given an array of integers, find the shortest subarray, that if sorted,
results in theentire array being sorted.

```
[1,2,4,5,3,5,6,7,9] --> [4,5,3] -
If you sort from indices 2 to 4, the entire array is sorted.

[1,3,5,2,6,4,7,8,9] --> [3,5,2,6,4] - indices 1 to 5
```

## Bruteforce

Sort Copy of array and compare with the original.

## Technicque

- Two pointers from each end
- Steps
  1. Find first dip and bump
  2. Find min and max between dip and bumb
  3. increase each end depending on min and mx

| Complexity | Big O |
| ---------- | ----- |
| Time       | O(n)  |
| Space      | O(1)  |

## Solution


```csharp
public class Solution {
    public int FindUnsortedSubarray(int[] nums) {
        int dip;
        for (dip = 0; dip < nums.Length - 1; dip++)
            if (nums[dip] > nums[dip + 1])
                break;

        if (dip == nums.Length - 1)
            return 0;

        int bump;
        for (bump = nums.Length - 1; bump > 0; bump--)
            if (nums[bump] < nums[bump - 1])
                break;

        var min = int.MaxValue;
        var max = int.MinValue;
        for (var i = dip; i <= bump; i++) {
            if (nums[i] < min)
                min = nums[i];
            if (nums[i] > max)
                max = nums[i];
        }

        while (dip - 1 >= 0 && nums[dip - 1] > min)
            dip--;
        while (bump + 1 < nums.Length && nums[bump + 1] < max)
            bump++;

        return bump - dip + 1;
    }
}
```
