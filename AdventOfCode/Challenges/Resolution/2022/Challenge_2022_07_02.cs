using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2022_07_02 : IChallengeResolution
    {
        public int ChallengeYear => 2022;
        public int ChallengeDay => 7;
        public int ChallengePart => 2;

        private static Dictionary<string, Directory> _directories = new Dictionary<string, Directory>();

        private class Directory
        {
            internal string Parent { get; set; }
            internal string Path { get; set; }
            internal HashSet<File> Files { get; set; } = new HashSet<File>();
            internal HashSet<string> Directories { get; set; } = new HashSet<string>();
            internal long? Size { get; set; }

            internal long GetSize()
            {
                if (Size != null)
                {
                    // Optimize
                    return Size.GetValueOrDefault();
                }

                var fileSize = Files?.Sum(c => c.Size) ?? 0;
                long directoriesSize = Directories?.Sum(c => _directories[c].GetSize()) ?? 0;

                Size = fileSize + directoriesSize;

                return Size.GetValueOrDefault();
            }

        }

        private class File
        {
            internal string Name { get; set; }
            internal long Size { get; set; }
        }

        public void LoadFileSystem(List<string> commands)
        {
            _directories.Clear();
            string currentDir = null;
            foreach (var cmd in commands)
            {
                if (cmd == "$ ls") continue;

                if (cmd.StartsWith("$ cd"))
                {
                    var parsedDir = cmd.Split(' ')[2];

                    if (parsedDir == "..")
                    {
                        // Go Back
                        currentDir = _directories[currentDir].Parent;
                    }
                    else
                    {
                        // Switch to Dir
                        var currentPath = $"{currentDir}{parsedDir}/";
                        if (!_directories.ContainsKey(currentPath))
                        {
                            _directories.Add(currentPath, new Directory() { Path = currentPath, Parent = currentPath });
                        }

                        currentDir = currentPath;
                    }
                }
                else
                {
                    var parsedOutput = cmd.Split(' ');
                    if (parsedOutput[0] == "dir")
                    {
                        var parsedDir = parsedOutput[1];
                        var currentPath = $"{currentDir}{parsedDir}/";
                        // Handle as Dir
                        if (!_directories.ContainsKey(currentPath))
                        {
                            _directories.Add(currentPath, new Directory() { Path = currentPath, Parent = currentDir });
                        }
                        _directories[currentDir].Directories.Add(currentPath);
                    }
                    else
                    {
                        // Assume File
                        _directories[currentDir].Files.Add(new File() { Size = long.Parse(parsedOutput[0]), Name = $"{currentDir}-{parsedOutput[1]}" });
                    }
                }
            }
        }


        public string ResolveChallenge(List<string> data)
        {
            LoadFileSystem(data);

            var totalDiskSpace = 70000000;
            var targetSpace = 30000000;

            var directoriesOfSize = _directories.Values.Select(c => c.GetSize()).OrderByDescending(c => c);
            var spaceToFreeUp = targetSpace - (totalDiskSpace - directoriesOfSize.First());

            var minimumImpactDeleteTarget = directoriesOfSize.Last(c => c >= spaceToFreeUp);


            return minimumImpactDeleteTarget.ToString();
        }
    }
}