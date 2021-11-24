## Problem 

```
Given​ ​a​ ​BST​ ​which​ ​can​ ​contain​ ​duplicate​ ​elements,​ ​find​ ​the​ ​first​ ​occurrence​ ​of​ ​a​ ​number​ ​N. 
```

## Solution 

```java
public static Node findFirstOccurence(Node root, int target) {
  Node current = root;
  Node result = null;
  while (current != null) {
	  if (current.getValue() > target) {
		  current = current.getLeft();
	  } else if (current.getValue() < target) {
		  current = current.getRight();
	  } else {
		  result = current;
		  current = current.getLeft();
	  }
  }
  return result;
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
