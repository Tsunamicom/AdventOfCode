using System.Collections.Generic;
using System.Text.Json;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2022_13_01 : IChallengeResolution
    {
        public int ChallengeYear => 2022;
        public int ChallengeDay => 13;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var itemSets = GetInitialGroups(data);

            var jdoc1 = JsonDocument.Parse("[[[]]]");

            var j = jdoc1.RootElement.EnumerateArray();
            foreach (var x in j)
            {
                var t = x.ValueKind;
                if (t == JsonValueKind.Array)
                {
                    var z = x.EnumerateArray();
                    foreach (var y in z)
                    {
                        var ty = y.ValueKind;  // Reveals type Array or Number
                    }
                }
            }



            return "Not Implemented Yet";
        }

        private List<(string, string)> GetInitialGroups(List<string> data)
        {
            var itemSets = new List<(string, string)>();

            string left = null;
            string right = null;

            foreach (var line in data)
            {
                if (string.IsNullOrEmpty(line))
                {
                    itemSets.Add((left, right));
                    left = right = null;
                    continue;
                }

                if (string.IsNullOrEmpty(left))
                {
                    left = line;
                    continue;
                }

                if (string.IsNullOrEmpty(right))
                {
                    right = line;
                    continue;
                }
            }
            itemSets.Add((left, right));

            return itemSets;
        }
    }


}