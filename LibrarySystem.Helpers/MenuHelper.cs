using LibrarySystem.Shared;
using SearchOption = LibrarySystem.Shared.SearchOption;

namespace LibrarySystem.Helpers
{
    public static class MenuHelper
    {
        //TODO - Refactor and remove unused code

        //Constants for Main Menu        
        public const string ADD = "1";
        public const string REMOVE = "2";
        public const string LIST = "3";
        public const string SEARCH = "4";
        public const string MARK = "5";
        public const string JSON = "6";

        //Constants for RemoveBookMenu
        public const string ISBN = "1. ISBN";
        public const string TITLE = "2. Title";
        public const string PICK = "Make a selection: ";

        //Constants for ListBooksMenu
        public const string TITLELIST = "1";
        public const string AUTHORLIST = "2";
        public const string ISBNLIST = "3";
        public const string CATEGORYLIST = "4";
        public const string AVAILABILITYLIST = "5";

        //Constants for SearchBookMenu
        public const string TITLESEARCH = "1";
        public const string AUTHORSEARCH = "2";

        //Constants for JsonMenu
        public const string SAVE = "1";
        public const string LOAD = "2";

        //Constants for all menus - quitting current menu 
        public const string QUIT = "*";


        //To test the method it should not be void. Just a reminderI
        //Method to call the menu

            public static void ShowMenu<T>(Dictionary<T, string> menuOptions) where T : Enum
            {
                Console.WriteLine($"{Environment.NewLine}-|          MENU          |-" +
                                  $"{Environment.NewLine}--------------------------");

                foreach (var option in menuOptions)
                {
                    Console.WriteLine($"{Convert.ToInt32(option.Key)}. {option.Value}");
                }

                Console.WriteLine($"{QUIT}. Quit");
            }

            public static void ShowRemoveBookMenu()
            {
                var removeOptions = new Dictionary<RemoveBookOption, string>
            {
                { RemoveBookOption.ReturnByISBN, "Return book by ISBN" },
                { RemoveBookOption.ReturnByTitle, "Return book by Title" }
            };

                ShowMenu(removeOptions);
            }

            public static void ShowListBooksOptions()
            {
                var listBooksOption = new Dictionary<ListBooksOption, string>
        {
            { ListBooksOption.Title, "Title" },
            { ListBooksOption.Author, "Author" },
            { ListBooksOption.ISBN, "ISBN" },
            { ListBooksOption.Category, "Category" },
            { ListBooksOption.Availability, "Availability" }
        };

                ShowMenu(listBooksOption);
            }

            public static void ShowSearchMenu()
            {
                var searchOptions = new Dictionary<SearchOption, string>
        {
            { SearchOption.Title, "Search by Title" },
            { SearchOption.Author, "Search by Author" }
        };

                ShowMenu(searchOptions);
            }

            public static void ShowJsonMenu()
            {
                var jsonOptions = new Dictionary<JsonOption, string>
        {
            { JsonOption.Save, "Save to JSON" },
            { JsonOption.Load, "Load from JSON" }
        };

                ShowMenu(jsonOptions);
            }

        //public static void ShowMenu()
        //{
            //Console.WriteLine($"{Environment.NewLine}-|          MENU          |-" +
                //$"{Environment.NewLine}{ADD}| Add book" +
                //$"{Environment.NewLine}{REMOVE}| Return book" +
                //$"{Environment.NewLine}{LIST}| List books" +
                //$"{Environment.NewLine}{SEARCH}| Search" +
                //$"{Environment.NewLine}{MARK}| Available/Unavailable" +
                //$"{Environment.NewLine}{JSON}| Read from JSON" +
                //$"{Environment.NewLine}{QUIT}| Quit");
        //}

        //public static void ShowRemoveBookMenu()
        //{
            //Console.WriteLine($"{Environment.NewLine}Do you want to return your book by: " +
                //$"{Environment.NewLine}{ISBN}" +
                //$"{Environment.NewLine}{TITLE}" +
                //$"{Environment.NewLine}{PICK}");
        //}

        //public static void ShowListBooksOptions()
        //{
            //Console.WriteLine($"{Environment.NewLine}Sort by:" +
                //$"{Environment.NewLine}{TITLELIST}. Title" +
                //$"{Environment.NewLine}{AUTHORLIST}. Author" +
                //$"{Environment.NewLine}{ISBNLIST}. ISBN" +
                //$"{Environment.NewLine}{CATEGORYLIST}. Category" +
                //$"{Environment.NewLine}{AVAILABILITYLIST}. Availability" +
                //$"{Environment.NewLine}{QUIT}. Back to main menu");
        //}

        //public static void ShowSearchMenu()
        //{
            //Console.WriteLine($"{Environment.NewLine}Search by: " +
                //$"{Environment.NewLine}{TITLESEARCH} Title" +
                //$"{Environment.NewLine}{AUTHORSEARCH} Author" +
                //$"{Environment.NewLine}{QUIT} Back to main menu");
        //}

        //public static void ShowJsonMenu()
        //{
            //Console.WriteLine($"{Environment.NewLine}What would you like to do:" +
            //$"{Environment.NewLine}{SAVE} Save to JSON" +
            //$"{Environment.NewLine}{LOAD} Load from JSON" +
            //$"{Environment.NewLine}{QUIT} Back to main menu");
        //}

        public static bool IsValidChoice<T>(string input) where T : Enum
        {
            return Enum.TryParse(typeof(T), input, out _);
        }


        //public static bool IsValidChoice(string input)
        //{
            //string[] validChoices = { ADD, REMOVE, LIST, SEARCH, MARK, JSON, ISBN, TITLE, PICK, QUIT };

            //return validChoices.Contains(input);
        //}        
        


        public static string GetStandardErrorMessage()
        {
            return ($"{Environment.NewLine}Invalid input. Please try again.");
        }

        //Remember to clean up and refactor.
        //Placeholder for invalid input.
        public static string GetInvalidText()
        {
            return ($"{Environment.NewLine}Input should be a number between 1-6! * for quitting");
        }
    }
}