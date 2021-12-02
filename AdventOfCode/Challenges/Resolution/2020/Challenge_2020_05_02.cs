using System.Collections.Generic;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_05_02 : IChallengeResolution
    {
        public int ChallengeYear => 2020;
        public int ChallengeDay => 5;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var seats = new List<int>();
            var mySeat = 0;

            foreach (var boardingPass in data)
            {
                var seatId = GetSeatId(boardingPass);
                seats.Add(seatId);
            }

            for (int i = 0; i < 1024; i++)
            {
                if (!seats.Contains(i) && seats.Contains(i - 1) && seats.Contains(i + 1))
                {
                    mySeat = i;
                    break;
                }
            }

            return mySeat.ToString();
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
