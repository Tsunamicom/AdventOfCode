using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2023_08_01 : IChallengeResolution
    {
        public int ChallengeYear => 2023;
        public int ChallengeDay => 8;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var (instructions, elements) = ParseMappingAndInstruction(data);

            var walkCount = 0;
            var start = "AAA";
            var end = "ZZZ";
            var current = start;

            while (current != end)
            {
                var nextElement =
                    instructions[walkCount % instructions.Length] == 'L'
                    ? elements[current].L
                    : elements[current].R;

                current = nextElement;

                walkCount++;

            }
            return $"{walkCount}";
        }

        private (string instructions, Dictionary<string, (string L, string R)>) ParseMappingAndInstruction(List<string> data)
        {
            Dictionary<string, (string, string)> elements = new();
            var instructions = data[0];

            foreach (var element in data.Skip(2))
            {
                var elementSeries = element
                    .Replace("(", null)
                    .Replace(")", null)
                    .Split('=', ',', '(', ')')
                    .Select(c => c.Trim())
                    .ToList();

                elements.TryAdd(elementSeries[0], (elementSeries[1], elementSeries[2]));
            }

            return (instructions, elements);
        }
    }
}
