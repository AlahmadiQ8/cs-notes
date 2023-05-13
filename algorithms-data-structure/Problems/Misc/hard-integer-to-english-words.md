## Problem

https://leetcode.com/problems/integer-to-english-words/

```
Convert a non-negative integer num to its English words representation.

Example 1:

Input: num = 123
Output: "One Hundred Twenty Three"
Example 2:

Input: num = 12345
Output: "Twelve Thousand Three Hundred Forty Five"
Example 3:

Input: num = 1234567
Output: "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"
Example 4:

Input: num = 1234567891
Output: "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One"
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(1)  |
| Space      | O(1)  |

```csharp
private string One(int num)
{
    return num switch
    {
        1 => "One",
        2 => "Two",
        3 => "Three",
        4 => "Four",
        5 => "Five",
        6 => "Six",
        7 => "Seven",
        8 => "Eight",
        9 => "Nine",
        _ => throw new ArgumentOutOfRangeException(nameof(num), "Number must be between 1 and 9")
    };
}

private string TwoLessThan20(int num)
{
    return num switch
    {
        10 => "Ten",
        11 => "Eleven",
        12 => "Twelve",
        13 => "Thirteen",
        14 => "Fourteen",
        15 => "Fifteen",
        16 => "Sixteen",
        17 => "Seventeen",
        18 => "Eighteen",
        19 => "Nineteen",
        _ => throw new ArgumentOutOfRangeException(nameof(num), "Must be between 10 and 19")
    };
}

private string Ten(int num)
{
    return num switch
    {
        2 => "Twenty",
        3 => "Thirty",
        4 => "Forty",
        5 => "Fifty",
        6 => "Sixty",
        7 => "Seventy",
        8 => "Eighty",
        9 => "Ninety",
        _ => throw new ArgumentOutOfRangeException(nameof(num))
    };
}

private string Two(int num)
{
    if (num == 0) return "";
    if (num < 10) return One(num);
    if (num < 20) return TwoLessThan20(num);
    var tenner = num / 10;
    var rest = num - tenner * 10;
    if (rest != 0) return Ten(tenner) + " " + One(rest);
    return Ten(tenner);
}

private string Three(int num)
{
    var hundred = num / 100;
    var rest = num - hundred * 100;
    if (rest * hundred != 0) return One(hundred) + " Hundred " + Two(rest);
    if (hundred == 0 && rest != 0) return Two(rest);
    if (hundred != 0 && rest == 0) return One(hundred) + " Hundred";
    return "";
}

public string NumberToWords(int num)
{
    if (num == 0) return "Zero";
    var billion = num / 1_000_000_000;
    var million = (num - billion * 1_000_000_000) / 1_000_000;
    var thousand = (num - billion * 1_000_000_000 - million * 1_000_000) / 1_000;
    var rest = num - billion * 1_000_000_000 - million * 1_000_000 - thousand * 1_000;

    var result = "";

    if (billion != 0) result += Three(billion) + " Billion";
    if (million != 0)
    {
        if (!string.IsNullOrEmpty(result)) result += " ";
        result += Three(million) + " Million";
    }

    if (thousand != 0)
    {
        if (!string.IsNullOrEmpty(result)) result += " ";
        result += Three(thousand) + " Thousand";
    }

    if (rest != 0)
    {
        if (!string.IsNullOrEmpty(result)) result += " ";
        result += Three(rest);
    }

    return result;
}
```
