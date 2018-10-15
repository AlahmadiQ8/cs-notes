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
