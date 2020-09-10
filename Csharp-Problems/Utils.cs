using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public static class Utils
    {
        public static string ToCommaSeparatedString(this IEnumerable<int> nums)
        {
            var foo = new List<int>(nums);
            return string.Join(',', foo.Select(n => n.ToString()));
        }

        public static string ToConcatenated(this IList<char> chars)
        {
            return new string(chars.ToArray());
        }

        public static void LogArray(this IEnumerable<int> arr)
        {
            Console.WriteLine(arr.ToCommaSeparatedString());
        }
        
        public static void LogArray<T>(this IEnumerable<T> arr)
        {
            Console.WriteLine(string.Join(',', arr));
        }

        public static void Log(this ListNode node)
        {
            var cur = node;
            var res = new List<int>();
            while (cur != null)
            {
                res.Add(cur.val);
                cur = cur.next;
            }
            res.LogArray();
        }
        
        public static ListNode Last(ListNode? node)
        {
            if (node == null) return null;
            if (node.next == null) return node;
            var cur = node;
            while (cur.next != null) cur = cur.next;
            return cur;
        }

        public static ListNode? AddLast(ListNode? head, ListNode? node)
        {
            if (node == null) return head;
            if (head == null) return node;
            var cur = head;
            while (cur.next != null) cur = cur.next;
            cur.next = node;
            return head;
        }
    }
}
