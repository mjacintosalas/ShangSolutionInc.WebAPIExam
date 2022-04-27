using ShangSolutionInc.WebAPIExam.Utilities;
using Xunit;

namespace ShangSolutionsInc.WebAPIExam.UnitTest
{
    public class TokenHandlerTest
    {
        [Fact]
        public void validate_TokenIdentifierClaim_ReturnTrue()
        {
            //Arrange
            string token = "Bearer eyJhbGciOiJIUzI1NiJ9.eyJJZGVudGlmaWVyIjoiU1NJIiwiSXNzdWVyIjoiSXNzdWVyIiwiZXhwIjoxNjUwOTYyODUzLCJpYXQiOjE2NTA5NjI4NTN9.36jtUID_Hr0KbkkDy6CeLxu6hUw4JSVejaTE9hG5KHs";
            var tokenHandler = new TokenHandler(token);

            //Act
            bool result = tokenHandler.validate();

            //Assert
            Assert.Equal(true, result);

        }
    }
}