## Problem

```
Write a function that takes an input string and a character set and returns the minimum-length substring
which contains every letter of the character set at least once, in any order
If you don't find a match, return an empty string

Example:
Input: "aabbcb"
Alphabet: {'a', 'b', 'c'}
Output: "abbc"

Input: "abababababababababababbccccccccsbabbbccc"
Alphabet: {'a', 'b', 'c'}
Output: "csba"

Input: "aaaaaaaaaabbbbbbbbccccccccsbabbbccc"
Alphabet: {'a', 'b', 'c', 'f'}
Output: ""
```

## Solution 

| Complexity | Big O                              |
| ---------- | ---------------------------------- |
| Time       | O(words.wordCount + coc.charCount) |
| Space      | O(S.chars + Doc.charCount)         |


```javascript
class Node {
  constructor(letter, index) {
    this.letter = letter
    this.index = index
    this.next = null
  }
}

class LinkedList {
  constructor() {
    this.head = null
    this.tail = null
  }

  add(node) {
    if (!this.head) {
      this.head = node
      this.tail = node
    } else {
      let cur = this.head
      while (cur.next != null) {
        cur = cur.next
      }
      cur.next = node
      node.prev = cur
      this.tail = node
    }
  }

  remove(node) {
    if (this.head == node) {
      this.head = this.head.next
      if (this.head && this.head.next) {
        this.head.next.prev = this.head
      }
    } else if (this.tail == node) {
      this.tail = this.tail.prev
      this.tail.next = null
    } else {
      const prev = node.prev
      const next = node.next
      prev.next = next
      next.prev = prev
    }
  }
}

function smallestSubstring(str, chars) {
  if (!str || chars.length == 0) return ''

  const list = new LinkedList()
  const hash = {}
  let min = Number.POSITIVE_INFINITY
  let result = ''
  
  for (let i = 0; i < str.length; i++) {
    if (!chars.has(str[i])) continue
    if (hash[str[i]]) {
      const nodeToDelete = hash[str[i]]
      list.remove(nodeToDelete)
    }
    const node = new Node(str[i], i)
    list.add(node)
    hash[str[i]] = node
    if (Object.keys(hash).length == chars.size) {
      const length = list.tail.index - list.head.index + 1
      if (length < min) {
        min = length
        result = str.substring(list.head.index, list.head.index + length)
      }
    }
  }
  return result
}

const str = 'accbbccaafgfabc'
const chars = new Set(['a', 'b', 'c'])
smallestSubstring(str, chars) //?
```
