using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2022_04_01 : IChallengeResolution
    {
        public int ChallengeYear => 2022;
        public int ChallengeDay => 4;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var pairs = data
                .Select(c => c.Split(',').Select(r => r.Split('-')).ToList());

            var fullyContainsOverlapCount = 0;

            foreach (var pair in pairs)
            {
                var lowerBoundPair1 = int.Parse(pair[0][0]);
                var lowerBoundPair2 = int.Parse(pair[1][0]);
                var upperBoundPair1 = int.Parse(pair[0][1]);
                var upperBoundPair2 = int.Parse(pair[1][1]);

                if ((lowerBoundPair1 > lowerBoundPair2 ||
                        upperBoundPair1 < upperBoundPair2) &&
                    (lowerBoundPair2 > lowerBoundPair1 ||
                        upperBoundPair2 < upperBoundPair1))
                    continue;

                fullyContainsOverlapCount++;
            }

            return fullyContainsOverlapCount.ToString();
        }
    }
}
