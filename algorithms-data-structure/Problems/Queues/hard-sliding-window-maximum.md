## Problem

https://leetcode.com/problems/sliding-window-maximum/

```
Given an array nums, there is a sliding window of size k which is moving from the very left of the array to the very right. You can only see the k numbers in the window. Each time the sliding window moves right by one position. Return the max sliding window.

Follow up:
Could you solve it in linear time?

Example:

Input: nums = [1,3,-1,-3,5,3,6,7], and k = 3
Output: [3,3,5,5,6,7] 
Explanation: 

Window position                Max
---------------               -----
[1  3  -1] -3  5  3  6  7       3
 1 [3  -1  -3] 5  3  6  7       3
 1  3 [-1  -3  5] 3  6  7       5
 1  3  -1 [-3  5  3] 6  7       5
 1  3  -1  -3 [5  3  6] 7       6
 1  3  -1  -3  5 [3  6  7]      7
```



## Technique


## Solution I 

* Keep track of max

| Complexity | Big O                         |
| ---------- | ----------------------------- |
| Time       | O(n) worst time, O(1) average |
| Space      | O(1)                          |

```csharp
public int[] MaxSlidingWindow(int[] nums, int k)
{
    if (nums.Length == 1) return new int[] {nums[0]};
    var max = int.MinValue;
    var maxIndex = -1;
    var result = new int[nums.Length - k + 1];
    for (var i = 0; i < k; i++)
    {
        if (nums[i] > max)
        {
            max = nums[i];
            maxIndex = i;
        }
    }

    result[0] = max;
    for (var i = k; i < nums.Length; i++)
    {
        if (maxIndex < i - k + 1)
        {
            max = int.MinValue;
            for (var j = i - k + 1; j <= i; j++)
            {
                if (nums[j] > max)
                {
                    max = nums[j];
                    maxIndex = j;
                }
            }
        }

        if (nums[i] > max)
        {
            max = nums[i];
            maxIndex = i;
        }

        result[i - k + 1] = max;
    }

    return result;
}
```


# Solution II

| Complexity | Big O                         |
| ---------- | ----------------------------- |
| Time       | O(n) worst time, O(1) average |
| Space      | O(k)                          |

* Use doubly linked list

```csharp
public int[] MaxSlidingWindow(int[] nums, int k)
{
    if (nums.Length == 0) return new int[0];
    if (k == 1) return nums;
    var max = new LinkedList<int>();
    var queue = new int[nums.Length - k + 1];

    for (var i = 0; i < k; i++)
    {
        if (max.Count > 0 && max.First() == i - k) max.RemoveFirst();
        while (max.Count > 0 && nums[i] > nums[max.Last()]) max.RemoveLast();
        max.AddLast(i);
    }

    queue[0] = nums[max.First()];

    for (var i = k; i < nums.Length; i++)
    {
        if (max.Count > 0 && max.First() == i - k) max.RemoveFirst();
        while (max.Count > 0 && nums[i] > nums[max.Last()]) max.RemoveLast();
        max.AddLast(i);
        queue[i - k + 1] = nums[max.First()];
    }

    return queue;
}
```
