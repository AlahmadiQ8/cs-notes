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

```csharp
public class PriorityQueue<T> where T : IComparable
{
    private readonly Queue<T> _queue = new Queue<T>();
    private readonly LinkedList<T> _max = new LinkedList<T>();

    public void Enqueue(T item)
    {
        _queue.Enqueue(item);
        
        while (_max.Count > 0 && _max.Last().CompareTo(item) < 0) _max.RemoveLast();
        _max.AddLast(item);
    }

    public T Dequeue()
    {
        var item = _queue.Dequeue();
        if (item.CompareTo(_max.First()) == 0) _max.RemoveFirst();
        return item;
    }

    public T PeekMax()
    {
        return _max.First();
    }

    public T Peek() => _queue.Peek();
}

public override void Test()
{
    var priorityQueue = new PriorityQueue<int>();
    priorityQueue.Enqueue(5);
    priorityQueue.Peek().Should().Be(5);
    priorityQueue.PeekMax().Should().Be(5);
    
    priorityQueue.Enqueue(4);
    priorityQueue.Peek().Should().Be(5);
    priorityQueue.PeekMax().Should().Be(5);
    
    priorityQueue.Enqueue(6);
    priorityQueue.Peek().Should().Be(5);
    priorityQueue.PeekMax().Should().Be(6);
    
    priorityQueue.Enqueue(7);
    priorityQueue.Peek().Should().Be(5);
    priorityQueue.PeekMax().Should().Be(7);
    
    priorityQueue.Enqueue(1);
    priorityQueue.Peek().Should().Be(5);
    priorityQueue.PeekMax().Should().Be(7);
    
    priorityQueue.Enqueue(2);
    priorityQueue.Peek().Should().Be(5);
    priorityQueue.PeekMax().Should().Be(7);

    priorityQueue.Dequeue().Should().Be(5);
    priorityQueue.PeekMax().Should().Be(7);
    
    priorityQueue.Dequeue().Should().Be(4);
    priorityQueue.PeekMax().Should().Be(7);
    
    priorityQueue.Dequeue().Should().Be(6);
    priorityQueue.PeekMax().Should().Be(7);
    
    priorityQueue.Dequeue().Should().Be(7);
    priorityQueue.PeekMax().Should().Be(2);
}
```
