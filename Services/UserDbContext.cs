using Microsoft.EntityFrameworkCore;
using BetAPI.Entities;
namespace BetAPI.Services
{
     public class UserDbContext : DbContext
     {
          public DbSet<User> Users { get; set; }
          public UserDbContext(
               DbContextOptions<UserDbContext> options)
               : base(options)
          {
               Database.EnsureCreated();
          }
     }
}