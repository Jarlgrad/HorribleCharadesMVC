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
        public IActionResult Ready()
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

        public IActionResult Score(int id)
        {
            var teams = DataManager.GetTeamsTest(HttpContext.Session.GetString("GameCode"));
            #region
            if (TempData["id"] != null)
            {
                if ((int)TempData["id"] >= teams.Count())
                {
                    return RedirectToAction(nameof(Standing));
                }
                else
                {
                    ScoreViewModel ScoreVM = new ScoreViewModel()
                    {
                        GameCode = "TONIS",
                        Team = teams[(int)TempData["id"]],

                    };
                    TempData["id"] = (int)TempData["id"] + 1;
                    return View(ScoreVM);
                }

            }
            else
            {
                TempData["id"] = 0;
                ScoreViewModel ScoreVM = new ScoreViewModel()
                {
                    GameCode = "TONIS",
                    Team = teams[0],
                };
                return View(ScoreVM);
            }
            #endregion
            //ScoreViewModel ScoreVM = new ScoreViewModel()
            //{
            //    GameCode = "TONIS",
            //    Team = teams[0],
            //    Id = id
            //};
            //return View(ScoreVM);
        }
        public IActionResult Standing()
        {
            TempData["id"] = null;
            StandingVM StandingVM = new StandingVM()
            {
                GameCode = "TONIS",
                Teams = DataManager.GetTeamsTest(HttpContext.Session.GetString("GameCode"))
            };
            return View(StandingVM);
        }
    }
}
