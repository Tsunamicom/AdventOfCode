using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_16_01 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 16;
        public int ChallengePart => 1;

        /// <summary>
        /// For Unit Tests
        /// </summary>
        public string ResolveChallenge(string message)
        {
            var messageBinary = string.Concat(message.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

            // (packetVersion, packetTypeId, value)
            List<(int, int, long)> packetInfo = new();

            GetEncodedString(messageBinary, packetInfo, -1);

            return $"{packetInfo.Sum(c => c.Item1)}";
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