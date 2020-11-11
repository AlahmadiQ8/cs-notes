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
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null) return head;

            var dummy = new ListNode(-1);
            dummy.next = head;
            var prev = dummy;

            while (head != null && head.next != null)
            {
                var first = head;
                var second = head.next;

                prev.next = second;
                first.next = second.next;
                second.next = first;

                prev = first;
                head = first.next;
            }

            return dummy.next;
        }

        public override void Test()
        {
        }
    }
}