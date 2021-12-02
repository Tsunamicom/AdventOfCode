using System.Collections.Generic;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_01_02 : IChallengeResolution
    {
        public int ChallengeYear => 2021;

        public int ChallengeDay => 1;

        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var count = 0;
            var dEnum = data.GetEnumerator();

            int prevTotal = int.MaxValue;
            
            int? curr = null;
            int? backOne = null;

            while (dEnum.MoveNext())
            {
                int? backTwo = backOne;
                backOne = curr;
                
                _ = int.TryParse(dEnum.Current, out var currVal);
                curr = currVal;
                if (backTwo.HasValue && backOne.HasValue)
                {
                    var total = (curr + backOne + backTwo).GetValueOrDefault();
                    if (total > prevTotal) count++;

                    prevTotal = total;
                }
            }

            return count.ToString();
        }
    }
}