## Problem

Given a sorted array, build a balanced Binary Search Tree with the elements of
the array.

## Solution 

```java
public static TreeNode getTree(int[] a, int start, int end) {
  if (start > end || oob(a, start) || oob(a, end))
    return null;
  int mid = start + (end - start) / 2;
  TreeNode root = new TreeNode(a[mid]);
  root.setLeft(getTree(a, start, mid - 1));
  root.setRight(getTree(a, mid + 1, end));
  return root;
}
/*
* Helper code. Implement only if the interviewer wants you to.
*/
private static boolean oob(int[] a, int index) {
  return index < 0 || index >= a.length;
}
public static class TreeNode {
  TreeNode left;
  TreeNode right;
  int value;
  public TreeNode(int value) {
    super();
    this.value = value;
  }
  public TreeNode getLeft() {
    return left;
  }
  public void setLeft(TreeNode left) {
    this.left = left;
  }
  public TreeNode getRight() {
    return right;
  }
  public void setRight(TreeNode right) {
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
