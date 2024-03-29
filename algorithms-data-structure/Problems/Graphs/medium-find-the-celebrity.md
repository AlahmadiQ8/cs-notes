## Problem

https://leetcode.com/problems/find-the-celebrity/

```
Suppose you are at a party with n people (labeled from 0 to n - 1) and among them, there may exist one celebrity. The definition of a celebrity is that all the other n - 1 people know him/her but he/she does not know any of them.

Now you want to find out who the celebrity is or verify that there is not one. The only thing you are allowed to do is to ask questions like: "Hi, A. Do you know B?" to get information of whether A knows B. You need to find out the celebrity (or verify there is not one) by asking as few questions as possible (in the asymptotic sense).

You are given a helper function bool knows(a, b) which tells you whether A knows B. Implement a function int findCelebrity(n). There will be exactly one celebrity if he/she is in the party. Return the celebrity's label if there is a celebrity in the party. If there is no celebrity, return -1.
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(N)  |
| Space      | O(1)  |

```csharp
public int FindCelebrity(int n) {   
    var candidate = 0;
    for (var i = 0; i < n; i++) {
        if (Knows(candidate, i)) candidate = i;
    }
    
    if (IsCelebrity(candidate, n)) return candidate;
    return -1;
    
}

private bool IsCelebrity(int id, int n) {
    for (var j = 0; j < n; j++) {
        if (j == id) continue;
        if (Knows(id, j) || !Knows(j, id)) return false;
    }
    return true;
}
```
