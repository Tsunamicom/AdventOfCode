using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_04_01 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 4;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var bingoCallsAll = GetBingoCalls(data);
            var bingoCards = GetBingoCards(data);

            var allCalled = new HashSet<int>();
            for (int i = 0; i < bingoCallsAll.Count; i++)
            {
                var currentCall = bingoCallsAll[i];
                allCalled.Add(currentCall);

                for (int j = 0; j < bingoCards.Count; j++)
                {
                    if (IsHorizontalMatch(bingoCards[j], allCalled) || IsVerticalMatch(bingoCards[j], allCalled))
                    {
                        var unmarkedValue = CalculateUnmarkedValueSum(bingoCards[j], allCalled);

                        return (unmarkedValue * currentCall).ToString();
                    }
                }
            };

            return "No Match Found";
        }

        /// <summary>
        /// Determine whether the current board has a match going horizontally.
        /// </summary>
        private static bool IsHorizontalMatch(List<HashSet<int>> bingoCard, HashSet<int> allCalled)
        {
            return bingoCard.Any(c => c.IsSubsetOf(allCalled));
        }

        /// <summary>
        /// Determine whether the current board has a match going vertically.
        /// </summary>
        private static bool IsVerticalMatch(List<HashSet<int>> bingoCard, HashSet<int> allCalled)
        {
            var rowLen = bingoCard.First().Count;
            for (int i = 0; i < rowLen; i++)
            {
                var column = new HashSet<int>();
                for (int j = 0; j < bingoCard.Count; j++)
                {
                    var columnVal = bingoCard[j].ToList()[i];
                    column.Add(columnVal);
                }
                if (column.IsSubsetOf(allCalled)) return true;
            }

            return false;
        }

        /// <summary>
        /// Provide a sum of the unmarked values on the bingo card.
        /// </summary>
        private static long CalculateUnmarkedValueSum(List<HashSet<int>> bingoCard, HashSet<int> allCalled)
        {
            var allBingoValues = bingoCard.SelectMany(c => c).ToHashSet();

            var unmarkedValues = allBingoValues.Except(allCalled);

            return unmarkedValues.Sum();
        }

        /// <summary>
        /// Parse the first row, which is expected to be the bingo number calls.
        /// </summary>
        private static List<int> GetBingoCalls(List<string> data)
        {
            return data
                .First()
                .Split(',')
                .Select(int.Parse)
                .ToList();
        }

        /// <summary>
        /// Parse the data and collect all the bingo card details.
        /// </summary>
        private static List<List<HashSet<int>>> GetBingoCards(List<string> data)
        {
            var bingoCards = new List<List<HashSet<int>>>();

            var currentCard = new List<HashSet<int>>();

            for (int i = 1; i < data.Count; i++)
            {
                if (string.IsNullOrEmpty(data[i].Trim()))
                {
                    if (currentCard.Any())
                    {
                        bingoCards.Add(currentCard);
                        currentCard = new List<HashSet<int>>();
                    }
                }
                else
                {
                    var currentCardRow = GetCurrentCardRow(data[i]).ToHashSet();
                    currentCard.Add(currentCardRow);
                }
            }

            if (currentCard.Any()) bingoCards.Add(currentCard);

            return bingoCards;
        }

        /// <summary>
        /// Parse the current row that represents a bingo card row
        /// </summary>
        /// <remarks>" 5  3 14  8 10" => [5,3,14,8,10]</remarks>
        private static IEnumerable<int> GetCurrentCardRow(string dataRow)
        {
            var currentCardRow = dataRow
                .Split(" ", System.StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse); // Expected that all values should be parsable, else fail

            return currentCardRow;
        }
    }
}
