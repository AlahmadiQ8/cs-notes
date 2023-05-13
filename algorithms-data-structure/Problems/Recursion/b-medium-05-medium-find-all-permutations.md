# [Permutations](https://leetcode.com/problems/permutations/description/)

Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.

```
Input: nums = [1,2,3]
Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
```

## Technique

- Auxiliary Buffer
- User hash set to mark which indexes are visited

| Complexity | Big O                              |
| ---------- | ---------------------------------- |
| Time       | O(n^2)                             |
| Space      | O(X) for buffer size and recursion |

```csharp
public class Solution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        var result = new List<IList<int>>();

        var visited = new bool[nums.Length];
        Permute(new LinkedList<int>());
        return result;

        void Permute(LinkedList<int> curr)
        {
            if (curr.Count == nums.Length)
            {
                result.Add(curr.ToList());
                return;
            }

            for (var i = 0; i < nums.Length; i++)
            {
                if (visited[i])
                    continue;

                curr.AddLast(nums[i]);
                visited[i] = true;

                Permute(curr);

                curr.RemoveLast();
                visited[i] = false;
            }
        }
    }
}
```
