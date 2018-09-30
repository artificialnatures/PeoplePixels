using PeoplePixels.App;
using Xunit;

namespace PeoplePixels.Tests
{
    public class ApplicationTests
    {
        [Fact]
        public void CanCreateApplication()
        {
            var app = Factory.CreateApplication();

            Assert.Equal("PeoplePixels", app.Title);
        }
    }
}