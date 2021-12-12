using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode.Challenges.Resolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Challenges.Resolution.Tests
{
    [TestClass()]
    public partial class Challenge_Tests
    {
        [TestMethod()]
        public void ResolveChallenge_2021_01_01_Test()
        {
            var challenge = new Challenge_2021_01_01();
            var result = challenge.ResolveChallenge(_TestData_2021_01);

            Assert.AreEqual("7", result);
        }

        [TestMethod()]
        public void ResolveChallenge_2021_01_02_Test()
        {
            var challenge = new Challenge_2021_01_02();
            var result = challenge.ResolveChallenge(_TestData_2021_01);

            Assert.AreEqual("5", result);
        }

        [TestMethod()]
        public void ResolveChallenge_2021_02_01_Test()
        {
            var challenge = new Challenge_2021_02_01();
            var result = challenge.ResolveChallenge(_TestData_2021_02);

            Assert.AreEqual("150", result);
        }

        [TestMethod()]
        public void ResolveChallenge_2021_02_02_Test()
        {
            var challenge = new Challenge_2021_02_02();
            var result = challenge.ResolveChallenge(_TestData_2021_02);

            Assert.AreEqual("900", result);
        }

        [TestMethod()]
        public void ResolveChallenge_2021_03_01_Test()
        {
            var challenge = new Challenge_2021_03_01();
            var result = challenge.ResolveChallenge(_TestData_2021_03);

            Assert.AreEqual("198", result);
        }

        [TestMethod()]
        public void ResolveChallenge_2021_03_02_Test()
        {
            var challenge = new Challenge_2021_03_02();
            var result = challenge.ResolveChallenge(_TestData_2021_03);

            Assert.AreEqual("230", result);
        }

        [TestMethod()]
        public void ResolveChallenge_2021_04_01_Test()
        {
            var challenge = new Challenge_2021_04_01();
            var result = challenge.ResolveChallenge(_TestData_2021_04);

            Assert.AreEqual("4512", result);
        }

        [TestMethod()]
        public void ResolveChallenge_2021_04_02_Test()
        {
            var challenge = new Challenge_2021_04_02();
            var result = challenge.ResolveChallenge(_TestData_2021_04);

            Assert.AreEqual("1924", result);
        }

        [TestMethod()]
        public void ResolveChallenge_2021_05_01_Test()
        {
            var challenge = new Challenge_2021_05_01();
            var result = challenge.ResolveChallenge(_TestData_2021_05);

            Assert.AreEqual("5", result);
        }

        [TestMethod()]
        public void ResolveChallenge_2021_05_02_Test()
        {
            var challenge = new Challenge_2021_05_02();
            var result = challenge.ResolveChallenge(_TestData_2021_05);

            Assert.AreEqual("12", result);
        }

        [TestMethod()]
        public void ResolveChallenge_2021_06_01_Test()
        {
            var challenge = new Challenge_2021_06_01();
            var result = challenge.ResolveChallenge(_TestData_2021_06);

            Assert.AreEqual("5934", result);
        }

        [TestMethod()]
        public void ResolveChallenge_2021_06_02_Test()
        {
            var challenge = new Challenge_2021_06_02();
            var result = challenge.ResolveChallenge(_TestData_2021_06);

            Assert.AreEqual("26984457539", result);
        }

        [TestMethod()]
        public void ResolveChallenge_2021_07_01_Test()
        {
            Assert.Inconclusive("Need to re-do this logic");
            var challenge = new Challenge_2021_07_01();
            var result = challenge.ResolveChallenge(_TestData_2021_07);

            Assert.AreEqual("37", result);
        }

        [TestMethod()]
        public void ResolveChallenge_2021_07_02_Test()
        {
            Assert.Inconclusive("Need to re-do this logic");
            var challenge = new Challenge_2021_07_02();
            var result = challenge.ResolveChallenge(_TestData_2021_07);

            Assert.AreEqual("168", result);
        }

        [TestMethod()]
        public void ResolveChallenge_2021_08_01_Test()
        {
            var challenge = new Challenge_2021_08_01();
            var result = challenge.ResolveChallenge(_TestData_2021_08);

            Assert.AreEqual("26", result);
        }

        [TestMethod()]
        public void ResolveChallenge_2021_08_02_Test()
        {
            var challenge = new Challenge_2021_08_02();
            var result = challenge.ResolveChallenge(_TestData_2021_08);

            Assert.AreEqual("61229", result);
        }

        [TestMethod()]
        public void ResolveChallenge_2021_09_01_Test()
        {
            var challenge = new Challenge_2021_09_01();
            var result = challenge.ResolveChallenge(_TestData_2021_09);

            Assert.AreEqual("15", result);
        }

        [TestMethod()]
        public void ResolveChallenge_2021_09_02_Test()
        {
            var challenge = new Challenge_2021_09_02();
            var result = challenge.ResolveChallenge(_TestData_2021_09);

            Assert.AreEqual("1134", result);
        }

        [TestMethod()]
        public void ResolveChallenge_2021_10_01_Test()
        {
            var challenge = new Challenge_2021_10_01();
            var result = challenge.ResolveChallenge(_TestData_2021_10);

            Assert.AreEqual("26397", result);
        }

        [TestMethod()]
        public void ResolveChallenge_2021_10_02_Test()
        {
            var challenge = new Challenge_2021_10_02();
            var result = challenge.ResolveChallenge(_TestData_2021_10);

            Assert.AreEqual("288957", result);
        }

        [TestMethod()]
        public void ResolveChallenge_2021_11_01_Test()
        {
            var challenge = new Challenge_2021_11_01();
            var result = challenge.ResolveChallenge(_TestData_2021_11);

            Assert.AreEqual("1656", result);
        }

        [TestMethod()]
        public void ResolveChallenge_2021_11_02_Test()
        {
            var challenge = new Challenge_2021_11_02();
            var result = challenge.ResolveChallenge(_TestData_2021_11);

            Assert.AreEqual("195", result);
        }
    }
}