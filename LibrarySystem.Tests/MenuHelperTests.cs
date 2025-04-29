using LibrarySystem.Helpers;

namespace LibrarySystem.Tests
{
    public class MenuHelperTests
    {
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
        public void PlaceHolder()
        {

            
            
        }
    }
}
