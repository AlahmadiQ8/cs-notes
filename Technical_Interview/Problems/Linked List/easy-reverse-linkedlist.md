## Problem

```
Reverse a singly linked list in O(1) space and O(n) time
```

## Solution

```java
public static Node reverse(Node head) {
  Node prev = null, curr = head;
  while (curr != null) {
    Node next = curr.getNext();
    curr.setNext(prev);
    prev = curr;
    curr = next;
  }
  return prev;
}
```
