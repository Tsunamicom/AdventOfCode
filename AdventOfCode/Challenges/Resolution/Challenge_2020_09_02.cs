using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_09_02 : IChallengeResolution
    {
        public int ChallengeDay => 9;
        public int ChallengePart => 2;
        public string ResolveChallenge(List<string> data)
        {
            var preambleLength = 25;

            // Find the Invalid Number
            long invalidNum = FindInvalidNum(data, preambleLength);
            if (invalidNum == long.MinValue) return "No Solution Found.";

            // Find the Contiguous Subset that sums to invalid number
            var orderedContiguousSubset = FindContiguousSubset(data, invalidNum).OrderBy(a => a);

            // Find the sum of smallest + largest in contiguous set and return
            return (orderedContiguousSubset.First() + orderedContiguousSubset.Last()).ToString();
        }

        /// <summary>
        /// Returns the subset of contiguous numbers which sum up to the invalid number
        /// </summary>
        public List<long> FindContiguousSubset(List<string> data, long invalidNum)
        {
            var numberSet = data
                    .Select(long.Parse)
                    .ToList();

            for (int i = 0; i < numberSet.Count() - 1; i++)
            {
                var setSum = numberSet[i];

                if (setSum >= invalidNum) continue;

                for (int j = i + 1; j < numberSet.Count(); j++)
                {
                    setSum += numberSet[j];

                    if (setSum > invalidNum) break; // Early return when sum is too high

                    if (setSum == invalidNum)
                    {
                        // We found our subset
                        return numberSet.GetRange(i, j - i + 1);
                    }
                }
            }


            return numberSet; // Change this
        }

        /// <summary>
        /// Given a set of data representing a list of numbers and a preamble length, find the invalid sum number
        /// </summary>
        public long FindInvalidNum(List<string> data, int preambleLength)
        {
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
                    return focusNum;
                }
            }

            return long.MinValue;
        }
    }
}