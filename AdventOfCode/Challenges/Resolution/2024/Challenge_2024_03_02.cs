using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2024_03_02 : IChallengeResolution
    {
        public int ChallengeYear => 2024;
        public int ChallengeDay => 3;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var adjusted = GetAdjusted(data.First());

            var match = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");  // TODO: Attempt lookback and forward
            var groups = match.Matches(adjusted);

            long totalValues = groups
                .Select(g => g.Groups.Values.ToList())
                .Select(g => g.Skip(1).Select(g => int.Parse(g.Value)))
                .Sum(g => g.Aggregate((a, b) => a * b));

            return totalValues.ToString();
        }

        private string GetAdjusted(string val)
        {
            var end = "don't()";
            var start = "do()";
            var isEnabled = true;
            var sb = new StringBuilder();
            for (int i = 0; i < val.Length; i++)
            {
                if (i > 6 && val[i] == ')')
                {
                    if (val.Substring(i - 6, 7) == end)
                    {
                        isEnabled = false;
                        continue;
                    }
                    else if (val.Substring(i - 3, 4) == start)
                    {
                        isEnabled = true;
                        continue;
                    }
                    
                }

                if (isEnabled)
                { sb.Append(val[i]); }
            }

            return sb.ToString();
        }
    }
}
