## Problem 

https://leetcode.com/problems/path-sum-iii/

Print all paths equal to given sum

## Solution 

* Cummulative Sum 

```csharp
private IDictionary<int, int> _map = new Dictionary<int, int>();
private int _sum;
private int _count;

public int PathSum(TreeNode root, int sum)
{
    _sum = sum;
    PreOrderTraversal(root, 0);
    return _count;
}

private void PreOrderTraversal(TreeNode? node, int currentSum)
{
    if (node == null) return;

    currentSum += node.val;

    if (currentSum == _sum) _count++;

    if (_map.ContainsKey(currentSum - _sum))
        _count += _map[currentSum - _sum];

    _map[currentSum] = _map.ContainsKey(currentSum) ? _map[currentSum] + 1 : 1;

    PreOrderTraversal(node.left, currentSum);
    PreOrderTraversal(node.right, currentSum);

    Console.WriteLine(string.Join(',', _map));

    _map[currentSum] = _map[currentSum] - 1;
}
```
