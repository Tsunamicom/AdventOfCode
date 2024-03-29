using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2023_01_02 : IChallengeResolution
    {
        public int ChallengeYear => 2023;
        public int ChallengeDay => 1;
        public int ChallengePart => 2;

        private Dictionary<string, int> _numberedWords = new() {
                    { "one", 1 },
                    { "two", 2 },
                    { "three", 3 },
                    { "four", 4 },
                    { "five", 5 },
                    { "six", 6 },
                    { "seven", 7 },
                    { "eight", 8 },
                    { "nine", 9 },
                    { "1", 1 },
                    { "2", 2 },
                    { "3", 3 },
                    { "4", 4 },
                    { "5", 5 },
                    { "6", 6 },
                    { "7", 7 },
                    { "8", 8 },
                    { "9", 9 } };

        public string ResolveChallenge(List<string> data)
        {
            var totalSum = data.Sum(FindCalibrationValue);
            return totalSum.ToString();
        }

        private int FindCalibrationValue(string line)
        {
            var minNumIdx = line.Length;
            var minNumVal = 0;
            var maxNumIdx = -2;
            var maxNumVal = 0;
            foreach (var kvp in _numberedWords)
            {
                var firstIndex = line.IndexOf(kvp.Key);
                if (firstIndex != -1 && firstIndex < minNumIdx)
                {
                    minNumIdx = firstIndex;
                    minNumVal = kvp.Value;
                }

                var lastIndex = line.LastIndexOf(kvp.Key);
                if (lastIndex != -1 && lastIndex > maxNumIdx)
                {
                    maxNumIdx = lastIndex;
                    maxNumVal = kvp.Value;
                }
            }

            var _ = int.TryParse($"{minNumVal}{maxNumVal}", out var calVal);
            return calVal;
        }
    }
}
