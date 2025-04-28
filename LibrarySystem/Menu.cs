using LibrarySystem.Enums;
using LibrarySystem.Helpers;
using System.Text.Json;

namespace LibrarySystem
{
    internal class Menu
    {
        #region [VARIABLES]
        private bool isRunning = true;
        private Library bookShelf;
        #endregion

        public Menu(Library library)
        {
            bookShelf = library;
            RunMenu();
        }

        #region [MENU]
        private void RunMenu()
        {

            do
            {
                MenuHelper.ShowMenu();
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || !MenuHelper.IsValidChoice(input))

                {
                    MenuHelper.GetStandardErrorMessage();
                    continue;
                }


                switch (input)
                {

                    case MenuHelper.ADD:

                        AddBookMenu();
                        break;

                    case MenuHelper.REMOVE:

                        RemoveBookMenu();
                        break;

                    case MenuHelper.LIST:

                        ListBooksMenu();
                        break;

                    case MenuHelper.SEARCH:

                        SearchBookMenu();
                        break;

                    case MenuHelper.MARK:

                        MarkBookMenu();
                        break;

                    case MenuHelper.JSON:

                        JsonMenu();
                        break;

                    case MenuHelper.QUIT:

                        isRunning = false;
                        break;

                    default:

                        MenuHelper.GetInvalidText();
                        break;

                }
            }
            while (isRunning);
        }
        #endregion

        #region [ADD BOOK]
        private void AddBookMenu()
        {
            try
            {
                string isbn = Utils.GetValidISBN();
                string category = Utils.SelectGenre();
                string title = Utils.PromptForInput("Title");
                string author = Utils.PromptForInput("Author");

                var book = new Book
                {
                    Title = title,
                    Author = author,
                    ISBN = isbn,
                    Category = category,
                    Available = false
                };

                bookShelf.AddBook(book);

                Console.WriteLine("Book has been added!");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong: {e.Message}");
            }
        }
        #endregion

        #region [REMOVE BOOK]
        private void RemoveBookMenu()
        {

            MenuHelper.ShowRemoveBookMenu();
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    string isbn = Utils.PromptForInput("ISBN of book to remove:");
                    bookShelf.RemoveBookByISBN(isbn);
                    Console.WriteLine("Book removed successfully."); //Not Dry
                    break;

                case "2":
                    string title = Utils.PromptForInput("Title of book to remove:");
                    bookShelf.RemoveBookByTitle(title);
                    Console.WriteLine("Book removed successfully."); //Not Dry
                    break;

                default:
                    Console.WriteLine("Invalid selection.");
                    break;
            }

        }
        #endregion

        #region [LIST BOOKS]
        private void ListBooksMenu()
        {
            do
            {
                MenuHelper.ShowListBooksOptions();
                var input = Console.ReadLine();
                SortOption option = SortOption.Title;

                switch (input)
                {
                    case "1":
                        option = SortOption.Title;
                        break;

                    case "2":
                        option = SortOption.Author;
                        break;

                    case "3":
                        option = SortOption.ISBN;
                        break;

                    case "4":
                        option = SortOption.Category;
                        break;

                    case "5":
                        option = SortOption.Available;
                        break;

                    case "*":
                        return;

                    default:
                        Console.WriteLine("Wrong input!");
                        break;

                }

                var sortedBooks = bookShelf.GetAllBooksSortedBySelection(option);

                if (!sortedBooks.Any())
                {
                    Console.WriteLine("Library seems to be empty.");
                }
                Console.WriteLine($"{Environment.NewLine}{"Title",-30} {"Author",-20} " +
                    $"{"ISBN",-15} {"Category",-15} {"Available",-10}");
                Console.WriteLine(new string('-', 90));

                foreach (var book in sortedBooks)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; //TODO - Remove before done.
                    Console.WriteLine($"{book.Title,-30} {book.Author,-20} {book.ISBN,-15} " +
                        $"{book.Category,-15} {book.Available,-10}");
                    Console.ResetColor(); //TODO - Remove before done.
                }
            }
            while (true);
        }
        #endregion

        #region [SEARCH]
        private void SearchBookMenu()
        {
            MenuHelper.ShowSearchMenu();
            var input = Console.ReadLine();
            List<Book> results = new();

            switch (input)
            {
                case "1":

                    string title = Utils.PromptForInput("Enter book title");
                    results = bookShelf.SearchByTitle(title);
                    break;

                case "2":

                    string author = Utils.PromptForInput("Enter name of author");
                    results = bookShelf.SearchByAuthor(author);
                    break;

                case "*":

                    return;

                default:
                    Console.WriteLine("Invalid input my man");
                    break;

            }

            if (!results.Any())
            {
                Console.WriteLine("No matches were found.");
                return;
            }

            Console.WriteLine($"{Environment.NewLine}{"Title",-30} {"Author",-20} " +
                    $"{"ISBN",-15} {"Category",-15} {"Available",-10}");
            Console.WriteLine(new string('-', 90));

            foreach (var books in results)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta; //TODO - Remove before done.
                Console.WriteLine($"{books.Title,-30} {books.Author,-20} {books.ISBN,-15} " +
                    $"{books.Category,-15} {books.Available,-10}");
                Console.ResetColor(); //TODO - Remove before done.
            }
        }
        #endregion

        #region [AVAILABLE OR NOT]
        private void MarkBookMenu()
        {
            string isbn = Utils.PromptForInput("Enter the books ISBN to mark it as availble or unavailable.");
            bookShelf.AvailableOrNot(isbn);

            Console.WriteLine("The books availability status has been updated.");

        }
        #endregion

        #region [SAVE & READ]
        private void JsonMenu()
        {
            MenuHelper.ShowJsonMenu();
            var input = Console.ReadLine();
            string filePath = "library.json";

            switch (input)
            {
                case "1":
                    bookShelf.SaveToFile(filePath);
                    break;

                case "2":
                    bookShelf.LoadFromFile(filePath);
                    break;

                case "*":
                    return;

                default:
                    Console.WriteLine("Wring onput"); //Yes this spelling error was made on purpose
                    break;
            }            
        }
        #endregion
    }
}