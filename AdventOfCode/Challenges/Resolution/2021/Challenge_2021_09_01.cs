using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_09_01 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 9;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var intData = data.Select(x => x.Select(y => int.Parse(y.ToString())).ToList()).ToList();

            var lowPoints = new List<int>();
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
                        lowPoints.Add(targetLocationHeight + 1);
                    }
                }
            }

            return lowPoints.Sum().ToString();
        }
    }
}