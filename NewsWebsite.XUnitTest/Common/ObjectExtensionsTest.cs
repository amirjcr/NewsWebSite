using NewsWebsite.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NewsWebsite.XUnitTest.Common
{
    public class ObjectExtensionsTest
    {
        [Fact]
        public void CheckArgumentIsNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => ObjectExtensions.CheckArgumentIsNull(null, "_keyNormalizer"));
        }
    }
}
