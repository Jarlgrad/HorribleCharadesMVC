using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HorribleCharadesMVC.Models;
using HorribleCharadesMVC.Viewmodels;
using HorribleCharadesMVC.Viewmodels.Play;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HorribleCharadesMVC.Controllers
{
    public class PlayController : Controller
    {
        // GET: /<controller>/
        public IActionResult ReadyPlay()
        {
            ReadyVM ReadyVM = new ReadyVM()
            {
                GameCode = "TONIS",
                Teams = DataManager.GetTeamsTest(HttpContext.Session.GetString("GameCode"))
            };
            return View(ReadyVM);
        }
        public IActionResult ReadyWait()
        {
            ReadyVM ReadyVM = new ReadyVM()
            {
                GameCode = "TONIS",
                Teams = DataManager.GetTeamsTest(HttpContext.Session.GetString("GameCode"))
            };
            return View(ReadyVM);
        }

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
            var teams = DataManager.GetTeamsTest(HttpContext.Session.GetString("GameCode"));
            int tmpInt = (int)HttpContext.Session.GetInt32("TeamCount");

            if (tmpInt == 0)
            {
                ScoreViewModel ScoreVM = new ScoreViewModel()
                {
                    Team = teams[0],

                };
                HttpContext.Session.SetInt32("TeamCount", 1);
                return View(ScoreVM);
            }
            else
            {
                if (tmpInt >= teams.Count())
                {
                    HttpContext.Session.SetInt32("TeamCount", 0);
                    return RedirectToAction(nameof(Standing));

                }
                
                ScoreViewModel ScoreVM = new ScoreViewModel
                {
                    Team = teams[tmpInt]
                };
                HttpContext.Session.SetInt32("TeamCount", ++tmpInt);
                return View(ScoreVM);
            }

        }
        public IActionResult Standing()
        {
            StandingVM StandingVM = new StandingVM()
            {
                GameCode = "TONIS",
                Teams = DataManager.GetTeamsTest(HttpContext.Session.GetString("GameCode"))
            };
            return View(StandingVM);
        }
    }
}
