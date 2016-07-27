using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorribleCharadesMVC.Models
{
    public class Game
    {
        public Game()
        {
            GenerateCode();
        }
        public List<Player> Teams { get; set; }
        public string Code { get; private set; }
        public void GenerateCode()
        {
            string newCode = "";
            for (int i = 0; i < 5; i++)
            {
                if (RandomUtils.ReturnValue(2) == 0) //50-50 om det blir en siffra eller bokstav
                {
                    int num = RandomUtils.ReturnValue(26);
                    char let = (Char)('A' + num);
                    newCode += let;
                }
                else
                {
                    string nr = Convert.ToString(RandomUtils.ReturnValue(10));
                    newCode += nr;
                }
            }

            Code = newCode;
        }

    }
}
