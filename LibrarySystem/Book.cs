using LibrarySystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{    
    public class Book
    {        
        public string Title { get; set; }
        public string Author { get; set;  }
        public string ISBN { get; init; }
        public string Category { get; set; }
        public bool Available { get; set; }

        public Book(string title, string author, string isbn, string category)
        {            
            Title = ValidateNotEmpty(title, nameof(Title));         
            Author = ValidateNotEmpty(author, nameof(Author));
            ISBN = ValidateISBN(isbn);
            Category = ValidateNotEmpty(category, nameof(Category));
            Available = true; //When book is added the book is set to as available.
        }

        //Used for quick access to unittests (Guess i shouldn't do it like this)
        public void MarkAsUnavailable() => Available = false;
        public void MarkAsAvailable() => Available = true;

        public override string ToString()
        {
            return $"{Title} by {Author} | ISBN: {ISBN} | Category: {Category} | " +
                   $"Status: {(Available ? "Available" : "Unavailable")}";
        }

        #region [Validation] //Methods for Validating
        private static string ValidateNotEmpty(string input, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException($"{fieldName} cannot be empty.", fieldName);
            return input.Trim();
        }

        private static string ValidateISBN(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn) || isbn.Length != 13 || !isbn.All(char.IsDigit))
                throw new ArgumentException("ISBN must be exactly 13 digits.", nameof(ISBN));
            return isbn;
        }

        //Empty method supposedly used for loading JSON file.
        public Book() { }
        #endregion
    }
}
