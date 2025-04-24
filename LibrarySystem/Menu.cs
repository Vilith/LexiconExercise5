using LibrarySystem.Helpers;

namespace LibrarySystem
{
    internal class Menu
    {
        #region [isRunning]
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
            #endregion
        }

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
            var allBooks = bookShelf.GetAllBooksSortedByTitle();

            if (!allBooks.Any())
            {
                Console.WriteLine("Ehrmegerd - The library is empty.");
                return;
            }

            Console.WriteLine($"{Environment.NewLine}{"Title", -30} {"Author", -20} " +
                $"{"ISBN", -15} {"Category", -15} {"Available", -10}");

            Console.WriteLine(new string('-', 90));
            //Implementation in progress
            foreach (var book in allBooks)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; //TODO - Remove before done.
                Console.WriteLine($"{book.Title, -30} {book.Author, -20} {book.ISBN, -15} " +
                    $"{book.Category, -15} {book.Available, -10}");
                Console.ResetColor(); //TODO - Remove before done.
            }
        }
        #endregion
        #region [Placeholder]
        private void SearchBookMenu()
        {
            Console.WriteLine("To be implemented.");
        }
        #endregion
        #region [Placeholder]
        private void MarkBookMenu()
        {
            Console.WriteLine("To be implemented.");
        }
        #endregion
        #region [Placeholder]
        private void JsonMenu()
        {
            Console.WriteLine("To be implemented.");
        }
        #endregion

    }
}