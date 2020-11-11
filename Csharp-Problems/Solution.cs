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
        public string DecodeString(string s)
        {
            return Backtrack(s, 0, s.Length - 1, "");
        }

        private string Backtrack(string s, int start, int end, string result)
        {
            if (start > end || s[start] == ']') return result;
            if (!char.IsDigit(s[start]))
                return Backtrack(s, start + 1, end, result + s[start]);

            var times = s[start] - '0';
            while (start + 1 < s.Length && char.IsDigit(s[start + 1]))
            {
                start++;
                times = 10 * times + (s[start] - '0');
            }

            var opening = start + 1;
            var closing = start + 1;
            var count = 1;
            while (count != 0)
            {
                closing++;
                if (s[closing] == '[') count++;
                else if (s[closing] == ']') count--;
            }

            var curResult = Backtrack(s, opening + 1, closing - 1, "");
            curResult = string.Concat(Enumerable.Repeat(curResult, times));
            return Backtrack(s, closing + 1, s.Length - 1, result + curResult);
        }

        public override void Test()
        {
            DecodeString("3[a2[c]]").Should().Be("accaccacc");
            DecodeString("3[a]2[bc]").Should().Be("aaabcbc");
        }
    }
}