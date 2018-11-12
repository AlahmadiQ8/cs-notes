## Problem 

[link](https://leetcode.com/problems/remove-nth-node-from-end-of-list/description/)

Given a linked list, remove the n-th node from the end of list and return its head.

Example:

```
Given linked list: 1->2->3->4->5, and n = 2.

After removing the second node from the end, the linked list becomes 1->2->3->5.
```

**Note:**

Given n will always be valid.

## Solution

```javascript
function removeNthFromEnd(head, n) {
  if (head == null) return null
  
  let cur = head
  let right = head
  for (let i = 0; i < n; i++) {
    right = right.next
  }
  if (right == null) return head.next
  while(right.next != null) {
    right = right.next 
    cur = cur.next
  }
  cur.next = cur.next.next
  return head
}
```
