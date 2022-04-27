using ShangSolutionInc.WebAPIExam.Models;
using ShangSolutionInc.WebAPIExam.Services;
using ShangSolutionInc.WebAPIExam.Utilities;
using System.Collections.Generic;
using Xunit;

namespace ShangSolutionsInc.WebAPIExam.UnitTest
{
    public class UsersServiceTest
    {
        [Fact]
        public void GetUsers_ReturnWithValues()
        {
            //Arrange
            string client = "ClientA";
            UsersService usersService = new UsersService(client);

            //Act
            List<User> result = usersService.GetUsers();

            //Assert
            Assert.NotEmpty(result);

        }
    }
}
