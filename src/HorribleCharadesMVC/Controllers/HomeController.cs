using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HorribleCharadesMVC.Models;

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
            DataManager.AddTeam(game.Code, game.Teams[0].TeamName);

            return View(game);
         
        }
        public IActionResult JoinGame()
        {
            return View();
        }
    }
}
