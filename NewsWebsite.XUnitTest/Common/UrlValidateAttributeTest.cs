using NewsWebsite.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NewsWebsite.XUnitTest.Common
{
    public class UrlValidateAttributeTest
    {
        private readonly UrlValidateAttribute _valiadte;

        public UrlValidateAttributeTest()
        {
            _valiadte = new UrlValidateAttribute("/", @"\", " ");
        }

        [Fact]
        public void IsValidTest1()
        {
            Assert.True(_valiadte.IsValid("خبرورزشی"));
        }

        [Theory]
        [InlineData("خبر ورزشی")]
        [InlineData("خبر / ورزشی")]
        [InlineData(@"خبر\ورزشی")]
        public void IsValidTest2(string testValue)
        {
            Assert.True(_valiadte.IsValid(testValue));
        }
    }
}
