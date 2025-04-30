using System.ComponentModel;

namespace LibrarySystem.Shared.Enums
{
    [Description("Main Menu")]
    public enum MenuOption
    {
        [Description("Add Book")]
        AddBook = 1,

        [Description("Remove Book")]
        RemoveBook,

        [Description("List Books")]
        ListBooks,

        [Description("Search Book")]
        SearchBook,

        [Description("Mark Book")]
        MarkBook,

        [Description("JSON")]
        JsonMenu                
    }
}
