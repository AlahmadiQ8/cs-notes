---
tags:
  - review
---

## [Sliding Window Maximum](https://leetcode.com/problems/sliding-window-maximum/)


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

* Queue with Max

# Solution

| Complexity | Big O                         |
| ---------- | ----------------------------- |
| Time       | O(n) worst time, O(1) average |
| Space      | O(k)                          |

* Use doubly linked list

```csharp
public class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        var result = new int[nums.Length - k + 1];
        var queue = new QueueWithMax();
        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            queue.Enqueue(num);
            if (queue.Count() < k)
                continue;
            result[i - k + 1] = queue.Max();
            queue.Dequeue();
        }

        return result;
    }


    class QueueWithMax
    {
        private readonly Queue<int> _queue = new();
        private LinkedList<int> _maxList = new();

        public void Enqueue(int value)
        {
            _queue.Enqueue(value);
            while (_maxList.Count > 0 && _maxList.Last.Value < value)
                _maxList.RemoveLast();
            _maxList.AddLast(value);
        }

        public int Dequeue()
        {
            var item = _queue.Dequeue();
            if (_maxList.Count > 0 && item == _maxList.First.Value)
                _maxList.RemoveFirst();
            return item;
        }

        public int Count()
        {
            return _queue.Count;
        }

        public int Max()
        {
            return _maxList.First.Value;
        }
    }
}
```
