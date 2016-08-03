using HorribleCharadesMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorribleCharadesMVC.Viewmodels.Play
{
    public class StandingVM
    {
        public string GameCode { get; set; }
        public List<Team> Teams { get; set; }
    }
}
