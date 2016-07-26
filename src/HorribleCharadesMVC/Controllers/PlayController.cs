﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HorribleCharadesMVC.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HorribleCharadesMVC.Controllers
{
    public class PlayController : Controller
    {
        // GET: /<controller>/
        public IActionResult Main()
        {
            //var charade = DataManager.GetObject(RandomUtils.ReturnValue(0, 8));
            
            var charade = DataManager.CombinedWords();

            return View(charade);
        }
    }
}
