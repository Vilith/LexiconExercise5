using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Helpers
{
    public static class Utils
    {

        public static string PromptForInput(string fieldName)
        {
            Console.WriteLine($"{fieldName}: ");
            return Console.ReadLine();
        }
        //Validating inputs here


    }
}
