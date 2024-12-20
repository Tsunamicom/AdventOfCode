using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2024_05_01 : IChallengeResolution
    {
        public int ChallengeYear => 2024;
        public int ChallengeDay => 5;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var split = Array.IndexOf([.. data], "");
            var rules = data.Take(split);
            var pages = data.Skip(split + 1).Select(p => p.Split(',').ToList());

            var rulesSplit = rules.Select(r => r.Split('|'));
            var rulesDict = rulesSplit
                .Select(r => r[1])
                .Distinct()
                .ToDictionary(r => r, r => rulesSplit.Where(rs => rs[1] == r).Select(rs => rs[0]).ToList());

            var orderedPages = pages.Where(p => IsOrdered(p, rulesDict));
            var sum = orderedPages.Sum(c => int.Parse(c[c.Count / 2]));

            return sum.ToString();
        }

        private bool IsOrdered(List<string> pages, Dictionary<string, List<string>> rulesDict)
        {
            for (int i = 0; i < pages.Count; i++)
            {
                if (!rulesDict.ContainsKey(pages[i])) continue;
                var checkedPages = pages.Skip(i);
                var diff = checkedPages.Except(rulesDict[pages[i]]);
                if (diff.Count() != checkedPages.Count()) return false;
            }
            return true;
        }
    }
}
