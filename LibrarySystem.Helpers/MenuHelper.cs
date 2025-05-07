using LibrarySystem.Shared.Enums;
using System.ComponentModel;
using System.Reflection;
using SearchOptions = LibrarySystem.Shared.Enums.SearchOptions;

namespace LibrarySystem.Helpers
{
    public static class MenuHelper
    {        
        #region [CONSTANTS]
        public const string QUIT = "*";

        #endregion

        #region [MENUS]
        //Retrieves the description and attribute of an enum value, if it exists
        //If not found it should return the name of the enum
        public static string GetEnumDescription(Enum value)
        {
            if (value == null) return string.Empty;

            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttribute<DescriptionAttribute>();

            return attribute?.Description ?? value.ToString();
        }

        //Displays a formatted menu in the console that's based on enum values of type T.
        //Each enum option is listed with it's own integer value and description.
        public static void ShowEnumMenu<T>(string title) where T : Enum
        {
            Console.WriteLine($"{Environment.NewLine}-|            {title.ToUpper()}            |-");
            foreach (T option in Enum.GetValues(typeof(T)))
            {
                Console.WriteLine($"{Convert.ToInt32(option)}. {GetEnumDescription((Enum)(object)option)}");
            }
            Console.WriteLine($"{QUIT}. Quit");
        }
                
        //Shows each individual menus based off of it's corresponding enumoption
        public static void ShowMainMenu() => ShowEnumMenu<MenuOption>("Main Menu");        

        public static void ShowRemoveBookMenu() => ShowEnumMenu<RemoveBookOption>("Return Book Menu");
        
        public static void ShowListBooksMenu() => ShowEnumMenu<ListBooksOption>("List Books Menu");

        public static void ShowSearchMenu() => ShowEnumMenu<SearchOptions>("Search Menu");

        public static void ShowJsonMenu() => ShowEnumMenu<JsonOption>("JSON Menu");
        #endregion

        //Checking if given input is a valid option in each specific enum type
        public static bool IsValidChoice<T>(string input)
        {
            return Enum.TryParse(typeof(T), input, out _) && Enum.IsDefined(typeof(T), int.Parse(input));
        }

        //Returns a standard error message
        public static string GetStandardErrorMessage()
        {
            return ($"{Environment.NewLine}Invalid input. Please try again.");
        }
        
        //Returns an error message if a menu option isn't correct
        public static string GetInvalidText()
        {
            return ($"{Environment.NewLine}Input should be a number corresponding to a menu option. Use '*' to quit.");
        }
    }
}