## [Subsets](https://leetcode.com/problems/subsets/)

Given an integer array nums of unique elements, return all possible subsets (the power set).

The solution set must not contain duplicate subsets. Return the solution in any order.

```
Input: nums = [1,2,3]
Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]

Input: nums = [0]
Output: [[],[0]]
```

# Technique

- Auxiliary Buffer
- Backtracking

| Complexity | Big O                              |
| ---------- | ---------------------------------- |
| Time       | O(n^2)                             |
| Space      | O(X) for buffer size and recursion |

```csharp
public class Solution
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        var result = new List<IList<int>>();
        Combination(0, new LinkedList<int>());
        return result;

        void Combination(int startIndex, LinkedList<int> curr)
        {
            result.Add(curr.ToList());

            if (startIndex == nums.Length)
                return;

            for (var i = startIndex; i < nums.Length; i++)
            {
                curr.AddLast(nums[i]);
                Combination(i + 1, curr);
                curr.RemoveLast();
            }
        }
    }
}
```
