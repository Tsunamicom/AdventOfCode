using System.Collections.Generic;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_05_01 : IChallengeResolution
    {
        public int ChallengeDay => 5;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var maxSeatId = 0;

            foreach (var boardingPass in data)
            {
                var seatId = GetSeatId(boardingPass);

                // Determine the max between the new seatId discovered and the last max.
                maxSeatId = maxSeatId > seatId ? maxSeatId : seatId;
            }

            return maxSeatId.ToString();
        }

        /// <summary>
        /// Calculate the SeatId
        /// </summary>
        private static int GetSeatId(string boardingPass)
        {
            int rowIdxLower = 0;
            int rowIdxUpper = 127;
            int columnIdxLower = 0;
            int columnIdxUpper = 7;

            foreach (var code in boardingPass)
            {
                switch (code)
                {
                    case 'F':
                        {
                            rowIdxUpper -= ((rowIdxUpper - rowIdxLower) / 2) + 1;
                            break;
                        }
                    case 'B':
                        {
                            rowIdxLower += ((rowIdxUpper - rowIdxLower) / 2) + 1;
                            break;
                        }
                    case 'R':
                        {
                            columnIdxLower += ((columnIdxUpper - columnIdxLower) / 2) + 1;
                            break;
                        }
                    case 'L':
                        {
                            columnIdxUpper -= ((columnIdxUpper - columnIdxLower) / 2) + 1;
                            break;
                        }
                }
            }

            return (rowIdxLower * 8) + columnIdxLower;
        }
    }
}
