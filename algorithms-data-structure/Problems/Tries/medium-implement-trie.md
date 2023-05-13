## Problem 

Implement​ ​a​ ​Trie​ ​with​ ​insertion,​ ​search​ ​and​ ​deletion​ ​operations.

## Solution 

```java
public class Trie {
  Node root;
  
  public Trie() {
    root = new Node();
  }
  public void insert(String word) {
    char[] ch = word.toCharArray();
    Node current = root;
    for (int i = 0; i < ch.length; i++) {
      if (!current.contains(ch[i]))
        current.addNode(ch[i]);
      current = current.getNode(ch[i]);
    }
    current.setWord(true);
  }
  public boolean hasPrefix(String prefix) {
    char[] ch = prefix.toCharArray();
    Node current = root;
    for (int i = 0; i < ch.length; i++) {
      if (!current.contains(ch[i]))
        return false;
      current = current.getNode(ch[i]);
    }
    return true;
  }
  public boolean hasWord(String word) {
    char[] ch = word.toCharArray();
    Node current = root;
    for (int i = 0; i < ch.length; i++) {
      if (!current.contains(ch[i]))
        return false;
      current = current.getNode(ch[i]);
    }
    return current.isWord();
  }
  public void delete(String word) {
    if (word == null || word.isEmpty())
      return;
    char[] ch = word.toCharArray();
    Node lastNodeWithMultipleChildren = null;
    char childToBreak = 0;
    Node current = root;
    // find last parent with multiple nodes
    for (int i = 0; i < ch.length; i++) {
      // get ith node
      if (!current.contains(ch[i])) // word not in trie
        return;
      current = current.getNode(ch[i]);
      if (i != ch.length - 1 && current.getMap().size() > 1) {
        lastNodeWithMultipleChildren = current;
        childToBreak = ch[i + 1];
      }
    }
    // process last node
    if (!current.isWord())
      return;
    current.setWord(false);
    // if last node has child, then there is another
    // word from there, don't delete any node.
    if (current.getMap().size() > 0) {
      return;
    }
    if (lastNodeWithMultipleChildren != null) {
      lastNodeWithMultipleChildren.getMap().remove(childToBreak);
    } else {
      root.getMap().remove(ch[0]);
    }
  }
}
public class Node {
  HashMap < Character, Node > map;
  boolean isWord;
  public Node() {
    map = new HashMap < > ();
    isWord = false;
  }
  public boolean isWord() {
    return isWord;
  }
  public void setWord(boolean isWord) {
    this.isWord = isWord;
  }
  public boolean contains(char ch) {
    return map.containsKey(ch);
  }
  public void addNode(char ch) {
    if (!map.containsKey(ch)) {
      map.put(ch, new Node());
    }
  }
  public Node getNode(char ch) {
    return map.get(ch);
  }
  public HashMap < Character, Node > getMap() {
    return map;
  }
}
```
