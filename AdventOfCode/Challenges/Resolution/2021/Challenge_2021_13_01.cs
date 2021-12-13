using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_13_01 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 13;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var dataCoords = data
                .Where(c => !c.Contains("fold") && !string.IsNullOrEmpty(c)).ToList()
                .Select(c => c.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToList())
                .ToList();

            var foldInstructions = data
                .Where(c => c.Contains("fold")).ToList()
                .Select(c => c.Split("fold along ", StringSplitOptions.RemoveEmptyEntries))
                .Select(c => c[0].Split("=", StringSplitOptions.RemoveEmptyEntries))
                .ToList();

            var paperLocations = new Dictionary<long, HashSet<long>>();

            for (int i = 0; i < dataCoords.Count; i++)
            {
                var x = dataCoords[i][1];
                var y = dataCoords[i][0];

                SetHashValue(paperLocations, x, y);
            }

            var paperHeight = paperLocations.Max(c => c.Key);
            var paperLength = paperLocations.SelectMany(c => c.Value).Max();

            for (int i = 0; i < foldInstructions.Count; i++)
            {
                switch (foldInstructions[i][0])
                {
                    case "x":
                        (paperLength, paperLocations) = FoldVertical(paperLocations, paperLength, long.Parse(foldInstructions[i][1]));
                        break;
                    case "y":
                        (paperHeight, paperLocations) = FoldHorizontal(paperLocations, paperHeight, long.Parse(foldInstructions[i][1]));
                        break;
                }

                var visibleCount = paperLocations.SelectMany(c => c.Value).Count();

                return visibleCount.ToString(); // Part 1, show only the first
            }

            return null;
        }

        /// <summary>
        /// Fold point sheet in half vertically, and overlay points
        /// </summary>
        private static (long, Dictionary<long, HashSet<long>>) FoldVertical(Dictionary<long, HashSet<long>> dictionaryHash, long length, long foldOnIndex)
        {
            var newDictionaryHash = new Dictionary<long, HashSet<long>>();

            foreach (var hash in dictionaryHash)
            {
                newDictionaryHash[hash.Key] = dictionaryHash[hash.Key].Where(c => c <= foldOnIndex).ToHashSet();
                foreach (var flippedValue in dictionaryHash[hash.Key].Where(c => c > foldOnIndex))
                {
                    var distance = Math.Abs(flippedValue - foldOnIndex);
                    var newVal = foldOnIndex - distance;
                    SetHashValue(newDictionaryHash, hash.Key, newVal);
                }
            }

            return (length - foldOnIndex, newDictionaryHash);
        }

        /// <summary>
        /// Fold point sheet in half horizontally, and overlay points
        /// </summary>
        private static (long, Dictionary<long, HashSet<long>>) FoldHorizontal(Dictionary<long, HashSet<long>> dictionaryHash, long height, long foldOnIndex)
        {
            var newDictionaryHash = new Dictionary<long, HashSet<long>>();

            foreach (var hash in dictionaryHash)
            {
                if (hash.Key > foldOnIndex)
                {
                    foreach (var val in hash.Value)
                    {
                        var distance = Math.Abs(hash.Key - foldOnIndex);
                        var newX = foldOnIndex - distance;

                        if (newX >= 0)
                        {
                            SetHashValue(newDictionaryHash, newX, val);
                        }
                    }
                }
                else
                {
                    foreach (var val in hash.Value)
                    {
                        SetHashValue(newDictionaryHash, hash.Key, val);
                    }
                }
            }

            return (height - foldOnIndex, newDictionaryHash);
        }


        /// <summary>
        /// Set an array value Array[i][j] for a Dictionary and Hashset construct
        /// </summary>
        private static void SetHashValue<IType, JType>(Dictionary<IType, HashSet<JType>> dictionaryHash, IType iVal, JType jVal)
        {
            if (dictionaryHash.TryGetValue(iVal, out var jHash)) jHash.Add(jVal);
            else
            {
                dictionaryHash.Add(iVal, new HashSet<JType>());
                dictionaryHash[iVal].Add(jVal);
            }
        }
    }
}