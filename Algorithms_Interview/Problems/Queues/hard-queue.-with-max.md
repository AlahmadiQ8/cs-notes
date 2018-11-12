## Problem 

```
Implement ​​a ​​Queue​​ with ​​O(1) ​​lookup ​​of ​​the ​​Maximum ​​element
```

# Solution

| Complexity          | Big O |
| ------------------- | ----- |
| Time for max lookup | O(1)  |
| Space               | O(n)  |

```typescript
import { expect } from 'chai'

class QueueWithMax {
  private queue: number[] = []
  private max: number[] = []

  enqueue(value: number) {
    this.queue.unshift(value)
    while (this.max.length !== 0 && this.max[0] < value) {
      this.max.shift()
    }
    this.max.unshift(value)
  }

  dequeue(): number {
    if (this.queue.length == 0) {
      throw Error('queue is empty')
    }
    const value = this.queue.pop()
    if (value == this.max[this.max.length - 1]) {
      this.max.pop()
    }
    return value
  }

  getMax(): number {
    if (this.queue.length == 0) {
      throw Error('queue is empty')
    }
    return this.max[this.max.length - 1]
  }
}

const queue = new QueueWithMax()
queue.enqueue(1)
expect(queue.getMax()).to.equal(1)

queue.enqueue(4)
expect(queue.getMax()).to.equal(4)

queue.enqueue(2)
expect(queue.getMax()).to.equal(4)\

queue.enqueue(3)
expect(queue.getMax()).to.equal(4)

expect(queue.dequeue()).to.equal(1)
expect(queue.dequeue()).to.equal(4)

expect(queue.getMax()).to.equal(3)

expect(queue.dequeue()).to.equal(2)
expect(queue.dequeue()).to.equal(3)
```
