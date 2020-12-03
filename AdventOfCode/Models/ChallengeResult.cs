namespace AdventOfCode.Models
{
    public class ChallengeResult
    {
        /// <summary>
        /// The day of the challenge
        /// </summary>
        public int ChallengeDay { get; set; }

        /// <summary>
        /// The part of the challenge, which can increment when multiple parts on the same day.
        /// </summary>
        public int ChallengePart { get; set; }

        /// <summary>
        /// The result of the challenge
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Indicates if an error occured.
        /// </summary>
        public bool HasError { get; set; }

        /// <summary>
        /// The time to resolve in milliseconds
        /// </summary>
        public long ResolveTime { get; set; }
    }
}
