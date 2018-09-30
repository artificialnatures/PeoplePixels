using PeoplePixels.Interfaces;

namespace PeoplePixels.Assets
{
    public static class Factory
    {
        public static FileOpener CreateFileOpener()
        {
            return new EmbeddedOpener();
        }
    }
}