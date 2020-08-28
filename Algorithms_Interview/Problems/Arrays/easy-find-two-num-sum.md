2 Sum Problem: Given a sorted array of integers, find two numbers in the array 
that sum to an integer X.For example, given a=[1,2,3,5,6,7] and X=11, the answer 
would be 5 and 6, which sum to 11

## Technique

- Two Pointers

## Notes

- Are there duplicates? 
- What to return if there is more than one answer? 

```javascript 
function findSub(arr, t) {
  if (!arr || arr.length <= 1) return [-1, -1]

  let s = 0
  let e = arr.length - 1
  while(s < arr.length && e >= 0) {
    const sum = arr[s] + arr[e]
    if (sum === t) return [s, e]
    if (sum > t) e--
    if (sum < t) s++
  }
  return [-1, -1]
}
findSub([-10, 1, 2, 3, 4, 5, 6], 6)    //​​​​​[ 1, 5 ]​​​​​
findSub([-10, 1, 2, 3, 4, 5, 6], -4)   //​​​​​[ 0, 6 ]​​​​​
findSub([-10, 1, 2, 3, 4, 5, 6], 7)    //​​​​​[ 1, 6 ]​​​​​
```

```csharp
public int[] FindTwoSumInSortedArr(int[] arr, int sum) {
    if (arr == null || arr.Length <= 1) return null;

    var left = 0;
    var right = arr.Length - 1;

    while (left < right) {
        var currentSum = arr[left] + arr[right];
        if (currentSum < sum) left++;
        else if (currentSum > sum) right--;
        else return new[] {arr[left], arr[right]};
    }

    return null;
}

public void Test()
{
    FindTwoSumInSortedArr(new[] {1, 2, 3, 4, 9}, 7).Should().Equal(new[] {3, 4});
    FindTwoSumInSortedArr(new[] {1, 2}, 3).Should().Equal(new int[] {1, 2});
    FindTwoSumInSortedArr(new[] {1, 2}, 5).Should().BeNull();
    FindTwoSumInSortedArr(new int[] {}, 5).Should().BeNull();
}
```


-4  -2  -1  0  3  5
[         ][       ]
Find index of zero or positive
reverse left side and square each value
square each value on right ride

[]
null
[-2, -1]
[1, 2, 3]

```csharp
public void SquareAndKeepOrder(int[] arr) {
    if (arr == null || arr.Length == 0) return;

    var firstZeroOrPositiveIndex = GetFirstZeroOrPositiveIndex(arr);
    
    if (firstZeroOrPositiveIndex = -1)
        Array.Reverse(arr);
    else 
        Reverse(arr, 0, firstZeroOrPositiveIndex);

    for (var i = 0; i < arr.Length; i++) arr[i] = arr[i] * arr[i];
}

public int GetFirstZeroOrPositiveIndex(arr) {
    var res = 0; 
    while (arr[res] < 0) res++;
    if (res == arr.Length) return -1;
}

public void Reverse(int[] arr, i, j) {
    while (i < j) {
        Swap(arr, i, i);
    }
}

```
