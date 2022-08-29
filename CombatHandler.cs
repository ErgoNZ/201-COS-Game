using System;
using System.Collections.Generic;
using System.Text;

namespace Grid_based_map
{
    class CombatHandler
    {
        Random Roll = new Random();
        public void EncounterRoll(int TileData, int LevelData)
        {
            if (Roll.Next(0, 101) >= 90)
            {

            }
        }
    }
}
