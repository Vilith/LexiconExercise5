using LibrarySystem.Helpers;
using LibrarySystem.Shared;
using SortOption = LibrarySystem.Shared.SortOption;

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
                MenuHelper.ShowEnumMenu<MenuOption>("Main Menu");
                //var menuOptions = MenuHelper.ShowEnumMenu<MenuOption>;
                //{
                //{ MenuOption.AddBook, "Add Book" },
                //{ MenuOption.RemoveBook, "Return Book" },
                //{ MenuOption.ListBooks, "List Books" },
                //{ MenuOption.SearchBook, "Search Books" },
                //{ MenuOption.MarkBook, "Available/Unavailabe" },
                //{ MenuOption.JsonMenu, "JSON" }
                //};
                //MenuHelper.ShowMainMenu();

                //MenuHelper.ShowMenu();
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


                //if (string.IsNullOrEmpty(input) || !MenuHelper.IsValidChoice<MenuOption>(input))
                //{
                //    MenuHelper.GetStandardErrorMessage();
                //    continue;
                //}

                //switch (selectedOption)
                //{
                //case MenuOption.AddBook:
                //AddBookMenu();
                //break;

                //case MenuOption.RemoveBook:
                //RemoveBookMenu();
                //break;

                //case MenuOption.ListBooks:
                //ListBooksMenu();
                //break;

                //case MenuOption.SearchBook:
                //SearchBookMenu();
                //break;

                //case MenuOption.MarkBook:
                //MarkBookMenu();
                //break;

                //case MenuOption.JsonMenu:
                //JsonMenu();
                //break;

                //default:
                //MenuHelper.GetInvalidText();
                //break;

                //case MenuHelper.ADD:
                //AddBookMenu();
                //break;

                //case MenuHelper.REMOVE:
                //RemoveBookMenu();
                //break;

                //case MenuHelper.LIST:
                //ListBooksMenu();
                //break;

                //case MenuHelper.SEARCH:
                //SearchBookMenu();
                //break;

                //case MenuHelper.MARK:
                //MarkBookMenu();
                //break;

                //case MenuHelper.JSON:
                //JsonMenu();
                //break;

                //case MenuHelper.QUIT:
                //isRunning = false;
                //break;

                //default:
                //MenuHelper.GetInvalidText();
                //break;
                HandleMenuSelection(selectedOption);

            }
            while (isRunning);
        }
        #endregion

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


        #region [ADD BOOK]
        private void AddBookMenu()
        {
            try
            {
                //string isbn = Console.ReadLine();
                string isbn = Utils.GetValidISBN();
                string category = Utils.SelectGenre();
                string title = Utils.PromptForInput("Title");
                string author = Utils.PromptForInput("Author");

                var book = new Book(title, author, isbn, category);
                //{
                    //Title = title,
                    //Author = author,
                    //ISBN = isbn,
                    //Category = category,
                    //Available = true
                //};

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
            MenuHelper.ShowEnumMenu<RemoveBookOption>("Remove Book Menu");
            //MenuHelper.ShowRemoveBookMenu();
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

        //switch (input)
        //{
        //case "1":
        //string isbn = Utils.PromptForInput("ISBN of book to remove:");
        //bookShelf.RemoveBookByISBN(isbn);
        //Console.WriteLine("Book removed successfully."); //Not Dry
        //break;

        //case "2":
        //string title = Utils.PromptForInput("Title of book to remove:");
        //bookShelf.RemoveBookByTitle(title);
        //Console.WriteLine("Book removed successfully."); //Not Dry
        //break;

        //default:
        //Console.WriteLine("Invalid selection.");
        //break;
        //}

        //}
        #endregion

        #region [LIST BOOKS]
        private void ListBooksMenu()
        {
            do
            {
                MenuHelper.ShowEnumMenu<SortOption>("List Books Menu");
                //MenuHelper.ShowListBooksMenu();
                var input = Console.ReadLine();
                //SortOption option = SortOption.Title;

                if (input == MenuHelper.QUIT) return;

                if (!Enum.TryParse(input, out SortOption option))
                {
                    Console.WriteLine(MenuHelper.GetInvalidText());
                    continue;
                }

                //switch (input)
                //{
                    //case "1":
                        //option = SortOption.Title;
                        //break;
                
                    //case "2":
                        //option = SortOption.Author;
                        //break;
                
                    //case "3":
                        //option = SortOption.ISBN;
                        //break;
                
                    //case "4":
                        //option = SortOption.Category;
                        //break;
                
                    //case "5":
                        //option = SortOption.Available;
                        //break;
                
                    //case "*":
                        //return;
                
                    //default:
                        //Console.WriteLine("Wrong input!");
                        //break;
                
                //}

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
            MenuHelper.ShowEnumMenu<SearchOptions>("Search Books Menu");
            //MenuHelper.ShowSearchMenu();
            var input = Console.ReadLine();
            //List<Book> results = new();

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


            //switch (input)
            //{
            //case "1":

            //string title = Utils.PromptForInput("Enter book title");
            //results = bookShelf.SearchByTitle(title);
            //break;

            //case "2":

            //string author = Utils.PromptForInput("Enter name of author");
            //results = bookShelf.SearchByAuthor(author);
            //break;

            //case "*":

            //return;

            //default:
            //Console.WriteLine("Invalid input my man");
            //break;

            //}

            //if (!results.Any())
            //{
            //Console.WriteLine("No matches were found.");
            //return;
            //}

            //Console.WriteLine($"{Environment.NewLine}{"Title",-30} {"Author",-20} " +
            //$"{"ISBN",-15} {"Category",-15} {"Available",-10}");
            //Console.WriteLine(new string('-', 90));

            //foreach (var books in results)
            //{
            //Console.ForegroundColor = ConsoleColor.DarkMagenta; //TODO - Remove before done.
            //Console.WriteLine($"{books.Title,-30} {books.Author,-20} {books.ISBN,-15} " +
            //$"{books.Category,-15} {books.Available,-10}");
            //Console.ResetColor(); //TODO - Remove before done.
            //}
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
            MenuHelper.ShowEnumMenu<JsonOption>("JSON Menu");
            //MenuHelper.ShowJsonMenu();
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

            //switch (input)
            //{
            //case "1":
            //bookShelf.SaveToFile(filePath);
            //break;

            //case "2":
            //bookShelf.LoadFromFile(filePath);
            //break;

            //case "*":
            //return;

            //default:
            //Console.WriteLine("Wring onput"); //Yes this spelling error was made on purpose
            //break;
            //}
            //}
            #endregion
        }
    }
}