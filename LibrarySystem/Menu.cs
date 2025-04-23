using LibrarySystem.Helpers;

namespace LibrarySystem
{
    internal class Menu
    {
        #region [isRunning]
        private bool isRunning = true;
        #endregion

        public Menu()
        {            
            #region [DO-WHILE]
            do
            {
                MenuHelper.ShowMenu();
                string input = Console.ReadLine();

                #region [MENU]
                switch (input)
                {

                    case MenuHelper.ADD:


                        break;

                    case MenuHelper.REMOVE:


                        break;

                    case MenuHelper.LIST:


                        break;

                    case MenuHelper.SEARCH:


                        break;

                    case MenuHelper.MARK:


                        break;

                    case MenuHelper.JSON:


                        break;

                    case MenuHelper.QUIT:

                        isRunning = false;
                        break;

                    default:

                        MenuHelper.GetInvalidText();
                        break;
                #endregion

                }
            }
            while (isRunning);
            #endregion
        }
    }
}