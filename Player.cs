using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace Grid_based_map
{
    class Player
    {
        //Variable set up
        public Rectangle Char;
        Random StatIncrease = new Random();
        public int PlayerX = -1, PlayerY = -1, PlayerXPos = 20, PlayerYPos = 22;
        public int Hp = 30, Def = 0, Spd = 5, Atk = 3, Lvl = 1, MaxHp = 30, Crit = 2, Xp = 0, TrueDef = 1;
        public string Name = "Player", AtkElement = "None";
        public bool WeaponEquipped, HelmetEquipped, ChestplateEquipped, LeggingsEquipped, BootsEquipped;
        //Xp requirements for every level
        List<Tuple<int, int>> XpReq = new List<Tuple<int, int>>
        {
            new Tuple<int, int>(1,15),
            new Tuple<int, int>(2,45),
            new Tuple<int, int>(3,100),
            new Tuple<int, int>(4,160),
            new Tuple<int, int>(5,250),
            new Tuple<int, int>(6,500),
            new Tuple<int, int>(7,750),
            new Tuple<int, int>(8,1250),
            new Tuple<int, int>(9,2500),
            new Tuple<int, int>(10,5000),
        };
        //Resets everything back to the default state 
        public void Reset()
        {
            PlayerX = -1; PlayerY = -1; PlayerXPos = 20; PlayerYPos = 22;
            Hp = 30; Def = 0; Spd = 5; Atk = 3; Lvl = 1; MaxHp = 30; Crit = 2; Xp = 0; TrueDef = 1;
            Name = "Player"; AtkElement = "None";
            WeaponEquipped = false;
            HelmetEquipped = false;
            ChestplateEquipped = false;
            LeggingsEquipped = false;
            BootsEquipped = false;
        }
        //Compares the players Xp and increases the players stats by random amounts when the player Xp exceeds the current Xp requirement
        public void XpCheck()
        {
            if (Xp >= XpReq[Lvl - 1].Item2)
            {
                Lvl++;
                TrueDef += StatIncrease.Next(1, 2);
                MaxHp += StatIncrease.Next(5, 7);
                Spd += StatIncrease.Next(1, 3);
                Atk += StatIncrease.Next(1, 3);
                Crit += StatIncrease.Next(0, 2);
            }
        }
    }
}
