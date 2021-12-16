using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_15_02 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 15;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var positions = data.Select(x => x.Select(y => int.Parse(y.ToString())).ToList()).ToList();
            var replicationModifier = 5;

            var maxX = positions.Count * replicationModifier - 1;
            var maxY = positions[0].Count * replicationModifier - 1;

            HashSet<(int, int)> movementModifiers = new()
            {
                (0, 1), // Down
                (0, -1), // Up
                (1, 0), // Right
                (-1, 0)  // Left
            };

            var visited = new HashSet<(int, int)>();
            var costDictionary = new Dictionary<(int, int), long>();
            var queue = new PriorityQueue<(long, int, int), long>(); // <(cost, x, y), cost>
            queue.Enqueue((0, 0, 0), 0); // Start (don't count the value of first position

            while (queue.Count > 0)
            {
                var (cost, x, y) = queue.Dequeue();

                if (visited.Contains((x, y)))
                {
                    continue;
                }
                visited.Add((x, y));

                costDictionary[(x, y)] = cost;

                if (x == maxX
                    && y == maxY)
                {
                    break;
                }

                foreach (var (xMod, yMod) in movementModifiers)
                {
                    var nextX = x + xMod;
                    var nextY = y + yMod;

                    if (nextX < 0 || nextX > maxX) continue; // Check next X out of bounds
                    if (nextY < 0 || nextY > maxY) continue; // Check next Y out of bounds

                    var nextCost = cost + GetModifierOffsetCost(nextX, nextY, positions);
                    queue.Enqueue((nextCost, nextX, nextY), nextCost);
                }
            }

            var minCost = costDictionary[(maxX, maxY)];

            return minCost.ToString();
        }

        /// <summary>
        /// Calculate the expected cost depending on the initial array value and the modified position.
        /// </summary>
        private int GetModifierOffsetCost(int x, int y, List<List<int>> positions)
        {
            var cost = positions[x % positions.Count][y % positions[0].Count]
                + x / positions.Count     // Floor division
                + y / positions[0].Count; // Floor division

            cost = (cost - 1) % 9 + 1; // Adjust for rollover when 9; 
            return cost;
        }
    }


}