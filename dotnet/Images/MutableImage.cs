using System.IO;
using PeoplePixels.Interfaces;

namespace PeoplePixels.Images
{
    internal class MutableImage : Image
    {
        public int Width => image.Width;

        public int Height => image.Height;
        
        public MutableImage(Stream stream)
        {
            image = SixLabors.ImageSharp.Image.Load(stream);
        }

        private SixLabors.ImageSharp.Image<SixLabors.ImageSharp.PixelFormats.Rgba32> image;
    }
}
