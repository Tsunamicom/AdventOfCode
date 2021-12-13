using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_13_02 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 13;
        public int ChallengePart => 2;

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

            var foldVisible = new List<long>();

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

                foldVisible.Add(visibleCount);
            }

            List<string> image = GenerateImage(paperLocations, paperHeight, paperLength);
            OutputImageToDebug(image);
            return string.Join(",", image);
        }

        /// <summary>
        /// Output the image to the debug console, if running in debug
        /// </summary>
        private static void OutputImageToDebug(List<string> image)
        {
#if DEBUG
            foreach (var line in image)
            {
                Debug.WriteLine(line);
            }
#endif
        }

        /// <summary>
        /// For a given paper size, provide a visual representation of marked points representing an image.
        /// </summary>
        private static List<string> GenerateImage(Dictionary<long, HashSet<long>> paperLocations, long paperHeight, long paperLength)
        {
            var image = new List<string>();
            for (int i = 0; i < paperHeight; i++)
            {

                if (paperLocations.ContainsKey(i))
                {
                    var sb = new StringBuilder();
                    for (int j = 0; j < paperLength; j++)
                    {
                        if (paperLocations[i].Contains(j))
                        {
                            sb.Append('#');
                        }
                        else
                        {
                            sb.Append('.');
                        }
                    }
                    image.Add(sb.ToString());
                }
                else
                {
                    image.Add(new string('.', (int)paperLength));
                }
            }

            return image;
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