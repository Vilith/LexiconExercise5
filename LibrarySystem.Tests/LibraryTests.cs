using LibrarySystem.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Tests
{
    public class LibraryTests
    {
        [Trait("Library", "Add")]
        [Fact]
        public void AddBook_ShouldAddBookToLibrary()
        {

            string title = "Title";
            string author = "Author";
            string isbn = "1234567890123";
            string category = "Childrens Book";

            var library = new Library();
            var book = new Book(title, author, isbn, category);

            library.AddBook(book);
            var result = library.SearchByISBN(isbn);

            Assert.NotNull(result);
            Assert.Equal(title, result.Title);
        }

        [Trait("Library", "Add")]
        [Fact]
        public void AddBook_WithNull_ShouldThrow()
        {            
            var library = new Library();
                        
            Assert.Throws<ArgumentNullException>(() => library.AddBook(null));
        }

        [Trait("Library", "Add")]
        [Fact]
        public void AddBook_WithDuplicateISBN_ShouldThrow()
        {            
            var library = new Library();
            var book1 = new Book("Title1", "Author1", "1234567891234", "Science Fiction");
            var book2 = new Book("Title2", "Author2", "1234567891234", "Sci-Fi");

            library.AddBook(book1);
                        
            var ex = Assert.Throws<InvalidOperationException>(() => library.AddBook(book2));

            Assert.Equal("Book with this ISBN already exists.", ex.Message);
        }

        [Trait("Library", "Remove")]
        [Fact]
        public void RemoveBook_ShouldRemoveBookIfExists()
        {
            var library = new Library();
            var book = new Book("Title", "Author", "1234567891234", "Fiction");
            library.AddBook(book);
            
            library.RemoveBookByISBN("1234567891234");

            var found = library.SearchByISBN("1234567891234");
            Assert.Null(found);
        }

        [Trait("Library", "Remove")]
        [Fact]
        public void RemoveBookByISBN_ShouldThrowIfBookDoesNotExist()
        {            
            var library = new Library();
                        
            var ex = Assert.Throws<InvalidOperationException>(() =>
                library.RemoveBookByISBN("0000000000000"));

            Assert.Equal("Found no book with provided ISBN", ex.Message);
        }

        [Trait("Library", "Search")]
        [Fact]
        public void SearchByTitle_ShouldReturnCorrectBook()
        {            
            var library = new Library();
            var book = new Book("C# Basics", "Author", "1234567891234", "Programming");
            library.AddBook(book);
                        
            var results = library.SearchByTitle("C# Basics");
                        
            Assert.Single(results);
            Assert.Equal("1234567891234", results[0].ISBN);
        }


        [Trait("Library", "List")]
        [Theory]
        [InlineData(SortOption.Title)]
        [InlineData(SortOption.Author)]
        public void GetAllBooksSortedBySelection_ShouldNotThrow(SortOption option)
        {            
            var library = new Library();
            library.AddBook(new Book("Zebra", "Author A", "1234567890001", "A"));
            library.AddBook(new Book("Alpha", "Author B", "1234567890002", "B"));
            library.AddBook(new Book("Gamma", "Author C", "1234567890003", "C"));
            library.AddBook(new Book("Omega", "Author D", "1234567890004", "D"));
                        
            var sorted = library.GetAllBooksSortedBySelection(option);
                        
            Assert.Equal(4, sorted.Count);
        }

    }
}
