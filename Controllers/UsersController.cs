using Microsoft.AspNetCore.Mvc;
using BetAPI.Services;
using System.Collections.Generic;
using System;
namespace BetAPI.Controllers
{
     [Route("api/[controller]")]
     public class UsersController : Controller
     {
          private UserDbContext _context;
          public UsersController(UserDbContext context)
          {
               _context = context;
          }

          // GET api/users
          public IActionResult GetUsers()
          {
               return Ok(_context.Users);
          }

          // GET api/users/guid
          [HttpGet("{id}", Name = nameof(GetUsersById))]
          public IActionResult GetUsersById(int id)
          {
              var userFilter = _context.Users.Find(id);
              if(userFilter == null) {
                  return NotFound();
              } else {
                  return Ok(userFilter);
              }
          }
     }
}