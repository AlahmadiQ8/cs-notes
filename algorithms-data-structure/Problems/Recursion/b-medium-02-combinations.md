## [Combinations](https://leetcode.com/problems/combinations)

Given two integers `n` and `k`, return all possible combinations of `k` numbers chosen from the range `[1, n]`.

You may return the answer in **any order**.

## Technique

- Auxiliary Buffer
- Backtracking


| Complexity | Big O                              |
| ---------- | ---------------------------------- |
| Time       | O(n^2)                             |
| Space      | O(X) for buffer size and recursion |

## Solution

```csharp
public class Solution
{
    public IList<IList<int>> Combine(int n, int k)
    {
        var result = new List<IList<int>>();
        Combination(new int[k], 1, 0);
        return result;

        void Combination(int[] buffer, int startIndex, int bufferIndex)
        {
            if (bufferIndex == k)
            {
                result.Add(buffer.ToList());
                return;
            }

            if (startIndex == n + 1)
                return;

            for (var i = startIndex; i <= n; i++)
            {
                buffer[bufferIndex] = i;
                Combination(buffer, i + 1, bufferIndex + 1);
            }
        }
    }
}
```

## Alternative Phrasing

Print all combinations of size x given an array


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
