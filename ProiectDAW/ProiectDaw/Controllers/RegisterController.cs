using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Models;
using ProiectDAW.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Controllers
{
    //[Authorize]
    [Route("api/register")]
    public class RegisterController : Controller
    {
        private BDRepo _repo = new BDRepo();

        [HttpGet]
        [Route("{userEmail}")]
        public IActionResult RegisterUser([FromBody]User user, string userEmail)
        {
            var existingUser = _repo.GetUser(email: userEmail, checkpassword: false, password: null);

            if (existingUser != null)
            {
                return Unauthorized();
            }
            var result = _repo.PostObject<User>(user);

            if (result == null)
                return BadRequest("Could not create user.");

            return Ok("User registered");
        }
    }
}