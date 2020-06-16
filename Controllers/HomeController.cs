using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefsNDishes.Models;


namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        public MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }



        [HttpGet("chefs")]
        public IActionResult DisplayChefs()
        {
            List<Chef> AllChefs = dbContext.Chefs.Include(c => c.CreatedDishes).ToList();
            return View("ChefDash", AllChefs);
        }


        [HttpGet("dishes")]
        public IActionResult DisplayDishes()
        {
            List<Dish> AllDishes = dbContext.Dishes.Include(d => d.Chef).ToList();
            // int numDishes = dbContext.Dishes.Incldue(dish = dish.Chef).firstor
            return View("DishDash", AllDishes);
        }


        [HttpGet("chefs/new")]
        public IActionResult AddChef()
        {
            return View("AddChefPage");
        }


        [HttpPost("chefs/new")]
        public IActionResult AddChefForm(Chef FromForm)
        {
            if (ModelState.IsValid)
            {
                dbContext.Chefs.Add(FromForm);
                dbContext.SaveChanges();
                return RedirectToAction("DisplayChefs");
            }
            else
            {
                return View("AddChefPage", FromForm);
            }
        }


        [HttpGet("dishes/new")]
        public IActionResult AddDish()
        {
            // List<Chef> AllChefs = dbContext.Chefs.ToList();
            oneDishAndAllChefs ViewModel = new oneDishAndAllChefs()
            {
                oneDish = new Dish(),
                AllChefs = dbContext.Chefs.ToList()
            };
            // ViewBag.Chefs = AllChefs;
            return View("AddDishPage", ViewModel);
        }

        [HttpPost("dishes/new")]
        public IActionResult AddDishForm(oneDishAndAllChefs FromForm)
        {
            if (ModelState.IsValid)
            {
                dbContext.Dishes.Add(FromForm.oneDish);
                dbContext.SaveChanges();
                return RedirectToAction("DisplayDishes");
            }
            else
            {
                return View("AddDishPage", FromForm);
            }
        }






        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
