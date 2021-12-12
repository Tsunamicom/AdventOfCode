using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_12_02 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 12;
        public int ChallengePart => 2;

        private List<List<string>> _allPaths = new();

        public string ResolveChallenge(List<string> data)
        {
            var connections = MapConnections(data);

            foreach (var location in connections["start"])
            {
                var visited = new HashSet<string>();
                var stack = new Stack<string>();

                visited.Add("start");
                stack.Push("start");

                TraverseConnections(connections, visited, stack, location);
            }

            return _allPaths.Count().ToString();
        }

        /// <summary>
        /// Traverse the connections in order to build the paths
        /// </summary>
        private void TraverseConnections(Dictionary<string, HashSet<string>> connections, HashSet<string> visited, Stack<string> stack, string currentLocation)
        {
            if (stack.Contains(currentLocation) && currentLocation.All(c => char.IsLower(c)))
            {
                var hasExistingDuplicateLowercase = stack
                    .GroupBy(c => c)
                    .Where(c => c.Key.All(c => char.IsLower(c)))
                    .Any(c => c.Count() > 1);

                if (hasExistingDuplicateLowercase) return;
            }

            visited.Add(currentLocation);
            stack.Push(currentLocation);

            if (currentLocation == "end")
            {
                _allPaths.Add(stack.ToList());
                stack.Pop();
                return;
            }

            foreach (var location in connections[currentLocation])
            {
                TraverseConnections(connections, visited, stack, location);
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
                if (connection[1] != "start" && connection[0] != "end") SetHashValue(mapping, connection[0], connection[1]);
                if (connection[0] != "start" && connection[1] != "end") SetHashValue(mapping, connection[1], connection[0]);
            }

            return mapping;
        }

        /// <summary>
        /// Set an array value Array[i][j] for a Dictionary and Hashset construct
        /// </summary>
        private static void SetHashValue<I, J>(Dictionary<I, HashSet<J>> dictionaryHash, I i, J j)
        {
            if (dictionaryHash.TryGetValue(i, out var jHash)) jHash.Add(j);
            else
            {
                dictionaryHash.Add(i, new HashSet<J>());
                dictionaryHash[i].Add(j);
            }
        }
    }
}