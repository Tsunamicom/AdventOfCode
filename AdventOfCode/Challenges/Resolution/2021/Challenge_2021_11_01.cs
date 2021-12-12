using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_11_01 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 11;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var intData = data.Select(x => x.Select(y => int.Parse(y.ToString())).ToList()).ToList();

            var stepCount = 100;
            var totalFlashed = 0L;

            for (var step = 0; step < stepCount; step++)
            {
                var flashed = new Dictionary<int, HashSet<int>>();
                var flashedVisited = new Dictionary<int, HashSet<int>>();

                // One time run through to increment a charge for the step
                for (int i = 0; i < intData.Count; i++)
                {
                    for (int j = 0; j < intData[i].Count; j++)
                    {
                        TryIncrementAndFlash(intData, flashed, i, j);
                    }
                }

                List<(int, int)> initialFlashed = new();
                foreach (var i in flashed.Keys)
                {
                    foreach (var j in flashed[i])
                    {
                        initialFlashed.Add((i, j));
                    }
                }

                foreach (var i in initialFlashed)
                {
                    ChainReactAndFlashForStep(intData, flashed, flashedVisited, i.Item1, i.Item2);
                }

                totalFlashed += flashed.Sum(c => c.Value.Count);
            }


            return totalFlashed.ToString();
        }

        /// <summary>
        /// Attempt to increment and flash where needed, and return whether a flash has ever occured
        /// </summary>
        private static bool TryIncrementAndFlash(List<List<int>> intData, Dictionary<int, HashSet<int>> flashed, int i, int j)
        {
            var isFlashed = IsIncluded(flashed, i, j);

            if (!isFlashed)
            {
                intData[i][j]++;

                if (intData[i][j] == 10)
                {
                    SetHashValue(flashed, i, j);
                    intData[i][j] = 0;
                    isFlashed = true;
                }
            }

            return isFlashed;
        }

        /// <summary>
        /// For a given point, attempt to increment, flash, and chain react to adjacent points
        /// </summary>
        private static void ChainReactAndFlashForStep(List<List<int>> intData, Dictionary<int, HashSet<int>> flashed, Dictionary<int, HashSet<int>> flashedVisited, int i, int j)
        {
            if (IsIncluded(flashedVisited, i, j)) return;

            if (!TryIncrementAndFlash(intData, flashed, i, j)) return;

            SetHashValue(flashedVisited, i, j);

            var leftModifier = Math.Max(0, j - 1);
            var rightModifier = Math.Min(intData[i].Count - 1, j + 1);
            var upModifier = Math.Max(0, i - 1);
            var downModifier = Math.Min(intData.Count - 1, i + 1);

            if (rightModifier != j) ChainReactAndFlashForStep(intData, flashed, flashedVisited, i, rightModifier);                  // Right
            if (leftModifier != j) ChainReactAndFlashForStep(intData, flashed, flashedVisited, i, leftModifier);                    // Left

            if (upModifier != i)
            {
                ChainReactAndFlashForStep(intData, flashed, flashedVisited, upModifier, j);                                         // Top
                if (rightModifier != j) ChainReactAndFlashForStep(intData, flashed, flashedVisited, upModifier, rightModifier);     // Top Right
                if (leftModifier != j) ChainReactAndFlashForStep(intData, flashed, flashedVisited, upModifier, leftModifier);       // Top Left
            }

            if (downModifier != i)
            {
                ChainReactAndFlashForStep(intData, flashed, flashedVisited, downModifier, j);                                       // Bottom
                if (rightModifier != j) ChainReactAndFlashForStep(intData, flashed, flashedVisited, downModifier, rightModifier);   // Bottom Right
                if (leftModifier != j) ChainReactAndFlashForStep(intData, flashed, flashedVisited, downModifier, leftModifier);     // Bottom Left
            }
        }

        /// <summary>
        /// Set an array value Array[i][j] for a Dictionary and Hashset construct
        /// </summary>
        private static void SetHashValue<I, J>(Dictionary<I, HashSet<J>> flashed, I i, J j)
        {
            if (flashed.TryGetValue(i, out var jHash)) jHash.Add(j);
            else
            {
                flashed.Add(i, new HashSet<J>());
                flashed[i].Add(j);
            }
        }

        /// <summary>
        /// Determine whether an array value Array[i][j] exists within a Dictionary HashSet construct
        /// </summary>
        private static bool IsIncluded<I, J>(Dictionary<I, HashSet<J>> flashed, I i, J j)
        {
            return flashed.TryGetValue(i, out var jHash) && jHash.Contains(j);
        }
    }
}