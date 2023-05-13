# [Build an Array With Stack Operations](https://leetcode.com/problems/build-an-array-with-stack-operations/description/)

You are given an integer array target and an integer n.

You have an empty stack with the two following operations:

* "Push": pushes an integer to the top of the stack.
* "Pop": removes the integer on the top of the stack.

You also have a stream of the integers in the range [1, n].

Use the two stack operations to make the numbers in the stack (from the bottom to the top) equal to target. You should follow the following rules:

* If the stream of the integers is not empty, pick the next integer from the stream and push it to the top of the stack.
* If the stack is not empty, pop the integer at the top of the stack.
* If, at any moment, the elements in the stack (from the bottom to the top) are equal to target, do not read new integers from the stream and do not do more operations on the stack.
*
Return the stack operations needed to build target following the mentioned rules. If there are multiple valid answers, return any of them.

## Solution

```csharp
// iterative
public class Solution
{
    public IList<string> BuildArray(int[] target, int n)
    {
        var result = new List<string>();

        int index = 0;
        int currentN = 1;

        while (index < target.Length && currentN <= n)
        {
            result.Add("Push");
            if (currentN < target[index])
                result.Add("Pop");
            else
                index = index + 1;
            currentN = currentN + 1;
        }

        return result;
    }
}

// recursive
public class Solution
{
    public IList<string> BuildArray(int[] target, int n)
    {
        var result = new List<string>();
        Backtrack(0, 1);
        return result;

        void Backtrack(int index, int currentN)
        {
            if (index == target.Length || currentN > n)
                return;

            result.Add("Push");

            if (currentN < target[index])
            {
                result.Add("Pop");
                Backtrack(index, currentN + 1);
            }
            else
                Backtrack(index + 1, currentN + 1);
        }
    }
}
```
