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
    }
}
