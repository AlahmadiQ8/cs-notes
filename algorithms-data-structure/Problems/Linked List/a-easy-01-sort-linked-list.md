## Problem

```
You are given a Linked List with nodes that have values 0, 1 or 2. Sort
the linked list.

Similar Problem, rearrange, linked list by odd numbers first then even
ones
```

```csharp
ListNode? Sort(ListNode? head)
{
    if (head == null) return null;

    ListNode? list0 = null;
    ListNode? list1 = null;
    ListNode? list2 = null;

    var cur = head;
    while (cur != null)
    {
        switch (cur.val)
        {
            case 0:
                list0 = AddLast(list0, cur);
                break;
            case 1:
                list1 = AddLast(list1, cur);
                break;
            case 2:
                list2 = AddLast(list2, cur);
                break;
        }

        var prev = cur;
        cur = cur.next;
        prev.next = null;
    }


    ListNode? result = null;
    if (list0 != null)
        result = AddLast(result, list0);
    if (list1 != null)
        result = AddLast(result, list1);
    if (list2 != null)
        result = AddLast(result, list2);

    return result;
}

ListNode? AddLast(ListNode? head, ListNode? node)
{
    if (node == null) return head;
    if (head == null) return node;
    var cur = head;
    while (cur.next != null) cur = cur.next;
    cur.next = node;
    return head;
}

class ListNode
{
    public int val;
    public ListNode? next;

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}
```
