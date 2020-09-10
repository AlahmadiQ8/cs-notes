## Problem

https://leetcode.com/problems/palindrome-linked-list/

```
Given a singly linked list, determine if it is a palindrome.

Example 1:

Input: 1->2
Output: false
Example 2:

Input: 1->2->2->1
Output: true
Follow up:
Could you do it in O(n) time and O(1) space?
```


## Technique

* Fast & Slow pointer with Stack

| Complexity | Big O |
|------------|-------|
| Time       | O(n)  |
| Space      | O(n)  |

## Solution

```csharp
public bool IsPalindrome(ListNode head)
{
    if (head == null) return true;
    var stack = new Stack<int>();
    
    var fast = head;
    var slow = head;
    while (fast != null && fast.next != null)
    {
        stack.Push(slow.val);
        slow = slow.next;
        fast = fast.next.next;
    }

    if (fast != null)
    {
        slow = slow.next;
    }
    
    while (slow != null)
    {
        if (slow.val != stack.Pop()) return false;
        slow = slow.next;
    }

    return true;
}

public override void Test()
{
    var foo = new[] {1, 1, 2, 1};
    var head = new ListNode(foo[0]);
    var cur = head;
    for (var i = 1; i < foo.Length; i++)
    {
        cur.next = new ListNode(foo[i]);
        cur = cur.next;
    }

    IsPalindrome(head).Should().BeFalse();
}
```
