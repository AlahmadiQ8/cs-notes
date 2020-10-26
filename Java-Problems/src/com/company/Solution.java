package com.company;

import java.security.KeyPair;
import java.util.*;

public class Solution extends AbstractSolution {

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


    @Override
    public void runTest() {

    }
}
