## Problem

Print all combinations of size x given an array 

## Technique

- Auxiliary Buffer


| Complexity | Big O                              |
| ---------- | ---------------------------------- |
| Time       | O(n^2)                             |
| Space      | O(X) for buffer size and recursion |


```javascript
function printCombinations(arr, length) {
  if (length > arr.length) throw Error("Invalid")
  const buffer = Array.from({ length }).fill(null)
  printCombos(arr, buffer, 0, 0)
}

function printCombos(arr, buff, buffIndex, startIndex) {
  // 1. termination case
  if (buffIndex == buff.length) {
    console.log(buff)
    return
  }
  if (startIndex == arr.length) {
    return 
  }

  // 2. find candidates to go into the current buffer index
  for (let i = startIndex; i < arr.length; i++) {
    // 3. place item into buffer
    buff[buffIndex] = arr[i]

    // 4. Recurse
    printCombos(arr, buff, buffIndex + 1, i + 1)
  }
}

printCombinations([1, 2, 3, 4], 3)
// [ 1, 2, 3 ]​​​​​
// ​​​​​[ 1, 2, 4 ]​​​​​
// ​​​​​[ 1, 3, 4 ]​​​​​
// ​​​​​[ 2, 3, 4 ]​​​​​
```

```csharp
public void PrintCombos<T>(T[] arr, int size)
{
    if (size == 0) return;
    if (arr.Length < size) throw new ArgumentException("arr length cannot be less than the combination size");

    var buffer = new T[size];
    PrintCombos(arr, buffer, 0, 0);
}

public void PrintCombos<T>(T[] arr, T[] buffer, int startIndex, int bufferIndex)
{
    if (bufferIndex == buffer.Length)
    {
        buffer.LogArray();
        return;
    }

    if (startIndex == arr.Length) return;

    for (var i = startIndex; i < arr.Length; i++)
    {
        buffer[bufferIndex] = arr[i];
        PrintCombos(arr, buffer, i + 1, bufferIndex + 1);
    }
}
```
