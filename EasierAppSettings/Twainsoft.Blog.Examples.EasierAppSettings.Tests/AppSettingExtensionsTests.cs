// **************************************************
// 
// Written by Fabian Deitelhoff, 2013-09-12
// http://www.fabiandeitelhoff.de
// 
// **************************************************

using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twainsoft.Blog.Examples.EasierAppSettings.Tests
{
    [TestClass]
    public sealed class AppSettingExtensionsTests
    {
        [ClassInitialize]
        public static void InitAppSettings(TestContext context)
        {
            ConfigurationManager.AppSettings["StringSetting"] = "TestSetting.";
            ConfigurationManager.AppSettings["NumberSetting"] = "1254524";
            ConfigurationManager.AppSettings["GuidSetting"] =
                Guid.Parse("fa1ab69a-0029-4738-9767-dcbcb0866039").ToString();
        }

        [TestMethod]
        public void TestStringExtension()
        {
            // Arrange
            const string exptectedStringValue = "TestSetting.";
            const int exptectedIntValue = 1254524;
            var exptectedGuidValue = Guid.Parse("fa1ab69a-0029-4738-9767-dcbcb0866039");

            // Act
            var stringValue = "StringSetting".AppSetting();
            var intValue = Convert.ToInt32("NumberSetting".AppSetting());
            var guidValue = Guid.Parse("GuidSetting".AppSetting());

            // Assert
            Assert.AreEqual(exptectedStringValue, stringValue);
            Assert.AreEqual(exptectedIntValue, intValue);
            Assert.AreEqual(exptectedGuidValue, guidValue);
        }

        [TestMethod]
        public void TestGenericExtension()
        {
            // Arrange
            const string exptectedStringValue = "TestSetting.";
            const int exptectedIntValue = 1254524;
            var exptectedGuidValue = Guid.Parse("fa1ab69a-0029-4738-9767-dcbcb0866039");

            // Act
            var stringValue = "StringSetting".AppSetting<string>();
            var intValue = "NumberSetting".AppSetting<int>();
            var guidValue = "GuidSetting".AppSetting<Guid>();

            // Assert
            Assert.AreEqual(exptectedStringValue, stringValue);
            Assert.AreEqual(exptectedIntValue, intValue);
            Assert.AreEqual(exptectedGuidValue, guidValue);
        }
    }
}