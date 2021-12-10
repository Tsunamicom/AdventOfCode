using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_10_02 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 10;
        public int ChallengePart => 2;

        private readonly Dictionary<char, char> _closingCharLookup = new Dictionary<char, char>
        {
            {'[', ']'},
            {'(', ')'},
            {'<', '>'},
            {'{', '}'}
        };

        private readonly Dictionary<char, int> _validationPoints = new Dictionary<char, int>()
        {
            {'(', 1},
            {'[', 2},
            {'{', 3},
            {'<', 4}
        };

        public string ResolveChallenge(List<string> data)
        {
            var allScores = new List<long>();
            var charsToComplete = new List<char>();

            foreach (var chunk in data)
            {
                var discard = false;
                var validation = new Stack<char>();

                for (int i = 0; i < chunk.Length; i++)
                {
                    if (discard) break;

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
                        discard = true;
                    }
                }

                if (!discard)
                {
                    var currentPoints = GetAutoCompletePoints(validation);
                    allScores.Add(currentPoints);
                }
            }

            var middleScore = GetMedianScoreValue(allScores);

            return middleScore.ToString();
        }

        /// <summary>
        /// Determines the median score of the collected points
        /// </summary>
        private static long GetMedianScoreValue(List<long> allScores)
        {
            allScores.Sort();

            var middleScore = allScores[allScores.Count / 2];
            return middleScore;
        }

        /// <summary>
        /// Calculates the points for autocompletion.
        /// </summary>
        private long GetAutoCompletePoints(Stack<char> validation)
        {
            var currentPoints = 0L;
            foreach (var point in validation.Select(c => _validationPoints[c]))
            {
                currentPoints = (5 * currentPoints) + point;
            }

            return currentPoints;
        }
    }
}