using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Grid_based_map
{
    class Enemy
    {
        public string Element = "", Name = "";
        public int Hp = 0, Atk = 0, Def = 0, Spd = 0, Crit = 0,Pos=0,TrueDef=0;
        public Image Sprite;
        public bool Defending=false,Fled=false;
        Random EnemyChoice = new Random();
        public Enemy(string FoeName,int FoeHp,int FoeAtk, int FoeDef, int FoeSpd, int FoeCrit,string FoeElement,int FoePos)
        {
            Name = FoeName;
            Hp = FoeHp;
            Atk = FoeAtk;
            Def = FoeDef;
            TrueDef = FoeDef;
            Spd = FoeSpd;
            Crit = FoeCrit;
            Element = FoeElement;
            Pos = FoePos;
            Sprite = Image.FromFile("../../../CombatData/EnemyData/Sprites/" + FoeName + ".gif");           
        }
        public int EnemyDecision()
        {
            int EC;
            EC = EnemyChoice.Next(0, 101);
            return EC;
        }
    }
}
