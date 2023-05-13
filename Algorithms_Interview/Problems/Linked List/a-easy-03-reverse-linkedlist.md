# [Reverse Linked List](https://leetcode.com/problems/reverse-linked-list/description/)

```
Reverse a singly linked list in O(1) space and O(n) time
```

## Solution

```csharp
public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        if (head == null || head.next == null)
            return head;

        ListNode prev = null;
        var curr = head;

        while (curr != null)
        {
            var nextTemp = curr.next;
            curr.next = prev;
            prev = curr;
            curr = nextTemp;
        }

        return prev;
    }
}
```
