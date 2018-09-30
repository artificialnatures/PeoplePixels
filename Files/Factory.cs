namespace PeoplePixels.Files
{
    public static class Factory
    {
        public static FileOpener CreateFileOpener()
        {
            return new LocalOpener();
        }
    }
}