# Problem 

https://leetcode.com/explore/interview/card/amazon/81/design/478/

Design and implement a data structure for Least Recently Used (LRU) cache. It
should support the following operations: get and put.

`get(key)` - Get the value (will always be positive) of the key if the key
exists in the cache, otherwise return -1. 

`put(key, value)` - Set or insert the value if the key is not already present.
When the cache reached its capacity, it should invalidate the least recently
used item before inserting a new item.

# Solution

```javascript
class LRUCache {
  constructor(capacity) {
    /** @private */
    this.capacity = capacity;
    this.map = new Map();
    this.list = new LinkedList();
  }

  /**
   * @param {number} key
   * @return {number}
   */
  get(key) {
    if (!this.map.has(key)) return -1;
    const node = this.map.get(key);
    const val = node.val;
    this.list.remove(node);
    this.list.append(key, val);
    this.map.set(key, this.list.tail)
    return val;
  }

  /**
   * @param {number} key
   * @param {number} value
   * @return {void}
   */
  put(key, value) {
    if (this.map.has(key)) {
      const node = this.map.get(key);
      this.list.remove(node);
    } else if (this.map.size === this.capacity) {
      const head = this.list.head;
      this.map.delete(head.key);
      this.list.remove(head);
    }
    this.list.append(key, value);
    this.map.set(key, this.list.tail);
  }
}

class LinkedList {
  constructor() {
    this.head = this.tail = null;
  }

  append(key, val) {
    if (!this.head) {
      this.head = new LinkedNode(key, val);
      this.tail = this.head;
    } else {
      const newNode = new LinkedNode(key, val);
      this.tail.next = newNode;
      newNode.prev = this.tail;
      this.tail = newNode;
    }
  }

  remove(node) {
    if (!node) return;
    if (this.head == node) {
      this.head = this.head.next;
      if (this.head) {
        this.head.prev = null;
      }
    } else if (this.tail == node) {
      const prev = this.tail.prev;
      prev.next = null;
      this.tail.prev = null;
      this.tail = prev;
    } else {
      const prev = node.prev;
      const next = node.next;
      if (prev) prev.next = next;
      if (next) next.prev = prev;
    }
  }
}

class LinkedNode {
  constructor(key, val) {
    this.val = val;
    this.key = key;
    this.next = this.prev = null;
  }
}
```
