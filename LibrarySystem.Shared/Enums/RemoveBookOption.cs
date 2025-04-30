using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Shared.Enums
{
    [Description("Remove Book Menu")]
    public enum RemoveBookOption
    {
        [Description("Return By ISBN")]
        ReturnByISBN = 1,

        [Description("Return By Title")]
        ReturnByTitle
    }
}
