using HorribleCharadesMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorribleCharadesMVC.Viewmodels.Play
{
    public class ScoreViewModel
    {
        public string GameCode { get; set; }
        public Team Team { get; set; }
        public int Id { get; set; }
    }
}
