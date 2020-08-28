Given an array of numbers, replace each even number with two of the same 
number. e.g, [1,2,5,6,8, , , ,] -> [1,2,2,5,6,6,8,8]. Assume that the array 
has the exact amount of space to accommodate the result.

```javascript
function duplicateEven(arr) {
  if (!arr || arr.length == 0) throw Error('invalid input')

  let i = arr.length - 1
  let j = getLastElement(arr)
  while (j >= 0) {
    if (arr[j] % 2 === 0) 
      arr[i--] = arr[j]
    arr[i--] = arr[j--]
  }
}
function getLastElement(arr) {
  let last = arr.length - 1
  while (arr[last] === -1) 
    last--
  return last
}

const arr = [1, 2, 5, 8, 6, -1, -1, -1]
duplicateEven(arr) // arr = ​​​​​[ 1, 2, 2, 5, 8, 8, 6, 6 ]​​​​​
```

```csharp
public int DuplicateEven(int[] arr) {
  if (arr == null) return -1;

  var i = GetLastIndex(arr);
  var end = arr.Length - 1;

  while (i >= 0) {
    if (arr[i] % 2 == 0) 
      arr[end--] = arr[i];
    arr[end--] = arr[i--];
  }

  return 1;
}

public int GetLastIndex(int[] arr) {
  if (arr.Length == 0) return -1;
  for (var i = 0; i < arr.Length; i++>) {
    if (arr[i] == -1) return i;
  }
  return -1;
}

public void Test() {
  var input = new[] { 1, 2, 5, 8, 6, -1, -1, -1 };
  var res = DuplicateEven(input);
  System.Console.WriteLine(res);
  System.Console.WriteLine(input.ToCommaSeparatedString()); // arr = ​​​​​[ 1, 2, 2, 5, 8, 8, 6, 6 ]​​​​​
}
```
