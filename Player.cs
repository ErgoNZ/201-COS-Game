using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Grid_based_map
{
    class Player
    {
       public Rectangle Char;
       public int PlayerX = -1, PlayerY = -1, PlayerXPos = 0, PlayerYPos = 0;
       public int Hp=1, Def=5, Spd=10, Atk=7, Lvl=1,MaxHp=20,Crit=3;
       public string Name="Player";
    }
}
