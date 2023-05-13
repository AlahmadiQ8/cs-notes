## Problem

```
Implement​​ a ​​Queue​​ using​ ​2 ​​stacks
```

## Solution

```java
public class Queue<A> {
  Stack<A> s1;
  Stack<A> s2;

  public Queue() {
    s1 = new Stack<A>();
    s2 = new Stack<A>();
  }

  public void enqueue(A a) {
    s1.push(a);
  }

  public A dequeue() throws EmptyQueueException {
    if (s2.isEmpty()) {
      flushToS2();
    }
    if (s2.isEmpty())
      throw new EmptyQueueException();
    return s2.pop();
  }

  private void flushToS2() {
    while (!s1.isEmpty()) {
      s2.push(s1.pop());
    }
  }
}

public class EmptyQueueException extends Exception {
  public EmptyQueueException() {
  }
}
```
