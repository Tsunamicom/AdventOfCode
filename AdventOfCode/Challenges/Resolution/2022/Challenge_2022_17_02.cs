using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2022_17_02 : IChallengeResolution
    {
        public int ChallengeYear => 2022;
        public int ChallengeDay => 17;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var numberOfRocks = 1000000000000;

            var currentMap = new HashSet<(long, long)>()
            {
                // Initialize Bottom Layer
                (0,0), (1,0), (2,0), (3,0), (4,0), (5,0), (6,0)
            };

            var blockedDepths = new Dictionary<int, long>();

            var jetPatternCharValueMap = new Dictionary<char, int>() { { '>', 1 }, { '<', -1 } };
            var jetPattern = data.Single().Select(c => jetPatternCharValueMap[c]).ToList();

            var currentJetPatternPosition = 0;
            var currentRockType = 0;

            var maxHeight = currentMap.Max(c => c.Item2);

            // <(jetPatternIndex, rockType), (rockCount, maxHeight)>
            var cycleDictionary = new Dictionary<(long, long), (long, long)>();

            long finalResult = 0;

            for (int rockCount = 0; rockCount < numberOfRocks; rockCount++)
            {
                var cycleKey = (currentJetPatternPosition, currentRockType);
                maxHeight = currentMap.Max(c => c.Item2);

                // Try to determine whether there is a cycle
                // by detecting whether we've seen a specific 
                // jetStream index and rockType.  This would mean
                // that we've gone full circle and will just continue
                // to see the same patterns.
                if (cycleDictionary.ContainsKey(cycleKey))
                {
                    // Potential Candidate found
                    var cycleRocks = rockCount - cycleDictionary[cycleKey].Item1;

                    var numberOfRocksRemainder = numberOfRocks % cycleRocks;
                    var rockCountRemainder = rockCount % cycleRocks;

                    var rocksLeft = numberOfRocks - rockCount;

                    var hasRemainingCycle = rocksLeft > cycleRocks;

                    // Make sure we have an even distribution
                    if (hasRemainingCycle && numberOfRocksRemainder == rockCountRemainder)
                    {
                        // Cycle Found
                        var cycleHeight = maxHeight - cycleDictionary[cycleKey].Item2;


                        long lastItemValue = 0;
                        var attachLastCycle = false;
                        if (hasRemainingCycle)
                        {
                            attachLastCycle = true;
                            lastItemValue = cycleDictionary[cycleKey].Item2;
                        }
                        else
                        {
                            lastItemValue = cycleDictionary.Last().Value.Item2;
                        }

                        // Determine how many cycles are left, make sure to add the currently calculated one.
                        var cyclesLeft = (rocksLeft / cycleRocks) + (attachLastCycle ? 1 : 0);

                        var expectedElevation = (cycleHeight * cyclesLeft) + lastItemValue;
                        finalResult = expectedElevation;
                        break;
                    }
                }
                else
                {
                    cycleDictionary.Add(cycleKey, (rockCount, maxHeight));
                }

                // Initialize Rock (next rock begins falling)
                var rock = GetNextRock(currentRockType);
                rock.SetStartingPositions(maxHeight);

                // While Rock Can Move
                while (rock.CanFall)
                {
                    // Check Push
                    // If Check Success: Push -- If can't drop, then last try
                    var jetPatternXOffsetValue = jetPattern[currentJetPatternPosition];

                    rock.CanPush = rock.CheckCanPush(currentMap, jetPatternXOffsetValue);
                    if (rock.CanPush)
                    {
                        rock.Push(jetPatternXOffsetValue);
                        if (!rock.CanFall) rock.CanPush = false;
                    }

                    // Check Fall
                    // If Check Fall Success:  Fall; 
                    rock.CanFall = rock.CheckCanFall(currentMap);
                    if (rock.CanFall)
                    {
                        rock.Fall();
                    }

                    // Cycle the jetPattern index back to either next value or back to 0
                    var newJetPatternPosition = ((currentJetPatternPosition + 1) >= jetPattern.Count)
                        ? 0
                        : (currentJetPatternPosition + 1);
                    currentJetPatternPosition = newJetPatternPosition;
                }

                foreach (var point in rock.Positions)
                {
                    currentMap.Add(point);
                }

                currentRockType = (currentRockType + 1) % 5;

                // Optimize:  Truncate current map
                currentMap = currentMap.TakeLast(100).ToHashSet();

            }
            maxHeight = currentMap.Max(c => c.Item2);
            if (finalResult == 0) finalResult = maxHeight;
            return finalResult.ToString();
        }

        private static Rock GetNextRock(int rockType)
        {
            return rockType switch
            {
                0 => new HorizontalRock(),
                1 => new PlusSignRock(),
                2 => new BackwardLRock(),
                3 => new VerticalLineRock(),
                4 => new SquareRock(),
                _ => throw new ArgumentException($"RockType {rockType} is unknown."),
            };
        }

        #region Rock Definitions

        private abstract class Rock
        {
            internal bool CanFall { get; set; } = true;
            internal bool CanPush { get; set; } = true;

            internal HashSet<(long, long)> Positions { get; set; } = new HashSet<(long, long)>();

            internal abstract void SetStartingPositions(long maxMapHeight);

            internal bool CheckCanFall(HashSet<(long, long)> currentMap)
            {
                var offsetPositions = Positions.Select(x => (x.Item1, x.Item2 - 1));

                // Collision with currently placed objects on the map
                if (currentMap.Intersect(offsetPositions).Any())
                {
                    return false;
                }

                return true;
            }

            internal void Fall()
            {
                Positions = Positions.Select(x => (x.Item1, x.Item2 - 1)).ToHashSet();
            }

            internal bool CheckCanPush(HashSet<(long, long)> currentMap, int pushXOffset) // pushXOffset -1 or 1
            {
                var offsetPositions = Positions.Select(x => (x.Item1 + pushXOffset, x.Item2));
                var direction = pushXOffset > 0 ? "right" : "left";

                // Collision with edge of the map
                if (offsetPositions.Select(x => x.Item1).Any(x => x < 0 || x > 6))
                {
                    return false;
                }

                // Collision with currently placed objects on the map
                if (currentMap.Intersect(offsetPositions).Any())
                {
                    return false;
                }

                return true;
            }

            internal void Push(int pushXOffset)
            {
                Positions = Positions.Select(x => (x.Item1 + pushXOffset, x.Item2)).ToHashSet();
            }

        }

        private class HorizontalRock : Rock
        {
            internal override void SetStartingPositions(long maxMapHeight)
            {
                Positions.Add((2, maxMapHeight + 4));
                Positions.Add((3, maxMapHeight + 4));
                Positions.Add((4, maxMapHeight + 4));
                Positions.Add((5, maxMapHeight + 4));
            }
        }

        private class PlusSignRock : Rock
        {
            internal override void SetStartingPositions(long maxMapHeight)
            {
                Positions.Add((3, maxMapHeight + 6));
                Positions.Add((2, maxMapHeight + 5));
                Positions.Add((3, maxMapHeight + 5));
                Positions.Add((4, maxMapHeight + 5));
                Positions.Add((3, maxMapHeight + 4));
            }
        }

        private class BackwardLRock : Rock
        {
            internal override void SetStartingPositions(long maxMapHeight)
            {


                Positions.Add((4, maxMapHeight + 6));
                Positions.Add((4, maxMapHeight + 5));
                Positions.Add((2, maxMapHeight + 4));
                Positions.Add((3, maxMapHeight + 4));
                Positions.Add((4, maxMapHeight + 4));
            }
        }

        private class VerticalLineRock : Rock
        {
            internal override void SetStartingPositions(long maxMapHeight)
            {
                Positions.Add((2, maxMapHeight + 7));
                Positions.Add((2, maxMapHeight + 6));
                Positions.Add((2, maxMapHeight + 5));
                Positions.Add((2, maxMapHeight + 4));
            }
        }

        private class SquareRock : Rock
        {
            internal override void SetStartingPositions(long maxMapHeight)
            {
                Positions.Add((2, maxMapHeight + 5));
                Positions.Add((3, maxMapHeight + 5));
                Positions.Add((2, maxMapHeight + 4));
                Positions.Add((3, maxMapHeight + 4));
            }
        }

        #endregion
    }
}