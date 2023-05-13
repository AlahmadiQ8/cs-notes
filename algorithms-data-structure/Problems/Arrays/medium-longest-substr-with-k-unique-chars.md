## Problem

```
Given a string, find the length of the longest substring T that contains at most k distinct characters.

Example 1:

Input: s = "eceba", k = 2
Output: 3
Explanation: T is "ece" which its length is 3.
Example 2:

Input: s = "aa", k = 1
Output: 2
Explanation: T is "aa" which its length is 2.
```

## Solution

- Linked Hash Table (LRU)

| Complexity | Big O |
|------------|-------|
| Time       | O(N)  |
| Space      | O(N)  |

```csharp
// MOST OPTIMAL 
public int LengthOfLongestSubstringKDistinct(string s, int k) {
    if (s.Length == 0 || k == 0) return 0;
    var map = new Dictionary<char, LinkedListNode<(char, int)>>();
    var list = new LinkedList<(char, int)>();

    var start = 0;
    var longest = 1;

    for (var end = 0; end < s.Length; end++)
    {
        var c = s[end];
        if (map.ContainsKey(c))
            list.Remove(map[c]);
        map[c] = new LinkedListNode<(char, int)>((c, end));
        list.AddLast(map[c]);

        if (map.Count == k + 1)
        {
            start = list.First().Item2 + 1;
            map.Remove(list.First().Item1);
            list.RemoveFirst();
        }

        longest = Math.Max(longest, end - start + 1);
    }

    return longest;
}

// LESS OPTIMAL
public int LengthOfLongestSubstringKDistinct(string s, int k) {
    if (s.Length == 0 || k == 0) return 0;
    var map = new Dictionary<char, int>();
    var start = 0;
    var end = 0;
    var longest = 1;
    
    while (start < s.Length && end < s.Length) {
        if (map.Count < k || (map.Count == k && map.ContainsKey(s[end]))) {
            if (!map.ContainsKey(s[end])) map[s[end]] = 0;
            map[s[end]] += 1;
            longest = Math.Max(longest, end - start + 1);
            end++;
        } else {
            map[s[start]] -= 1;
            if (map[s[start]] == 0) map.Remove(s[start]);
            start += 1;
        }
    }
    
    return longest;
}
```
