using System.Collections.Generic;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_01_01 : IChallengeResolution
    {
        public int ChallengeYear => 2021;

        public int ChallengeDay => 1;

        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var count = 0;
            var dEnum = data.GetEnumerator();
            var prevVal = int.MaxValue;
            while (dEnum.MoveNext())
            {
                _ = int.TryParse(dEnum.Current, out var curVal);
                if (curVal > prevVal) count++;

                prevVal = curVal;
            }

            return count.ToString();
        }
    }
}