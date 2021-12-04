using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NewsWebsite.Common;

namespace NewsWebsite.XUnitTest.Common
{
    public class StringExtensionsTest
    {
        [Fact]
        public void CombineWithTest()
        {
            string[] testArray = { "Hello", "Asp", "Core" };
            Assert.Equal("Hello,Asp,Core", StringExtensions.CombineWith(testArray, ','));
        }


        [Theory]
        [InlineData("2","۲")]
        [InlineData("3","۳")]
        [InlineData("4","rerer")]
        public void En2FaTest(string englishNumber,string persianNumber)
        {
            Assert.Equal(persianNumber, StringExtensions.En2Fa(englishNumber));
        }
    }
}
