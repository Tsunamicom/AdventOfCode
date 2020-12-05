using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_04_01 : IChallengeResolution
    {
        public int ChallengeDay => 4;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var validPassports = 0;
            data.Add(string.Empty); // Add a new line at end to facilitate passport detection

            var validatedFields = new List<string>() { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            var currentPassPort = new Dictionary<string, string>();
            foreach (var passportLine in data)
            {
                if (string.IsNullOrEmpty(passportLine))
                {
                    if (IsCurrentPassportValid(validatedFields, currentPassPort))
                    {
                        validPassports++;
                    }
                    currentPassPort = new Dictionary<string, string>();
                }
                else
                {
                    passportLine.Split(' ').Select(f => f.Split(':')).ToList()
                        .ForEach(kvp => currentPassPort.Add(kvp[0], kvp[1]));
                }
            }

            return validPassports.ToString();
        }

        /// <summary>
        /// Evaluates the current passport to determine whether it meets the validation criteria
        /// </summary>
        private bool IsCurrentPassportValid(List<string> validatedFields, Dictionary<string, string> passport)
        {
            return validatedFields.All(f => passport.Keys.Contains(f));
        }
    }
}
