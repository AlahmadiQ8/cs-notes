using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public static class Utils
    {
        public static string ToCommaSeparatedString(this int[] nums)
        {
            var foo = new List<int>(nums);
            return string.Join(',', foo.Select(n => n.ToString()));
        }
        public static string ToConcatenated(this IList<char> chars)
        {
            return new string(chars.ToArray());
        }
    }
}
