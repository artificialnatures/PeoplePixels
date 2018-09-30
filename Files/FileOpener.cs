using System.IO;
using Optional;

namespace PeoplePixels.Files
{
    public interface FileOpener
    {
        string DefaultFilepath { get; set; }
        
        Option<Stream> Open(string location);
    }
}