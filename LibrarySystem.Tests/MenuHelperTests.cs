using LibrarySystem.Helpers;

namespace LibrarySystem.Tests
{
    public class MenuHelperTests
    {

        public enum DummyMenu
        {
            OptionOne = 1,
            OptionTwo,
            OptionThree,
            OptionFour,
            OptionFive,
            OptionSix,
            OptionSeven,
        }


        [Fact]
        public void ShowEnumMenu_ShouldPrintAllEnumOptions()
        {
            // Arrange
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            MenuHelper.ShowEnumMenu<DummyMenu>("Dummy Menu");

            // Assert
            var output = sw.ToString();
            Assert.Contains("Dummy Menu", output);
            Assert.Contains("1. OptionOne", output);
            Assert.Contains("2. OptionTwo", output);
            Assert.Contains("3. OptionThree", output);
        }


        #region [AAA]
        //ARRANGE
        //ACT
        //ASSERT
        #endregion

        [Fact]
        public void InvalidText_ShouldReturnExpectedMessage()
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
