using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_12_01 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 12;
        public int ChallengePart => 1;

        private readonly List<List<string>> _allPaths = new();
        private static readonly string _startLabel = "start";
        private static readonly string _endLabel = "end";

        public string ResolveChallenge(List<string> data)
        {
            var connections = MapConnections(data);

            foreach (var location in connections[_startLabel])
            {
                var stack = new Stack<string>();
                stack.Push(_startLabel);

                TraverseConnections(connections, stack, location);
            }

            return _allPaths.Count().ToString();
        }

        /// <summary>
        /// Traverse the connections in order to build the paths
        /// </summary>
        private void TraverseConnections(Dictionary<string, HashSet<string>> connections, Stack<string> stack, string currentLocation)
        {
            if (stack.Contains(currentLocation) && currentLocation.All(c => char.IsLower(c)))
            {
                return;
            }

            stack.Push(currentLocation);

            if (currentLocation == _endLabel)
            {
                _allPaths.Add(stack.ToList());
                stack.Pop();
                return;
            }

            foreach (var location in connections[currentLocation])
            {
                TraverseConnections(connections, stack, location);
            }
            stack.Pop();
        }


        /// <summary>
        /// Map all connections
        /// </summary>
        private static Dictionary<string, HashSet<string>> MapConnections(List<string> data)
        {
            Dictionary<string, HashSet<string>> mapping = new();

            foreach (var line in data)
            {
                var connection = line.Split("-");
                if (connection[1] != _startLabel && connection[0] != _endLabel) SetHashValue(mapping, connection[0], connection[1]);
                if (connection[0] != _startLabel && connection[1] != _endLabel) SetHashValue(mapping, connection[1], connection[0]);
            }

            return mapping;
        }

        /// <summary>
        /// Set an array value Array[i][j] for a Dictionary and Hashset construct
        /// </summary>
        private static void SetHashValue<IType, JType>(Dictionary<IType, HashSet<JType>> dictionaryHash, IType iVal, JType jVal)
        {
            if (dictionaryHash.TryGetValue(iVal, out var jHash)) jHash.Add(jVal);
            else
            {
                dictionaryHash.Add(iVal, new HashSet<JType>());
                dictionaryHash[iVal].Add(jVal);
            }
        }
    }
}