using Xunit;

namespace PeoplePixels.App.Tests
{
    public class ApplicationTests
    {
        [Fact]
        public void CanCreateApplication()
        {
            var app = PeoplePixels.App.Factory.CreateApplication();

            Assert.Equal("PeoplePixels", app.Title);
        }
    }
}
