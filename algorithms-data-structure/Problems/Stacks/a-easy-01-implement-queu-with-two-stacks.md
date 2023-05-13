## [Implement Queue using Stacks](https://leetcode.com/problems/implement-queue-using-stacks/description/)

```
Implement​​ a ​​Queue​​ using​ ​2 ​​stacks
```

## Solution

```csharp
public class MyQueue
{
    private readonly Stack<int> _stack1 = new();
    private readonly Stack<int> _stack2 = new();

    public void Push(int x)
    {
        _stack1.Push(x);
    }

    public int Pop()
    {
        if (_stack2.Count == 0)
            Flush();
        return _stack2.Pop();
    }

    public int Peek()
    {
        if (_stack2.Count == 0)
            Flush();
        return _stack2.Peek();
    }

    public bool Empty()
    {
        return _stack1.Count == 0 && _stack2.Count == 0;
    }

    private void Flush()
    {
        while (_stack1.Count > 0)
            _stack2.Push(_stack1.Pop());
    }
}
```
