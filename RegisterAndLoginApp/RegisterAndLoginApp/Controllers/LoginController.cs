using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RegisterAndLoginApp.Models;
using RegisterAndLoginApp.Services;

namespace RegisterAndLoginApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

      

        public IActionResult ProcessLogin(UserModel userModel)
        {

            SecurityService securityService = new SecurityService();
            if(securityService.IsValid(userModel))
            {
                return View("GirisBasarili", userModel);

            } else
            {
                return View("GirisBasarisiz", userModel);
            }
        }
    }
}



    
        
    

