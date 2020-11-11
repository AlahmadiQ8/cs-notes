package com.company;

import java.security.KeyPair;
import java.util.*;

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
