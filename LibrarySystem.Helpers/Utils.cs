using System;
using System.Collections.Generic;
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
            return Console.ReadLine();
        }

        #region [ISBN]
        public static bool IsValidISBN(string isbn)
        {
            return isbn.Length == 13 && isbn.All(char.IsDigit);
        }

        public static string GetValidISBN()
        {
            while (true)
            {
                Console.WriteLine("ISBN (13 digits):");
                string isbn = Console.ReadLine();

                if (IsValidISBN(isbn))
                {
                    return isbn;
                }
                Console.WriteLine("Wrong input! ISBN contains of 13 numbers!");
            }
        }
        #endregion

        #region [Category]
        public static readonly List<string> Genres = new()
        {
            "Novel",
            "Romance",
            "Fantasy",
            "Science Fiction",
            "Biography",
            "Childrens book"
        };

        public static void ShowGenres()
        {
            Console.WriteLine("Category:");

            for (int i = 0; i < Genres.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Genres[i]}");
            }
        }

        public static string SelectGenre()
        {
            while (true)
            {
                ShowGenres();
                Console.WriteLine("Your choice (1-" + Genres.Count + "): ");

                string input = Console.ReadLine();

                if (int.TryParse(input, out int index) && index >= 1 && index <= Genres.Count)
                {
                    return Genres[index - 1];
                }
                Console.WriteLine("Input should be between 1-6. Try again.");
            }
        }
        #endregion


        //Validating inputs here


    }
}
