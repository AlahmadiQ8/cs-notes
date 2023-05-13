## Problem

https://leetcode.com/problems/swap-nodes-in-pairs/

```
Given a linked list, swap every two adjacent nodes and return its head.

You may not modify the values in the list's nodes. Only nodes itself may be changed.

Example 1:


Input: head = [1,2,3,4]
Output: [2,1,4,3]
Example 2:

Input: head = []
Output: []
Example 3:

Input: head = [1]
Output: [1]
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(N)  |
| Space      | O(1)  |

```csharp
public ListNode SwapPairs(ListNode head)
{
    if (head == null) return head;

    var dummy = new ListNode(-1);
    dummy.next = head;
    var prev = dummy;

    while (head != null && head.next != null)
    {
        var first = head;
        var second = head.next;

        prev.next = second;
        first.next = second.next;
        second.next = first;

        prev = first;
        head = first.next;
    }

    return dummy.next;
}
```
