## Problem

https://leetcode.com/problems/evaluate-reverse-polish-notation/

```
Evaluate the value of an arithmetic expression in Reverse Polish Notation.

Valid operators are +, -, *, /. Each operand may be an integer or another expression.

Note:

Division between two integers should truncate toward zero.
The given RPN expression is always valid. That means the expression would always evaluate to a result and there won't be any divide by zero operation.
Example 1:

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
public int EvalRPN(string[] tokens) {
    var operands = new Stack<int>();

    foreach (var t in tokens) {
        if (_operators.ContainsKey(t)) {
            var num2 = operands.Pop();
            var num1 = operands.Pop();
            var result = _operators[t](num1, num2);
            operands.Push(result);
        } else {
            operands.Push(int.Parse(t));
        }
    }

    return operands.Peek();
}

private readonly Dictionary<string, Func<int, int, int>> _operators = new Dictionary<string, Func<int, int, int>>
{
    {"+", (a, b) => a + b},
    {"-", (a, b) => a - b},
    {"*", (a, b) => a * b},
    {"/", (a, b) => a / b}
};
```
