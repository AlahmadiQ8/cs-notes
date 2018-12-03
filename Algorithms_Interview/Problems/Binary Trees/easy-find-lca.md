## Problem

```
Given​ ​2​ ​nodes​ ​of​ ​a​ ​tree,​ ​find​ ​their​ ​lowest​ common​​ancestor​ ​(LCA).​ ​Assume​ ​that​ ​each​ ​node has​ ​a​ ​parent​ ​pointer.
```

## Solution 


https://interviewcamp.io/courses/101687/lectures/3312095

for binary search tree see: https://interviewcamp.io/courses/101687/lectures/3312698

```java
public static Node findLCA(Node a, Node b) {
  if (a == null || b == null)
    throw new NullPointerException("Input node is null");
  /*
   * Notice we used pointers to 'a' (references in Java)
   * because if we had modified 'a', we would have lost
   * node.
   */
  Node aPointer = a, bPointer = b;
  // find aDepth
  int aDepth = -1;
  while (aPointer != null) {
    aDepth++;
    aPointer = aPointer.getParent();
  }
  // find bDepth
  int bDepth = -1;
  while (bPointer != null) {
    bDepth++;
    bPointer = bPointer.getParent();
  }
  // Raise the lower node
  Node x = aDepth > bDepth ? a : b;
  for (int i = 0; i < Math.abs(aDepth - bDepth); i++) {
    x = x.getParent();
  }
  // Raise both until they meet (at LCA)
  Node y = aDepth > bDepth ? b : a; // the node that wasn't raised
  while (x != y) {
    x = x.getParent();
    y = y.getParent();
  }
  return x; // can return either x or y here
}

/*
* Helper code. Implement only if the interviewer wants you to.
*/
public class Node {
  Node left;
  Node right;
  Node parent;
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
  public Node getParent() {
    return parent;
  }
  public void setParent(Node parent) {
    this.parent = parent;
  }
}
```
