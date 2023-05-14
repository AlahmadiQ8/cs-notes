## [Evaluate Reverse Polish Notation (postfix evaluation)](https://leetcode.com/problems/evaluate-reverse-polish-notation/)


Evaluate the value of an arithmetic expression in Reverse Polish Notation.

Valid operators are +, -, *, /. Each operand may be an integer or another expression.

Note:

Division between two integers should truncate toward zero.
The given RPN expression is always valid. That means the expression would always evaluate to a result and there won't be any divide by zero operation.

```
Input: ["2", "1", "+", "3", "*"]
Output: 9
Explanation: ((2 + 1) * 3) = 9
Example 2:

Input: ["4", "13", "5", "/", "+"]
Output: 6
Explanation: (4 + (13 / 5)) = 6
Example 3:

Input: ["10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+"]
Output: 22
Explanation:
  ((10 * (6 / ((9 + 3) * -11))) + 17) + 5
= ((10 * (6 / (12 * -11))) + 17) + 5
= ((10 * (6 / -132)) + 17) + 5
= ((10 * 0) + 17) + 5
= (0 + 17) + 5
= 17 + 5
= 22
```

## Technique

* Use a stack

| Complexity | Big O |
|------------|-------|
| Time       | O(n)  |
| Space      | O(n)  |

## Solution

```csharp
public class Solution
{
    public int EvalRPN(string[] tokens)
    {
        var stack = new Stack<int>();

        foreach (var c in tokens)
        {
            if (!_operators.ContainsKey(c))
                stack.Push(int.Parse(c));
            else
                stack.Push(_operators[c](stack.Pop(), stack.Pop()));
        }

        return stack.Pop();
    }

    private readonly Dictionary<string, Func<int, int, int>> _operators = new()
    {
        { "+", (b, a) => a + b },
        { "-", (b, a) => a - b },
        { "*", (b, a) => a * b },
        { "/", (b, a) => a / b }
    };
}
```
