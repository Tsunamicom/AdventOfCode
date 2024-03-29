using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2023_11_01 : IChallengeResolution
    {
        public int ChallengeYear => 2023;
        public int ChallengeDay => 11;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var galaxyCoords = GetGalaxyCoords(data);
            var expandedIs = GetExpandedIs(data);
            var expandedJs = GetExpandedJs(data);
            var expansionAdditions = 1; // Expansions add this many additional empty row/columns n-1
            var galaxyCoordPermutations = GetCoordinatePermuations(galaxyCoords);

            long sumOfPaths = 0;
            foreach (var coordPerm in galaxyCoordPermutations)
            {
                sumOfPaths += GetCoordinateDistance(coordPerm[0], coordPerm[1], expansionAdditions, expandedIs, expandedJs);
            }

            return $"{sumOfPaths}";
        }



        private List<List<(int i, int j)>> GetCoordinatePermuations(List<(int i, int j)> galaxyCoords)
        {
            List<List<(int i, int j)>> permutations = [];
            for (var s = 0; s < galaxyCoords.Count - 1; s++)
            {
                for (var e = s + 1; e < galaxyCoords.Count; e++)
                {
                    permutations.Add([galaxyCoords[s], galaxyCoords[e]]);
                }
            }

            return permutations;
        }

        private static long GetCoordinateDistance(
            (int i, int j) start,
            (int i, int j) end,
            int expansionAdditions,
            List<int> expandedIs,
            List<int> expandedJs)
        {
            (int max, int min) minMaxI = (Math.Max(start.i, end.i), Math.Min(start.i, end.i));
            var expansionsBetweenIs = expandedIs.Count(c => c > minMaxI.min && c < minMaxI.max);
            var iDist = minMaxI.max - minMaxI.min + (expansionsBetweenIs * expansionAdditions);

            (int max, int min) minMaxJ = (Math.Max(start.j, end.j), Math.Min(start.j, end.j));
            var expansionsBetweenJs = expandedJs.Count(c => c > minMaxJ.min && c < minMaxJ.max);
            var jDist = minMaxJ.max - minMaxJ.min + (expansionsBetweenJs * expansionAdditions);

            return iDist + jDist;
        }

        private static List<(int i, int j)> GetGalaxyCoords(List<string> data)
        {
            return data
                .SelectMany((a, i) => data[i]
                    .Select((d, j) => d == '#' ? j : -1)
                    .Where(r => r != -1)
                    .Select(r => (i, r)))
                .ToList();
        }

        private static List<int> GetExpandedIs(List<string> data)
        {
            return data
                .Select((c, i) => (i, c.All(c => c == '.')))
                .Where(i => i.Item2)
                .Select(s => s.i)
                .ToList();
        }

        private static List<int> GetExpandedJs(List<string> data)
        {
            return Enumerable.Range(0, data.First().Length)
                .Select(j => (j, data
                    .Select((a, i) => a[j])
                    .All(t => t == '.')))
                .Where(t => t.Item2)
                .Select(s => s.j)
                .ToList();
        }
    }
}
