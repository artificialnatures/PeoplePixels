using PeoplePixels.Interfaces;

namespace PeoplePixels.Files
{
    public static class Factory
    {
        public static FileOpener CreateFileOpener(FileSource fileSource)
        {
            switch (fileSource)
            {
                case FileSource.Local:
                    return new LocalOpener();
                case FileSource.Embedded:
                    return new EmbeddedOpener();
            }
            return null;
        }
    }
}