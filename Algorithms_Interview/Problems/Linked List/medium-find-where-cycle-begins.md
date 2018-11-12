## Problem

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
