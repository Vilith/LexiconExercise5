using LibrarySystem.Helpers;
using LibrarySystem.Shared.Enums;
using Xunit.Abstractions;

namespace LibrarySystem.Tests
{
    public class MenuHelperTests
    {
        #region [AAA]
        //ARRANGE
        //ACT
        //ASSERT
        #endregion

        [Theory]
        [InlineData(typeof(MenuOption), "Main Menu")]
        [InlineData(typeof(ListBooksOption), "List Books Menu")]
        [InlineData(typeof(SearchOptions), "Search Menu")]
        [InlineData(typeof(JsonOption), "JSON Menu")]
        [InlineData(typeof(RemoveBookOption), "Return Book Menu")]        
        public void ShowEnumMenu_ShouldPrintExpectedOptions(Type enumType, string menuTitle)
        {
            // Arrange
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            typeof(MenuHelper)
                .GetMethod("ShowEnumMenu")!
                .MakeGenericMethod(enumType)
                .Invoke(null, new object[] { menuTitle });            

            // Assert
            var output = sw.ToString();
            Assert.Contains(menuTitle.ToUpper(), output);

            foreach (var value in Enum.GetValues(enumType))
            {
                var description = MenuHelper.GetEnumDescription((Enum)value);
                var line = $"{(int)value}. {description}";
                Assert.Contains(line, output);
            }            
        }

        [Theory]
        [InlineData(typeof(SearchOptions), "Search Menu", "1. Title")]
        [InlineData(typeof(ListBooksOption), "List Books Menu", "1. Title")]
        public void ShowEnumMenu_ShouldIncludeDescriptions(Type enumType, string menuTitle, string expectedLine)
        {
            // Arrange
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            typeof(MenuHelper)
                .GetMethod("ShowEnumMenu")!
                .MakeGenericMethod(enumType)
                .Invoke(null, new object[] { menuTitle });

            // Assert            
            var output = sw.ToString();
            Assert.Contains(menuTitle.ToUpper(), output);
            Assert.Contains(expectedLine, output);          
        }

        [Fact]
        public void ShowMainMenu_ShouldDisplayMainMenu()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);

            MenuHelper.ShowMainMenu();

            var output = sw.ToString();
            Assert.Contains("MAIN MENU", output);
            Assert.Contains("1. Add Book", output);
        }

        [Fact]
        public void GetInvalidText_ShouldReturnExpectedMessage()
        {
            
            var result = MenuHelper.GetInvalidText();
                        
            Assert.Equal($"{Environment.NewLine}Input should be a number corresponding to a menu option. Use '*' to quit.", result);
            
        }

        [Fact]
        public void QuitConstant_ShouldBeExpectedValue()
        {
            Assert.Equal("*", MenuHelper.QUIT); // eller vad du har satt
        }
    }
}
