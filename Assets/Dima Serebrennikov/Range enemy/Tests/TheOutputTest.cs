using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEngine;
namespace Serebrennikov {
    public class TheOutputTest {
        [Test]
        public void TheOutputTestSimplePasses1() {
            string result = TheOutput.RoundToThreeSignificantDigits(115.2f);
            Assert.AreEqual(result, "115");
        }
        [Test]
        public void TheOutputTestSimplePasses2() {
            string result = TheOutput.RoundToThreeSignificantDigits(93.2f);
            Assert.AreEqual(result, "93.2");
        }
        [Test]
        public void TheOutputTestSimplePasses3() {
            string result = TheOutput.RoundToThreeSignificantDigits(11573f);
            Assert.AreEqual(result, "115");
        }
        [Test]
        public void TheOutputTestSimplePasses4() {
            string result = TheOutput.RoundToThreeSignificantDigits(0.42f);
            Assert.AreEqual(result, "0.42");
        }
        [Test]
        public void TheOutputTestSimplePasses5() {
            string result = TheOutput.RoundToThreeSignificantDigits(0.424f);
            Assert.AreEqual(result, "0.42");
        }
    }
}
