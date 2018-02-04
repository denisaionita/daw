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
    [Route("api/wishlist")]
    public class WishlistController : Controller
    {
        private BDRepo _repo = new BDRepo();
        [HttpGet]
        [Route("{userEmail}/get")]
        public IActionResult GetUser(string userEmail)
        {
            var user = _repo.GetUser(username: userEmail, checkpassword: false, password: null);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
