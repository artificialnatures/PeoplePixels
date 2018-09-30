using System;
using System.IO;
using Optional;

namespace PeoplePixels.Files
{
    internal class LocalOpener : FileOpener
    {
        public string DefaultFilepath { get; set; }
        
        public Option<Stream> Open(string location)
        {
            if (File.Exists(location))
            {
                return Option.Some<Stream>(File.Open(location, FileMode.Open, FileAccess.Read));
            }
            else
            {
                var fileAtDefaultFilepath = Path.Combine(DefaultFilepath, location);
                if (File.Exists(fileAtDefaultFilepath))
                {
                    return Option.Some<Stream>(File.Open(fileAtDefaultFilepath, FileMode.Open, FileAccess.Read));
                }
            }
            return Option.None<Stream>();
        }

        public LocalOpener()
        {
            DefaultFilepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }
    }
}
