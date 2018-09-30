using System.IO;
using Optional;

namespace PeoplePixels.Interfaces
{
    public interface FileOpener
    {
        Option<Stream> Open(string filename);
    }
}