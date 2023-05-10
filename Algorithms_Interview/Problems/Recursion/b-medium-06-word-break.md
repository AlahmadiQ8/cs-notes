---
tags:
  - techniques/backtracking
---

# [Word Break](https://leetcode.com/problems/word-break/description/)

Given a string s and a dictionary of strings wordDict, return true if s can be segmented into a space-separated sequence of one or more dictionary words.

Note that the same word in the dictionary may be reused multiple times in the segmentation.

```
Input: s = "leetcode", wordDict = ["leet","code"]
Output: true
Explanation: Return true because "leetcode" can be segmented as "leet code".

Input: s = "applepenapple", wordDict = ["apple","pen"]
Output: true
Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
Note that you are allowed to reuse a dictionary word.

Input: s = "catsandog", wordDict = ["cats","dog","sand","and","cat"]
Output: false
```

## Solution

```csharp
public class Solution {
    public bool WordBreak(string s, IList<string> wordDict)
    {
        var set = new HashSet<string>(wordDict);
        var memo = new Dictionary<string, bool>();
        return Backtrack(s);

        bool Backtrack(string current)
        {
            if (string.IsNullOrEmpty(current))
                return true;
            if (memo.TryGetValue(current, out var backtrack))
                return backtrack;

            for (var i = 1; i <= current.Length; i++)
            {
                if (set.Contains(current[..i]) && Backtrack(current[i..]))
                    return memo[current] = true;
            }

            return memo[current] = false;
        }
    }
}
```
