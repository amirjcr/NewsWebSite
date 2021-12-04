using NewsWebsite.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NewsWebsite.XUnitTest.Common
{
    public class DateTimeExtensionsTest
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void IsLeapYearTest(DateTime miladiDate, bool isLeap)
        {
            Assert.Equal(isLeap, DateTimeExtensions.IsLeapYear(miladiDate));
        }


        [Theory]
        [InlineData("dff121", false)]
        [InlineData("1398/10/12", true)]
        public void CheckShamsiDateTimeTest1(string persianDateTime, bool result)
        {
            Assert.Equal(result, DateTimeExtensions.CheckShamsiDateTime(persianDateTime).IsShamsi);
        }


        [Theory]
        [ClassData(typeof(DateTimeResultClassData))]
        public void CheckShamsiDateTimeTest2(DateTimeResult resultTest)
        {
            var result = DateTimeExtensions.CheckShamsiDateTime(resultTest.searchText);
            Assert.Equal(result.IsShamsi, resultTest.IsShamsi);
            Assert.Equal(result.MiladiDate, resultTest.MiladiDate);
        }


        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { new DateTime(2019, 12, 23), false };
            yield return new object[] { new DateTime(2020, 12, 23), true };
        }

    }

    public class DateTimeResultClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new DateTimeResult
                {
                   searchText="1398/10/02",
                   IsShamsi=true,
                   MiladiDate= new DateTime(2019,12,23),
                }
            };

            yield return new object[] {
                 new DateTimeResult
                {
                   searchText="kfjdj",
                   IsShamsi=false,
                   MiladiDate= null,
                }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
