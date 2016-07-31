using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HorribleCharadesMVC.Models
{
    public class Team
    {
        [Required(ErrorMessage = "Enter a player name")]
        public string TeamName { get; set; }

        public int TeamId { get; set; }

        public string charadeGuess { get; set; }

        public int Points { get; set; }

        public double GuessTime { get; set; }

    }
}
