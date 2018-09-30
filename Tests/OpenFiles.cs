using System;
using System.IO;
using Xunit;

namespace PeoplePixels.Tests
{
    public class OpenFiles
    {
        [Fact]
        public void CanOpenFileFromSpecifiedLocalFilepath()
        {
            var fileOpener = Files.Factory.CreateFileOpener();
            //the working directory will be ./bin/config/platform, so use a relative path
            var filepath = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "..", "Assets", "Images", "hendrix.jpg");

            var stream = fileOpener.Open(filepath);
            
            Assert.True(stream.HasValue);
            Assert.True(stream.Exists(s => s.Length > 0));
            
            stream.MatchSome(s => s.Close());
        }

        [Fact]
        public void BadFilepathResultsInEmptyStream()
        {
            var fileOpener = Files.Factory.CreateFileOpener();

            var stream = fileOpener.Open("badfile.jpg");
            
            Assert.False(stream.HasValue);
        }

        [Fact]
        public void CanOpenEmbeddedResource()
        {
            var fileOpener = Assets.Factory.CreateFileOpener();

            var stream = fileOpener.Open("hendrix.jpg");
            
            Assert.True(stream.HasValue);
            Assert.True(stream.Exists(s => s.Length > 0));
            
            stream.MatchSome(s => s.Close());
        }

        [Fact]
        public void BadEmbeddedResourceResultsInEmptyStream()
        {
            var fileOpener = Assets.Factory.CreateFileOpener();

            var stream = fileOpener.Open("badfile.jpg");
            
            Assert.False(stream.HasValue);
        }
    }
}