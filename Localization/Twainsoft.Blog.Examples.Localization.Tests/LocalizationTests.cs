using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twainsoft.Blog.Examples.Localization.Tests
{
    [TestClass]
    public class LocalizationTests
    {
        [TestMethod]
        public void TestTurkishStringCompare()
        {
            const string lowerCharacters = "abcdefghijklmnopqrstuvwxyz";
            const string upperCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var turkishCulture = CultureInfo.GetCultureInfo("tr-TR");

            var upper = lowerCharacters.ToUpper(turkishCulture);
            var lower = upperCharacters.ToLower(turkishCulture);

            Assert.AreNotEqual(upper, lower);
        }
    }
}
