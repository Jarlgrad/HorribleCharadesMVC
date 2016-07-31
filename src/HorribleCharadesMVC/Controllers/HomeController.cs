using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HorribleCharadesMVC.Models;
using HorribleCharadesMVC.Viewmodels.Home;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HorribleCharadesMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NewGame()
        {
            Game game = new Game();
            
            DataManager.AddTeam(game.Code, game.Teams[0].TeamName); //Kom ihåg att ändra adda teams till SQL
            var viewModel = new NewGameViewModel()
            {
                GameCode = game.Code
            };
            return View(viewModel);
         
        }
        //[HttpPost]
        //public IActionResult NewGame(string gameCode)
        //{
        //    Game game = new Game();

        //    DataManager.AddTeam(game.Code, game.Teams[0].TeamName); //Kom ihåg att ändra adda teams till SQL

        //    return RedirectToAction(nameof(PlayController.Main));

        //}
        public IActionResult JoinGame()
        {
            return View();
        }
    }
}
