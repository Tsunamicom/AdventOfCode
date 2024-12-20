using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2024_05_02 : IChallengeResolution
    {
        public int ChallengeYear => 2024;
        public int ChallengeDay => 5;
        public int ChallengePart => 2;

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

            var unOrderedPages = pages.Where(p => IsUnOrdered(p, rulesDict)).ToList();
            unOrderedPages.ForEach(up => up.Sort(new PageComparer(rulesDict)));

            var sum = unOrderedPages.Sum(c => int.Parse(c[c.Count / 2]));

            return sum.ToString();
        }

        private class PageComparer : Comparer<string>
        {
            private readonly Dictionary<string, List<string>> _rules;
            public PageComparer(Dictionary<string, List<string>> rules)
            {
                _rules = rules;
            }

            public override int Compare(string x, string y)
            {
                if (!_rules.ContainsKey(x)) return -1;
                if (_rules[x].Contains(y)) return 1;
                
                if (!_rules.ContainsKey(y)) return 1;
                if (_rules[y].Contains(x)) return -1;

                return 0;
            }
        }

        private bool IsUnOrdered(List<string> pages, Dictionary<string, List<string>> rulesDict)
        {
            for (int i = 0; i < pages.Count; i++)
            {
                if (!rulesDict.ContainsKey(pages[i])) continue;
                var checkedPages = pages.Skip(i);
                var diff = checkedPages.Except(rulesDict[pages[i]]);
                if (diff.Count() != checkedPages.Count()) return true;
            }

            return false;
        }
    }
}
