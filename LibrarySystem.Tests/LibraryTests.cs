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
        [Trait("Library", "Add Book(s)")]
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

        [Fact]
        public void AddBook_WithNull_ShouldThrow()
        {
            // Arrange
            var library = new Library();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => library.AddBook(null));
        }

        [Fact]
        public void AddBook_WithDuplicateISBN_ShouldThrow()
        {
            // Arrange
            var library = new Library();
            var book1 = new Book("Title1", "Author1", "1234567891234", "Science Fiction");
            var book2 = new Book("Title2", "Author2", "1234567891234", "Sci-Fi");

            library.AddBook(book1);

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => library.AddBook(book2));

            Assert.Equal("Book with this ISBN already exists.", ex.Message);
        }


        [Fact]
        public void RemoveBook_ShouldRemoveBookIfExists()
        {
            // Arrange
            var library = new Library();
            var book = new Book("Title", "Author", "1234567891234", "Fiction");
            library.AddBook(book);

            // Act
            library.RemoveBookByISBN("1234567891234");


            // Assert
            var found = library.SearchByISBN("1234567891234");
            Assert.Null(found);            
        }


        [Fact]
        public void RemoveBookByISBN_ShouldThrowIfBookDoesNotExist()
        {
            // Arrange
            var library = new Library();

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() =>
                library.RemoveBookByISBN("0000000000000"));

            Assert.Equal("Found no book with provided ISBBN", ex.Message);
        }
        

        [Fact]
        public void SearchByTitle_ShouldReturnCorrectBook()
        {
            // Arrange
            var library = new Library();
            var book = new Book("C# Basics", "Author", "1234567891234", "Programming");
            library.AddBook(book);

            // Act
            var results = library.SearchByTitle("C# Basics");

            // Assert
            Assert.Single(results);
            Assert.Equal("1234567891234", results[0].ISBN);
        }


        [Theory]
        [InlineData(SortOption.Title)]
        [InlineData(SortOption.Author)]
        public void GetAllBooksSortedBySelection_ShouldNotThrow(SortOption option)
        {
            // Arrange
            var library = new Library();
            library.AddBook(new Book("Zebra", "Author A", "1234567890001", "A"));
            library.AddBook(new Book("Alpha", "Author B", "1234567890002", "B"));

            // Act
            var sorted = library.GetAllBooksSortedBySelection(option);

            // Assert
            Assert.Equal(2, sorted.Count);
        }

    }
}
