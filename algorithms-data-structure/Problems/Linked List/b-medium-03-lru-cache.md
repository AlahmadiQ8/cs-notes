---
tags:
  - review
---

# [LRU Cache](https://leetcode.com/problems/lru-cache/description/)

Design a data structure that follows the constraints of a [Least Recently Used (LRU) cache](https://en.wikipedia.org/wiki/Cache_replacement_policies#LRU).

## Technique

- Linked Hash Map

## Solution

```csharp
public class LRUCache
{
    private int _capacity;
    private readonly Dictionary<int, LinkedListNode<(int key, int value)>> _hash = new();
    private readonly LinkedList<(int key, int value)> _linkedList = new();

    public LRUCache(int capacity)
    {
        _capacity = capacity;
    }

    public int Get(int key)
    {
        if (!_hash.ContainsKey(key))
            return -1;

        var node = _hash[key];
        MoveToFirst(node);

        return node.Value.value;
    }

    public void Put(int key, int value)
    {
        LinkedListNode<(int key, int value)> node;
        if (_hash.ContainsKey(key))
        {
            node = _hash[key];
            node.Value = (key, value);
            MoveToFirst(node);
        }
        else
        {
            node = new LinkedListNode<(int key, int value)>((key, value));
            _hash[key] = node;
            _linkedList.AddFirst(node);
            if (_linkedList.Count > _capacity)
            {
                _hash.Remove(_linkedList.Last!.Value.key);
                _linkedList.RemoveLast();
            }
        }
    }

    private void MoveToFirst(LinkedListNode<(int key, int value)> node)
    {
        _linkedList.Remove(node);
        _linkedList.AddFirst(node);
    }
}
```
