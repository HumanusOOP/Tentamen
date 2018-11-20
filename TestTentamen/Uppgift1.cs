using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestTentamen
{

    // Uppgift 1a
    public static class StringExtensions
    {
        public static int LastIndexOf2(this string @this, string value)
        {
            return LastIndexOfRec(@this, value, -1);
        }

        private static int LastIndexOfRec(string s, string value, int skippedCharacters)
        {
            var currentIndex = s.IndexOf(value);
            if (currentIndex == -1)
            {
                return skippedCharacters;
            }
            else
            {

                return LastIndexOfRec(s.Substring(currentIndex + 1), value, skippedCharacters + currentIndex + 1);
            }
        }
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        public void OneOccurence_ReturnsIndexOfOccurence()
        {
            var lastIndex = "HejsanSvejsansa".LastIndexOf2("Svej");
            Assert.AreEqual(6, lastIndex);
        }

        [Test]
        public void TwoOccurences_ReturnIndexOfSecondOccurence()
        {
            var lastIndex = "HejsanSvejsansa".LastIndexOf2("ejsan");
            Assert.AreEqual(8, lastIndex);
        }

        [Test]
        public void ThreeOccurences_ReturnIndexOfThirdOccurence()
        {
            var lastIndex = "HejsanSvejsansa".LastIndexOf2("sa");
            Assert.AreEqual(13, lastIndex);
        }

        [Test]
        public void NoOccurences_ReturnsNegative1()
        {
            var lastIndex = "HejsanSvejsansa".LastIndexOf2("Tjena");
            Assert.AreEqual(-1, lastIndex);
        }
    }
}

