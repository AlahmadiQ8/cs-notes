## Problem

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

```java
public static int evaluate(char[] expression) {
  if (expression == null || expression.length == 0)
    return 0;

  Stack < Character > operand = new Stack < > ();
  Stack < Character > operator = new Stack < > ();

  for (char ch: expression) {
    if (isOperand(ch))
      operand.push(ch);
    else if (isOperator(ch)) {
      while (!operator.isEmpty() && precedence(operator.peek()) >= precedence(ch)) {
        process(operator, operand);
      }
      operator.push(ch);
    }
  }
  while (!operator.isEmpty()) {
    process(operator, operand);
  }
  return operand.pop();
}
/*
* Helper functions. Ask interviewer if they want you to implement.
*/
private static boolean isOperand(char ch) {
  return (ch >= '0') && (ch <= '9');
}

private static boolean isOperator(char ch) {
  return ch == '+' || ch == '-' || ch == '*' || ch == '/';
}

private static int precedence(char ch) {
  switch (ch) {
    case '/':
    case '*':
      return 2;
    case '+':
    case '-':
      return 1;
    default:
      throw new IllegalArgumentException("Invalid operator: " +
        ch);
  }
}

private static void process(Stack < Character > operator, Stack < Character > operand) {
  int num2 = Character.getNumericValue(operand.pop());
  int num1 = Character.getNumericValue(operand.pop());
  char op = operator.pop();
  int result = 0;
  switch (op) {
    case '/':
      result = num1 / num2;
      break;
    case '*':
      result = num1 * num2;
      break;
    case '+':
      result = num1 + num2;
      break;
    case '-':
      result = num1 - num2;
      break;
  }
  operand.push((char)('0' + result));
}
```


2 * (1 - 1) = 2

            1 + 3 / 3 - 1
operands    1, 1
operators   +, 

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
        else if (IsOperand(c))
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

private static bool IsOperand(char input) => input >= '0' && input <= '9';

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
}
```
