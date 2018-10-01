using System.IO;
using Optional;
using PeoplePixels.Interfaces;

namespace PeoplePixels.Images
{
    public static class Factory
    {
        public static Option<Image> CreateImage(Stream stream)
        {
            Image image = new MutableImage(stream);
            return image.SomeNotNull();
        }
    }
}