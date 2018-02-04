using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Models;
using ProiectDAW.FrontendModels;
using ProiectDAW.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Controllers

{   //[Authorize]
    [Route("api/user")]
    public class UserController : Controller
    {
        private BDRepo _repo = new BDRepo();

        [HttpGet]
        [Route("all")]
        public IActionResult GetUsers()
        {
            var users = _repo.GetObjects<User>();

            return Ok(users);
        }

        [HttpGet]
        [Route("{userEmail}")]
        public IActionResult GetUser(string userEmail)
        {
            var user = _repo.GetUser(username:userEmail, checkpassword:false,password:null);

            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut]
        [Route("{userEmail}/update")]
        public IActionResult UpdateUser(string userEmail, [FromBody] User updatedUser)
        {
            var user = _repo.GetUser(username: userEmail, checkpassword: false, password: null);
            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = updatedUser.FirstName ?? user.FirstName;
            user.LastName = updatedUser.LastName ?? user.LastName;
            user.Role = user.Role;
            user.Password = user.Password;
            user.Username = user.Username;

            var result = _repo.PutObject<User>(user);

            if (result == null)
            {
                return BadRequest("Could not update user");
            }
            return Ok(user);
        }

        [HttpPut]
        [Route("{userEmail}/changePassword")]
        public IActionResult UpdateUser(string userEmail, ChangePasswordContent passwordContent)
        {
            var user = _repo.GetUser(username: userEmail, checkpassword: true, password: passwordContent.OldPassword);
            if (user == null)
            {
                return NotFound();
            }

            user.Password = passwordContent.NewPassword;

            var result = _repo.PutObject<User>(user);

            if (result == null)
            {
                return BadRequest("Could not change password");
            }
            return Ok(user);
        }
    }
}
