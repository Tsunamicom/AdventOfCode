using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_20_01 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 20;
        public int ChallengePart => 1;

        private List<char> _lightValues = new();

        public string ResolveChallenge(List<string> data)
        {
            _lightValues = data.First().Select(c => c).ToList();
            var initialMap = data.Skip(2).Select(c => c.Select(r => r).ToList()).ToList();

            var enhanceLevel = 2;
            var workingCopy = initialMap.ToList();

            for (int i = 0; i < enhanceLevel; i++)
            {
                //OutputToDebug(data, workingCopy);
                var fillChar = ((_lightValues[0] == '#') && (i % 2 != 0)) ? '#' : '.';

                workingCopy = ExpandWorkingCopy(workingCopy, fillChar);
                workingCopy = GenerateEnhancedMap(workingCopy, fillChar);
            }

            //workingCopy.ForEach(c => Debug.WriteLine(string.Concat(c)));

            var litPixels = workingCopy.SelectMany(c => c).Count(c => c == '#');
            return $"{litPixels}";
        }

        private void OutputToDebug(List<string> data, List<List<char>> workingCopy)
        {
            Debug.WriteLine("");
            workingCopy.ForEach(c => Debug.WriteLine(string.Concat(c)));
            Debug.WriteLine("");
        }

        private static List<List<char>> ExpandWorkingCopy(List<List<char>> initialMap, char fillChar)
        {
            var workingCopy = new List<List<char>>();

            // Pad Top
            workingCopy.Add(new string(fillChar, initialMap[0].Count + 2).Select(c => c).ToList());

            foreach (var scanLine in initialMap)
            {
                var workingScanLine = scanLine.Prepend(fillChar).Append(fillChar).ToList();
                workingCopy.Add(workingScanLine);
            }

            // Pad Bottom
            workingCopy.Add(new string(fillChar, initialMap[0].Count + 2).Select(c => c).ToList());

            return workingCopy;
        }

        private List<List<char>> GenerateEnhancedMap(List<List<char>> initialMap, char fillChar)
        {
            var newMap = new List<List<char>>();

            for (int y = 0; y < initialMap.Count; y++)
            {
                for (int x = 0; x < initialMap[y].Count; x++)
                {
                    if (newMap.Count <= y) newMap.Add(new List<char>());
                    var pixelValueBinary = CalculatePixelValue(initialMap, x, y, fillChar);

                    var newValue = _lightValues[pixelValueBinary];

                    newMap[y].Add(newValue);
                }
            }

            return newMap;
        }

        private int CalculatePixelValue(List<List<char>> initialMap, int x, int y, char fillChar)
        {
            var sb = new StringBuilder();

            var isTopBound = y - 1 < 0;
            var isLeftBound = x - 1 < 0;
            var isBottomBound = y + 1 > initialMap.Count - 1;
            var isRightBound = x + 1 > initialMap[0].Count - 1;

            // Get Top Left
            if (isTopBound || isLeftBound) sb.Append(fillChar); else sb.Append(initialMap[y - 1][x - 1]);

            // Get Top
            if (isTopBound) sb.Append(fillChar); else sb.Append(initialMap[y - 1][x]);

            // Get Top Right
            if (isTopBound || isRightBound) sb.Append(fillChar); else sb.Append(initialMap[y - 1][x + 1]);

            // Get Left
            if (isLeftBound) sb.Append(fillChar); else sb.Append(initialMap[y][x - 1]);

            // Get Mid
            sb.Append(initialMap[y][x]);

            // Get Right
            if (isRightBound) sb.Append(fillChar); else sb.Append(initialMap[y][x + 1]);

            // Get Bottom Left
            if (isBottomBound || isLeftBound) sb.Append(fillChar); else sb.Append(initialMap[y + 1][x - 1]);

            // Get Bottom
            if (isBottomBound) sb.Append(fillChar); else sb.Append(initialMap[y + 1][x]);

            // Get Bottom Right
            if (isBottomBound || isRightBound) sb.Append(fillChar); else sb.Append(initialMap[y + 1][x + 1]);

            //Debug.WriteLine($"{sb}; {x}, {y}");

            sb.Replace('.', '0');
            sb.Replace('#', '1');

            var sbStr = sb.ToString();
            var result = Convert.ToInt32(sbStr, 2);

            return result;
        }
    }
}