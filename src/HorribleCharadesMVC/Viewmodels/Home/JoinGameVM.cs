using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HorribleCharadesMVC.Viewmodels.Home
{
    public class JoinGameVM
    {
        [Display(Name = "GameCode")]
        [Required(ErrorMessage = "Please input GameCode")]
        public string GameCode { get; set; }
    }
}
