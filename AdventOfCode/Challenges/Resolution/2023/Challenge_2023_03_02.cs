using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2023_03_02 : IChallengeResolution
    {
        public int ChallengeYear => 2023;
        public int ChallengeDay => 3;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var parts = new List<Part>();
            var currentPart = new Part();

            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    (int i, int j) currentPosition = (i, j);
                    var inspected = data[currentPosition.i][currentPosition.j];
                    if (int.TryParse(inspected.ToString(), out var intVal))
                    {
                        currentPart.PartNumValues.Add(intVal);
                        currentPart.CheckAdjacentSymbols(data, currentPosition);
                    }
                    else
                    {
                        if (currentPart.PartNumValues.Count > 0)
                        {
                            // Cut to new part
                            parts.Add(currentPart.CopyPart());
                            currentPart = new Part();
                        }
                    }
                }
                if (currentPart.PartNum != 0) parts.Add(currentPart.CopyPart());
                currentPart = new Part();
            }

            var uniqueGearCandidates = parts.Where(c => c.AdjacentGearCandidates.Count > 0)
                .SelectMany(c => c.AdjacentGearCandidates)
                .ToHashSet();

            var gears = new Dictionary<(int i, int j), long>();
            foreach (var gear in uniqueGearCandidates)
            {
                var nearbyParts = parts.Where(c => c.AdjacentGearCandidates.Contains(gear)).ToList();
                if (nearbyParts.Count == 2)
                {
                    // Valid Gears, Gear Ratio
                    gears.Add(gear, nearbyParts.Select(c => c.PartNum).Aggregate((a, b) => a * b));
                }
            }

            var finalGearSum = gears.Values.Sum();



            return $"{finalGearSum}";
        }

        private class Part
        {
            internal Part()
            {

            }

            internal Part CopyPart()
            {
                var part = new Part();
                part.PartNumValues = PartNumValues.ToList();
                part.PartNum = PartNum;
                part.HasAdjacentSymbols = HasAdjacentSymbols;
                part.AdjacentGearCandidates = AdjacentGearCandidates.ToHashSet();
                return part;
            }

            internal List<int> PartNumValues { get; set; } = [];

            private long? _partNum;

            internal long PartNum
            {
                get
                {
                    if (!_partNum.HasValue)
                    {
                        // Calculate once and set on first get
                        _ = int.TryParse(string.Join(null, PartNumValues), out var val);
                        _partNum = val;
                    }

                    return _partNum.Value;
                }
                private set { }
            }

            internal HashSet<(int i, int j)> AdjacentGearCandidates { get; set; } = [];

            internal bool HasAdjacentSymbols { get; set; }

            private bool IsValidSymbol(List<string> data, (int i, int j) checkedPosition, out char? symbol)
            {
                symbol = null;
                var symbolCandidate = data[checkedPosition.i][checkedPosition.j];
                var isValidSymbol = !(int.TryParse(symbolCandidate.ToString(), out var _) || symbolCandidate == '.');
                if (isValidSymbol) { symbol = symbolCandidate; }
                return isValidSymbol;
            }

            private void SetSymbolMarkers(List<string> data, (int i, int j) checkedPoint)
            {
                if (IsValidSymbol(data, (checkedPoint.i, checkedPoint.j), out var symb))
                {
                    HasAdjacentSymbols = true;
                    if (symb == '*')
                    {
                        AdjacentGearCandidates.Add((checkedPoint.i, checkedPoint.j));
                    }
                }
            }

            internal void CheckAdjacentSymbols(List<string> data, (int i, int j) currentPosition)
            {
                int above = currentPosition.i - 1;
                int below = currentPosition.i + 1;
                (int i, int j) aboveLeft = (above, currentPosition.j - 1);
                (int i, int j) aboveMid = (above, currentPosition.j);
                (int i, int j) aboveRight = (above, currentPosition.j + 1);
                (int i, int j) midLeft = (currentPosition.i, currentPosition.j - 1);
                (int i, int j) midRight = (currentPosition.i, currentPosition.j + 1);
                (int i, int j) belowLeft = (below, currentPosition.j - 1);
                (int i, int j) belowMid = (below, currentPosition.j);
                (int i, int j) belowRight = (below, currentPosition.j + 1);

                //   j
                // i_|

                // Above
                if (above >= 0 && data.Count - 1 > above)
                {
                    // Left
                    if (aboveLeft.j >= 0 && data[above].Length - 1 > aboveLeft.j)
                    {
                        SetSymbolMarkers(data, (above, aboveLeft.j));
                    }

                    // Mid
                    if (data[above].Length - 1 >= aboveMid.j)
                    {
                        SetSymbolMarkers(data, (above, aboveMid.j));
                    }

                    // Right
                    if (data[above].Length - 1 >= aboveRight.j)
                    {
                        SetSymbolMarkers(data, (above, aboveRight.j));
                    }
                }

                // Mid
                if (data.Count - 1 >= currentPosition.i)
                {
                    // Left
                    if (midLeft.j >= 0 && data[currentPosition.i].Length - 1 > midLeft.j)
                    {
                        SetSymbolMarkers(data, (currentPosition.i, midLeft.j));
                    }

                    // Right
                    if (data[currentPosition.i].Length - 1 >= midRight.j)
                    {
                        SetSymbolMarkers(data, (currentPosition.i, midRight.j));
                    }
                }

                // Below
                if (data.Count - 1 >= below)
                {
                    // Left
                    if (belowLeft.j >= 0 && data[below].Length - 1 > belowLeft.j)
                    {
                        SetSymbolMarkers(data, (below, belowLeft.j));
                    }

                    // Mid
                    if (data[below].Length - 1 >= belowMid.j)
                    {
                        SetSymbolMarkers(data, (below, belowMid.j));
                    }

                    // Right
                    if (data[below].Length - 1 >= belowRight.j)
                    {
                        SetSymbolMarkers(data, (below, belowRight.j));
                    }
                }
            }
        }
    }
}
