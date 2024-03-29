using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2023_08_02 : IChallengeResolution
    {
        public int ChallengeYear => 2023;
        public int ChallengeDay => 8;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var (instructions, elements) = ParseMappingAndInstruction(data);

            var walkCount = 0;
            var current = elements.Keys.Where(e => e.EndsWith('A')).ToDictionary(e => e, e => e);
            var currentFirstIdx = elements.Keys.Where(e => e.EndsWith('A')).ToDictionary(e => e, e => (long)0);

            while (!current.Values.All(c => c.EndsWith('Z')))
            {
                foreach (var currentElement in current.Where(c => !c.Value.EndsWith('Z')))
                {
                    var nextElement =
                        instructions[walkCount % instructions.Length] == 'L'
                        ? elements[current[currentElement.Key]].L
                        : elements[current[currentElement.Key]].R;

                    current[currentElement.Key] = nextElement;

                    currentFirstIdx[currentElement.Key]++;
                }
                walkCount++;
            }

            var arrayLCM = currentFirstIdx.Values.OrderBy(c => c).Aggregate(FindLCM);

            return $"{arrayLCM}";
        }

        private long FindLCM(long x, long y)
        {
            var gcd = x;
            var next = y;
            while (next != 0)
            {
                var temp = next;
                next = gcd % next;
                gcd = temp;
            }

            return x * y / gcd;
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
