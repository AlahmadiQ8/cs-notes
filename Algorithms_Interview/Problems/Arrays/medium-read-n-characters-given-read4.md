## Problem

https://leetcode.com/problems/read-n-characters-given-read4/submissions/

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(N)  |
| Space      | O(1)  |

```csharp

public int Read(char[] buf, int n)
{
    var buf4 = new char[4];
    var offset = 0;
    int currentRead = 4;

    while (offset < n && currentRead == 4)
    {
        currentRead = Read4(buf4);
        var numToRead = currentRead < n - offset ? currentRead : n - offset;
        Array.Copy(buf4, 0, buf, offset, numToRead);
        offset += numToRead;
        if (numToRead < 4) break;
    }

    return offset;
}
```
