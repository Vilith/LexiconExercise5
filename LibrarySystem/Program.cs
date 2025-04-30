namespace LibrarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            //Instansiating Library here for cleaner code.
            //Also for the purpose of making testing more accessible            
            var library = new Library();
            //library.LoadFromFile("library.json"); //Loading saved JSON when program starts.
            var menu = new Menu(library);

            #region [REQUIREMENT LIST]
            /*
              Funktioner: 

            - Lägg till en bok (titel, författare, ISBN, kategori)              *
            - Ta bort en bok (via titel eller ISBN)                             *
            - Lista alla böcker (sorterade t.ex. efter titel) med LINQ          *
            - Sök efter bok (titel eller författare) med LINQ                   *
            - Markera bok som "utlånad" eller "tillgänglig"                     *
            - Spara och läsa in biblioteket från fil (JSON)                     *
            
-------------------------------------------------------------------------------------

              Tekniska krav - Du förväntas använda:

            - Flera egna klasser (exempelvis Book, Library, ev. LibraryApp)     *
            - Listor (List<Book>) för att hantera bokdata                       *
            - Felhantering (try/catch och rimliga felmeddelanden)               
            - Filhantering med JSON (System.Text.Json)                          *
            - Tydlig, uppdelad meny med metoder för varje val                   
            - LINQ ska användas för att hantera collections.                    
            - Lägg till validering (ex: förhindra dubbletter baserat på ISBN)   
            - Grundläggande xUnit-tester (t.ex. för att testa inläsning,        
              sökfunktion eller bokvalidering)                                  
            */
            #endregion
        }
    }
}
