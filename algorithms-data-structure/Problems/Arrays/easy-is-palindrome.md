## Problem

Link: https://leetcode.com/problems/valid-palindrome-ii/description/

Given a non-empty string s, you may delete at most one character. Judge whether
you can make it a palindrome.

**Example 1:**

```
Input: "aba"
Output: True
```

**Example 2:**

```
Input: "abca"
Output: True
```

Explanation: You could delete the character 'c'.

**Note**:

The string will only contain lowercase characters a-z. The maximum length of the string is 50000.

## Solution

```csharp
public bool ValidPalindrome(string s)
{
    var i = 0;
    var j = s.Length - 1;
    while (i < j)
    {
        if (s[i] != s[j]) return IsPalindromRange(s, i + 1, j) || IsPalindromRange(s, i, j - 1);
        i++;
        j--;
    }

    return true;
}

private bool IsPalindromRange(string s, int i, int j)
{
    while (i < j)
        if (s[i++] != s[j--])
            return false;
    
    return true;
}
```
