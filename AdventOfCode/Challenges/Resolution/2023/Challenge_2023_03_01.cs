using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2023_03_01 : IChallengeResolution
    {
        public int ChallengeYear => 2023;
        public int ChallengeDay => 3;
        public int ChallengePart => 1;

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

            var partSum = parts.Where(p => p.HasAdjacentSymbols).Sum(c => c.PartNum);

            return $"{partSum}";
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

            internal bool HasAdjacentSymbols { get; set; }

            private bool IsSymbol(List<string> data, (int i, int j) checkedPosition)
            {
                var symbolCandidate = data[checkedPosition.i][checkedPosition.j];
                return !(int.TryParse(symbolCandidate.ToString(), out _) || symbolCandidate == '.');
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
                if (HasAdjacentSymbols) return; // No need to still check



                // Above
                if (above >= 0 && data.Count - 1 > above)
                {
                    // Left
                    if (aboveLeft.j >= 0 && data[above].Length - 1 > aboveLeft.j)
                    {
                        if (IsSymbol(data, (above, aboveLeft.j)))
                        {
                            HasAdjacentSymbols = true;
                            return;
                        }
                    }

                    // Mid
                    if (data[above].Length - 1 >= aboveMid.j)
                    {
                        if (IsSymbol(data, (above, aboveMid.j)))
                        {
                            HasAdjacentSymbols = true;
                            return;
                        }
                    }

                    // Right
                    if (data[above].Length - 1 >= aboveRight.j)
                    {
                        if (IsSymbol(data, (above, aboveRight.j)))
                        {
                            HasAdjacentSymbols = true;
                            return;
                        }
                    }
                }

                // Mid
                if (data.Count - 1 >= currentPosition.i)
                {
                    // Left
                    if (midLeft.j >= 0 && data[currentPosition.i].Length - 1 > midLeft.j)
                    {
                        if (IsSymbol(data, (currentPosition.i, midLeft.j)))
                        {
                            HasAdjacentSymbols = true;
                            return;
                        }
                    }

                    // Right
                    if (data[currentPosition.i].Length - 1 >= midRight.j)
                    {
                        if (IsSymbol(data, (currentPosition.i, midRight.j)))
                        {
                            HasAdjacentSymbols = true;
                            return;
                        }
                    }
                }

                // Below
                if (data.Count - 1 >= below)
                {
                    // Left
                    if (belowLeft.j >= 0 && data[below].Length - 1 > belowLeft.j)
                    {
                        if (IsSymbol(data, (below, belowLeft.j)))
                        {
                            HasAdjacentSymbols = true;
                            return;
                        }
                    }

                    // Mid
                    if (data[below].Length - 1 >= belowMid.j)
                    {
                        if (IsSymbol(data, (below, belowMid.j)))
                        {
                            HasAdjacentSymbols = true;
                            return;
                        }
                    }

                    // Right
                    if (data[below].Length - 1 >= belowRight.j)
                    {
                        if (IsSymbol(data, (below, belowRight.j)))
                        {
                            HasAdjacentSymbols = true;
                            return;
                        }
                    }
                }
            }
        }
    }
}
