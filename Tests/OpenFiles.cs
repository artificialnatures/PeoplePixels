using System;
using System.IO;
using Xunit;
using PeoplePixels.Files;

namespace PeoplePixels.Tests
{
    public class OpenFiles
    {
        [Fact]
        public void CanOpenFileFromSpecifiedLocalFilepath()
        {
            var fileOpener = Factory.CreateFileOpener(FileSource.Local);
            //the working directory will be ./bin/config/platform, so use a relative path
            var filepath = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "..", "Files", "Images", "hendrix.jpg");

            var stream = fileOpener.Open(filepath);
            
            Assert.True(stream.HasValue);
            Assert.True(stream.Exists(s => s.Length > 0));
            
            stream.MatchSome(s => s.Close());
        }

        [Fact]
        public void BadFilepathResultsInEmptyStream()
        {
            var fileOpener = Factory.CreateFileOpener(FileSource.Local);

            var stream = fileOpener.Open("badfile.jpg");
            
            Assert.False(stream.HasValue);
        }

        [Fact]
        public void CanOpenEmbeddedResource()
        {
            var fileOpener = Factory.CreateFileOpener(FileSource.Embedded);

            var stream = fileOpener.Open("hendrix.jpg");
            
            Assert.True(stream.HasValue);
            Assert.True(stream.Exists(s => s.Length > 0));
            
            stream.MatchSome(s => s.Close());
        }

        [Fact]
        public void BadEmbeddedResourceResultsInEmptyStream()
        {
            var fileOpener = Factory.CreateFileOpener(FileSource.Embedded);

            var stream = fileOpener.Open("badfile.jpg");
            
            Assert.False(stream.HasValue);
        }
    }
}