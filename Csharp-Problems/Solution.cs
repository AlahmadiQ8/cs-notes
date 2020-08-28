using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace Algorithms
{
    public class Solution : AbstractSolution
    {
        public void MoveZerosToStart(int[] arr) {
            if (arr == null || arr.Length == 0) return;
            var left = 0;
            var cur = 0;
            while (cur < arr.Length) {
                if (arr[cur] == 0) Swap(arr, left++, cur++);
                else cur++;
            }
        }
        public void MoveZerosToEnd(int[] arr) {
            if (arr == null || arr.Length == 0) return;

            var right = arr.Length - 1;
            var cur = arr.Length - 1;
            while (cur >= 0) {
                if (arr[cur] == 0) Swap(arr, right--, cur--);
                else cur--;
            }
        }

        public override void Test()
        {
            var input = new[] {3, 0, 2, 0, 0, 4, 4, 6, 4, 4, 0};
            MoveZerosToStart(input);
            Console.WriteLine(input.ToCommaSeparatedString());
            MoveZerosToEnd(input);
            Console.WriteLine(input.ToCommaSeparatedString());
        }
    }
}