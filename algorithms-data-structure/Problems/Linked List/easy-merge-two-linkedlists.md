## Problem 

## Solution

### Recursive

| Complexity | Big O    |
| ---------- | -------- |
| Time       | O(n + m) |
| Space      | O(n + m) |

```javascript
class Node {
  constructor(value) {
    this.value = value
    this.next = null
  }
}

function mergeTwoLists(node1, node2) {
  if (!node1) return node2
  if (!node2) return node1
  if (node1.value < node2.value) {
    node1.next = mergeTwoLists(node1.next, node2)
    return node1
  } else {
    node2.next = mergeTwoLists(node2.next, node1)
    return node2
  }
}

const node1 = generateList([0,4, 5, 6])
const node2 = generateList([1, 2, 3])
const head = mergeTwoLists(node1, node2)
printList(head) 
```

### Iterative

| Complexity | Big O    |
| ---------- | -------- |
| Time       | O(n + m) |
| Space      | O(1)     |

```javascript
class Node {
  constructor(value) {
    this.value = value
    this.next = null
  }
}

function mergeTwoLists(n1, n2) {
  if (!n1) return n2
  if (!n2) return n1
  const prehead = new Node(-1)
  let prev = prehead
  while (n1 && n2) {
    if (n1.value < n2.value) {
      prev.next = n1
      n1 = n1.next
    } else {
      prev.next = n2
      n2 = n2.next
    }
    prev = prev.next
  }
  // exactly one of l1 and l2 can be non-null at this point, so connect
  // the non-null list to the end of the merged list
  prev.next = !n1 ? n2 : n1
  return prehead.next
}

const node1 = generateList([0,4, 5, 6])
const node2 = generateList([1, 2, 3])
const head = mergeTwoLists(node1, node2)
printList(head) 
```
