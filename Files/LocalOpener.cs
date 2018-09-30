using System.IO;
using Optional;
using PeoplePixels.Interfaces;

namespace PeoplePixels.Files
{
    internal class LocalOpener : FileOpener
    {
        public Option<Stream> Open(string filename)
        {
            return OpenStream(filename).SomeNotNull();
        }

        private Stream OpenStream(string filename)
        {
            if (File.Exists(filename))
            {
                return File.Open(filename, FileMode.Open, FileAccess.Read);
            }
            return null;
        }
    }
}
