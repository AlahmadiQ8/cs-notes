## Problem 

https://leetcode.com/problems/max-stack/

```
Implement​ ​a​ ​Stack​ ​with​ ​a​ ​max()​ ​function.​ ​This​ ​function​ 
​runs​ ​in​ ​O(1)​ ​time​ ​and​ ​returns​ ​the value​ ​of​ ​the​ 
​maximum​ ​number​ ​on​ ​the​ ​stack. 
```

## Solution (Min)

```javascript
class MinStack {
  constructor() {
    this.stack = [];
    this.minStack = [];
  }

  /**
   * @param {number} x
   * @return {void}
   */
  push(x) {
    this.stack.push(x);
    if (
      this.minStack.length === 0 ||
      this.minStack[this.minStack.length - 1] >= x
    ) {
      this.minStack.push(x);
    }
  }

  /**
   * @return {number}
   */
  pop() {
    if (this.stack.length === 0) return null;
    const el = this.stack.pop();
    if (el == this.minStack[this.minStack.length - 1]) {
      this.minStack.pop();
    }
    return el;
  }

  /**
   * @return {number}
   */
  top() {
    if (this.stack.length === 0) return null;
    return this.stack[this.stack.length - 1];
  }

  /**
   * @return {number}
   */
  getMin() {
    if (this.stack.length === 0) return null;
    return this.minStack[this.minStack.length - 1];
  }
}
```

## Solution (Max)

```java
public class StackWithMaxImpl {
  Stack<Integer> main;
  Stack<Integer> max;
  
  public StackWithMaxImpl() {
    main = new Stack<>();
    max = new Stack<>();
  }
  
  public void push(int a) {
    main.push(a);
    if (!max.isEmpty() || a >= max.peek())
      max.push(a);
  }
  
  public int max() throws StackEmptyException {
    if (max.isEmpty())
      throw new StackEmptyException();
    return max.peek();
  }
  
  public int pop() throws StackEmptyException {
    if (main.isEmpty())
      throw new StackEmptyException();
    int item = main.pop();
    if (max.peek() == item)
      max.pop();
    return item;
  }
}

public class StackEmptyException extends Exception {
  public StackEmptyException() {
  }
}
```


```csharp
public class MaxStack {

    private readonly Stack<int> _main = new Stack<int>();
    private readonly Stack<int> _max = new Stack<int>();

    public void Push(int x) {
        _main.Push(x);
        if (_max.Count == 0 || x >= _max.Peek()) _max.Push(x);
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

    public int PeekMax() {
        return _max.Peek();
    }

    public int PopMax()
    {
        var max = _max.Pop();
        var temp = new Stack<int>();
        while (_main.Peek() != max) temp.Push(_main.Pop());
        _main.Pop();
        while (temp.Count != 0) Push(temp.Pop());
        return max;
    }
}
```