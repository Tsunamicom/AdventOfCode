using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_24_01 : IChallengeResolution
    {
        public int ChallengeYear => 2020;
        public int ChallengeDay => 24;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var blackTilePositions = new HashSet<Tuple<int, int>>();

            foreach (var tile in data)
            {
                var currentTilePosition = GetCurrentTilePosition(tile);

                if (blackTilePositions.Contains(currentTilePosition))
                {
                    blackTilePositions.Remove(currentTilePosition);
                }
                else
                {
                    blackTilePositions.Add(currentTilePosition);
                }
            }

            return blackTilePositions.Count.ToString();
        }

        private Tuple<int, int> GetCurrentTilePosition(string tileLocation)
        {
            var x = 0;
            var y = 0;

            // Designate sides
            tileLocation = new StringBuilder(tileLocation)
                .Replace("se", "1")
                .Replace("sw", "2")
                .Replace("ne", "3")
                .Replace("nw", "4")
                .Replace("e", "5")
                .Replace("w", "6")
                .ToString();

            foreach (var directionCode in tileLocation)
            {
                switch (directionCode)
                {
                    case '1': // se
                        {
                            y -= 1;
                            x += 1;
                            break;
                        }
                    case '2': // sw
                        {
                            y -= 1;
                            x -= 1;
                            break;
                        }
                    case '3': // ne
                        {
                            y += 1;
                            x += 1;
                            break;
                        }
                    case '4': // nw
                        {
                            y += 1;
                            x -= 1;
                            break;
                        }
                    case '5': // e
                        {
                            x += 2;
                            break;
                        }
                    case '6': // w
                        {
                            x -= 2;
                            break;
                        }
                }
            }

            return new Tuple<int, int>(x, y);
        }
    }
}