## [Linked List Cycle II](https://leetcode.com/problems/linked-list-cycle-ii/description/)

```
Given a Linked List with a cycle, find the node where the cycle begins`
```

## Technique

- Slow and fast pointer

## Solution

```
As done in the video above, detect a cycle, then find the length of
the cycle. Once you know the length of the cycle, it makes things easy.
Let's say the length is L. Simply take 2 pointers A and B, both at the
start of the list. Move A forward by the L nodes. Now, advance both
pointers by 1 until they meet. The node at which they meet will be the
start of the cycle.
```

```csharp

// O(n) time, O(1) space
public class Solution
{
    public ListNode DetectCycle(ListNode head)
    {
        var nodeInCycle = FindNodeInCycle(head);
        if (nodeInCycle == null)
            return null;
        var cycleLength = FindCycleLength(nodeInCycle);
        var a = head;
        var b = head;
        for (var i = 0; i < cycleLength; i++)
            b = b.next;
        while (a != b)
        {
            a = a.next;
            b = b.next;
        }

        return a;
    }

    ListNode FindNodeInCycle(ListNode head)
    {
        if (head == null || head.next == null) return null;
        var slow = head;
        var fast = head.next;
        while (slow != fast)
        {
            if (fast == null || fast.next == null)
                return null;
            slow = slow.next;
            fast = fast.next.next;
        }

        return slow;
    }

    int FindCycleLength(ListNode node)
    {
        var i = 1;
        var curr = node.next;
        while (curr != node)
        {
            i++;
            curr = curr.next;
        }

        return i;
    }
}

// O(n) time O(n) space
public class Solution
{
    public ListNode DetectCycle(ListNode head)
    {
        var set = new HashSet<ListNode>();
        var cur = head;
        while (cur != null)
        {
            if (set.Contains(cur))
                return cur;
            set.Add(cur);
            cur = cur.next;
        }

        return null;
    }
}
```
