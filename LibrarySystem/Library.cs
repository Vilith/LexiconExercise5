using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace LibrarySystem
{
    class Library
    {

        private List<Book> books = new();

        #region [ADD BOOK]
        public void AddBook(Book book)
        {
            /*Lambda so this is basically:

                foreach (Book b in books)
                { if (b.ISBN == book.ISBN)
                throw new InvalidOperationException("Book with this ISBN already exists."); */

            if (books.Any(b => b.ISBN == book.ISBN))
                throw new InvalidOperationException("Book with this ISBN already exists.");

            books.Add(book);
        }
        #endregion

        //public void RemoveBook() //TODO - Remove when i'm confident at wich way to approach
        //{
        //    Console.WriteLine("Empty for now");            
        //}
        #region [REMOVE BOOK]
        public void RemoveBookByISBN(string isbn)
        {
            var bookToRemove = books.FirstOrDefault(b => b.ISBN == isbn);

            if (bookToRemove == null)
                throw new InvalidOperationException("Found no book with provided ISBN.");

            books.Remove(bookToRemove);
        }

        public void RemoveBookByTitle(string title)
        {
            var bookToRemove = books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (bookToRemove == null)
                throw new InvalidOperationException("Found no book with provided Title");

            books.Remove(bookToRemove);
        }
        #endregion

        public List<Book> GetAllBooksSortedByTitle()
        {
            return books.OrderBy(b => b.Title).ToList();
        }

        //Playing around with how to setup json. Knacking code is how you learn right?

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

    }
}