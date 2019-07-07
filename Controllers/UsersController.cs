using Microsoft.AspNetCore.Mvc;
using BetAPI.Services;
using BetAPI.Entities;
using System.Collections.Generic;
using System;
namespace BetAPI.Controllers
{
     [Produces("application/json", "application/xml")]
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

          // POST api/users
          [HttpPost]
          public IActionResult PostUser([FromBody]User user)
          {
               if (user == null)
               {
                    return BadRequest();
               }
               _context.Add(user);
               _context.SaveChanges();
               return CreatedAtRoute(nameof(GetUsersById), new { id = user.Id }, user);
          }

          // PUT api/users/guid
          [HttpPut("{id}")]
          public IActionResult PutUser(int id, [FromBody]User user)
          {
               if (user == null)
               {
                    return BadRequest();
               }
               var putUser = _context.Users.Find(id);
               if (putUser == null)
               {
                    return NotFound();
               }
               putUser.Name = user.Name;
               putUser.Age = user.Age;
               _context.Update(putUser);
               _context.SaveChanges();
               return new NoContentResult();
          }

          // DELETE api/users/guid
          [HttpDelete("{id}")]
          public void Delete(int id)
          {
               var putUser = _context.Users.Find(id);
               if (putUser != null)
               {
                    _context.Users.Remove(putUser);
                    _context.SaveChanges();
               }
          }         
     }
}