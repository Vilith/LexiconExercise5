using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace LibrarySystem
{
    class Library
    {

        private List<Book> books = new();

        public void AddBook(Book book)
        {
            if (books.Any(b => b.ISBN == book.ISBN))
                throw new InvalidOperationException("Book with this ISBN already exists.");
        }
        
        public bool RemoveBook(string identifier)
        {
            Console.WriteLine("Empty for now");
            return true;
        }
        /* 
        public void SaveToFile(string path)
        {
            var json = JsonSerializer.Serialize(books);
            File.WriteAllText(path, json);
        }

        public void LoadFromFile(string path)
        {
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                books = JsonSerializer.Deserialize<List<Book>>(json);
            }
        }*/

        //File.WriteAllText("library.json", JsonSerializer.Serialize(Library));

        //Library lib = JsonSerializer.Deserialize<Library>(File.ReadAllText("library.json"));


        public string Hej() //Placeholder for now. It will be removed
        {
            string hej = "You're currently looking in the bookshelf";

            return hej;
        }
    }
}