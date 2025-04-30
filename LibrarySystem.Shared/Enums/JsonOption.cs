using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Shared.Enums
{
    [Description("JSON Menu")]
    public enum JsonOption
    {
        [Description("Save")]
        Save = 1,

        [Description("Load")]
        Load
    }
}
