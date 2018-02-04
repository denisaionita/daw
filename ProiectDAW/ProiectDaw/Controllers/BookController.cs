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
              var existingBook = _repo.get

                return BadRequest();
            }

        [AllowAnonymous]
        [HttpPut]
        [Route("add")]
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

