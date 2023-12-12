using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Challenges.Resolution.Tests
{
    public partial class Challenge_Tests
    {
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_01_01_Test()
        {
            var challenge = new Challenge_2023_01_01();
            var result = challenge.ResolveChallenge(_TestData_2023_01_01);

            Assert.AreEqual("142", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_01_02_Test()
        {
            var challenge = new Challenge_2023_01_02();
            var result = challenge.ResolveChallenge(_TestData_2023_01_02);

            Assert.AreEqual("281", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_02_01_Test()
        {
            var challenge = new Challenge_2023_02_01();
            var result = challenge.ResolveChallenge(_TestData_2023_02);

            Assert.AreEqual("8", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_02_02_Test()
        {
            var challenge = new Challenge_2023_02_02();
            var result = challenge.ResolveChallenge(_TestData_2023_02);

            Assert.AreEqual("2286", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_03_01_Test()
        {
            var challenge = new Challenge_2023_03_01();
            var result = challenge.ResolveChallenge(_TestData_2023_03);

            Assert.AreEqual("4361", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_03_02_Test()
        {
            var challenge = new Challenge_2023_03_02();
            var result = challenge.ResolveChallenge(_TestData_2023_03);

            Assert.AreEqual("467835", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_04_01_Test()
        {
            var challenge = new Challenge_2023_04_01();
            var result = challenge.ResolveChallenge(_TestData_2023_04);

            Assert.AreEqual("13", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_04_02_Test()
        {
            var challenge = new Challenge_2023_04_02();
            var result = challenge.ResolveChallenge(_TestData_2023_04);

            Assert.AreEqual("30", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_05_01_Test()
        {
            var challenge = new Challenge_2023_05_01();
            var result = challenge.ResolveChallenge(_TestData_2023_05);

            Assert.AreEqual("35", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_05_02_Test()
        {
            var challenge = new Challenge_2023_05_02();
            var result = challenge.ResolveChallenge(_TestData_2023_05);

            Assert.AreEqual("46", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_06_01_Test()
        {
            var challenge = new Challenge_2023_06_01();
            var result = challenge.ResolveChallenge(_TestData_2023_06);

            Assert.AreEqual("288", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_06_02_Test()
        {
            var challenge = new Challenge_2023_06_02();
            var result = challenge.ResolveChallenge(_TestData_2023_06);

            Assert.AreEqual("71503", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_07_01_Test()
        {
            var challenge = new Challenge_2023_07_01();
            var result = challenge.ResolveChallenge(_TestData_2023_07);

            Assert.AreEqual("6440", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_07_02_Test()
        {
            var challenge = new Challenge_2023_07_02();
            var result = challenge.ResolveChallenge(_TestData_2023_07);

            Assert.AreEqual("5905", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_08_01_Test()
        {
            var challenge = new Challenge_2023_08_01();
            var result = challenge.ResolveChallenge(_TestData_2023_08_01);

            Assert.AreEqual("6", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_08_02_Test()
        {
            var challenge = new Challenge_2023_08_02();
            var result = challenge.ResolveChallenge(_TestData_2023_08_02);

            Assert.AreEqual("6", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_09_01_Test()
        {
            var challenge = new Challenge_2023_09_01();
            var result = challenge.ResolveChallenge(_TestData_2023_09);

            Assert.AreEqual("114", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_09_02_Test()
        {
            var challenge = new Challenge_2023_09_02();
            var result = challenge.ResolveChallenge(_TestData_2023_09);

            Assert.AreEqual("2", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_10_01_Test()
        {
            var challenge = new Challenge_2023_10_01();
            var result1 = challenge.ResolveChallenge(_TestData_2023_10_01_01);
            Assert.AreEqual("4", result1);
            var result2 = challenge.ResolveChallenge(_TestData_2023_10_01_02);
            Assert.AreEqual("8", result2);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_10_02_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_10_02();
            var result = challenge.ResolveChallenge(_TestData_2023_10_01_02);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_11_01_Test()
        {
            var challenge = new Challenge_2023_11_01();
            var result = challenge.ResolveChallenge(_TestData_2023_11);

            Assert.AreEqual("374", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_11_02_Test()
        {
            var challenge = new Challenge_2023_11_02();
            var result = challenge.ResolveChallenge(_TestData_2023_11);

            Assert.AreEqual("82000210", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_12_01_Test()
        {
            var challenge = new Challenge_2023_12_01();
            var result = challenge.ResolveChallenge(_TestData_2023_12);

            Assert.AreEqual("21", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_12_02_Test()
        {
            var challenge = new Challenge_2023_12_02();
            var result = challenge.ResolveChallenge(_TestData_2023_12);

            Assert.AreEqual("525152", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_13_01_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_13_01();
            var result = challenge.ResolveChallenge(_TestData_2023_13);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_13_02_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_13_02();
            var result = challenge.ResolveChallenge(_TestData_2023_13);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_14_01_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_14_01();
            var result = challenge.ResolveChallenge(_TestData_2023_14);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_14_02_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_14_02();
            var result = challenge.ResolveChallenge(_TestData_2023_14);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_15_01_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_15_01();
            var result = challenge.ResolveChallenge(_TestData_2023_15);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_15_02_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_15_02();
            var result = challenge.ResolveChallenge(_TestData_2023_15);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_16_01_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_16_01();
            var result = challenge.ResolveChallenge(_TestData_2023_16);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_16_02_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_16_02();
            var result = challenge.ResolveChallenge(_TestData_2023_16);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_17_01_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_17_01();
            var result = challenge.ResolveChallenge(_TestData_2023_17);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_17_02_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_17_02();
            var result = challenge.ResolveChallenge(_TestData_2023_17);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_18_01_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_18_01();
            var result = challenge.ResolveChallenge(_TestData_2023_18);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_18_02_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_18_02();
            var result = challenge.ResolveChallenge(_TestData_2023_18);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_19_01_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_19_01();
            var result = challenge.ResolveChallenge(_TestData_2023_19);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_19_02_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_19_02();
            var result = challenge.ResolveChallenge(_TestData_2023_19);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_20_01_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_20_01();
            var result = challenge.ResolveChallenge(_TestData_2023_20);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_20_02_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_20_02();
            var result = challenge.ResolveChallenge(_TestData_2023_20);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_21_01_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_21_01();
            var result = challenge.ResolveChallenge(_TestData_2023_21);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_21_02_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_21_02();
            var result = challenge.ResolveChallenge(_TestData_2023_21);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_22_01_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_22_01();
            var result = challenge.ResolveChallenge(_TestData_2023_22);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_22_02_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_22_02();
            var result = challenge.ResolveChallenge(_TestData_2023_22);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_23_01_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_23_01();
            var result = challenge.ResolveChallenge(_TestData_2023_23);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_23_02_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_23_02();
            var result = challenge.ResolveChallenge(_TestData_2023_23);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_24_01_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_24_01();
            var result = challenge.ResolveChallenge(_TestData_2023_24);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_24_02_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_24_02();
            var result = challenge.ResolveChallenge(_TestData_2023_24);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part1")]
        public void ResolveChallenge_2023_25_01_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_25_01();
            var result = challenge.ResolveChallenge(_TestData_2023_25);

            Assert.AreEqual("Not Implemented", result);
        }
        [TestMethod(), TestCategory("2023"), TestCategory("Part2")]
        public void ResolveChallenge_2023_25_02_Test()
        {
            Assert.Inconclusive();
            var challenge = new Challenge_2023_25_02();
            var result = challenge.ResolveChallenge(_TestData_2023_25);

            Assert.AreEqual("Not Implemented", result);
        }

    }
}