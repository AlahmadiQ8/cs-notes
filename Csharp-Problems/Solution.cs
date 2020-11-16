using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using FluentAssertions;

namespace Algorithms
{
    public class Solution : AbstractSolution
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums.Length == 0) return new int[0];
            if (k == 1) return nums;
            var max = new LinkedList<int>();
            var queue = new int[nums.Length - k + 1];
    
            for (var i = 0; i < k; i++)
            {
                if (max.Count > 0 && max.First() == i - k) max.RemoveFirst();
                while (max.Count > 0 && nums[i] > nums[max.Last()]) max.RemoveLast();
                max.AddLast(i);
            }

            queue[0] = nums[max.First()];

            for (var i = k; i < nums.Length; i++)
            {
                if (max.Count > 0 && max.First() == i - k) max.RemoveFirst();
                while (max.Count > 0 && nums[i] > nums[max.Last()]) max.RemoveLast();
                max.AddLast(i);
                queue[i - k + 1] = nums[max.First()];
            }

            return queue;
        }

        public override void Test()
        {
            // int.
        }
    }
}