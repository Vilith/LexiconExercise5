using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Shared.Enums
{
    [Description("List Books Menu")]
    public enum ListBooksOption
    {
        [Description("Title")]
        Title = 1,

        [Description("Author")]
        Author,

        [Description("ISBN")]
        ISBN,

        [Description("Genre")]
        Category,

        [Description("Available")]
        Availability
    }
}
