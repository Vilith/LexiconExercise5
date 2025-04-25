using LibrarySystem.Enums;
using System.Text.Json;
using static LibrarySystem.Menu;

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

        public List<Book> GetAllBooksSortedBySelection(SortOption option)
        {
            return option switch
            {
                SortOption.Title => books.OrderBy(b => b.Title).ToList(),
                SortOption.Author => books.OrderBy(b => b.Author).ToList(),
                SortOption.ISBN => books.OrderBy(b => b.ISBN).ToList(),
                SortOption.Category => books.OrderBy(b => b.Category).ToList(),
                SortOption.Available => books.OrderBy(b => b.Available).ToList(),
                _ => books.ToList()
            };
        }
        //public List<Book> GetAllBooksSortedByTitle()
        //{
        //    return books.OrderBy(b => b.Title).ToList();
        //}
        //public List<Book> GetAllBooksSortedByAuthor()
        //{
        //    return books.OrderBy(b => b.Author).ToList();
        //}
        //public List<Book> GetAllBooksSortedByISBN()
        //{
        //    return books.OrderBy(b => b.ISBN).ToList();
        //}
        //public List<Book> GetAllBooksSortedByCategory()
        //{
        //    return books.OrderBy(b => b.Category).ToList();
        //}
        //public List<Book> GetAllBooksSortedByAvailable()
        //{
        //    return books.OrderBy(b => b.Available).ToList();
        //}

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