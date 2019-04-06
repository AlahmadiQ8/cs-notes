## Problem

```
Implement​​ a​​ data​​ structure​ ​for​ ​a​ ​Least​​ Recently​​ Used​​(LRU)​​ cache
```

## Technique

- Linked Hash Map

## Solution

```javascript
class LRUCache {
  constructor(capacity) {
    this.capacity = capacity
    this.head = null
    this.map = new Map() 
  }

  read(key) { 
    const node = map.get(key)
    if (!node) {
      return null
    }
    this.remove(key)  // remove​​ from​​ linked​​ hash​​ table
    this.add(node.key, node.value) //add back to the front

    return node.value
  }
  write(key, value) {
    if (this.map.size === capacity) {
      this.remove(this.head.key)  // cache​​ is​​ full,​​ evict​​ the ​​head)
    }
    this.add(key, value)
  }

  remove(key) {
    if (!map.has(key)) {
      return
    }
    const toRemove = map.get(key)
    this.removeFromLinkedList(toRemove)
    map.delete(key)
  }

  add(key, value) {
    const node = new Node(key, value)
    this.appendToLinkedList(node)
    this.map.set(node.key, node.value)
    
  }
}
```
