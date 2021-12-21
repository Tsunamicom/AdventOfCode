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

        private class PacketInfo
        {
            public PacketInfo(PacketInfo parentPacket, string packageMessage, int version, int typeId, long value)
            {
                Parent = parentPacket;
                PackageMessage = packageMessage;
                Version = version;
                TypeId = typeId;
                Value = value;
            }

            public string PackageMessage { get; set; }

            public PacketInfo Parent { get; set; }

            public List<PacketInfo> Children = new();

            public int Version { get; private set; }

            public int TypeId { get; private set; }

            public long Value { get; set; }
        }


        public string ResolveChallenge(string message)
        {
            var messageBinary = string.Concat(message.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

            PacketInfo parentPacket = new PacketInfo(null, messageBinary, -1, -1, 0);

            var (parsedIdx, currentPacket) = GetEncodedString(messageBinary, parentPacket, 0);

            //var packetVersionSum = GetVersionSum(currentPacket);
            var bitEval = CountVals(currentPacket);

            return $"{bitEval}";
        }

        /// <summary>
        /// File Input wrapper
        /// </summary>
        public string ResolveChallenge(List<string> data)
        {
            var message = data.First();
            return ResolveChallenge(message);
        }

        private long GetVersionSum(PacketInfo packetInfo)
        {
            var sum = (packetInfo.Version == -1) ? 0 : packetInfo.Version;

            if (packetInfo.Children.Any())
            {
                return sum + packetInfo.Children.Sum(c => GetVersionSum(c));
            }

            return sum;
        }

        /// <summary>
        /// For a given encoded binary string, catalogue the decoded packet details (possible nested) and return the current Index
        /// </summary>
        private (int, PacketInfo) GetEncodedString(string messageBinary, PacketInfo parentPacket, int indexMod)
        {
            if (string.IsNullOrEmpty(messageBinary)
                || int.TryParse(messageBinary, out var msgVal) && msgVal == 0)
            {
                return (messageBinary?.Length - 1 ?? 0, null);
            }

            var packetVersion = Convert.ToInt32(messageBinary.Substring(0, 3), 2); // Need to sum all of these, maybe make (packetVersion, currentString) as return
            var packetTypeId = Convert.ToInt32(messageBinary.Substring(3, 3), 2);

            var currentPacket = new PacketInfo(parentPacket, messageBinary, packetVersion, packetTypeId, 0);
            if (parentPacket == null) parentPacket = currentPacket;

            indexMod = 0;

            if (packetTypeId == 4)
            {
                var (processedCount, value) = GetLiteral(messageBinary);

                currentPacket.Value = value;

                indexMod = processedCount;
                var remaining = messageBinary.Length - processedCount;
                if (remaining < 11) indexMod += remaining;
            }
            else
            {

                switch (messageBinary[6])
                {
                    case '0':
                        {
                            // 15 bits for Length
                            var pkLength = Convert.ToInt32(messageBinary.Substring(7, 15), 2);

                            while (pkLength > 0)
                            {
                                (var indexMod1, var newPacket1) = GetEncodedString(messageBinary.Substring(22 + indexMod, pkLength), currentPacket, indexMod);
                                if (newPacket1 != null)
                                {
                                    currentPacket.Children.Add(newPacket1);
                                }
                                indexMod += indexMod1;
                                pkLength -= indexMod1;
                            }
                            indexMod += 22;

                            break;
                        }
                    case '1':
                        {
                            // 11 bits for Count
                            var packetCount = Convert.ToInt32(messageBinary.Substring(7, 11), 2);

                            for (int i = 0; i < packetCount; i++)
                            {
                                var msgToParse = messageBinary.Substring(18 + indexMod);
                                (var indexMod3, var newPacket) = GetEncodedString(msgToParse, currentPacket, indexMod);

                                if (newPacket != null)
                                {
                                    currentPacket.Children.Add(newPacket);
                                }

                                indexMod += indexMod3;
                            }
                            indexMod += 18;

                            break;
                        }
                }
            }
            return (indexMod, currentPacket);
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

        private long CountVals(PacketInfo packetInfo)
        {
            var subPackets = packetInfo.Children;

            if (subPackets.Any())
            {
                switch (packetInfo.TypeId)
                {
                    case 0:
                        {
                            return subPackets.Sum(c => CountVals(c));
                        }
                    case 1:
                        {
                            return subPackets.Aggregate(1L, (sum, b) => sum * CountVals(b));
                        }
                    case 2:
                        {
                            return subPackets.Min(c => CountVals(c));
                        }
                    case 3:
                        {
                            return subPackets.Max(c => CountVals(c));
                        }
                    case 5:
                        {
                            return Convert.ToInt64(CountVals(subPackets[0]) > CountVals(subPackets[1]));
                        }
                    case 6:
                        {
                            return Convert.ToInt64(CountVals(subPackets[0]) < CountVals(subPackets[1]));
                        }
                    case 7:
                        {
                            var x = CountVals(subPackets[0]);
                            var y = CountVals(subPackets[1]);
                            return Convert.ToInt64(x == y);
                        }
                }
            }

            return packetInfo.Value;
        }
    }
}