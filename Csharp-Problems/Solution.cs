using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace Algorithms
{
    public class Solution : AbstractSolution
    {
        private Dictionary<int, IList<int>> _cols = new Dictionary<int, IList<int>>();

        public IList<IList<int>> VerticalOrder(TreeNode root)
        {
            if (root == null) return new List<IList<int>>();

            var queue = new Queue<(TreeNode node, int colIndex)>();
            queue.Enqueue((root, 0));
            var minIndex = int.MaxValue;
            var maxIndex = int.MinValue;

            while (queue.Count != 0)
            {
                var (cur, index) = queue.Dequeue();
                if (!_cols.ContainsKey(index)) _cols[index] = new List<int>();
                _cols[index].Add(cur.val);

                minIndex = Math.Min(minIndex, index);
                maxIndex = Math.Max(maxIndex, index);

                if (cur.left != null) queue.Enqueue((cur.left, index - 1));
                if (cur.right != null) queue.Enqueue((cur.right, index + 1));
            }

            var result = new List<IList<int>>();
            for (var i = minIndex; i <= maxIndex; i++)
            {
                result.Add(_cols[i]);
            }

            return result;
        }


        public override void Test()
        {
            TreeNode? root = new TreeNode
            {
                val = 3,
                left = new TreeNode(9),
                right = new TreeNode
                {
                    val = 20,
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }
            };
            var res = VerticalOrder(root);
            foreach (var re in res)
            {
                re.LogArray();
            }
        }
    }
}