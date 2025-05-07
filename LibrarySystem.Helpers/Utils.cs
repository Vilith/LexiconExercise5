using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Helpers
{
    public static class Utils
    {   
        public static string PromptForInput(string fieldName)
        {
        Console.WriteLine($"{fieldName}: ");
        return Console.ReadLine()?.Trim() ?? string.Empty;
        }
        
        #region [ISBN]        
        //As long as input for ISBN isn't correct it will loop until a value of 13 numbers is entered
        public static string GetValidISBN()
        {
            while (true)
            {                
                string isbn = PromptForInput("ISBN (13 digits):");

                try
                {
                    ValidateISBN(isbn);
                    return isbn;
                }
                catch (ValidationException ex)
                {
                    Console.WriteLine($"[ERROR] {ex.Message}");
                }                                
            }
        }

        //Validating that ISBN is 13 numbers
        public static void ValidateISBN(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn) || isbn.Length != 13 || !isbn.All(char.IsDigit))
            {
                throw new ValidationException("ISBN must be exactly 13 digits");
            }
        }
        #endregion

        #region [Category]
        //List of predefined genres for the book(s)
        public static readonly List<string> Genres = new()
        {
            "Novel",
            "Romance",
            "Fantasy",
            "Science Fiction",
            "Biography",
            "Childrens Book"
        };

        //Displays the list of available genres to the console
        public static void ShowGenres()
        {
            Console.WriteLine("Category:");

            for (int i = 0; i < Genres.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Genres[i]}");
            }
        }

        //Allows the user to select a genre from the list
        //As long as the input isn't valid it will prompt for a valid input
        public static string SelectGenre()
        {
            while (true)
            {
                ShowGenres();                
                string input = PromptForInput("Your choice (1-" + Genres.Count + "): ");

                try
                {
                    ValidateGenreSelection(input);
                    return Genres[int.Parse(input) - 1];
                }
                catch (ValidationException ex) 
                {
                    Console.WriteLine($"[ERROR] {ex.Message}");
                }                
            }
        }

        //Validation of the input for selecting genre
        public static void ValidateGenreSelection(string input)
        {
            if (!int.TryParse(input, out int index) || index < 1 || index > Genres.Count)
            {
                throw new ValidationException($"Selection must be between 1 and {Genres.Count}");
            }
        }
        #endregion
                
    }
}
