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
            if(_db.MenuInfo.ToList().Count() < 1)
            {
                var baseInfo = new MenuInfo();
                _db.MenuInfo.Add(baseInfo);
            }
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

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var thisUser = _db.Users.FirstOrDefault(users => users.UserName == model.UserName);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Admin()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.UserList = _db.Users.ToList();
                return View();
            }
            else
            {
                return View("Index");
            }
        }

        public IActionResult FrontEdit()
        {
            MenuInfo thisMenu = _db.MenuInfo.FirstOrDefault(menuinfo => menuinfo.Id == 0);
            return View(thisMenu);
        }

        public IActionResult Newsletter()
        {
            ViewBag.MailList = _db.Mailusers.ToList();
            return View();
        }

        public IActionResult RegisterMail(MailViewModel model)
        {
            var mailUser = new Mailuser { email = model.Email };
            _db.Mailusers.Add(mailUser);

            return View("Index");
        }

    }
}
