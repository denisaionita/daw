using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Models;
using ProiectDAW.FrontendModels;
using ProiectDAW.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace ProiectDAW.Controllers
{
    [EnableCors("CorsPolicy")]
    //[Authorize]
    [Route("api/wishlist")]
    public class WishlistController : Controller
    {
        private BDRepo _repo = new BDRepo();
        [HttpGet]
        [Route("{username}/get")]
        public IActionResult GetWishlist(string username)
        {
            try 
            {
                var wishList = _repo.GetWishlist(username);
                return Ok(wishList);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("{username}/{bookId}/add")]
        public IActionResult Add(string username, string bookId)
        {
            try
            {
                var wish = new Wishlist();
                wish.BookId = _repo.GenerateIdWishList();
                wish.UserEmail = username;
                wish.BookId = bookId;

                _repo.PostObject<Wishlist>(wish);

                return Ok(wish);
            }
            catch
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("{username}/{bookId}/delete")]
        public IActionResult Delete(string bookId, string username)
        {
            try
            {
                var existingWishlist = _repo.GetWish(username, bookId);
                if (existingWishlist == null)
                {
                    return NotFound();
                }
                var result = _repo.DeleteObject<Wishlist>(existingWishlist);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
