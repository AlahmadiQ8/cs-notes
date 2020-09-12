using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Net.WebSockets;
using FluentAssertions;

namespace Algorithms
{
    public class Solution : AbstractSolution
    {
        public int CoinChange(int[] coins, int amount)
        {
            var max = amount + 1;

            var dp = new int[amount + 1];

            Array.Fill(dp, max);

            dp[0] = 0;
            for (var i = 1; i <= amount; i++)
            {
                foreach (var coin in coins)
                {
                    if (coin <= i)
                        dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                }
            }

            return dp[amount] > amount ? -1 : dp[amount];
        }

        public override void Test()
        {
            // LengthOfLIS(new[] {10, 9, 2, 5, 3, 7, 101, 18}).Should().Be(4);
            CoinChange(new[] {1, 3, 5}, 8);
        }
    }
}