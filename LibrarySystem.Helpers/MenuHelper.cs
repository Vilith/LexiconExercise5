namespace LibrarySystem.Helpers
{
    public static class MenuHelper
    {
        //TODO - Refactor and remove unused code

        //Constants for menu        
        public const string ADD = "1";
        public const string REMOVE = "2";
        public const string LIST = "3";
        public const string SEARCH = "4";
        public const string MARK = "5";
        public const string JSON = "6";
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

        //Remember to clean up and refactor.
        //Placeholder for invalid input.
        public static string GetInvalidText()
        {
            return($"{Environment.NewLine}Input should be a number between 1-6! * for quitting");
        }


    }
}

