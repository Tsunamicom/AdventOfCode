using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_05_02 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 5;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var allUniquePoints = new HashSet<Tuple<int, int>>();
            var duplicatePoints = new HashSet<Tuple<int, int>>();

            foreach (var line in data)
            {
                var lineCoordinates = line
                    .Replace(" -> ", ",")
                    .Split(',')
                    .Select(int.Parse)
                    .ToList();

                HashSet<Tuple<int, int>> generatedPoints = new HashSet<Tuple<int, int>>();
                if (IsHorizontalLine(lineCoordinates))
                {
                    // Horizontal Line
                    generatedPoints = GenerateHorizontalLineCoordinates(lineCoordinates);
                }

                else if (IsVerticalLine(lineCoordinates))
                {
                    // Vertical Line
                    generatedPoints = GenerateVerticalLineCoordinates(lineCoordinates);
                }

                else
                {
                    // Diagonal Line => Note:  This is assumed as true for the data from the problem description
                    generatedPoints = GenerateDiagonalLineCoordinates(lineCoordinates);
                }

                var alreadyIncludedPts = allUniquePoints.Intersect(generatedPoints).ToHashSet();

                duplicatePoints.UnionWith(alreadyIncludedPts);
                allUniquePoints.UnionWith(generatedPoints);
            }

            return duplicatePoints.Count.ToString();
        }

        /// <summary>
        /// Determine whether the coordinates are a horizontal line
        /// </summary>
        private static bool IsHorizontalLine(List<int> lineCoordinates)
        {
            return lineCoordinates[1] == lineCoordinates[3]
                && lineCoordinates[0] != lineCoordinates[2];
        }

        /// <summary>
        /// Determine whether the coordinates are a vertical line
        /// </summary>
        private static bool IsVerticalLine(List<int> lineCoordinates)
        {
            return lineCoordinates[0] == lineCoordinates[2]
                && lineCoordinates[1] != lineCoordinates[3];
        }

        /// <summary>
        /// Generate the Horizontal Line Coordinates for the given horizontal line
        /// </summary>
        private static HashSet<Tuple<int, int>> GenerateHorizontalLineCoordinates(List<int> lineCoordinates)
        {
            var result = new HashSet<Tuple<int, int>>();
            var diff = lineCoordinates[0] - lineCoordinates[2];
            var min = Math.Min(lineCoordinates[0], lineCoordinates[2]);
            for (int i = 0; i <= Math.Abs(diff); i++)
            {
                var x = min + i;
                var y = lineCoordinates[1];

                var coordinate = new Tuple<int, int>(x, y);

                result.Add(coordinate);
            }

            return result;
        }

        /// <summary>
        /// Generate the Vertical Line Coordinates for the given vertical line
        /// </summary>
        private static HashSet<Tuple<int, int>> GenerateVerticalLineCoordinates(List<int> lineCoordinates)
        {
            var result = new HashSet<Tuple<int, int>>();
            var diff = lineCoordinates[1] - lineCoordinates[3];
            var min = Math.Min(lineCoordinates[1], lineCoordinates[3]);
            for (int i = 0; i <= Math.Abs(diff); i++)
            {
                var x = lineCoordinates[0];
                var y = min + i;

                var coordinate = new Tuple<int, int>(x, y);

                result.Add(coordinate);
            }

            return result;
        }

        /// <summary>
        /// Generate the Diagonal Line Coordinates for the given diagonal line
        /// </summary>
        private static HashSet<Tuple<int, int>> GenerateDiagonalLineCoordinates(List<int> lineCoordinates)
        {
            var result = new HashSet<Tuple<int, int>>();

            var distance = Math.Abs(lineCoordinates[0] - lineCoordinates[2]); // Assumed that diagonals are 45 degrees, per problem

            var directionModifier = 
                   (lineCoordinates[0] < lineCoordinates[2] && lineCoordinates[1] > lineCoordinates[3]) 
                || (lineCoordinates[1] < lineCoordinates[3] && lineCoordinates[0] > lineCoordinates[2])
                ? -1 // Going Up Left -> Right
                : 1; // Going Down Left -> Right

            var startX = Math.Min(lineCoordinates[0], lineCoordinates[2]);
            var startY = directionModifier == -1
                ? Math.Max(lineCoordinates[1], lineCoordinates[3])
                : Math.Min(lineCoordinates[1], lineCoordinates[3]);

            for (int i = 0; i <= distance; i++)
            {
                var x = startX + i;
                var y = startY + i * directionModifier;

                var coordinate = new Tuple<int, int>(x, y);

                result.Add(coordinate);
            }


            return result;
        }
    }
}
