using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab21.Models;

namespace Lab21.Controllers
{
    public class HomeController : Controller
    {
        private readonly CoffeeShopUserDbContext _context;
        public HomeController(CoffeeShopUserDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string FirstName)
        {
            ViewBag.Name = FirstName;
            return View();
        }
        public IActionResult LoginUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginUser(int UserID, string Password)
        {
            List<RegisterUser> userList = _context.RegisterUser.ToList();
            foreach (var user in userList)
            {
                if (user.UserId == UserID)
                {
                    if (user.Password == Password)
                    {
                        return View("Index", user.FirstName);
                    }
                    else
                    {
                        return RedirectToAction("InvalidLogin");
                    }
                }
            }
            return RedirectToAction("InvalidLogin");
        }
        public IActionResult InvalidLogin()
        {
            return View();
        }
        public IActionResult RegisterNewUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterNewUser(RegisterUser newUser)
        {
            if(ModelState.IsValid)
            {
                _context.RegisterUser.Add(newUser);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "That was not a valid entry for a new user";
                return View("RegisterNewUser");
            }
        }
    }
    
}
