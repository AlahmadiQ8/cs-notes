## Problem

https://leetcode.com/problems/group-anagrams/

```
Given an array of strings strs, group the anagrams together. You can return the answer in any order.

An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

 

Example 1:

Input: strs = ["eat","tea","tan","ate","nat","bat"]
Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
Example 2:

Input: strs = [""]
Output: [[""]]
Example 3:

Input: strs = ["a"]
Output: [["a"]]
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O( )  |
| Space      | O( )  |

```csharp
public IList<IList<string>> GroupAnagrams(string[] strs)
{
    if (strs.Length == 0) return new List<IList<string>>();

    var map = new Dictionary<string, IList<string>>();
    foreach (var word in strs)
    {
        var hash = HashAnagram(word);
        if (!map.ContainsKey(hash)) map[hash] = new List<string>();
        map[hash].Add(word);
    }

    return map.Values.ToList();
}

private static string HashAnagram(string word)
{
    var counts = new int[26];
    foreach (var c in word)
        counts[c - 'a'] += 1;

    return string.Join("#", counts);
}
```
