## [Letter Combinations of a Phone Number](https://leetcode.com/problems/letter-combinations-of-a-phone-number)

Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.

A mapping of digit to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.

```
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
public class Solution
{
    public IList<string> LetterCombinations(string digits)
    {
        var result = new List<string>();
        if (digits.Length == 0) return result;
        Combination(0, "");
        return result;

        void Combination(int letterIndex, string curr)
        {
            if (letterIndex == digits.Length)
            {
                if (!string.IsNullOrEmpty(curr))
                    result.Add(curr);
                return;
            }

            var letters = _letters[digits[letterIndex]];

            foreach (var c in letters)
                Combination(letterIndex + 1, curr + c);
        }
    }

    private IDictionary<char, string> _letters = new Dictionary<char, string>
    {
        { '0', "" },
        { '1', "" },
        { '2', "abc" },
        { '3', "def" },
        { '4', "ghi" },
        { '5', "jkl" },
        { '6', "mno" },
        { '7', "pqrs" },
        { '8', "tuv" },
        { '9', "wxyz" }
    };
}
```
