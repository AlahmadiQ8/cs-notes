## Problem

https://leetcode.com/problems/binary-tree-level-order-traversal/

```
Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).

For example:
Given binary tree [3,9,20,null,null,15,7],
    3
   / \
  9  20
    /  \
   15   7
return its level order traversal as:
[
  [3],
  [9,20],
  [15,7]
]
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(N)  |
| Space      | O(N)  |

```csharp
public IList<IList<int>> LevelOrder(TreeNode root)
{
    if (root == null) return new List<IList<int>>();

    var result = new List<IList<int>>();
    var queue = new Queue<(TreeNode, int)>();
    queue.Enqueue((root, 0));
    while (queue.Count != 0)
    {
        var (current, level) = queue.Dequeue();

        if (level < result.Count)
            result[level].Add(current.val);
        else
            result.Add(new List<int> {current.val});

        if (current.left != null) queue.Enqueue((current.left, level + 1));
        if (current.right != null) queue.Enqueue((current.right, level + 1));
    }

    return result;
}
```
