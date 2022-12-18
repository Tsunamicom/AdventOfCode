using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdventOfCode.Challenges.Resolution.Tests
{
    public partial class Challenge_Tests
    {
        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_01_01_Test()
        {
            var challenge = new Challenge_2022_01_01();
            var result = challenge.ResolveChallenge(_TestData_2022_01);

            Assert.AreEqual("24000", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_01_02_Test()
        {
            var challenge = new Challenge_2022_01_02();
            var result = challenge.ResolveChallenge(_TestData_2022_01);

            Assert.AreEqual("45000", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_02_01_Test()
        {
            var challenge = new Challenge_2022_02_01();
            var result = challenge.ResolveChallenge(_TestData_2022_02);

            Assert.AreEqual("15", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_02_02_Test()
        {
            var challenge = new Challenge_2022_02_02();
            var result = challenge.ResolveChallenge(_TestData_2022_02);

            Assert.AreEqual("12", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_03_01_Test()
        {
            var challenge = new Challenge_2022_03_01();
            var result = challenge.ResolveChallenge(_TestData_2022_03);

            Assert.AreEqual("157", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_03_02_Test()
        {
            var challenge = new Challenge_2022_03_02();
            var result = challenge.ResolveChallenge(_TestData_2022_03);

            Assert.AreEqual("70", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_04_01_Test()
        {
            var challenge = new Challenge_2022_04_01();
            var result = challenge.ResolveChallenge(_TestData_2022_04);

            Assert.AreEqual("2", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_04_02_Test()
        {
            var challenge = new Challenge_2022_04_02();
            var result = challenge.ResolveChallenge(_TestData_2022_04);

            Assert.AreEqual("4", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_05_01_Test()
        {
            var challenge = new Challenge_2022_05_01();
            var result = challenge.ResolveChallenge(_TestData_2022_05);

            Assert.AreEqual("CMZ", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_05_02_Test()
        {
            var challenge = new Challenge_2022_05_02();
            var result = challenge.ResolveChallenge(_TestData_2022_05);

            Assert.AreEqual("MCD", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_06_01_Test()
        {
            var challenge = new Challenge_2022_06_01();

            var result1 = challenge.ResolveChallenge(new List<string>() { "bvwbjplbgvbhsrlpgdmjqwftvncz" });
            var result2 = challenge.ResolveChallenge(new List<string>() { "nppdvjthqldpwncqszvftbrmjlhg" });
            var result3 = challenge.ResolveChallenge(new List<string>() { "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg" });
            var result4 = challenge.ResolveChallenge(new List<string>() { "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw" });

            Assert.AreEqual("5", result1);
            Assert.AreEqual("6", result2);
            Assert.AreEqual("10", result3);
            Assert.AreEqual("11", result4);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_06_02_Test()
        {
            var challenge = new Challenge_2022_06_02();
            var result1 = challenge.ResolveChallenge(new List<string>() { "mjqjpqmgbljsphdztnvjfqwrcgsmlb" });
            var result2 = challenge.ResolveChallenge(new List<string>() { "bvwbjplbgvbhsrlpgdmjqwftvncz" });
            var result3 = challenge.ResolveChallenge(new List<string>() { "nppdvjthqldpwncqszvftbrmjlhg" });
            var result4 = challenge.ResolveChallenge(new List<string>() { "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg" });
            var result5 = challenge.ResolveChallenge(new List<string>() { "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw" });

            Assert.AreEqual("19", result1);
            Assert.AreEqual("23", result2);
            Assert.AreEqual("23", result3);
            Assert.AreEqual("29", result4);
            Assert.AreEqual("26", result5);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_07_01_Test()
        {
            var challenge = new Challenge_2022_07_01();
            var result = challenge.ResolveChallenge(_TestData_2022_07);

            Assert.AreEqual("95437", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_07_02_Test()
        {
            var challenge = new Challenge_2022_07_02();
            var result = challenge.ResolveChallenge(_TestData_2022_07);

            Assert.AreEqual("24933642", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_08_01_Test()
        {
            var challenge = new Challenge_2022_08_01();
            var result = challenge.ResolveChallenge(_TestData_2022_08);

            Assert.AreEqual("21", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_08_02_Test()
        {
            var challenge = new Challenge_2022_08_02();
            var result = challenge.ResolveChallenge(_TestData_2022_08);

            Assert.AreEqual("8", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_09_01_Test()
        {
            var challenge = new Challenge_2022_09_01();
            var result = challenge.ResolveChallenge(_TestData_2022_09_01);

            Assert.AreEqual("13", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_09_02_Test()
        {
            var challenge = new Challenge_2022_09_02();
            var result = challenge.ResolveChallenge(_TestData_2022_09_02);

            Assert.AreEqual("36", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_10_01_Test()
        {
            var challenge = new Challenge_2022_10_01();
            var result = challenge.ResolveChallenge(_TestData_2022_10_01_02);

            Assert.AreEqual("13140", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_10_02_Test()
        {
            var challenge = new Challenge_2022_10_02();
            var result = challenge.ResolveChallenge(_TestData_2022_10_01_02);

            var resultList = result.Split(',');

            var expectedOutput = new List<string>()
            {
                "##..##..##..##..##..##..##..##..##..##..",
                "###...###...###...###...###...###...###.",
                "####....####....####....####....####....",
                "#####.....#####.....#####.....#####.....",
                "######......######......######......####",
                "#######.......#######.......#######.....",
            };

            for (int i = 0; i < expectedOutput.Count; i++)
            {
                Assert.AreEqual(expectedOutput[i], resultList[i], $"Index {i}");
            }
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_11_01_Test()
        {
            var challenge = new Challenge_2022_11_01();
            var result = challenge.ResolveChallenge(_TestData_2022_11);

            Assert.AreEqual("10605", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_11_02_Test()
        {
            var challenge = new Challenge_2022_11_02();
            var result = challenge.ResolveChallenge(_TestData_2022_11);

            Assert.AreEqual("2713310158", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_12_01_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_12_01();
            var result = challenge.ResolveChallenge(_TestData_2022_12);

            Assert.AreEqual("31", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_12_02_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_12_02();
            var result = challenge.ResolveChallenge(_TestData_2022_12);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_13_01_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_13_01();
            var result = challenge.ResolveChallenge(_TestData_2022_13);

            Assert.AreEqual("13", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_13_02_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_13_02();
            var result = challenge.ResolveChallenge(_TestData_2022_13);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_14_01_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_14_01();
            var result = challenge.ResolveChallenge(_TestData_2022_14);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_14_02_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_14_02();
            var result = challenge.ResolveChallenge(_TestData_2022_14);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_15_01_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_15_01();
            var result = challenge.ResolveChallenge(_TestData_2022_15);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_15_02_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_15_02();
            var result = challenge.ResolveChallenge(_TestData_2022_15);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_16_01_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_16_01();
            var result = challenge.ResolveChallenge(_TestData_2022_16);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_16_02_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_16_02();
            var result = challenge.ResolveChallenge(_TestData_2022_16);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_17_01_Test()
        {
            var challenge = new Challenge_2022_17_01();
            var result = challenge.ResolveChallenge(_TestData_2022_17);

            Assert.AreEqual("3068", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_17_02_Test()
        {
            var challenge = new Challenge_2022_17_02();
            var result = challenge.ResolveChallenge(_TestData_2022_17);

            Assert.AreEqual("1514285714288", result);
        }

        //[TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        //public void ResolveChallenge_2022_17_01_alt_Test()
        //{
        //    var challenge = new Challenge_2022_17_01();
        //    var result = challenge.ResolveChallenge(_TestData_2022_17_02);

        //    Assert.AreEqual("14", result);
        //}

        //[TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        //public void ResolveChallenge_2022_17_02_alt_Test()
        //{
        //    var challenge = new Challenge_2022_17_02();
        //    var result = challenge.ResolveChallenge(_TestData_2022_17_02);

        //    Assert.AreEqual("14", result);
        //}

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_18_01_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_18_01();
            var result = challenge.ResolveChallenge(_TestData_2022_18);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_18_02_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_18_02();
            var result = challenge.ResolveChallenge(_TestData_2022_18);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_19_01_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_19_01();
            var result = challenge.ResolveChallenge(_TestData_2022_19);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_19_02_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_19_02();
            var result = challenge.ResolveChallenge(_TestData_2022_19);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_20_01_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_20_01();
            var result = challenge.ResolveChallenge(_TestData_2022_20);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_20_02_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_20_02();
            var result = challenge.ResolveChallenge(_TestData_2022_20);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_21_01_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_21_01();
            var result = challenge.ResolveChallenge(_TestData_2022_21);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_21_02_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_21_02();
            var result = challenge.ResolveChallenge(_TestData_2022_21);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_22_01_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_22_01();
            var result = challenge.ResolveChallenge(_TestData_2022_22);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_22_02_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_22_02();
            var result = challenge.ResolveChallenge(_TestData_2022_22);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_23_01_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_23_01();
            var result = challenge.ResolveChallenge(_TestData_2022_23);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_23_02_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_23_02();
            var result = challenge.ResolveChallenge(_TestData_2022_23);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_24_01_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_24_01();
            var result = challenge.ResolveChallenge(_TestData_2022_24);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_24_02_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_24_02();
            var result = challenge.ResolveChallenge(_TestData_2022_24);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day1")]
        public void ResolveChallenge_2022_25_01_Test()
        {
            Assert.Inconclusive("TBD");
            var challenge = new Challenge_2022_25_01();
            var result = challenge.ResolveChallenge(_TestData_2022_25);

            Assert.AreEqual("", result);
        }

        [TestMethod(), TestCategory("2022"), TestCategory("Day2")]
        public void ResolveChallenge_2022_25_02_Test()
        {
            Assert.Inconclusive("Not Needed");
            // There is no Part 2.  Need to complete all the previous tasks.
        }
    }
}