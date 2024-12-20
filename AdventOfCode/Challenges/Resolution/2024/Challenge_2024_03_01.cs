using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2024_03_01 : IChallengeResolution
    {
        public int ChallengeYear => 2024;
        public int ChallengeDay => 3;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var match = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");
            var groups = match.Matches(data.First());

            long totalValues = groups
                .Select(g => g.Groups.Values.ToList())
                .Select(g => g.Skip(1).Select(g => int.Parse(g.Value)))
                .Sum(g => g.Aggregate((a,b) => a*b));
            
            return totalValues.ToString();
        }
    }
}
