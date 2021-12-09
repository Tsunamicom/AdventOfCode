using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_08_02 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 8;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            // N: PATTERN   LEN
            //==================
            // 0: abcefg    6
            // 1: cf        2
            // 2: acdeg     5
            // 3: acdfg     5
            // 4: bcdf      4
            // 5: abdfg     5
            // 6: abdefg    6
            // 7: acf       3
            // 8: abcdefg   7
            // 9: abcdfg    6

            // 1: cf        2 - 
            // 7: acf       3 - 
            // 4: bcdf      4 - 
            // 2: acdeg     5 =
            // 3: acdfg     5 =
            // 5: abdfg     5 =
            // 6: abdefg    6 =
            // 0: abcefg    6 =
            // 9: abcdfg    6 =
            // 8: abdcefg   7 -

            var totalValue = 0L;

            foreach (var line in data)
            {
                var currentLineData = line.Split('|', System.StringSplitOptions.RemoveEmptyEntries);
                var patternData = currentLineData.First().Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                var decodeRequestData = currentLineData.Last().Split(' ', System.StringSplitOptions.RemoveEmptyEntries).ToList();

                var one = patternData.Single(c => c.Length == 2);
                var seven = patternData.Single(c => c.Length == 3);
                var four = patternData.Single(c => c.Length == 4);
                var eight = patternData.Single(c => c.Length == 7);

                var six = patternData.Single(c => c.Length == 6 && eight.Except(c).Count() == one.Except(c).Count());

                var top = seven.Except(one).Single().ToString(); // a
                var bottomAndLeft = string.Concat(eight.Except(four).Except(top)); // eg

                var two = patternData.Single(c => c.Length == 5 && c.Intersect(bottomAndLeft).Count() == 2);

                var topLeft = string.Join("", eight.Except(two).Except(one)); // b

                var five = patternData.Single(c => c.Length == 5 && c.Contains(topLeft));

                var nine = patternData.Single(c => c.Length == 6 && c.Intersect(string.Concat(five.Union(one))).Count() == c.Length);

                var three = patternData.Single(c => c.Length == 5 && c != two && c != five);

                var zero = patternData.Single(c => c.Length == 6 && c != six && c != nine);

                var lookupList = new List<string>() { zero, one, two, three, four, five, six, seven, eight, nine };
                
                var lookupListSorted = lookupList.Select(c => c = string.Concat(c.OrderBy(r => r))).ToList();
                var decodeListSorted = decodeRequestData.Select(c => c = string.Concat(c.OrderBy(r => r))).ToList();

                var valueString = string.Concat(decodeListSorted.Select(c => lookupListSorted.IndexOf(lookupListSorted.Single(r => r == c))));

                totalValue += int.Parse(valueString);
            }

            return totalValue.ToString();
        }
    }
}