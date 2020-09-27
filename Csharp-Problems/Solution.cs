using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Xml.XPath;
using FluentAssertions;

namespace Algorithms
{
    public class Solution : AbstractSolution
    {
        public bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;

            return IsBalancedHelper(root) != -1 ? true : false;

            int IsBalancedHelper(TreeNode node)
            {
                if (node == null) return 0;

                var left = IsBalancedHelper(node.left);
                var right = IsBalancedHelper(node.right);

                if (left == -1 || right == -1 || Math.Abs(left - right) > 1) return -1;

                return 1 + Math.Max(left, right);
            }
        }

        public override void Test()
        {
            var n4 = new TreeNode(4);
            var n2 = new TreeNode(2);
            var n1 = new TreeNode(1);
            var n3 = new TreeNode(3);
            var n6 = new TreeNode(6);
            var n5 = new TreeNode(5);
            var n7 = new TreeNode(7);

            n4.left = n2;
            n2.left = n1;
            n2.right = n3;
            n4.right = n6;
            n6.left = n5;
            n6.right = n7;

            var root = n4;

            // InOrderTraversal(root);
            // PreOrderTraversal(root);
            // PostOrderTraversal(root);
            InOrderTraversalIterative(root);
            string.Join()
        }
    }
}