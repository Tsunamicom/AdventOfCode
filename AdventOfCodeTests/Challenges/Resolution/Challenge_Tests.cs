using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdventOfCode.Challenges.Resolution.Tests
{
    [TestClass()]
    public partial class Challenge_Tests
    {
        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_01_01_Test()
        {
            var challenge = new Challenge_2021_01_01();
            var result = challenge.ResolveChallenge(_TestData_2021_01);

            Assert.AreEqual("7", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_01_02_Test()
        {
            var challenge = new Challenge_2021_01_02();
            var result = challenge.ResolveChallenge(_TestData_2021_01);

            Assert.AreEqual("5", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_02_01_Test()
        {
            var challenge = new Challenge_2021_02_01();
            var result = challenge.ResolveChallenge(_TestData_2021_02);

            Assert.AreEqual("150", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_02_02_Test()
        {
            var challenge = new Challenge_2021_02_02();
            var result = challenge.ResolveChallenge(_TestData_2021_02);

            Assert.AreEqual("900", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_03_01_Test()
        {
            var challenge = new Challenge_2021_03_01();
            var result = challenge.ResolveChallenge(_TestData_2021_03);

            Assert.AreEqual("198", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_03_02_Test()
        {
            var challenge = new Challenge_2021_03_02();
            var result = challenge.ResolveChallenge(_TestData_2021_03);

            Assert.AreEqual("230", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_04_01_Test()
        {
            var challenge = new Challenge_2021_04_01();
            var result = challenge.ResolveChallenge(_TestData_2021_04);

            Assert.AreEqual("4512", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_04_02_Test()
        {
            var challenge = new Challenge_2021_04_02();
            var result = challenge.ResolveChallenge(_TestData_2021_04);

            Assert.AreEqual("1924", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_05_01_Test()
        {
            var challenge = new Challenge_2021_05_01();
            var result = challenge.ResolveChallenge(_TestData_2021_05);

            Assert.AreEqual("5", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_05_02_Test()
        {
            var challenge = new Challenge_2021_05_02();
            var result = challenge.ResolveChallenge(_TestData_2021_05);

            Assert.AreEqual("12", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_06_01_Test()
        {
            var challenge = new Challenge_2021_06_01();
            var result = challenge.ResolveChallenge(_TestData_2021_06);

            Assert.AreEqual("5934", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_06_02_Test()
        {
            var challenge = new Challenge_2021_06_02();
            var result = challenge.ResolveChallenge(_TestData_2021_06);

            Assert.AreEqual("26984457539", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_07_01_Test()
        {
            Assert.Inconclusive("Need to re-do this logic, take Average.");
            var challenge = new Challenge_2021_07_01();
            var result = challenge.ResolveChallenge(_TestData_2021_07);

            Assert.AreEqual("37", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_07_02_Test()
        {
            Assert.Inconclusive("Need to re-do this logic, take Average.");
            var challenge = new Challenge_2021_07_02();
            var result = challenge.ResolveChallenge(_TestData_2021_07);

            Assert.AreEqual("168", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_08_01_Test()
        {
            var challenge = new Challenge_2021_08_01();
            var result = challenge.ResolveChallenge(_TestData_2021_08);

            Assert.AreEqual("26", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_08_02_Test()
        {
            var challenge = new Challenge_2021_08_02();
            var result = challenge.ResolveChallenge(_TestData_2021_08);

            Assert.AreEqual("61229", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_09_01_Test()
        {
            var challenge = new Challenge_2021_09_01();
            var result = challenge.ResolveChallenge(_TestData_2021_09);

            Assert.AreEqual("15", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_09_02_Test()
        {
            var challenge = new Challenge_2021_09_02();
            var result = challenge.ResolveChallenge(_TestData_2021_09);

            Assert.AreEqual("1134", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_10_01_Test()
        {
            var challenge = new Challenge_2021_10_01();
            var result = challenge.ResolveChallenge(_TestData_2021_10);

            Assert.AreEqual("26397", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_10_02_Test()
        {
            var challenge = new Challenge_2021_10_02();
            var result = challenge.ResolveChallenge(_TestData_2021_10);

            Assert.AreEqual("288957", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_11_01_Test()
        {
            var challenge = new Challenge_2021_11_01();
            var result = challenge.ResolveChallenge(_TestData_2021_11);

            Assert.AreEqual("1656", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_11_02_Test()
        {
            var challenge = new Challenge_2021_11_02();
            var result = challenge.ResolveChallenge(_TestData_2021_11);

            Assert.AreEqual("195", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_12_01_Mod1_Test()
        {
            var challenge = new Challenge_2021_12_01();
            var result = challenge.ResolveChallenge(_TestData_2021_12_Mod1);

            Assert.AreEqual("10", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_12_01_Mod2_Test()
        {
            var challenge = new Challenge_2021_12_01();
            var result = challenge.ResolveChallenge(_TestData_2021_12_Mod2);

            Assert.AreEqual("19", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_12_02_Mod1_Test()
        {
            var challenge = new Challenge_2021_12_02();
            var result = challenge.ResolveChallenge(_TestData_2021_12_Mod1);

            Assert.AreEqual("36", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_12_02_Mod2_Test()
        {
            var challenge = new Challenge_2021_12_02();
            var result = challenge.ResolveChallenge(_TestData_2021_12_Mod2);

            Assert.AreEqual("103", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_13_01_Test()
        {
            var challenge = new Challenge_2021_13_01();
            var result = challenge.ResolveChallenge(_TestData_2021_13);

            Assert.AreEqual("17", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_13_02_Test()
        {
            var challenge = new Challenge_2021_13_02();
            var result = challenge.ResolveChallenge(_TestData_2021_13);

            var expectedValueList = new List<string>()
            {
                "#####",
                "#...#",
                "#...#",
                "#...#",
                "#####",
                ".....",
                "....."
            };

            var expectedValue = string.Join(",", expectedValueList);

            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_14_01_Test()
        {
            var challenge = new Challenge_2021_14_01();
            var result = challenge.ResolveChallenge(_TestData_2021_14);

            Assert.AreEqual("1588", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_14_02_Test()
        {
            var challenge = new Challenge_2021_14_02();
            var result = challenge.ResolveChallenge(_TestData_2021_14);

            Assert.AreEqual("2188189693529", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_15_01_Test()
        {
            var challenge = new Challenge_2021_15_01();
            var result = challenge.ResolveChallenge(_TestData_2021_15);

            Assert.AreEqual("40", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_15_02_Test()
        {
            var challenge = new Challenge_2021_15_02();
            var result = challenge.ResolveChallenge(_TestData_2021_15);

            Assert.AreEqual("315", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_16_01_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2021_16_01();
            var result = challenge.ResolveChallenge(_TestData_2021_16);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_16_02_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2021_16_02();
            var result = challenge.ResolveChallenge(_TestData_2021_16);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_17_01_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2021_17_01();
            var result = challenge.ResolveChallenge(_TestData_2021_17);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_17_02_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2021_17_02();
            var result = challenge.ResolveChallenge(_TestData_2021_17);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_18_01_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2021_18_01();
            var result = challenge.ResolveChallenge(_TestData_2021_18);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_18_02_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2021_18_02();
            var result = challenge.ResolveChallenge(_TestData_2021_18);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_19_01_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2021_19_01();
            var result = challenge.ResolveChallenge(_TestData_2021_19);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_19_02_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2021_19_02();
            var result = challenge.ResolveChallenge(_TestData_2021_19);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_20_01_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2021_20_01();
            var result = challenge.ResolveChallenge(_TestData_2021_20);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_20_02_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2021_20_02();
            var result = challenge.ResolveChallenge(_TestData_2021_20);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_21_01_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2021_21_01();
            var result = challenge.ResolveChallenge(_TestData_2021_21);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_21_02_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2021_21_02();
            var result = challenge.ResolveChallenge(_TestData_2021_21);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_22_01_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2021_22_01();
            var result = challenge.ResolveChallenge(_TestData_2021_22);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_22_02_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2021_22_02();
            var result = challenge.ResolveChallenge(_TestData_2021_22);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_23_01_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2021_23_01();
            var result = challenge.ResolveChallenge(_TestData_2021_23);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_23_02_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2021_23_02();
            var result = challenge.ResolveChallenge(_TestData_2021_23);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_24_01_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2021_24_01();
            var result = challenge.ResolveChallenge(_TestData_2021_24);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_24_02_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2021_24_02();
            var result = challenge.ResolveChallenge(_TestData_2021_24);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day1")]
        public void ResolveChallenge_2021_25_01_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2021_25_01();
            var result = challenge.ResolveChallenge(_TestData_2021_25);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2021"), TestCategory("Day2")]
        public void ResolveChallenge_2021_25_02_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2021_25_02();
            var result = challenge.ResolveChallenge(_TestData_2021_25);

            Assert.AreEqual("", result);
        }
    }
}