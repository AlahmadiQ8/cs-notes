## Problem

https://leetcode.com/problems/implement-strstr/

```
Implement strStr().

Return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.

Example 1:

Input: haystack = "hello", needle = "ll"
Output: 2
Example 2:

Input: haystack = "aaaaa", needle = "bba"
Output: -1
Clarification:

What should we return when needle is an empty string? This is a great question to ask during an interview.

For the purpose of this problem, we will return 0 when needle is an empty string. This is consistent to C's strstr() and Java's indexOf().

 

Constraints:

haystack and needle consist only of lowercase English characters.
```

## Solution

* Rabin Karp Algorithm

| Complexity | Big O |
|------------|-------|
| Time       | O(n)  |
| Space      | O(1)  |

```csharp
public int StrStr(string haystack, string needle)
{
    if (needle.Length == 0) return 0;
    if (haystack.Length < needle.Length) return -1;

    var hashT = 0;
    var hash = 0;

    var x = 51;

    for (var i = 0; i < needle.Length; i++)
    {
        hashT = hashT * x + needle[i];
        hash = hash * x + haystack[i];
    }

    if (hashT == hash) return 0;

    var xPow = 1;
    for (var i = 0; i < needle.Length - 1; i++) xPow *= x;

    for (var i = 1; i < haystack.Length - needle.Length + 1; i++)
    {
        var charToRemove = haystack[i - 1];
        hash = (hash - charToRemove * xPow) * x + haystack[i + needle.Length - 1];
        if (hashT == hash) return i;
    }

    return -1;
}
```
