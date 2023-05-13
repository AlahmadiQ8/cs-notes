---
tags:
  - review
---

# [Max Stack](https://leetcode.com/problems/max-stack/description/)

Implement​ ​a​ ​Stack​ ​with​ ​a​ ​max()​ ​function.​ ​This​ ​function​
​runs​ ​in​ ​O(1)​ ​time​ ​and​ ​returns​ ​the value​ ​of​ ​the​
​maximum​ ​number​ ​on​ ​the​ ​stack.

## Solution

```csharp
public class MaxStack
{
    private readonly Stack<int> _main = new Stack<int>();
    private readonly Stack<int> _max = new Stack<int>();

    public void Push(int x)
    {
        _main.Push(x);
        if (_max.Count == 0 || x >= _max.Peek())
            _max.Push(x);
    }

    public int Pop()
    {
        var val = _main.Pop();
        if (val == _max.Peek()) _max.Pop();
        return val;
    }

    public int Top()
    {
        return _main.Peek();
    }

    public int PeekMax()
    {
        return _max.Peek();
    }

    public int PopMax()
    {
        var max = _max.Pop();
        var temp = new Stack<int>();
        while (_main.Peek() != max)
            temp.Push(_main.Pop());
        _main.Pop();
        while (temp.Count != 0) Push(temp.Pop());
        return max;
    }
}
```
