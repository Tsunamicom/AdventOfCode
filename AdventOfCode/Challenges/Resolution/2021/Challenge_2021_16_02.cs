using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_16_02 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 16;
        public int ChallengePart => 2;

        List<(int, int, long)> _packetInfo = new();
        /// <summary>
        /// For Unit Tests
        /// </summary>
        public string ResolveChallenge(string message)
        {
            var messageBinary = string.Concat(message.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

            _packetInfo.Clear();

            // (packetVersion, packetTypeId, value)
            GetEncodedString(messageBinary, _packetInfo, -1);
            var sum = 0L;
            //for (int i = 0; i < packetInfo.Count; i++)
            //{
            sum = CountVals(_packetInfo, 0);
            //}


            return $"{sum}";
        }

        private long CountVals(List<(int, int, long)> packetInfo, int index)
        {
            if (index < 0) return 0;
            var (_, type, value) = packetInfo[index];

            if (packetInfo.Count > 1)
            {
                var subPackets = packetInfo.GetRange(1, packetInfo.Count - 1);

                switch (type)
                {
                    case 0:
                        {
                            return subPackets.Sum(c => CountVals(subPackets, subPackets.IndexOf(c)));
                        }
                    case 1:
                        {
                            return subPackets.Aggregate(1L, (sum, b) => sum * CountVals(subPackets, subPackets.IndexOf(b)));
                        }
                    case 2:
                        {
                            return subPackets.Min(c => CountVals(subPackets, subPackets.IndexOf(c)));
                        }
                    case 3:
                        {
                            return subPackets.Max(c => CountVals(subPackets, subPackets.IndexOf(c)));
                        }
                    case 5:
                        {
                            return Convert.ToInt64(CountVals(subPackets, 0) > CountVals(subPackets, 1));
                        }
                    case 6:
                        {
                            return Convert.ToInt64(CountVals(subPackets, 0) < CountVals(subPackets, 1));
                        }
                    case 7:
                        {
                            var x = CountVals(subPackets, 0);
                            var y = CountVals(subPackets, 1);
                            return Convert.ToInt64(x == y); 
                        }
                }
            }
            
            return value;
        }


        /// <summary>
        /// For file input
        /// </summary>
        public string ResolveChallenge(List<string> data)
        {
            var message = data.First();
            var messageBinary = string.Concat(message.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

            // (packetVersion, packetTypeId, value)
            List<(int, int, long)> packetInfo = new();

            GetEncodedString(messageBinary, packetInfo, -1);

            return $"{packetInfo.Sum(c => c.Item1)}";
        }

        /// <summary>
        /// For a given encoded binary string, catalogue the decoded packet details (possible nested)
        /// </summary>
        private void GetEncodedString(string messageBinary, List<(int, int, long)> packetInfo, int count)
        {
            if (string.IsNullOrEmpty(messageBinary)
                || int.TryParse(messageBinary, out var msgVal) && msgVal == 0)
            {
                return;
            }

            var packetVersion = Convert.ToInt32(messageBinary.Substring(0, 3), 2); // Need to sum all of these, maybe make (packetVersion, currentString) as return
            var packetTypeId = Convert.ToInt32(messageBinary.Substring(3, 3), 2);

            if (packetTypeId == 4)
            {
                var (processedCount, value) = GetLiteral(messageBinary);
                packetInfo.Add((packetVersion, packetTypeId, value));

                var remainingToProcess = messageBinary.Substring(processedCount);
                GetEncodedString(remainingToProcess, packetInfo, count - 1);
            }
            else
            {
                packetInfo.Add((packetVersion, packetTypeId, 0));

                switch (messageBinary[6])
                {
                    case '0':
                        {
                            // 15 bits for Length
                            var pkLength = Convert.ToInt32(messageBinary.Substring(7, 15), 2);

                            GetEncodedString(messageBinary.Substring(22, pkLength), packetInfo, -1);
                            GetEncodedString(messageBinary.Substring(22 + pkLength), packetInfo, count - 1);
                            break;
                        }
                    case '1':
                        {
                            // 11 bits for Count
                            var packetCount = Convert.ToInt32(messageBinary.Substring(7, 11), 2);

                            GetEncodedString(messageBinary.Substring(18), packetInfo, packetCount);
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Calculate the Literal Value.  Track the count of digits we had to traverse.
        /// </summary>
        private (int, long) GetLiteral(string messageBinary)
        {
            // Parse as Literal Value
            var sb = new StringBuilder();
            var count = 0;
            // Start at 6 because we've already read these
            for (int i = 6; i <= messageBinary.Length - 5; i += 5)
            {
                count = i + 5;
                sb.Append(messageBinary.AsSpan(i + 1, 4));
                if (messageBinary[i] == '0')
                {
                    break;
                }
            }

            return (count, Convert.ToInt64(sb.ToString(), 2));
        }
    }
}