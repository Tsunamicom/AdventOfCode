using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_09_02 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 9;
        public int ChallengePart => 2;
        public string ResolveChallenge(List<string> data)
        {
            var intData = data.Select(x => x.Select(y => int.Parse(y.ToString())).ToList()).ToList();

            var basinSizes = new List<long>();

            var visited = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < intData.Count; i++)
            {
                for (int j = 0; j < intData[i].Count; j++)
                {
                    var upModifier = Math.Max(0, i - 1);
                    var downModifier = Math.Min(intData.Count - 1, i + 1);
                    var leftModifier = Math.Max(0, j - 1);
                    var rightModifier = Math.Min(intData[i].Count - 1, j + 1);

                    var targetLocationHeight = intData[i][j];
                    var above = intData[upModifier][j];
                    var below = intData[downModifier][j];
                    var left = intData[i][leftModifier];
                    var right = intData[i][rightModifier];

                    // Can't all be the same
                    if (targetLocationHeight == above &&
                        targetLocationHeight == below &&
                        targetLocationHeight == left &&
                        targetLocationHeight == right)
                        continue;

                    // Must be lowest point, but not the same (see above)
                    if (targetLocationHeight <= above &&
                        targetLocationHeight <= below &&
                        targetLocationHeight <= left &&
                        targetLocationHeight <= right)
                    {
                        basinSizes.Add(WalkBasin(intData, visited, i, j, 0));
                    }
                }
            }

            var basinSizesTop3Aggregate = basinSizes.OrderBy(c => c).TakeLast(3).Aggregate((r, v) => r * v);

            return basinSizesTop3Aggregate.ToString();
        }

        private long WalkBasin(List<List<int>> intData, Dictionary<int, HashSet<int>> visited, int i, int j, long sum)
        {
            if (visited.TryGetValue(i, out var jHash))
            {
                if (jHash.Contains(j)) return sum;

                jHash.Add(j);
            }
            else
            {
                visited.Add(i, new HashSet<int>());
                visited[i].Add(j);
            }

            var targetLocationHeight = intData[i][j];
            if (targetLocationHeight == 9) return sum;

            sum++;

            var upModifier = Math.Max(0, i - 1);
            var downModifier = Math.Min(intData.Count - 1, i + 1);
            var leftModifier = Math.Max(0, j - 1);
            var rightModifier = Math.Min(intData[i].Count - 1, j + 1);

            sum = WalkBasin(intData, visited, upModifier, j, sum);
            sum = WalkBasin(intData, visited, downModifier, j, sum);
            sum = WalkBasin(intData, visited, i, leftModifier, sum);
            sum = WalkBasin(intData, visited, i, rightModifier, sum);

            return sum;
        }
    }
}