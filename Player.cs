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
       public int PlayerX = -1, PlayerY = -1, PlayerXPos = 0, PlayerYPos = 0;
       public int Hp=1, Def=5, Spd=10, Atk=7, Lvl=1,MaxHp=20,Crit=3,Xp=0;
       public string Name="Player", AtkElement = "None";
       public List<string> DefElement = new List<string>();
       public void StatPrint()
        {
            Debug.WriteLine(Hp);
            Debug.WriteLine(MaxHp);
            Debug.WriteLine(Def);
            Debug.WriteLine(Spd);
            Debug.WriteLine(Atk);
            Debug.WriteLine(Lvl);
            Debug.WriteLine(Crit);
            Debug.WriteLine(Xp);
            Debug.WriteLine(AtkElement);
            Debug.WriteLine(DefElement);
        }
    }
}
