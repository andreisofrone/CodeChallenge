using Application.Common.Extensions;
using Xunit;

namespace Tests
{
    public class Extensions
    {
        [Fact]
        public void ShouldReturnYes()
        {
            var isTrue = true;

            Assert.Equal("Yes", isTrue.ToYesNoString());
        }

        [Fact]
        public void ShouldReturnNo()
        {
            var isTrue = false;

            Assert.Equal("No", isTrue.ToYesNoString());
        }
    }
}
