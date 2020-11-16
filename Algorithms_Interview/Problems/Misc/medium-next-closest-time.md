## Problem

```
Given a time represented in the format "HH:MM", form the next closest time by reusing the current digits. There is no limit on how many times a digit can be reused.

You may assume the given input string is always valid. For example, "01:34", "12:09" are all valid. "1:34", "12:9" are all invalid.

Example 1:

Input: "19:34"
Output: "19:39"
Explanation: The next closest time choosing from digits 1, 9, 3, 4, is 19:39, which occurs 5 minutes later.  It is not 19:33, because this occurs 23 hours and 59 minutes later.
Example 2:

Input: "23:59"
Output: "22:22"
Explanation: The next closest time choosing from digits 2, 3, 5, 9, is 22:22. It may be assumed that the returned time is next day's time since it is smaller than the input time numerically.
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(1)  |
| Space      | O(1)  |

```csharp
public string NextClosestTime(string time)
{
    var result = time.ToCharArray();
    var digits = new char[] {result[0], result[1], result[3], result[4]};
    Array.Sort(digits);

    // HH:M_
    result[4] = FindNext(result[4], '9', digits);
    if (result[4] > time[4]) return new string(result);

    // HH:_M
    result[3] = FindNext(result[3], '5', digits);
    if (result[3] > time[3]) return new string(result);

    // H_:MM
    result[1] = result[0] != '2'
        ? FindNext(result[1], '9', digits)
        : FindNext(result[1], '3', digits);
    if (result[1] > time[1]) return new string(result);

    // _H:MM
    result[0] = FindNext(result[0], '2', digits);
    return new string(result);
}

private char FindNext(char current, char upperLimit, char[] digits)
{
    if (current == upperLimit) return digits[0];
    var index = Array.BinarySearch(digits, current) + 1;
    while (index < 4 && (digits[index] == current || digits[index] > upperLimit)) index++;
    return index == 4 ? digits[0] : digits[index];
}
```
