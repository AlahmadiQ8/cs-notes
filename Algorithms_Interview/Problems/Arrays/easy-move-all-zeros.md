Move all zeroes to end of array

# Technique

- Dutch national flag algorithm

| Complexity | Big O |
|------------|-------|
| Time       | O(n)  |
| Space      | O(1)  |

```javascript
function moveZeros(arr) {
  if (!arr || arr.length <= 1) return
  let lo = 0,
    mid = 0
  while (mid < arr.length) {
    if (arr[mid] !== 0) swap(arr, lo++, mid++)
    else mid++
  }
}
function swap(arr, i, j) {
  let temp = arr[i]
  arr[i] = arr[j]
  arr[j] = temp
}

const arr = [3, 0, 2, 0, 0, 4, 4, 6, 4, 4, 0]
moveZeros(arr) // ​​​​​[ 3, 2, 4, 4, 6, 4, 4, 0, 0, 0, 0 ]​​​​​
```

```csharp
public void MoveZerosToStart(int[] arr) {
    if (arr == null || arr.Length == 0) return;

    var left = 0;
    var cur = 0;
    while (cur < arr.Length) {
        if (arr[cur] == 0) Swap(arr, left++, cur++);
        else cur++;
    }
}
public void MoveZerosToEnd(int[] arr) {
    if (arr == null || arr.Length == 0) return;

    var right = arr.Length - 1;
    var cur = arr.Length - 1;
    while (cur >= 0) {
        if (arr[cur] == 0) Swap(arr, right--, cur--);
        else cur--;
    }
}

public override void Test()
{
    var input = new[] {3, 0, 2, 0, 0, 4, 4, 6, 4, 4, 0};
    MoveZerosToStart(input);
    Console.WriteLine(input.ToCommaSeparatedString());
    MoveZerosToEnd(input);
    Console.WriteLine(input.ToCommaSeparatedString());
}
```

