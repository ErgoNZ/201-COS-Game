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
        //Tuple(Hp,Atk,Def,Spd,Crit,Element,Position)
        List<Tuple<int,int,int,int,int,string,int>> CurrentEncounter = new List<Tuple<int,int,int,int,int,string,int>>();
        Random Roll = new Random();
        public void EncounterListSetup(int LevelData)
        {
            EncounterTable.Clear();
            EncounterData.Clear();
            using (StreamReader FileReader = new StreamReader("../../../CombatData/EncounterTables/" + LevelData + ".txt"))
            {
               string line;
               while ((line = FileReader.ReadLine()) != null)
               {
                 EncounterTable.Add(line);
               }
            }
         foreach(string FightData in EncounterTable)
         {
                using (StreamReader FileReader = new StreamReader("../../../CombatData/EncounterTables/" + FightData + ".txt"))
            {
                string line, Foe1="", Foe2="", Foe3="";
                double Tile=0;
                int count = 0;

                while ((line = FileReader.ReadLine()) != null)
                {
                    if (count == 4)
                    {
                        EncounterData.Add(new Tuple<double,string,string,string>(Tile,Foe1,Foe2,Foe3));
                    }
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
        }
        public void EncounterRoll(int TileData)
        {          
            SelEncounters.Clear();
            if (Roll.Next(0, 101) >= 90)
            {
                foreach(Tuple<double,string,string,string> tuple in EncounterData)
                {
                    if(TileData == tuple.Item1)
                    {
                        SelEncounters.Add(new Tuple<double, string, string, string>(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4));
                    }
                }
                    //Enemy data is read here from their files
                    int Index = Roll.Next(0,SelEncounters.Count+1);
                    //Tuple(Hp,Atk,Def,Spd,Crit,Element,Position)
                    using (StreamReader FileReader = new StreamReader("../../../CombatData/EnemyData/" + SelEncounters[Index].Item2 + ".txt"))
                    {
                        string line="",Element="";
                        int count=0, Hp,Atk,Def,Spd,Crit;
                        while ((line = FileReader.ReadLine()) != null)
                        {
                           if(count==0)
                           {
                            Hp = int.Parse(line);
                           }
                           if(count==1)
                           {
                            Atk = int.Parse(line);
                           }
                           if(count==2)
                           {
                            Def = int.Parse(line);
                           }
                           if(count==3)
                           {
                            Spd = int.Parse(line);
                           }
                           if(count==4)
                           {
                            Crit = int.Parse(line);
                           }
                           if(count==5)
                           {
                            Element = line;
                           }
                           if(count==6)
                           {
                            
                           }
                           if(count==7)
                           {
                            
                           }
                           count++;
                        }
                    }
                    using (StreamReader FileReader = new StreamReader("../../../CombatData/EnemyData/" + SelEncounters[Index].Item3 + ".txt"))
                    {
                        string line;
                        while ((line = FileReader.ReadLine()) != null)
                        {

                        }
                    }
                    using (StreamReader FileReader = new StreamReader("../../../CombatData/EnemyData/" + SelEncounters[Indexx].Item4 + ".txt"))
                    {
                        string line;
                        while ((line = FileReader.ReadLine()) != null)
                        {

                        }
                    }
            }
        }
    }
}
