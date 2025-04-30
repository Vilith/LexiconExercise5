using LibrarySystem.Shared.Enums;
using System.ComponentModel;
using System.Reflection;
using SearchOptions = LibrarySystem.Shared.Enums.SearchOptions;

namespace LibrarySystem.Helpers
{
    public static class MenuHelper
    {
        //TODO - Refactor and remove unused code
        #region [CONSTANTS]
        public const string QUIT = "*";

        #endregion

        #region [MENUS]
        public static string GetEnumDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttribute<DescriptionAttribute>();

            return attribute?.Description ?? value.ToString();
        }

        public static void ShowEnumMenu<T>(string title) where T : Enum
        {
            Console.WriteLine($"{Environment.NewLine}-|            {title.ToUpper()}            |-");
            foreach (T option in Enum.GetValues(typeof(T)))
            {
                Console.WriteLine($"{Convert.ToInt32(option)}. {GetEnumDescription((Enum)(object)option)}");
            }
            Console.WriteLine($"{QUIT}. Quit");
        }
                
        public static void ShowMainMenu() => ShowEnumMenu<MenuOption>("Main Menu");        

        public static void ShowRemoveBookMenu() => ShowEnumMenu<RemoveBookOption>("Return Book Menu");
        
        public static void ShowListBooksMenu() => ShowEnumMenu<ListBooksOption>("List Books Menu");

        public static void ShowSearchMenu() => ShowEnumMenu<SearchOptions>("Search Menu");

        public static void ShowJsonMenu() => ShowEnumMenu<JsonOption>("JSON Menu");
        #endregion

        public static bool IsValidChoice<T>(string input)
        {
            return Enum.TryParse(typeof(T), input, out _) && Enum.IsDefined(typeof(T), int.Parse(input));
        }

        public static string GetStandardErrorMessage()
        {
            return ($"{Environment.NewLine}Invalid input. Please try again.");
        }

        //Remember to clean up and refactor.
        //Placeholder for invalid input.
        public static string GetInvalidText()
        {
            return ($"{Environment.NewLine}Input should be a number corresponding to a menu option. Use '*' to quit.");
        }
    }
}