using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Models;
using ProiectDAW.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Controllers

{   [Authorize]
    [Route("api/user")]
    public class UserController : Controller
    {
        private BDRepo bdr = new BDRepo();

        [HttpGet]
        [Route("all")]
        public IActionResult GetUsers()
        {
            var users = bdr.GetObjects<User>();

            return Ok(users);
        }
    }
}
