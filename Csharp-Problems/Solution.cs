using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace Algorithms
{
    public class Solution : AbstractSolution
    {
        public string AlienOrder(string[] words)
        {
            var adjList = new Dictionary<char, IList<char>>();
            var result = "";
            var state = new Dictionary<char, State>();

            // Step 0: add all letters to the graph
            foreach (var word in words)
            {
                foreach (var c in word)
                {
                    adjList[c] = new List<char>();
                    state[c] = State.Unvisited;
                }
            }

            // Step 1: add edges        
            for (var i = 0; i < words.Length - 1; i++)
            {
                var word1 = words[i];
                var word2 = words[i + 1];

                if (word1.Length > word2.Length && word1.StartsWith(word2))
                    return "";

                for (var j = 0; j < Math.Min(word1.Length, word2.Length); j++)
                {
                    if (word1[j] != word2[j])
                    {
                        adjList[word2[j]].Add(word1[j]);
                        break;
                    }
                }
            }

            // Step 2: Dfs
            foreach (var c in adjList.Keys)
                if (state[c] == State.Unvisited && !DepthFirst(c)) return "";
            
            return result;

            bool DepthFirst(char node)
            {
                state[node] = State.Visiting;

                foreach (var nei in adjList[node])
                {
                    if (state[nei] == State.Visiting) return false;
                    if (state[nei] == State.Unvisited && !DepthFirst(nei))
                    {
                        return false;
                    }
                }

                result = result + node;
                state[node] = State.Visited;
                return true;
            }
        }

        private enum State
        {
            Unvisited,
            Visited,
            Visiting
        }

        public override void Test()
        {
            AlienOrder(new[]
            {
                "aac",
                "aabb",
                "aaba"
            }).Should().Be("cba");
            AlienOrder(new[] {"wrt", "wrf", "er", "ett", "rftt"}).Should().Be("wertf");
            // AlienOrder(new []{"z" , "x"})
        }
    }
}