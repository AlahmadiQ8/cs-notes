# [Two Sum II - Input Array Is Sorted](https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/)

Given a sorted array of integers, find two numbers in the array
that sum to an integer X. For example, given a=[1,2,3,5,6,7] and X=11, the answer
would be 5 and 6, which sum to 11

## Technique

- Two Pointers

## Notes

- Are there duplicates?
- What to return if there is more than one answer?

```csharp
public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        var start = 0;
        var end = numbers.Length - 1;
        while (start < end) {
            var sum = numbers[start] + numbers[end];
            if (sum > target)
              end--;
            else if (sum < target)
              start ++;
            else
              return new[] { start + 1, end + 1 };
        }

        return null;
    }
}
```
