using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SonOfCod.Models;
using SonOfCod.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace SonOfCod.Controllers
{
    public class HomeController : Controller
    {
        private readonly SonOfCodDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public IActionResult Index()
        {
            return View();
        }

        public HomeController(UserManager<User> userManager, SignInManager<User> signInManager, SonOfCodDbContext db)
        {
            _db = db;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterViewModel model)
        {
            var user = new User { UserName = model.UserName };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


    }
}
