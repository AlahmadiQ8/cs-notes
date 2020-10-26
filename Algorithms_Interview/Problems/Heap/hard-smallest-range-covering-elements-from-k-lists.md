## Problem

```
You have k lists of sorted integers in non-decreasing order. Find the smallest range that includes at least one number from each of the k lists.

We define the range [a, b] is smaller than range [c, d] if b - a < d - c or a < c if b - a == d - c.

Example 1:

Input: nums = [[4,10,15,24,26],[0,9,12,20],[5,18,22,30]]
Output: [20,24]
Explanation: 
List 1: [4, 10, 15, 24,26], 24 is in range [20,24].
List 2: [0, 9, 12, 20], 20 is in range [20,24].
List 3: [5, 18, 22, 30], 22 is in range [20,24].
Example 2:

Input: nums = [[1,2,3],[1,2,3],[1,2,3]]
Output: [1,1]
Example 3:

Input: nums = [[10,10],[11,11]]
Output: [10,11]
Example 4:

Input: nums = [[10],[11]]
Output: [10,11]
Example 5:

Input: nums = [[1],[2],[3],[4],[5],[6],[7]]
Output: [1,7]
```

## Solution

| Complexity | Big O |
|------------|-------|
| Time       | O(n∗log(m))  |
| Space      | O(m)  |

```java
public int[] smallestRange(List<List<Integer>> nums) {
    PriorityQueue<LinkedList<Integer>> heapMin = new PriorityQueue<>(nums.size(), Comparator.comparing(LinkedList::getFirst));

    int min = Integer.MAX_VALUE;
    int max = Integer.MIN_VALUE;
    int diff = Integer.MAX_VALUE;
    for (List<Integer> n : nums) {
        var list = new LinkedList<>(n);
        heapMin.add(list);
        if (list.getFirst() > max) {
            max = list.getFirst();
        }
    }

    int lastMax = max;
    while (!heapMin.peek().isEmpty()) {
        int curMin = heapMin.peek().getFirst();
        if (lastMax - curMin < diff) {
            min = curMin;
            max = lastMax;
            diff = max - min;
        }

        var removed = heapMin.remove();
        removed.removeFirst();
        if (removed.isEmpty()) break;

        if (removed.getFirst() > lastMax) lastMax = removed.getFirst();
        heapMin.add(removed);
    }
    return new int[]{min, max};
}
```
