## Problem

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
public bool HasCycle(ListNode head) {
    if (head == null) return false;
    var fast = head;
    var slow = head;
    while (fast != null) {
        fast = fast.next;
        if (fast == slow) return true;
        if (fast != null) {
            fast = fast.next;
            if (fast == slow) return true;
        }
        slow = slow.next;
    }    
    return false;
}
```
