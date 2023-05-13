## Problem

https://leetcode.com/problems/design-circular-queue/submissions/

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


```csharp
public class MyCircularQueue {

    private readonly int[] _arr;
    private readonly int _length;
    private readonly int _front = 0;
    private readonly int _back = 0;

    /** Initialize your data structure here. Set the size of the queue to be k. */
    public MyCircularQueue(int k) {
        _arr = new int[k];
        _length = 0;
    }
    
    /** Insert an element into the circular queue. Return true if the operation is successful. */
    public bool EnQueue(int value) {
        if (_length == _arr.Length) return false;
        _arr[_back] = value;
        _back = (back + 1) % _arr.Length;
        _length++;
    }
    
    /** Delete an element from the circular queue. Return true if the operation is successful. */
    public bool DeQueue() {
        if (_length == 0) return false;
        _front = (front + 1) % _arr.Length;
        _length--;
    }
    
    /** Get the front item from the queue. */
    public int Front() {
        return _length[_front];
    }
    
    /** Get the last item from the queue. */
    public int Rear() {
        return _length[_back];
    }
    
    /** Checks whether the circular queue is empty or not. */
    public bool IsEmpty() {
        return _length == 0;
    }
    
    /** Checks whether the circular queue is full or not. */
    public bool IsFull() {
        return _length == _arr.Length;
    }
}
```


```csharp
public class MyCircularQueue
{
    private readonly int[] _arr;
    private int _length;
    private int _front;
    private int _back;

    /** Initialize your data structure here. Set the size of the queue to be k. */
    public MyCircularQueue(int k)
    {
        _arr = new int[k];
        _length = 0;
    }

    /** Insert an element into the circular queue. Return true if the operation is successful. */
    public bool EnQueue(int value)
    {
        if (IsFull()) return false;
        _arr[_back] = value;
        _back = (_back + 1) % _arr.Length;
        _length++;
        return true;
    }

    /** Delete an element from the circular queue. Return true if the operation is successful. */
    public bool DeQueue()
    {
        if (IsEmpty()) return false;
        _front = (_front + 1) % _arr.Length;
        _length--;
        return true;
    }

    /** Get the front item from the queue. */
    public int Front()
    {
        if (IsEmpty()) return -1;
        return _arr[_front];
    }

    /** Get the last item from the queue. */
    public int Rear()
    {
        if (IsEmpty()) return -1;
        return _back == 0 ? _arr[^1] : _arr[_back - 1];
    }

    /** Checks whether the circular queue is empty or not. */
    public bool IsEmpty()
    {
        return _length == 0;
    }

    /** Checks whether the circular queue is full or not. */
    public bool IsFull()
    {
        return _length == _arr.Length;
    }
}
```
