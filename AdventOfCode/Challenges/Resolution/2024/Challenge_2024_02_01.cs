using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2024_02_01 : IChallengeResolution
    {
        public int ChallengeYear => 2024;
        public int ChallengeDay => 2;
        public int ChallengePart => 1;

        private const int minSafeDiff = 1;
        private const int maxSafeDiff = 3;

        public string ResolveChallenge(List<string> data)
        {
            var reports = data.Select(c => c.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => int.Parse(c))
                .ToList())
              .ToList();

            var totalSafeReports = reports.Count(IsSafeReport);

            return totalSafeReports.ToString();
        }

        private bool IsSafeReport(List<int> report)
        {
            var isIncreasing = false;
            var isDecreasing = false;
            for (int i = 1; i < report.Count; i++)
            {
                var rDiff = report[i] - report[i - 1];

                // Check Increase / Decrease Consistency
                if (!isDecreasing && rDiff > 0)
                {
                    isIncreasing = true;
                }
                else if (!isIncreasing && rDiff < 0)
                {
                    isDecreasing = true;
                }
                else
                {
                    return false;
                }

                // Check Min/Max Change
                var rDiffAbs = Math.Abs(rDiff);
                if (rDiffAbs < minSafeDiff || rDiffAbs > maxSafeDiff)
                {
                    return false;
                }
            }
            return true;
        }
    }

    
}
