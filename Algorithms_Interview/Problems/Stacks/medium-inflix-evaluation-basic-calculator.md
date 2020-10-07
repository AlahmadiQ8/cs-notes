## Problem

https://leetcode.com/problems/basic-calculator/solution/

```
Given an arithmetic expression with *,/,- & + operators and single 
digit numbers,

evaluate it and return the result.

For example,
1 + 2 / 1 + 3 * 2 ==> 9
```
## Solution 

| Complexity | Big O                                                |
| ---------- | ---------------------------------------------------- |
| Time       | O(n)                                                 |
| Space      | O(n) because we store a copy of operators & operands |
 

```csharp
public int Calculate(string s)
{
    var operands = new Stack<char>();
    var operators = new Stack<char>();

    foreach (var c in s)
    {
        if (_operators.ContainsKey(c))
        {
            while (operators.Count != 0 && ComparePrecedence(operators.Peek(), c) >= 0)
                Eval();
            operators.Push(c);
        }
        else if (c == '(')
        {
            operators.Push(c);
        }
        else if (c == ')')
        {
            while (operators.Peek() != '(')
                Eval();
            operators.Pop();
        }
        else if (char.IsDigit(c))
        {
            operands.Push(c);
        }
    }

    while (operators.Count > 0) Eval();

    return operands.Peek() - '0';

    void Eval()
    {
        var n2 = operands.Pop() - '0';
        var n1 = operands.Pop() - '0';
        var opr = operators.Pop();
        var result = (char) (_operators[opr](n1, n2) + '0');
        operands.Push(result);
    }
}

private readonly Dictionary<char, Func<int, int, int>> _operators = new Dictionary<char, Func<int, int, int>>
{
    {'+', (a, b) => a + b},
    {'-', (a, b) => a - b},
    {'*', (a, b) => a * b},
    {'/', (a, b) => a / b}
};

private readonly Dictionary<char, int> _precedence = new Dictionary<char, int>
{
    {'+', 1},
    {'-', 1},
    {'*', 2},
    {'/', 2}
};

private int ComparePrecedence(char c1, char c2)
{
    if (c1 == '(' || c1 == ')') return -1;
    return _precedence[c1] - _precedence[c2];
}

public override void Test()
{
    Calculate("2+3/3+1").Should().Be(4);
    Calculate("5/(2+3)+1").Should().Be(2);
    Calculate("1 + 1").Should().Be(2);
    Calculate("5-(3+1)/(6-5)").Should().Be(1);
}
```
