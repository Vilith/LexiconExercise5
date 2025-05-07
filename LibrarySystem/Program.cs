namespace LibrarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {                        
            
            var library = new Library();
            library.LoadFromFile("library.json");
            var menu = new Menu(library);
            
        }
    }
}
