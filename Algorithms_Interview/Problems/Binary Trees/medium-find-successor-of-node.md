## Problem 

https://leetcode.com/problems/inorder-successor-in-bst/

Finding the successor of a Binary Search Tree (BST) is useful in several
problems.

Lets say you wanted to find all the nodes greater than a value X in a BST. You
find the first node greater than X using the Record and Move On technique. Then,
you keep finding Successors of the node until there are no nodes left.

```
Find​ ​Successor:​ ​Given​ ​a​ ​Node​ ​N​ ​in​ ​a​ ​BST,​ ​find​ ​the​ ​node​
​with​ ​the​ ​next​ ​largest​ ​value,​ ​also known​ ​as​ ​the​ ​successor​ ​of​
​the​ ​node. 
```

## Solution 

1. If the node has a right child: The successor will be the left most node of
   the right subtree.
2. If there is no right child: The successor for the first parent on the right.
   To find that, perform a search for the node. We traverse the tree from root
   to the node and find the ancestor to the right of the node. This is very
   similar to the Record and Move On technique.
3. If there is no right child or no parent on the right: this is the last node
   of the tree, there is no successor.

```java
public static Node findSuccessor(Node n, Node root) {
  if (n.getRight() != null) {
      Node current = n.getRight();
      while (current.getLeft() != null)
          current = current.getLeft();
      return current;
  } else {
      Node current = root, successor = null;
      while (current != null) {
          if (current.getValue() > n.getValue()) {
              successor = current;
              current = current.getLeft();
          } else if (current.getValue() < n.getValue()) {
              current = current.getRight();
          } else if (current == n) {
              break;
          }
      }
      return successor;
  }
}
/*
* Helper code. Implement only if the interviewer wants you to.
*/
public class Node {
  Node left;
  Node right;
  int value;
  public Node() {
      super();
  }
  public Node getLeft() {
      return left;
  }
  public void setLeft(Node left) {
      this.left = left;
  }
  public Node getRight() {
      return right;
  }
  public void setRight(Node right) {
      this.right = right;
  }
  public int getValue() {
      return value;
  }
  public void setValue(int value) {
      this.value = value;
  }
}
```


```csharp
public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
{
    TreeNode successor = null;
    var cur = p;

    if (cur.right != null)
    {
        cur = cur.right;
        while (cur.left != null) cur = cur.left;
        return cur;
    }

    cur = root;
    while (cur != null)
    {
        if (p.val < cur.val)
        {
            successor = cur;
            cur = cur.left;
        }
        else if (p.val > cur.val)
            cur = cur.right;
        else
            break;
    }

    return successor;
}
```
