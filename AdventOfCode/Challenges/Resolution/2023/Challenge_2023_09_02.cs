using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2023_09_02 : IChallengeResolution
    {
        public int ChallengeYear => 2023;
        public int ChallengeDay => 9;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var histories = data
                .Select(c => c
                    .Split(' ', System.StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToList())
                .ToList();
            var finalSum = histories.Sum(GetDiffFirstInSequence);
            return $"{finalSum}";
        }

        private long GetDiffFirstInSequence(List<long> sequence)
        {
            if (sequence.Distinct().Count() == 1) return sequence[0];
            var nextSequence = Enumerable.Range(0, sequence.Count - 1)
                .Select(c => sequence[c + 1] - sequence[c])
                .ToList();
            return sequence.First() - GetDiffFirstInSequence(nextSequence);
        }
    }
}
