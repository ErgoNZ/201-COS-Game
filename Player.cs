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
        public int PlayerX = -1, PlayerY = -1, PlayerXPos = 20, PlayerYPos = 22;
        public int Hp = 30, Def = 0, Spd = 5, Atk = 5, Lvl = 1, MaxHp = 30, Crit = 2, Xp = 0, TrueDef=2;
        public string Name = "Player", AtkElement = "None";
        public bool WeaponEquipped, HelmetEquipped, ChestplateEquipped, LeggingsEquipped, BootsEquipped;
        public List<string> DefElement = new List<string>();
        List<Tuple<int, int>> XpReq = new List<Tuple<int, int>>
        {
            new Tuple<int, int>(1,5),
            new Tuple<int, int>(2,15),
            new Tuple<int, int>(3,30),
            new Tuple<int, int>(4,60),
            new Tuple<int, int>(5,80),
            new Tuple<int, int>(6,100),
            new Tuple<int, int>(7,130),
            new Tuple<int, int>(8,175),
            new Tuple<int, int>(9,250),
            new Tuple<int, int>(10,400),
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
