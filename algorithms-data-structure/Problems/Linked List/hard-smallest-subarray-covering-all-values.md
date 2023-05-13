## Problem

```
Smallest Subarray Covering All Values: Let's say you are given a large 
text document Doc. You are also given a set S of words. You want to 
find the smallest substring of Doc that contains all the words in S. 
For example:

S: ["and", "of", "one"]

Doc: "a set of words that is complete in itself, typically containing a 
subject and predicate, conveying a statement, question, exclamation, or 
command, and consisting of a main clause and sometimes one or more 
subordinate clauses"

The underlined part above is the solution. Note that the order in which 
the words appear doesn't matter. Also, the length of the substring is 
in terms of number of characters.
```

## Technique

- Linked hash

| Complexity | Big O                              |
| ---------- | ---------------------------------- |
| Time       | O(words.wordCount + coc.charCount) |
| Space      | O(S.chars + Doc.charCount)         |

## Solution

```javascript
class Node {
  constructor(word, index) {
    this.word = word
    this.index = index
    this.next = null
    this.prev = null
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

function getShortestSubString(doc, words) {
  let result = ''

  const wordsSet = new Set(words)
  const wordsMap = new Map()
  const list = new LinkedList()
  const wordsIter = wordsIterator(doc)
  
  for (wordIndex of wordsIter) {
    const word = getWord(doc, wordIndex)
    if (!wordsSet.has(word)) continue
    if (wordsMap.has(word)) {
      const nodeToDelete = wordsMap.get(word)
      list.remove(nodeToDelete)
    }
    const node = new Node(word, wordIndex)
    list.add(node) // add to front
    wordsMap.set(word, node) // use hash to reference that node

    if (wordsMap.size == wordsSet.size) {
      const startIndex = list.head.index
      const endIndex = list.tail.index + list.tail.word.length - 1
      const sentenceLength = endIndex - startIndex + 1
      if (result == '' || result.length > sentenceLength) {
        result = doc.slice(startIndex, endIndex + 1)
      }
    }
  }
  return result
}

function* wordsIterator(doc) {
  let index = 0
  while (index < doc.length && !doc[index].match(/\s/)) {
    const word = getWord(doc, index)
    yield index
    index += word.length + 1
  }
}

function getWord(doc, index) {
  let word = ''
  let i = index
  while (index < doc.length && doc[index].match(/\w/)) {
    word += doc[index++]
  }
  return word
}

const res = getShortestSubString(
  'one one of omg omg omg the car and bike and one test test of those',
  ['and', 'of', 'one']
)
res
```
