## Problem

```
Given an array of meeting time intervals consisting of start and end times [[s1,e1],[s2,e2],...] (si < ei), find the minimum number of conference rooms required.

Example 1:

Input: [[0, 30],[5, 10],[15, 20]]
Output: 2
Example 2:

Input: [[7,10],[2,4]]
Output: 1
NOTE: input types have been changed on April 15, 2019. Please reset to default code definition to get new method signature.
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(NLog(n))  |
| Space      | O(N)  |

```csharp
public int MinMeetingRooms(int[][] intervals) {
    if (intervals.Length == 0) return 0;
    var points = new List<(int time, bool isStart)>();
    foreach (var interval in intervals) {
        var start = (interval[0], true);
        var end = (interval[1], false);
        points.Add(start);
        points.Add(end);
    }

    points.Sort((a, b) => {
        if (a.time == b.time)
        {
            if (!a.isStart && b.isStart) return -1;
            if (a.isStart && !b.isStart) return 1;
        }
        return a.time - b.time;
    });

    var maxRooms = 0;
    var count = 0;
    var last = 0;
    for (var i = 0; i < points.Count; i++) {
        if (points[i].isStart) count++;
        else count--;
        maxRooms = Math.Max(maxRooms, count);
    }

    return maxRooms;
}
```
