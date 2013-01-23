using NUnit.Framework;
using FluentAssertions;

namespace Bootstrap.Unit.Tests
{
    public class Bootstrap
    {
        [Test]
        public void ShouldBeAbleToInitialize()
        {
            "nothing".Should().Be("nothing");
        }

        [Test]
        public void ShouldBeAbleToFail()
        {
            "Something".Should().Be("nothing");
        }
    }
}
