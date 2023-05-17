## [Design Circular Queue](https://leetcode.com/problems/design-circular-queue)

Implement a queue using a circular array

## Solution

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
