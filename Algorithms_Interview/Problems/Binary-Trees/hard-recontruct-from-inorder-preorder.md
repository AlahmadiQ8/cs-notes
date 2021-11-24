## Problem 

```
Given inorder and preorder traversals of a binary tree, reconstruct the binary 
tree.
```

## Solution 

https://interviewcamp.io/courses/101687/lectures/3312093

```csharp
public TreeNode BuildTree(int[] preorder, int[] inorder)
{
    var inOrderLookup = new Dictionary<int, int>();
    for (var i = 0; i < inorder.Length; i++)
    {
        inOrderLookup[inorder[i]] = i;
    }

    return ConstructTree(0, preorder.Length - 1, 0, inorder.Length - 1);

    TreeNode ConstructTree(int preStart, int preEnd, int inStart, int inEnd)
    {
        if (preStart > preEnd || inStart > inEnd) return null;

        var node = new TreeNode(preorder[preStart]);
        var k = inOrderLookup[preorder[preStart]];

        node.left = ConstructTree(preStart + 1, preStart + (k - inStart), inStart, k - 1);
        node.right = ConstructTree(preStart + (k - inStart) + 1, preEnd, k + 1, inEnd);
        return node;
    }
}
```
