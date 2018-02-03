using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Models;
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
            var user = _repo.GetUser(email:userEmail, checkpassword:false,password:null);

            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
