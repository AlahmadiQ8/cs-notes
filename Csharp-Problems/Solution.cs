using System;
using FluentAssertions;

namespace Algorithms
{
    public class Solution : AbstractSolution
    {
        public int FindSquareRoot(int num)
        {
            if (num == 0) return 0;
            if (num == 1) return 1;

            var low = 2;
            var high = num;
            while (low <= high)
            {
                var mid = low + (high - low) / 2;
                var midTimesMid = mid * mid;
                if (midTimesMid > num)
                {
                    high = mid - 1;
                } else if (midTimesMid < num)
                {
                    if (Math.Pow(mid + 1, 2) > num) return mid;
                    low = mid + 1;
                }
                else return mid;
            }

            return low; 
        }

        public override void Test()
        {
            FindSquareRoot(16).Should().Be(4);
            FindSquareRoot(36).Should().Be(6);
            FindSquareRoot(9).Should().Be(3);
            FindSquareRoot(10).Should().Be(3);
            FindSquareRoot(4).Should().Be(2);
            // FindSquareRoot(4).Should().Be(2);
        }
    }
}