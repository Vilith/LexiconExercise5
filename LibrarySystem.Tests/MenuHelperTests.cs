using LibrarySystem.Helpers;

namespace LibrarySystem.Tests
{
    public class MenuHelperTests
    {
        [Fact]
        public void InvalidText_ShouldReturnExpectedMessage()
        {
            //ARRANGE
            var result = MenuHelper.GetInvalidText();
            //ACT           

            //ASSERT
            Assert.Equal($"{Environment.NewLine}Input should be a number between 1-6! * for quitting", result);
            
        }

        [Fact]
        public void PlaceHolder()
        {

        }
    }
}
