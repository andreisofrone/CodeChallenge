using Application.Common.Extensions;
using Xunit;

namespace Tests
{
    public class Extensions
    {
        [Fact]
        public void Should_return_Yes()
        {
            var isTrue = true;

            Assert.Equal("Yes", isTrue.ToYesNoString());
        }

        [Fact]
        public void Should_return_No()
        {
            var isTrue = false;

            Assert.Equal("No", isTrue.ToYesNoString());
        }
    }
}
