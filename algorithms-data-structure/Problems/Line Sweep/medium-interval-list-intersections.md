## Problem

https://leetcode.com/problems/interval-list-intersections/

```
Given two lists of closed intervals, each list of intervals is pairwise disjoint and in sorted order.

Return the intersection of these two interval lists.

(Formally, a closed interval [a, b] (with a <= b) denotes the set of real numbers x with a <= x <= b.  The intersection of two closed intervals is a set of real numbers that is either empty, or can be represented as a closed interval.  For example, the intersection of [1, 3] and [2, 4] is [2, 3].)

Example 1:
Input: A = [[0,2],[5,10],[13,23],[24,25]], B = [[1,5],[8,12],[15,24],[25,26]]
Output: [[1,2],[5,5],[8,10],[15,23],[24,24],[25,25]]
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O( )  |
| Space      | O( )  |

```csharp
public int[][] IntervalIntersection(int[][] A, int[][] B)
{
    if (A.Length == 0 || B.Length == 0) return new int[][] { };

    var result = new List<int[]>();

    int i = 0, j = 0;

    while (i < A.Length && j < B.Length)
    {
        int lo = Math.Max(A[i][0], B[j][0]);
        int hi = Math.Min(A[i][1], B[j][1]);
        if (lo <= hi)
            result.Add(new[] {lo, hi});

        if (A[i][1] < B[j][1])
            i++;
        else
            j++;
    }

    return result.ToArray();
}

public override void Test()
{
    IntervalIntersection(new[] {new[] {1, 10}}, new[] {new[] {2, 5}, new[] {6, 10}}).Should().BeEquivalentTo(new []{2, 5}, new []{6, 10});
}
```
