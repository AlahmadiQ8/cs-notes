using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Xml.XPath;
using FluentAssertions;

namespace Algorithms
{
    public class Solution : AbstractSolution
    {
        private readonly Random _rand = new Random();

        public int MinMeetingRooms(int[][] intervals)
        {
            if (intervals.Length == 0) return 0;
            var points = new List<(int time, bool isStart)>();
            foreach (var interval in intervals)
            {
                var start = (interval[0], true);
                var end = (interval[1], false);
                points.Add(start);
                points.Add(end);
            }

            points.Sort((a, b) =>
            {
                if (a.time == b.time)
                {
                    if (!a.isStart && b.isStart) return -1;
                    if (a.isStart && !b.isStart) return 1;
                }

                return a.time - b.time;
            });

            var maxRooms = 0;
            var count = 0;
            var last = 0;
            for (var i = 0; i < points.Count; i++)
            {
                if (points[i].isStart) count++;
                else count--;
                maxRooms = Math.Max(maxRooms, count);
            }

            return maxRooms;
        }

        public override void Test()
        {
            // var hs = MD5.Create();
            // var buffer = hs.ComputeHash(Encoding.UTF8.GetBytes("omg"));
            // var endoded = Convert.ToBase64String(buffer);
        }
    }
}