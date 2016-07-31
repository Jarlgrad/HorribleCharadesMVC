using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HorribleCharadesMVC.Models;
using HorribleCharadesMVC.Viewmodels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HorribleCharadesMVC.Controllers
{
    public class PlayController : Controller
    {
        // GET: /<controller>/
        public IActionResult Main(Game game)
        {
            MainViewModel MainVM = new MainViewModel()
            {
                charadeWord = DataManager.CombinedWords(),
                game = game
            };

            return View(MainVM);
        }

        public IActionResult Score(Game game)
        {
            var team = DataManager.GetTeams(game.Code);
            return View();
        }
    }
}
