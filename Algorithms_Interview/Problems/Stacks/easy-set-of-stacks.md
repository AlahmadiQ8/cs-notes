```typescript
class SetOfStacks<T> {
  public stacks: Array<Array<T>> = [[]]
  private capacity: number;
  private count = 0

  constructor(capacity: number) {
    this.capacity = capacity
  }

  public push(val) {
    const stackIndex = Math.floor(this.count / this.capacity)
    if (!this.stacks[stackIndex]) {
      this.stacks[stackIndex] = []
    }
    this.stacks[stackIndex].push(val)
    this.count++
  }

  public pop() {
    this.count--
    const stackIndex = Math.floor(this.count / this.capacity)
    const value = this.stacks[stackIndex].pop()
    return value
  }
}
```
