using Microsoft.AspNetCore.Mvc;
namespace BetAPI.Controllers
{
     [Route("/home")]
     public class HomeController : Controller
     {
          public IActionResult Index()
          {
               return View();
          }
     }
}