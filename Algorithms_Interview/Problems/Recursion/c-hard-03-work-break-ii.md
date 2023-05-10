---
tags:
  - techniques/backtracking
---

# [Word Break II](https://leetcode.com/problems/word-break-ii)

```
Consider the following dictionary
{ i, like, sam, sung, samsung, mobile, ice,
  cream, icecream, man, go, mango}

Input: "ilikesamsungmobile"
Output: i like sam sung mobile
        i like samsung mobile

Input: "ilikeicecreamandmango"
Output: i like ice cream and man go
        i like ice cream and mango
        i like icecream and man go
        i like icecream and mango
```

## Technique

- Recursion (Obviously)


| Complexity | Big O                            |
| ---------- | -------------------------------- |
| Time       | Exponential, quite poor actually |
| Space      |                                  |

## Solution

```csharp
public class Solution
{
    public IList<string> WordBreak(string s, IList<string> wordDict)
    {
        var set = new HashSet<string>(wordDict);
        var result = new List<string>();
        Backtrack(s, new LinkedList<string>());
        return result;

        void Backtrack(string current, LinkedList<string> list)
        {
            if (string.IsNullOrEmpty(current))
            {
                result.Add(string.Join(' ', list));
                return;
            }

            for (var i = 1; i <= current.Length; i++)
            {
                if (set.Contains(current[..i]))
                {
                    list.AddLast(current[..i]);
                    Backtrack(current[i..], list);
                    list.RemoveLast();
                }
            }
        }
    }
}
```
