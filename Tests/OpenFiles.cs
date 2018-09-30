using System;
using System.IO;
using PeoplePixels.Files;
using Xunit;

namespace Tests
{
    public class OpenFiles
    {
        [Fact]
        public void CanOpenFileFromSpecifiedFilepath()
        {
            var fileOpener = Factory.CreateFileOpener();
            //the working directory will be ./bin/platform, so use a relative path
            var filepath = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "..", "Assets", "Images", "hendrix.jpg");

            var stream = fileOpener.Open(filepath);
            
            Assert.True(stream.HasValue);
            Assert.True(stream.Exists(s => s.Length > 0));
            
            stream.MatchSome(s => s.Close());
        }
        
        [Fact]
        public void CanOpenFileFromDefaultFilepath()
        {
            var fileOpener = Factory.CreateFileOpener();
            
            //default filepath is Environment.SpecialFolders.Desktop
            //want to open files in the Assets/Images folder in this repository
            //the working directory will be ./bin/config/platform, so use a relative path
            fileOpener.DefaultFilepath = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "..", "Assets", "Images");

            var stream = fileOpener.Open("hendrix.jpg");

            Assert.True(stream.HasValue);
            Assert.True(stream.Exists(s => s.Length > 0));

            stream.MatchSome(s => s.Close());
        }

        [Fact]
        public void BadFilepathResultsInEmptyStream()
        {
            var fileOpener = Factory.CreateFileOpener();

            var stream = fileOpener.Open("badfile.jpg");
            
            Assert.False(stream.HasValue);
        }
    }
}