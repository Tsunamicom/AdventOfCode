using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_20_02 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 20;
        public int ChallengePart => 2;

        private List<char> _lightValues = new();

        public string ResolveChallenge(List<string> data)
        {
            return Task.Run(() => ResolveChallengeAsync(data)).GetAwaiter().GetResult();
        }

        public async Task<string> ResolveChallengeAsync(List<string> data)
        {
            _lightValues = data.First().Select(c => c).ToList();
            var initialMap = data.Skip(2).Select(c => c.Select(r => r).ToList()).ToList();

            var enhanceLevel = 50;
            var workingCopy = initialMap.ToList();

            for (int i = 0; i < enhanceLevel; i++)
            {
                var fillChar = ((_lightValues[0] == '#') && (i % 2 != 0)) ? '#' : '.';

                workingCopy = await ExpandWorkingCopy(workingCopy, fillChar).ConfigureAwait(false);
                workingCopy = await GenerateEnhancedMap(workingCopy, fillChar).ConfigureAwait(false);
            }

            var litPixels = workingCopy.SelectMany(c => c).Count(c => c == '#');
            return $"{litPixels}";
        }

        private void OutputToDebug(List<string> data, List<List<char>> workingCopy)
        {
            Debug.WriteLine("");
            workingCopy.ForEach(c => Debug.WriteLine(string.Concat(c)));
            Debug.WriteLine("");
        }

        private static async Task<List<List<char>>> ExpandWorkingCopy(List<List<char>> initialMap, char fillChar)
        {
            List<List<char>> workingCopy = new();

            // Pad Top
            workingCopy.Add(new string(fillChar, initialMap[0].Count + 2).Select(c => c).ToList());

            foreach (var scanLine in initialMap)
            {
                List<char> workingScanLine = new();

                workingScanLine.Add(fillChar);
                workingScanLine.AddRange(scanLine.ToList());
                workingScanLine.Add(fillChar);

                workingCopy.Add(workingScanLine.ToList());
            }

            // Pad Bottom
            workingCopy.Add(new string(fillChar, initialMap[0].Count + 2).Select(c => c).ToList());

            return await Task.FromResult(workingCopy).ConfigureAwait(false);
        }

        private async Task<List<List<char>>> GenerateEnhancedMap(List<List<char>> initialMap, char fillChar)
        {
            List<List<char>> newMap = new();

            List<Task<List<char>>> rowTasks = new();

            for (int y = 0; y < initialMap.Count; y++)
            {
                rowTasks.Add(EnhanceRowValues(initialMap, fillChar, y));
            }

            await Task.WhenAll(rowTasks).ConfigureAwait(false);

            foreach (var result in rowTasks)
            {
                newMap.Add(result.Result);
            }

            return newMap;
        }

        private async Task<List<char>> EnhanceRowValues(List<List<char>> initialMap, char fillChar, int y)
        {
            List<char> currentRow = new();
            for (int x = 0; x < initialMap[0].Count; x++)
            {
                var pixelValueBinary = await CalculatePixelValue(initialMap, x, y, fillChar).ConfigureAwait(false);

                var newValue = _lightValues[pixelValueBinary];

                currentRow.Add(newValue);
            }

            return currentRow;
        }

        private async Task<int> CalculatePixelValue(List<List<char>> initialMap, int x, int y, char fillChar)
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

            return await Task.FromResult(result).ConfigureAwait(false);
        }
    }
}