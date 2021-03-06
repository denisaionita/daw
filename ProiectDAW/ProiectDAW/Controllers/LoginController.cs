﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProiectDAW.Models;
using ProiectDAW.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace ProiectDAW.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/login")]
    public class LoginController : Controller
    {
        private BDRepo bdr = new BDRepo();

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                //This method returns user from email and password.
                var checkUser = bdr.GetUser(username: user.Username,checkpassword: true,password: user.Password);

                if (checkUser == null)
                {
                    return Unauthorized();
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                 };

                var token = new JwtSecurityToken
                (
                    issuer: "ProiectDAW",
                    audience: "FrontendDAW",
                    claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(60),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("89babe78-2664-4c7f-b516-8bea619af7ad")),
                            SecurityAlgorithms.HmacSha256)
                );

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }

            return BadRequest();
        }
    }
}
