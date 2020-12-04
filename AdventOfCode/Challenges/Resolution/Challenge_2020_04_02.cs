using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_04_02 : IChallengeResolution
    {
        public int ChallengeDay => 4;
        public int ChallengePart => 2;

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
                    if (IsCurrentPassPortValid(validatedFields, currentPassPort))
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
        private bool IsCurrentPassPortValid(List<string> validatedFields, Dictionary<string, string> passport)
        {
            try
            {
                if (validatedFields.All(f => passport.Keys.Contains(f)))
                {
                    var isValid =
                        IsValidYearValue(passport["byr"], 1920, 2002) &&
                        IsValidYearValue(passport["iyr"], 2010, 2020) &&
                        IsValidYearValue(passport["eyr"], 2020, 2030) &&
                        IsValidHeightValue(passport["hgt"], 150, 193, 59, 76) &&
                        IsValidHairColorValue(passport["hcl"]) &&
                        IsValidEyeColorValue(passport["ecl"], new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }) &&
                        IsValidPassportId(passport["pid"]);

                    return isValid;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }

        /// <summary>
        /// Evaluates the year value against the validation rules
        /// </summary>
        private bool IsValidYearValue(string val, int minYear, int maxYear)
        {
            var successParse = int.TryParse(val, out var valNum);
            return successParse &&
                val.Length == 4 &&
                valNum >= minYear &&
                valNum <= maxYear;
        }

        /// <summary>
        /// Evaluates the height value against the validation rules
        /// </summary>
        private bool IsValidHeightValue(string val, int minHeightcm, int maxHeightcm, int minHeightin, int maxHeightin)
        {
            if (val.Length < 3) return false;

            var measurement = val.Substring(val.Length - 2, 2);
            var heightValid = int.TryParse(val.Substring(0, val.Length - 2), out var height);

            if (!heightValid) return false;

            switch (measurement)
            {
                case "cm":
                    {
                        return height >= minHeightcm && height <= maxHeightcm;
                    }
                case "in":
                    {
                        return height >= minHeightin && height <= maxHeightin;
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        /// <summary>
        /// Evaluates the hair color value against the validation rules
        /// </summary>
        private bool IsValidHairColorValue(string val)
        {
            return Regex.IsMatch(val, "^#[0-9a-f]{6}$");
        }

        /// <summary>
        /// Evaluates the eye color value against the validation rules
        /// </summary>
        private bool IsValidEyeColorValue(string val, List<string> validEyeColors)
        {
            return validEyeColors.Contains(val);
        }

        /// <summary>
        /// Evaluates the Passport ID value against the validation rules
        /// </summary>
        private bool IsValidPassportId(string val)
        {
            return val.Length == 9 && int.TryParse(val, out var _);
        }
    }
}
