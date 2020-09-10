using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using FluentAssertions;

namespace Algorithms
{
    public class Solution : AbstractSolution
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums.Length == 0) return new int[0];
            if (k == 1) return nums;
            var list = new LinkedList<int>();
            var result = new int[nums.Length - k + 1];
            
            for (var i = 0; i < k; i++)
            {
                CleanDeque(i);
                list.AddLast(i);
            }

            result[0] = nums[list.First()];

            for (var i = k; i < nums.Length; i++)
            {
                CleanDeque(i);
                list.AddLast(i);
                result[i - k + 1] = nums[list.First()];
            }

            return result;

            void CleanDeque(int i)
            {
                if (list.Count > 0 && list.First() == i - k) list.RemoveFirst();

                while (list.Count > 0 && nums[i] > nums[list.Last()]) list.RemoveLast();
            }
        }

        public override void Test()
        {
            MaxSlidingWindow(new[] {1,3,1,2,0,5}, 3).LogArray();
            MaxSlidingWindow(new[] {1,3,1,2,0,5}, 3).Should().BeEquivalentTo(new []{3, 3, 2, 5});

        }
    }
}