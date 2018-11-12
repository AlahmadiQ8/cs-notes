## Problem

```
Implement a queue using a circular array
```

## Solution 

```javascript 
class Queue {
  constructor(size) {
    this.size = size
    this.length = 0
    this.front = 0
    this.back = 0
    this.arr = Array.from({ length: size }).fill(null)
  }

  add(value) {
    if (this.length == this.size) return false
    this.arr[this.back] = value
    this.back = (this.back + 1) % this.size
    this.length++
    return true
  }

  remove() {
    if (this.length == 0) return false
    this.front = (this.front + 1) % this.size
    this.length--
    return true
  }

  peakFront() {
    return this.arr[this.front]
  }

  peakBack() {
    const backIndex = this.back - 1 < 0 ? this.size - 1 : this.back - 1
    return this.arr[backIndex]
  }

  isFull() {
    return this.size == this.length
  }
}

const obj = new Queue(3)
expect(obj.add(1)).to.be.true
expect(obj.add(2)).to.be.true
expect(obj.add(3)).to.be.true
expect(obj.add(4)).to.be.false
expect(obj.peakFront()).to.be.eq(1)
expect(obj.peakBack()).to.be.eq(3)
expect(obj.isFull()).to.be.true
expect(obj.remove()).to.be.true
expect(obj.peakFront()).to.be.eq(2)
```
