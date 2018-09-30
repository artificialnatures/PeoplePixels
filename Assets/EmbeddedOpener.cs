using System.IO;
using System.Linq;
using System.Reflection;
using Optional;
using PeoplePixels.Interfaces;

namespace PeoplePixels.Assets
{
    internal class EmbeddedOpener : FileOpener
    {
        public Option<Stream> Open(string filename)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceNames = assembly.GetManifestResourceNames();
            var matches = resourceNames.Where(rn => rn.Contains(filename));
            return matches.Take(1).Select(resourceName => assembly.GetManifestResourceStream(resourceName))
                .FirstOrDefault()
                .SomeNotNull();
        }
    }
}