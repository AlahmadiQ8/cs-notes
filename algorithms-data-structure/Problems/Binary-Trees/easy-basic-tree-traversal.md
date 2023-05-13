## Problem

```
In order, pre order, post order traversal
```

## Solution

```csharp
void InOrderTraversal(TreeNode? node)
{
    if (node == null) return;
    InOrderTraversal(node.left);
    Console.WriteLine(node.val);
    InOrderTraversal(node.right);
}

void PreOrderTraversal(TreeNode? node)
{
    if (node == null) return;
    Console.WriteLine(node.val);
    PreOrderTraversal(node.left);
    PreOrderTraversal(node.right);
}

void PostOrderTraversal(TreeNode? node)
{
    if (node == null) return;
    PostOrderTraversal(node.left);
    PostOrderTraversal(node.right);
    Console.WriteLine(node.val);
}

void InOrderTraversalIterative(TreeNode? root)
{
    var stack = new Stack<TreeNode>();
    var node = root;

    while (node != null || stack.Count != 0)
    {
        if (node != null)
        {
            stack.Push(node);
            node = node.left;
        }
        else
        {
            node = stack.Pop();
            Console.WriteLine(node.val);
            node = node.right;
        }
    }
}

public override void Test()
{
    var n4 = new TreeNode(4);
    var n2 = new TreeNode(2);
    var n1 = new TreeNode(1);
    var n3 = new TreeNode(3);
    var n6 = new TreeNode(6);
    var n5 = new TreeNode(5);
    var n7 = new TreeNode(7);

    n4.left = n2;
    n2.left = n1;
    n2.right = n3;
    n4.right = n6;
    n6.left = n5;
    n6.right = n7;

    var root = n4;

    // InOrderTraversal(root);
    // PreOrderTraversal(root);
    // PostOrderTraversal(root);
    InOrderTraversalIterative(root);
}
```
