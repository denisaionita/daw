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

        [HttpPost]
        [Route("")]
        public IActionResult RegisterUser([FromBody]User user)
        {
            var existingUser = _repo.GetUser(username: user.Username, checkpassword: false, password: null);

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