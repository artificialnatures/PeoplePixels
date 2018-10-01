using Xunit;

namespace PeoplePixels.Tests
{
    public class OpenImages
    {
        [Fact]
        public void CanOpenImage()
        {
            var fileOpener = Files.Factory.CreateFileOpener(Files.FileSource.Embedded);
            var stream = fileOpener.Open("westre.jpg");
            
            var image = stream.FlatMap(s => Images.Factory.CreateImage(s));
            
            Assert.True(image.HasValue);
            Assert.True(image.Exists(i => i.Width > 0));
            Assert.True(image.Exists(i => i.Height > 0));
        }
    }
}