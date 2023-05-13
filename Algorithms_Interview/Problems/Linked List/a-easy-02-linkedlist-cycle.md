## [Linked List Cycle](https://leetcode.com/problems/linked-list-cycle/description/)

```
Given a linked list, determine if it has a cycle in it.

To represent a cycle in the given linked list, we use an integer pos which represents the position (0-indexed) in the linked list where the tail connects to. If pos == -1, then there is no cycle in the linked list.
```

## Technique

* Fast and Slow Pointers

| Complexity | Big O |
|------------|-------|
| Time       | O(n)  |
| Space      | O(1)  |

## Solution

```csharp
public class Solution
{
    public bool HasCycle(ListNode head)
    {
        if (head == null) return false;

        var slow = head;
        var fast = head.next;
        while (slow != fast)
        {
            if (fast == null || fast.next == null)
                return false;

            fast = fast.next.next;
            slow = slow.next;
        }

        return true;
    }
}
```
