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

        #region [METHODS]
        private void AddBookMenu()
        {

            string title = Utils.PromptForInput("Title");
            string author = Utils.PromptForInput("Author");
            string isbn = Utils.PromptForInput("Isbn");
            string category = Utils.PromptForInput("Category");

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

        private void RemoveBookMenu()
        {
            Console.WriteLine("To be implemented.");
        }

        private void ListBooksMenu()
        {
            Console.WriteLine("To be implemented.");
        }

        private void SearchBookMenu()
        {
            Console.WriteLine("To be implemented.");
        }
        private void MarkBookMenu()
        {
            Console.WriteLine("To be implemented.");
        }
        private void JsonMenu()
        {
            Console.WriteLine("To be implemented.");
        }
        #endregion
    }
}