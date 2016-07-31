﻿using System;
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
            Teams = new List<Player>();
            Teams.Add(new Player { PlayerName = "Team1", PlayerId = 1});
            Teams.Add(new Player { PlayerName = "Team2", PlayerId = 2 });

        }
        public List<Player> Teams { get; set; }
        public string Code { get; private set; }
        public void GenerateCode()
            //Genererar en kod som användare skriver in för att komma in på samma spel
        {
            string newCode = "";
            for (int i = 0; i < 5; i++) //Antal tecken
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
