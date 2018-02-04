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
   [Route("api/books")]
        public class BookController : Controller
        {
            private BDRepo _repo = new BDRepo();

        [AllowAnonymous]
        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody] Book book)
        {
            try
            {
                var bookAdded = new Book();
                bookAdded.BookId = _repo.GenerateIdBookList();
                var result = _repo.PostObject<Book>(bookAdded);
                return Ok(bookAdded);
            }
            catch
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("all")]
        public IActionResult Update([FromBody] Book book)
        {

            return BadRequest();
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("add")]
        public IActionResult Delete([FromBody] Book book)
        {

            return BadRequest();
        }
    }
    }

