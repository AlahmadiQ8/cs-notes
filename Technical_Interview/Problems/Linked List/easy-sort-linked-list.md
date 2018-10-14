## Problem

```
You are given a Linked List with nodes that have values 0, 1 or 2. Sort 
the linked list.

Similar Problen, rearrange, linked list by odd numbers first then even 
ones
```

```javascript 
class Node {
  constructor(value) {
    this.value = value
    this.next = null
  }
}

function sortList(head) {
  if (head == null || head.next == null) return head
  let zeroNodes = null
  let oneNodes = null
  let twoNodes = null
  let cur = head,
    prev = null
  while (cur) {
    switch (cur.value) {
      case 0:
        zeroNodes = append(zeroNodes, cur)
        break
      case 1:
        oneNodes = append(oneNodes, cur)
        break
      case 2:
        twoNodes = append(twoNodes, cur)
    }
    prev = cur
    cur = cur.next
    prev.next = null
  }

  let zeroTail = zeroNodes
  if (zeroTail) {
    while (zeroTail.next) zeroTail = zeroTail.next
    zeroTail.next = oneNodes
  } else {
    zeroTail = oneNodes
  }

  let oneTail = oneNodes
  if (oneTail) {
    while (oneTail.next) oneTail = oneTail.next
    oneTail.next = twoNodes
  } else {
    oneTail = twoNodes
  }
  return zeroNodes
}

function append(head, node) {
  if (!head) return node
  let cur = head
  while (cur.next) {
    cur = cur.next
  }
  cur.next = node
  return head
}

const input = [1, 0, 2, 1, 2, 1]
let cur = null
let head = cur
for (const el of input) {
  if (!cur) {
    cur = new Node(el)
    head = cur
  } else {
    cur.next = new Node(el)
    cur = cur.next
  }
}
head = sortList(head)
cur = head
while (cur) {
  console.log(cur.value) // 0, 1, 1, 1, 2, 2
  cur = cur.next
}
```
