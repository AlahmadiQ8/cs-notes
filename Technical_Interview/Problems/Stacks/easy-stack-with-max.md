## Problem 

```
Implement​ ​a​ ​Stack​ ​with​ ​a​ ​max()​ ​function.​ ​This​ ​function​ 
​runs​ ​in​ ​O(1)​ ​time​ ​and​ ​returns​ ​the value​ ​of​ ​the​ 
​maximum​ ​number​ ​on​ ​the​ ​stack. 
```

## Solution

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
