using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HorribleCharadesMVC.Models;
using HorribleCharadesMVC.Viewmodels;
using HorribleCharadesMVC.Viewmodels.Play;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HorribleCharadesMVC.Controllers
{
    public class PlayController : Controller
    {
        // GET: /<controller>/
        public IActionResult Main(string id)
        {
            MainViewModel MainVM = new MainViewModel()
            {
                charadeWord = DataManager.CombinedWords(),
                GameCode = id
            };

            return View(MainVM);
        }

        public IActionResult Score()
        {
            ScoreViewModel ScoreVM = new ScoreViewModel()
            {
                GameCode = "TONIS",
                Teams = DataManager.GetTeamsTest()
            };
            return View(ScoreVM);
        }
        public IActionResult Standing()
        {
            ScoreViewModel ScoreVM = new ScoreViewModel()
            {
                GameCode = "TONIS",
                Teams = DataManager.GetTeamsTest()
            };
            return View(ScoreVM);
        }
    }
}
