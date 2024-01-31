using Api.Helper;
using System;
using Xunit;

namespace ApiTests.UnitTests
{
    public class CalculateAgeHelperTests
    {

        [Fact]
        public void CalculateAge_Should_Calculate_Right_Age()
        {
            var birthday = new DateTime(1990, 1, 17);

            var age = CalculateAgeHelper.CalculateAge(birthday);

            Assert.Equal(34, age);
        }
    }
}
