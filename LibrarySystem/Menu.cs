using LibrarySystem.Helpers;
using LibrarySystem.Shared.Enums;
using SortOption = LibrarySystem.Shared.Enums.SortOption;

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
                MenuHelper.ShowMainMenu();             
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine(MenuHelper.GetStandardErrorMessage());
                    continue;
                }

                if (input == MenuHelper.QUIT)
                {
                    isRunning = false;
                    break;
                }

                if (!Enum.TryParse(input, out MenuOption selectedOption))
                {
                    Console.WriteLine(MenuHelper.GetInvalidText());
                    continue;
                }

                HandleMenuSelection(selectedOption);
            }
            while (isRunning);
        }        

        private void HandleMenuSelection(MenuOption option)
        {
            switch (option)
            {
                case MenuOption.AddBook:
                    AddBookMenu();
                    break;

                case MenuOption.RemoveBook:
                    RemoveBookMenu();
                    break;

                case MenuOption.ListBooks:
                    ListBooksMenu();
                    break;

                case MenuOption.SearchBook:
                    SearchBookMenu();
                    break;

                case MenuOption.MarkBook:
                    MarkBookMenu();
                    break;

                case MenuOption.JsonMenu:
                    JsonMenu();
                    break;

                default:
                    Console.WriteLine(MenuHelper.GetInvalidText());
                    break;
            }
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

                var book = new Book(title, author, isbn, category);
                
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

            if (input == MenuHelper.QUIT) return;

            if (!Enum.TryParse(input, out RemoveBookOption option))
            {
                Console.WriteLine(MenuHelper.GetInvalidText());
                return;
            }

            switch (option)
            {
                case RemoveBookOption.ReturnByISBN:
                    string isbn = Utils.PromptForInput("ISBN of book to remove:");
                    bookShelf.RemoveBookByISBN(isbn);
                    break;

                case RemoveBookOption.ReturnByTitle:
                    string title = Utils.PromptForInput("Title of book to remove:");
                    bookShelf.RemoveBookByTitle(title);
                    break;
            }

            Console.WriteLine("Book removed successfully.");
        }     
        #endregion

        #region [LIST BOOKS]
        private void ListBooksMenu()
        {
            do
            {
                MenuHelper.ShowListBooksMenu();                
                var input = Console.ReadLine();                

                if (input == MenuHelper.QUIT) return;

                if (!Enum.TryParse(input, out SortOption option))
                {
                    Console.WriteLine(MenuHelper.GetInvalidText());
                    continue;
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
            
            if (input == MenuHelper.QUIT) return;

            if (!Enum.TryParse(input, out SearchOptions option))
            {
                Console.WriteLine(MenuHelper.GetInvalidText());
                return;
            }

            List<Book> results = option switch
            {
                SearchOptions.ByTitle => bookShelf.SearchByTitle(Utils.PromptForInput("Enter book title")),
                SearchOptions.ByAuthor => bookShelf.SearchByAuthor(Utils.PromptForInput("Enter name of author")),
                _ => new List<Book>()
            };

            if (!results.Any())
            {
                Console.WriteLine("No matches were found.");
                return;
            }

            Console.WriteLine($"{Environment.NewLine}{"Title",-30} {"Author",-20} " +
                              $"{"ISBN",-15} {"Category",-15} {"Available",-10}");
            Console.WriteLine(new string('-', 90));

            foreach (var book in results)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"{book.Title,-30} {book.Author,-20} {book.ISBN,-15} " +
                                  $"{book.Category,-15} {book.Available,-10}");
                Console.ResetColor();
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

            if (input == MenuHelper.QUIT) return;

            if (!Enum.TryParse(input, out JsonOption option))
            {
                Console.WriteLine(MenuHelper.GetInvalidText());
                return;
            }

            switch (option)
            {
                case JsonOption.Save:
                    bookShelf.SaveToFile(filePath);
                    break;

                case JsonOption.Load:
                    bookShelf.LoadFromFile(filePath);
                    break;
            }                        
        }
        #endregion
    }
}