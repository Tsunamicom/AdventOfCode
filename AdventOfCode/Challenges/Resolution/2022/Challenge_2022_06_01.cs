using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2022_06_01 : IChallengeResolution
    {
        public int ChallengeYear => 2022;
        public int ChallengeDay => 6;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var datastream = data.Single();
            var lookBackCount = 4;

            for (int i = 0; i < datastream.Length - lookBackCount; i++)
            {
                if (datastream
                    .Skip(i)
                    .Take(lookBackCount)
                    .Distinct()
                    .Count() == lookBackCount)
                    return (i + lookBackCount).ToString();
            }

            return "Not Found";
        }
    }
}
