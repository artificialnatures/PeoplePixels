using PeoplePixels.Interfaces;

namespace PeoplePixels.App
{
    public static class Factory
    {
        public static Application CreateApplication()
        {
            return new PeoplePixels();
        }
    }
}