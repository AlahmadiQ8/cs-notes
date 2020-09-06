## Problem

```
Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.

A mapping of digit to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.

Example:

    Input: "23"
    Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
```

## Technique

- Combination

| Complexity | Big O |
|------------|-------|
| Time       | O( )  |
| Space      | O( )  |

## Solution

```csharp
private readonly IDictionary<char, string> _phoneLetters = new Dictionary<char, string>
{
    {'0', ""},
    {'1', ""},
    {'2', "abc"},
    {'3', "def"},
    {'4', "ghi"},
    {'5', "jkl"},
    {'6', "mno"},
    {'7', "pqrs"},
    {'8', "tuv"},
    {'9', "wxyz"},
};

public IList<string> LetterCombinations(string digits)
{
    var result = new List<string>();
    if (digits.Length == 0) return result;
    var buffer = "";
    LetterCombinationsRecursion(0);
    return result;


    void LetterCombinationsRecursion(int startIndex)
    {
        if (buffer.Length == digits.Length || startIndex == digits.Length)
        {
            result.Add(buffer);
            return;
        }

        var letters = _phoneLetters[digits[startIndex]];

        if (letters.Length == 0) LetterCombinationsRecursion(startIndex + 1);

        foreach (var letter in letters)
        {
            buffer += letter;
            LetterCombinationsRecursion(startIndex + 1);
            buffer = buffer.Remove(buffer.Length - 1);
        }
    }
}
```
