using System;
using System.Collections.Generic;
using System.IO;

namespace Grid_based_map
{
    class CombatHandler
    {
        List<string> EncounterTable = new List<string>();
        List<Tuple<double,string, string, string>> EncounterData = new List<Tuple<double,string, string, string>>();
        List<Tuple<double, string, string, string>> SelEncounters = new List<Tuple<double, string, string, string>>();
        Random Roll = new Random();
        public void EncounterListSetup(int LevelData)
        {
            using (StreamReader FileReader = new StreamReader("../../../CombatData/EncounterTables/" + LevelData + ".txt"))
            {
                string line, Foe1, Foe2, Foe3;
                double Tile;
                int count = 0;

                while ((line = FileReader.ReadLine()) != null)
                {
                    if (count == 0)
                    {
                        Tile = double.Parse(line);
                    }
                    if (count == 1)
                    {
                        Foe1 = line;
                    }
                    if (count == 2)
                    {
                        Foe2 = line;
                    }
                    if (count == 3)
                    {
                        Foe3 = line;
                    }
                    count++;
                }
            }
        }
        public void EncounterRoll(int TileData)
        {          
            if (Roll.Next(0, 101) >= 90)
            {
                foreach(Tuple<double,string,string,string> tuple in EncounterData)
                {
                    if(TileData == tuple.Item1)
                    {
                        SelEncounters.Add(new Tuple<double, string, string, string>(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4));
                    }
                }
                Roll.Next(0,SelEncounters.Count+1);
                
            }
        }
    }
}
