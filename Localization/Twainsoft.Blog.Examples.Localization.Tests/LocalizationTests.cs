// **************************************************
// 
// Written by Fabian Deitelhoff, 2013-09-13
// http://www.fabiandeitelhoff.de
// 
// **************************************************

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
            // Arrange
            const string lowerCharacters = "abcdefghijklmnopqrstuvwxyz";
            const string upperCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var turkishCulture = CultureInfo.GetCultureInfo("tr-TR");

            // Act
            var upper = lowerCharacters.ToUpper(turkishCulture);
            var lower = upperCharacters.ToLower(turkishCulture);

            // Assert
            Assert.AreNotEqual(upper, lower);
        }
    }
}