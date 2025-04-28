using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    internal class Book
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }
        //public string ISBN
        //{
        //    get => isbn;
        //    set
        //    {
        //        if (value.Length != 13 || !value.All(char.IsDigit))
        //            throw new ArgumentException("Wrong input! ISBN contains of 13 numbers!");
        //        isbn = value;
        //    }
        //}
        
        public string Category { get; set; }
        public bool Available { get; set; }


        
    }    
}
