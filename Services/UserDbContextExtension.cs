using System.Collections.Generic;
using System.Linq;
using BetAPI.Entities;
namespace BetAPI.Services
{
     public static class UserDbContextExtensions
     {
          public static void CreateSeedData
               (this UserDbContext context)
          {
               if (context.Users.Any())
                    return;
               var users = new List<User>()
               {
                    new User()
                    {
                         Name = "El Bananero",
                         Age = 32
                    },
                    new User()
                    {
                         Name = "Pepe Lucho",
                         Age = 24
                    },
                    new User()
                    {
                         Name = "Black Panther",
                         Age = 28
                    }
               };
               context.AddRange(users);
               context.SaveChanges();
          }
     }
}