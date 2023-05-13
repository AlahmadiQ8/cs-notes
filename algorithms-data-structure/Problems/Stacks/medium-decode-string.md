## Problem 

https://leetcode.com/problems/decode-string/

```
Given an encoded string, return its decoded string.

The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is being repeated exactly k times. Note that k is guaranteed to be a positive integer.

You may assume that the input string is always valid; No extra white spaces, square brackets are well-formed, etc.

Furthermore, you may assume that the original data does not contain any digits and that digits are only for those repeat numbers, k. For example, there won't be input like 3a or 2[4].

 

Example 1:

Input: s = "3[a]2[bc]"
Output: "aaabcbc"
Example 2:

Input: s = "3[a2[c]]"
Output: "accaccacc"
Example 3:

Input: s = "2[abc]3[cd]ef"
Output: "abcabccdcdcdef"
Example 4:

Input: s = "abc3[cd]xyz"
Output: "abccdcdcdxyz"
```

## Solution 

```csharp
public string DecodeString(string s)
{
    return Backtrack(s, 0, s.Length - 1, "");
}

private string Backtrack(string s, int start, int end, string result)
{
    if (start > end || s[start] == ']') return result;
    if (!char.IsDigit(s[start]))
        return Backtrack(s, start + 1, end, result + s[start]);

    var times = s[start] - '0';
    while (start + 1 < s.Length && char.IsDigit(s[start + 1]))
    {
        start++;
        times = 10 * times + (s[start] - '0');
    }

    var opening = start + 1;
    var closing = start + 1;
    var count = 1;
    while (count != 0)
    {
        closing++;
        if (s[closing] == '[') count++;
        else if (s[closing] == ']') count--;
    }

    var curResult = Backtrack(s, opening + 1, closing - 1, "");
    curResult = string.Concat(Enumerable.Repeat(curResult, times));
    return Backtrack(s, closing + 1, s.Length - 1, result + curResult);
}
```
