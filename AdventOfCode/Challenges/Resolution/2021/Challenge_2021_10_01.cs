using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_10_01 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 10;
        public int ChallengePart => 1;

        private readonly Dictionary<char, char> _closingCharLookup = new Dictionary<char, char>
        {
            {'[', ']'},
            {'(', ')'},
            {'<', '>'},
            {'{', '}'}
        };

        private readonly Dictionary<char, int> _illegalCharValues = new Dictionary<char, int>()
        {
            {')', 3},
            {']', 57},
            {'}', 1197},
            {'>', 25137}
        };

        public string ResolveChallenge(List<string> data)
        {
            var failedChars = new List<char>();

            foreach (var chunk in data)
            {
                var validation = new Stack<char>();

                for (int i = 0; i < chunk.Length; i++)
                {
                    var c = chunk[i];

                    if (_closingCharLookup.ContainsKey(c))
                    {
                        validation.Push(c);
                    }
                    else
                    {
                        if (validation.TryPeek(out var checkedVal))
                        {

                            if (_closingCharLookup[checkedVal] == c)
                            {
                                validation.Pop();
                                continue;
                            }
                        }

                        failedChars.Add(c);
                        break;
                    }
                }
            }

            var illegalCharPoints = failedChars.Sum(c => _illegalCharValues[c]);

            return illegalCharPoints.ToString();
        }
    }
}