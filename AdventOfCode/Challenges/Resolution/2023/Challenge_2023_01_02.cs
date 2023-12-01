using System.Collections.Generic;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2023_01_02 : IChallengeResolution
    {
        public int ChallengeYear => 2023;
        public int ChallengeDay => 1;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var numberedWords = new Dictionary<string, int>() {
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

            var totalSum = 0;
            foreach (var line in data)
            {
                var minNumIdx = line.Length;
                var minNumVal = 0;
                var maxNumIdx = -2;
                var maxNumVal = 0;
                foreach (var kvp in numberedWords)
                {
                    var firstIndex = line.IndexOf(kvp.Key);
                    var lastIndex = line.LastIndexOf(kvp.Key);
                    if (firstIndex != -1 && firstIndex < minNumIdx)
                    {
                        minNumIdx = firstIndex;
                        minNumVal = kvp.Value;
                    }

                    if (lastIndex != -1 && lastIndex > maxNumIdx)
                    {
                        maxNumIdx = lastIndex;
                        maxNumVal = kvp.Value;
                    }
                }

                var calibrationVal = int.TryParse($"{minNumVal}{maxNumVal}", out var calVal);
                totalSum += calVal;
            }

            return totalSum.ToString();
        }
    }
}
