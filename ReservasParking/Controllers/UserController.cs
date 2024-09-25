using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservasParking.Data;
using ReservasParking.Models;

namespace ReservasParking.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UserController : Controller
    {
        
        private readonly ParkingDBContext _userContext;

        public UserController(ParkingDBContext userContext)
        {
            _userContext = userContext;
        }

        [HttpGet]
        public JsonResult get(int id)
        {
            var result = _userContext.tbl_users.Find(id);

            if (result == null)
                return new JsonResult(NotFound());
            return new JsonResult(Ok(result));
        }

        [HttpGet("getall")]
        public JsonResult getall()
        {
            var users = _userContext.tbl_users.ToList();

            return new JsonResult(users);
        }


        [HttpPost] 
        public JsonResult post([FromBody] UserRegister userRegister)
        {

            var newUser = new User { name = userRegister.name, email = userRegister.email, password = userRegister.password };
            
            _userContext.tbl_users.Add(newUser);
            
            _userContext.SaveChanges();

            return new JsonResult(Ok(newUser));
        }

        [HttpPost("login")]
        public JsonResult login([FromBody]UserLogin userLogin)
        {
            var result = _userContext.tbl_users.Where( u => u.email ==  userLogin.email ).ToList();

            if(!result.Any()) return new JsonResult(NotFound());

            if (result[0].password != userLogin.password) return new JsonResult(Unauthorized());

            return new JsonResult(Ok(result[0].Id));
        }
    }
}
