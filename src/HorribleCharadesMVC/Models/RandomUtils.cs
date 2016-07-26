using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorribleCharadesMVC.Models
{
    public static class RandomUtils
    {
        static Random rnd = new Random();

        public static int ReturnValue(int upperBound)
        {
            return ReturnValue(0, upperBound);
            
        }
        public static int ReturnValue(int lower, int upperBound)
        {
            return rnd.Next(lower, upperBound);
        }
    }
}
