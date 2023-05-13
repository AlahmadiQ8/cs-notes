---
tags:
  - review
  - techniques/two-pointers
---

## [Longest Substring Without Repeating Characters](https://leetcode.com/problems/longest-substring-without-repeating-characters/description/)

Given a string s, find the length of the longest substring without repeating characters.

```
Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.

Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
```

## Notes

- If the interviewer restricts the input to alphabets, you can use an array of size 52 (26 x 2)instead of using a Hashmap.

## Technique

- A hashmap and two points at the start and expand (similar to subarr sum to x)

## Solution

0  1  2  3  4  6
a  b  c  b  b  b
               e
            s

cur longest 3
Hash {
    a 0
    b 4
    c 2
}

```csharp
// using Set
public int LengthOfLongestSubstring(string s)
{
    if (s.Length <= 1) return s.Length;

    var max = 1;
    var start = 0;
    var end = 0;
    var set = new HashSet<char>();

    while (end < s.Length)
        if (!set.Contains(s[end]))
        {
            set.Add(s[end++]);
            max = Math.Max(max, end - start);
        }
        else
            set.Remove(s[start++]);

    return max;
}

// using Dictionary
int LengthOfLongestSubstring(string s) {
    if (s.Length <= 1) return s.Length;

    var max = 1;
    var start = 0;
    var hash = new Dictionary<char, int>();
    hash[s[0]] = 0;

    int end;
    for (end = 1; end < s.Length; end++) {
        if (hash.ContainsKey(s[end]) && hash[s[end]] >= start) {
            start = hash[s[end]] + 1;
        }
        hash[s[end]] = end;
        max = Math.Max(max, end - start + 1);
    }

    return max;
}
```
