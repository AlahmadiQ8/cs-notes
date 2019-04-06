# Problem 

You are given two **non-empty** linked lists representing two non-negative
integers. The digits are stored in **reverse order** and each of their nodes
contain a single digit. Add the two numbers and return it as a linked list.

You may assume the two numbers do not contain any leading zero, except the
number 0 itself.

**Example:**

```
Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
Output: 7 -> 0 -> 8
Explanation: 342 + 465 = 807
```

# Solution

```javascript
/**
 * @param {ListNode} l1
 * @param {ListNode} l2
 * @return {ListNode}
 */
function addTwoNumbers(l1, l2) {
  let curry = 0
  const dummy = new ListNode(null)
  let cur = dummy
  let curL1 = l1
  let curL2 = l2
  while (curL1 || curL2) {
    const val1 = curL1 ? curL1.val : 0
    const val2 = curL2 ? curL2.val : 0
    let value = val1 + val2 + curry
    curry = Math.floor(value / 10)
    value = value % 10
    cur.next = new ListNode(value)
    cur = cur.next
    curL1 = curL1 && curL1.next
    curL2 = curL2 && curL2.next 
  }
  if (curry) {
    cur.next = new ListNode(curry)
  }

  return dummy.next
};
```
