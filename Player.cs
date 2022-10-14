using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace Grid_based_map
{
    class Player
    {
        public Rectangle Char;
        Random StatIncrease = new Random();
        public int PlayerX = -1, PlayerY = -1, PlayerXPos = 15, PlayerYPos = 13;
        public int Hp = 25, Def = 0, Spd = 5, Atk = 99, Lvl = 1, MaxHp = 25, Crit = 2, Xp = 0, TrueDef=2;
        public string Name = "Player", AtkElement = "None";
        public bool WeaponEquipped, HelmetEquipped, ChestplateEquipped, LeggingsEquipped, BootsEquipped;
        public List<string> DefElement = new List<string>();
        List<Tuple<int, int>> XpReq = new List<Tuple<int, int>>
        {
            new Tuple<int, int>(1,25),
            new Tuple<int, int>(2,75),
            new Tuple<int, int>(3,150),
            new Tuple<int, int>(4,250),
            new Tuple<int, int>(5,375),
            new Tuple<int, int>(6,500),
            new Tuple<int, int>(7,750),
            new Tuple<int, int>(8,1250),
            new Tuple<int, int>(9,1750),
            new Tuple<int, int>(10,2500),
        };
        public void XpCheck()
        {
            if(Xp >= XpReq[Lvl-1].Item2)
            {
                Lvl++;
                TrueDef += StatIncrease.Next(1, 3);
                MaxHp += StatIncrease.Next(4, 7);
                Spd += StatIncrease.Next(2, 4);
                Atk += StatIncrease.Next(2, 4);
                Crit += StatIncrease.Next(0, 2);
            }
        }
    }
}
