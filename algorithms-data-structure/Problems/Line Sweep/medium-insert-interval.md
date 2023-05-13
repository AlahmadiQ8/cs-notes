## Problem

https://leetcode.com/problems/insert-interval/

```
Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).

You may assume that the intervals were initially sorted according to their start times.

 

Example 1:

Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
Output: [[1,5],[6,9]]
Example 2:

Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
Output: [[1,2],[3,10],[12,16]]
Explanation: Because the new interval [4,8] overlaps with [3,5],[6,7],[8,10].
Example 3:

Input: intervals = [], newInterval = [5,7]
Output: [[5,7]]
Example 4:

Input: intervals = [[1,5]], newInterval = [2,3]
Output: [[1,5]]
Example 5:

Input: intervals = [[1,5]], newInterval = [2,7]
Output: [[1,7]]
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(N)  |
| Space      | O(N)  |

```csharp
public int[][] Insert(int[][] intervals, int[] newInterval)
{
    if (intervals.Length == 0) return new[] {newInterval};

    var clone = new int[intervals.Length + 1][];

    var inserted = false;
    var j = 0;
    for (var i = 0; i < clone.Length; i++)
    {
        if (!inserted && (j == intervals.Length || newInterval[0] < intervals[j][0]))
        {
            clone[i++] = newInterval;
            inserted = true;
        }

        if (j < intervals.Length) clone[i] = intervals[j++];
    }

    var result = new List<int[]> {clone[0]};

    for (var i = 0; i < clone.Length; i++)
    {
        if (clone[i][0] <= result.Last()[1])
        {
            result.Last()[1] = Math.Max(result.Last()[1], clone[i][1]);
        }
        else
        {
            result.Add(clone[i]);
        }
    }

    return result.ToArray();
}
```
