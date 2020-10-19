## Problem

https://leetcode.com/problems/longest-substring-without-repeating-characters/submissions/

```
Given a String, find the longest substring with unique characters.

For example: "whatwhywhere" --> "atwhy"

Should return start and end indices
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
public int LengthOfLongestSubstring(string s)
{
    if (string.IsNullOrEmpty(s)) return 0;

    var longest = 0;
    var set = new HashSet<char>();

    int i = 0, j = 0;
    while (j < s.Length)
    {
        if (!set.Contains(s[j]))
        {
            set.Add(s[j++]);
            longest = Math.Max(longest, j - i);
        }
        else
            set.Remove(s[i++]);
    }

    return longest;
}
```
