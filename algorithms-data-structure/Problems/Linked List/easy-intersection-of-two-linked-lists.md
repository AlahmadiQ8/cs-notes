# Problem 

https://leetcode.com/problems/intersection-of-two-linked-lists/

# Solution 

```javascript
/**
 * @param {ListNode} headA
 * @param {ListNode} headB
 * @return {ListNode}
 */
function getIntersectionNode(headA, headB) {
  if (!headA || !headB) return null

  let pA = headA
  let pB = headB

  while (pA && pB && pA != pB) {
    pA = pA.next
    pB = pB.next
    if (pA == pB) return pA
    if (!pA) pA = headB
    if (!pB) pB = headA
  }

  return pA
};

/**
 * @param {ListNode} headA
 * @param {ListNode} headB
 * @return {ListNode}
 */
function getIntersectionNode(headA, headB) {
  let lengthA = getLength(headA)
  let lengthB = getLength(headB)
  if (lengthA == 0 || lengthB == 0) return null

  let startA = headA
  let startB = headB

  if (lengthA > lengthB) {
    for (let i = 0; i < lengthA - lengthB; i++) {
      startA = startA.next
    }
  }
  if (lengthA < lengthB) {
    for (let i = 0; i < lengthB - lengthA; i++) {
      startB = startB.next
    }
  }

  while (startA && startB) {
    if (startA == startB) return startA
    startA = startA.next
    startB = startB.next
  }

  return null
};

function getLength(head) {
  if (!head) return 0
  let count = 1
  let cur = head
  while (cur) {
    count++
    cur = cur.next 
  }
  return count
}
```
