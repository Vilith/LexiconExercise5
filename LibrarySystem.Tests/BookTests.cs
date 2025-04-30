using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Tests
{
    public class BookTests
    {
        [Trait("Book", "Create")]
        [Fact]        
        public void Constructor_WithValidData_ShouldCreateBook()
        {
            //Arrange
            string title = "Title";
            string author = "Author";
            string isbn = "1231231231234";
            string category = "Childrens Book";

            //Act
            var book = new Book(title, author, isbn, category);

            //Assert
            Assert.Equal(title, book.Title);
            Assert.Equal(author, book.Author);
            Assert.Equal(isbn, book.ISBN);
            Assert.Equal(category, book.Category);

            Assert.True(book.Available);
        }


        [Trait("Book", "Throws")]
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("     ")]
        public void Constructor_WithEmptyTitle_ShouldThrow(string invalidTitle)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            new Book(invalidTitle, "Author", "1234567891234", "Childrens Book"));

            Assert.Equal("Title", ex.ParamName);
        }


        [Trait("Book", "Throws")]
        [Fact]
        public void Constructor_WithInvalidISBN_ShouldThrow()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            new Book("Title", "Author", "123456789123", "Childrens Book"));

            Assert.Equal("ISBN", ex.ParamName);
        }


        [Theory]
        [Trait("Book", "Validation")]
        [InlineData("12345678912AB")] //Letters
        [InlineData("1234 5678 9123")] //Whitespaces
        [InlineData("12345678912345")] //14 characters
        public void Constructor_WithNonDigitsOrWrongLengthISBN_ShouldThrow(string isbn)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new Book("Title", "Author", isbn, "Science Fiction"));

            Assert.Equal("ISBN", ex.ParamName);
        }


        [Fact]
        [Trait("Book", "State")]
        public void MarkAsUnavailable_ShouldSetAvailableToFalse()
        {
            var book = new Book("Title", "Author", "1234567891234", "Fiction");
            book.Available = false;

            Assert.False(book.Available);
        }


        [Fact]
        [Trait("Book", "State")]
        public void MarkAsAvailable_ShouldSetAvailableToTrue()
        {
            var book = new Book("Title", "Author", "1234567891234", "Science Fiction");
            book.MarkAsUnavailable();
            book.MarkAsAvailable();

            Assert.True(book.Available);
        }


        [Fact]
        [Trait("Book", "State")]
        public void MarkAsAvailable_ShouldSetAvailableToFalse()
        {
            var book = new Book("Title", "Author", "1234567891234", "Science Fiction");
            book.MarkAsAvailable();
            book.MarkAsUnavailable();
            
            Assert.False(book.Available);
            //Assert.True(book.Available);
        }


        [Fact]
        [Trait("Book", "ToString")]
        public void ToString_ShouldReturnFormattedString()
        {
            var book = new Book("Title", "Author", "1234567891234", "Science Fiction");
            string result = book.ToString();

            Assert.Contains("Title by Author", result);
            Assert.Contains("ISBN: 1234567891234", result);
            Assert.Contains("Category: Science Fiction", result);
            Assert.Contains("Available", result);
        }


        [Fact]
        [Trait("Book", "Whitespace")]
        public void Constructor_ShouldTrimWhitespaceFromInput()
        {
            var book = new Book("  Title  ", " Author ", "1234567891234", "Science Fiction ");

            Assert.Equal("Title", book.Title);
            Assert.Equal("Author", book.Author);
            Assert.Equal("Science Fiction", book.Category);
        }


        [Fact]
        [Trait("Book", "Whitespace")]
        public void Constructor_ShouldAllowWhitespaceBetweenWords()
        {
            var book = new Book("Title With Spaces", "Anna Maria", "1234567891234", "Science Fiction");

            Assert.Equal("Title With Spaces", book.Title);
            Assert.Equal("Anna Maria", book.Author);
            Assert.Equal("Science Fiction", book.Category);
        }
    }
}
