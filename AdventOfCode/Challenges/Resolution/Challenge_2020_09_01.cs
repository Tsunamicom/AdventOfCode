using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_09_01 : IChallengeResolution
    {
        public int ChallengeDay => 9;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var preambleLength = 25;

            long invalidNum = long.MinValue;

            for (int i = preambleLength; i < data.Count; i++)
            {
                var hasValue = false;
                long.TryParse(data[i], out var focusNum);

                var focusSubSet = data
                    .GetRange(i - preambleLength, preambleLength)
                    .Select(long.Parse)
                    .ToList();

                for (int j = 0; j < focusSubSet.Count(); j++)
                {
                    var targetNum = focusSubSet[j];
                    if (focusSubSet.Contains(focusNum - targetNum))
                    {
                        hasValue = true;
                        break;
                    }
                }

                if (!hasValue)
                {
                    invalidNum = focusNum;
                    break;
                }
            }

            if (invalidNum == long.MinValue) return "No Solution Found.";

            return invalidNum.ToString();
        }
    }
}