using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Shared
{
    public enum SearchOptions
    {
        [Description("Title")]
        ByTitle = 1,

        [Description("Author")]
        ByAuthor
    }
}
