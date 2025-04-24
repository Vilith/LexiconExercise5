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
        
        //Constants for all menus - quitting current menu 
        public const string QUIT = "*";


        //To test the method it should not be void. Just a reminderI
        //Method to call the menu
        public static void ShowMenu()
        {
            Console.WriteLine($"{Environment.NewLine}|          MENU          |" +
                $"{Environment.NewLine}{ADD}| Add book" +
                $"{Environment.NewLine}{REMOVE}| Return book" +
                $"{Environment.NewLine}{LIST}| List books" +
                $"{Environment.NewLine}{SEARCH}| Search" +
                $"{Environment.NewLine}{MARK}| Available/Unavailable" +
                $"{Environment.NewLine}{JSON}| Read from JSON" +
                $"{Environment.NewLine}{QUIT}| Quit");
        }

        public static void ShowRemoveBookMenu()
        {
            Console.WriteLine($"{Environment.NewLine}Do you want to return your book by: " +
                $"{Environment.NewLine}{ISBN}" +
                $"{Environment.NewLine}{TITLE}" +
                $"{Environment.NewLine}{PICK}");

        }

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

        public static bool IsValidChoice(string input)
        {
            string[] validChoices = {ADD, REMOVE, LIST, SEARCH, MARK, JSON, ISBN, TITLE, PICK, QUIT};

            return validChoices.Contains(input);
        }

        public static void ShowListBooksOptions()
        {
            Console.WriteLine($"{Environment.NewLine}Sort by:" +
                $"{Environment.NewLine}{TITLELIST} Title" +
                $"{Environment.NewLine}{AUTHORLIST} Author" +
                $"{Environment.NewLine}{ISBNLIST} ISBN" +
                $"{Environment.NewLine}{CATEGORYLIST} Category" +
                $"{Environment.NewLine}{AVAILABILITYLIST} Availability" +
                $"{Environment.NewLine}{QUIT} Back to main menu" );
                
        }
        
    }
}

