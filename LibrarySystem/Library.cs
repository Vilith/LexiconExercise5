using LibrarySystem.Shared;
using System.Runtime.CompilerServices;
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

        #region [LIST BOOK]
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
        #endregion

        #region [SEARCH]
        public List<Book> SearchByTitle(string title)
        {
            return books
                .Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<Book> SearchByAuthor(string author)
        {
            return books
                .Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        #endregion

        #region [AVAILABLE OR NOT]
        public void AvailableOrNot(string isbn)
        {
            var book = books.FirstOrDefault(b => b.ISBN == isbn); ;

            if (book == null)
                throw new InvalidOperationException("No book could be found with provided ISBN.");

            book.Available = !book.Available;
        }
        #endregion

        #region [SAVE AND READ]
        public void SaveToFile(string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(books, options);
            File.WriteAllText(filePath, json);
            Console.WriteLine("File saved!");
        }

        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found!");
                return;
            }

            try
            {
                var json = File.ReadAllText(filePath);
                var loadedBooks = JsonSerializer.Deserialize<List<Book>>(json);

                if (loadedBooks != null)
                {
                    books = loadedBooks;
                    Console.WriteLine("File loaded");
                }
                else
                {
                    Console.WriteLine("File empty?");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
            }
        }
        #endregion
    }
}