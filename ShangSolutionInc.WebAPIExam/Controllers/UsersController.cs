using Microsoft.AspNetCore.Mvc;
using Microsoft.Owin.Security;
using System.IdentityModel.Tokens.Jwt;
using ShangSolutionInc.WebAPIExam.Utilities;
using ShangSolutionInc.WebAPIExam.Services;
using ShangSolutionInc.WebAPIExam.Models;

namespace ShangSolutionInc.WebAPIExam.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet()]
        //public string Get()
        //{
        //    try
        //    {
        //        //Validate JWT Token
        //        String token = Request.Headers.Authorization;
        //        var tokenHandler = new TokenHandler(token);
        //        bool tokenIsValid = tokenHandler.validate();

        //        if (!tokenIsValid)
        //        {
        //            //Return unauthorized response
        //            Response.StatusCode = 401;
        //            return "401 par";
        //        }

        //        String client = string.IsNullOrEmpty(Request.Headers["client"]) ? "ClientA" : Request.Headers["client"];
        //        UsersService usersService = new UsersService(client);
        //        //List<User> users = usersService.GetUsers();
        //        string m = usersService.GetUserss();
        //        return m;
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.StatusCode = 500;
        //        return ex.Message;
        //    }

        //}
        public List<User> Get()
        {
            try
            {
                //Validate JWT Token
                String token = Request.Headers.Authorization;
                var tokenHandler = new TokenHandler(token);
                bool tokenIsValid = tokenHandler.validate();

                if (!tokenIsValid)
                {
                    //Return unauthorized response
                    Response.StatusCode = 401;
                    return null;
                }

                String client = string.IsNullOrEmpty(Request.Headers["client"]) ? "ClientA" : Request.Headers["client"];
                UsersService usersService = new UsersService(client);
                List<User> users = usersService.GetUsers();

                return users;
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return null;
            }

        }
        [HttpPost()]
        public bool Post([FromBody] UserWrapper User)//Sample JSON Request Body {"User":{"UserId":1,"Username":"adams.baker","Firstname":"Adams","Lastname":"Baker","State":"Cleveland"}}
        {
            try
            {
                //Validate JWT Token
                String token = Request.Headers.Authorization;
                var tokenHandler = new TokenHandler(token);
                bool tokenIsValid = tokenHandler.validate();

                if (!tokenIsValid)
                {
                    //Return unauthorized response
                    Response.StatusCode = 401;
                    return false;
                }

                String client = string.IsNullOrEmpty(Request.Headers["client"]) ? "ClientA" : Request.Headers["client"];
                UsersService usersService = new UsersService(client);
                bool result = usersService.AddUser(User.User.UserId, User.User.Username, User.User.Firstname, User.User.Lastname, User.User.State);

                return result;
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return false;
            }
        }

        [HttpPut()]
        public bool Put([FromBody] UserWrapper User)//Sample JSON Request Body {"User":{"UserId":1,"Username":"adams.baker","Firstname":"Adams","Lastname":"Baker","State":"Cleveland"}}
        {
            try
            {
                //Validate JWT Token
                String token = Request.Headers.Authorization;
                var tokenHandler = new TokenHandler(token);
                bool tokenIsValid = tokenHandler.validate();

                if (!tokenIsValid)
                {
                    //Return unauthorized response
                    Response.StatusCode = 401;
                    return false;
                }

                String client = string.IsNullOrEmpty(Request.Headers["client"]) ? "ClientA" : Request.Headers["client"];
                UsersService usersService = new UsersService(client);
                bool result = usersService.UpdateUser(User.User.UserId, User.User.Username, User.User.Firstname, User.User.Lastname, User.User.State);

                return result;
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return false;
            }

        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                //Validate JWT Token
                String token = Request.Headers.Authorization;
                var tokenHandler = new TokenHandler(token);
                bool tokenIsValid = tokenHandler.validate();

                if (!tokenIsValid)
                {
                    //Return unauthorized response
                    Response.StatusCode = 401;
                    return false;
                }

                String client = string.IsNullOrEmpty(Request.Headers["client"]) ? "ClientA" : Request.Headers["client"];
                UsersService usersService = new UsersService(client);
                bool result = usersService.DeleteUser(id);

                return result;
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return false;
            }

        }
    }
}