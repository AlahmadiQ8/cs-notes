## Problem

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
public Indices FindLongestUniqueSubstr(string str) {
    if (string.IsNullOrEmpty()) return null;

    var start = 0;
    var end = 0;
    var map = new Dictionary<char, int> { { str[0], 0 }};
    var longest = 1; 
    var result = new Indices {Start = 0, End = 0};

    while (end + 1 < str.Length) {
        end++;
        if (map.ContainsKey(str[end])) {
            start = map[str[end]] + 1;
        }
        map[str[end]] = end;

        if (end - start + 1 > longest) {
            longest = end - start + 1;
            result.Start = start;
            result.End = end;
        }
    }

    return result;
}
```
