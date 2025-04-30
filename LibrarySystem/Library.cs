using LibrarySystem.Shared.Enums;
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
            if (book == null) 
                throw new ArgumentNullException(nameof(book), "Book cannot be null");

            if (books.Any(b => b.ISBN == book.ISBN))
                throw new InvalidOperationException("Book with this ISBN already exists.");

            books.Add(book);
        }
        #endregion

        #region [REMOVE BOOK]
        public void RemoveBookByISBN(string isbn) => 
            RemoveBook(b => b.ISBN == isbn, 
                "Found no book with provided ISBBN");
        
        public void RemoveBookByTitle(string title) =>
            RemoveBook(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase), 
                "Found no book with provided Title");
        
        private void RemoveBook(Func<Book, bool> predicate, string errorMessage)
        {
            var book = books.FirstOrDefault(predicate);

            if (book == null)
                throw new InvalidOperationException(errorMessage);

            books.Remove(book);
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
        public List<Book> SearchByTitle(string title) =>
            SearchBooks(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        
        public List<Book> SearchByAuthor(string author) =>
            SearchBooks(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase));

        public Book? SearchByISBN(string isbn) =>
            books.FirstOrDefault(b => b.ISBN == isbn);
        
        private List<Book> SearchBooks(Func<Book, bool> predicate) =>
            books.Where(predicate).ToList();

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