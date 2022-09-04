using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Grid_based_map
{
    class Enemy
    {
        string Element = "", Name = "";
        int Hp = 0, Atk = 0, Def = 0, Spd = 0, Crit = 0,Pos=0;
        Image Sprite;
        public Enemy(string FoeName,int FoeHp,int FoeAtk, int FoeDef, int FoeSpd, int FoeCrit,string FoeElement,int FoePos)
        {
            Name = FoeName;
            Hp = FoeHp;
            Atk = FoeAtk;
            Def = FoeDef;
            Spd = FoeSpd;
            Crit = FoeCrit;
            Element = FoeElement;
            Pos = FoePos;
            Sprite = Image.FromFile("../../../CombatData/EnemyData/Sprites/" + FoeName + ".gif");
        }
    }
}
