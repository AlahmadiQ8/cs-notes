## Problem

https://leetcode.com/problems/smallest-range-covering-elements-from-k-lists/solution/

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
public class Solution extends AbstractSolution {
    class Pair {
        int list_index;
        int cur_index;

        public Pair(int list_index, int cur_index) {
            this.list_index = list_index;
            this.cur_index = cur_index;
        }
    }

    public int[] smallestRange(List<List<Integer>> nums) {
        PriorityQueue<Pair> heapMin = new PriorityQueue<>(nums.size(), Comparator.comparingInt(a -> nums.get(a.list_index).get(a.cur_index)));

        int min = Integer.MAX_VALUE;
        int max = Integer.MIN_VALUE;
        int diff = Integer.MAX_VALUE;
        for (var i = 0; i < nums.size(); i++) {
            heapMin.add(new Pair(i, 0));
            max = Math.max(max, nums.get(i).get(0));
        }

        int last_max = max;
        while (nums.get(heapMin.peek().list_index).get(heapMin.peek().cur_index) < nums.get(heapMin.peek().list_index).size()) {
            Pair curMin = heapMin.remove();
            int value = nums.get(curMin.list_index).get(curMin.cur_index);
            if (last_max - value < diff) {
                min = value;
                max = last_max;
                diff = max - min;
            }
            var next = new Pair(curMin.list_index, curMin.cur_index + 1);
            var next_value = nums.get(next.list_index).get(next.cur_index);

            if (next_value > last_max) last_max = next_value;
            heapMin.add(next);
        }
        return new int[]{min, max};
    }


    @Override
    public void runTest() {

    }
}
```
