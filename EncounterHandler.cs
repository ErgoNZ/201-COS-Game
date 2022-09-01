using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace Grid_based_map
{
    class EncounterHandler
    {
        List<string> EncounterTable = new List<string>();
        List<Tuple<double,string, string, string>> EncounterData = new List<Tuple<double,string, string, string>>();
        List<Tuple<double, string, string, string>> SelEncounters = new List<Tuple<double, string, string, string>>();
        //Tuple(Hp,Atk,Def,Spd,Crit,Element,Position)
        List<Tuple<string,int,int,int,int,int,string,Tuple<int>>> CurrentEncounter = new List<Tuple<string,int,int,int,int,int,string,Tuple<int>>>();
        Random Roll = new Random();
        public bool Infight;
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
                    Debug.WriteLine(line);
               }
            }
         foreach(string FightData in EncounterTable)
         {
                using (StreamReader FileReader = new StreamReader("../../../CombatData/Encounters/" + FightData + ".txt"))
            {
                string line, Foe1="", Foe2="", Foe3="";
                double Tile=0;
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
                        EncounterData.Add(new Tuple<double, string, string, string>(Tile, Foe1, Foe2, Foe3));
                    }
                    count++;
                }
            }
         }
        }
        public void EncounterRoll(double TileData)
        {          
            SelEncounters.Clear();
            if (Roll.Next(0, 101) >= 95)
            {
                foreach(Tuple<double,string,string,string> tuple in EncounterData)
                {
                    if(TileData == tuple.Item1)
                    {
                        SelEncounters.Add(new Tuple<double, string, string, string>(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4));
                    }
                }
                    //Enemy data is read here from their files
                    int Index = Roll.Next(0,SelEncounters.Count);
                    //Tuple(Hp,Atk,Def,Spd,Crit,Element,Position)
                    if(SelEncounters[Index].Item2 != null || SelEncounters[Index].Item2 != "None")
                {
                    using (StreamReader FileReader = new StreamReader("../../../CombatData/EnemyData/" + SelEncounters[Index].Item2 + ".txt"))
                    {
                        string line = "", Element = "", Name = "";
                        int count = 0, Hp = 0, Atk = 0, Def = 0, Spd = 0, Crit = 0, Position = 0;
                        while ((line = FileReader.ReadLine()) != null)
                        {
                            if (count == 0)
                            {
                                Name = line;
                            }
                            if (count == 1)
                            {
                                Hp = int.Parse(line);
                            }
                            if (count == 2)
                            {
                                Atk = int.Parse(line);
                            }
                            if (count == 3)
                            {
                                Def = int.Parse(line);
                            }
                            if (count == 4)
                            {
                                Spd = int.Parse(line);
                            }
                            if (count == 5)
                            {
                                Crit = int.Parse(line);
                            }
                            if (count == 6)
                            {
                                Element = line;
                                Position = 1;
                                CurrentEncounter.Add(new Tuple<string, int, int, int, int, int, string, Tuple<int>>(Name, Hp, Atk, Def, Spd, Crit, Element, Tuple.Create<int>(Position)));
                            }
                            count++;
                        }
                    }
                }                   
                    if(SelEncounters[Index].Item3 != "None")
                {
                    using (StreamReader FileReader = new StreamReader("../../../CombatData/EnemyData/" + SelEncounters[Index].Item3 + ".txt"))
                    {
                        string line = "", Element = "", Name = "";
                        int count = 0, Hp = 0, Atk = 0, Def = 0, Spd = 0, Crit = 0, Position = 0;
                        while ((line = FileReader.ReadLine()) != null)
                        {
                            if (count == 0)
                            {
                                Name = line;
                            }
                            if (count == 1)
                            {
                                Hp = int.Parse(line);
                            }
                            if (count == 2)
                            {
                                Atk = int.Parse(line);
                            }
                            if (count == 3)
                            {
                                Def = int.Parse(line);
                            }
                            if (count == 4)
                            {
                                Spd = int.Parse(line);
                            }
                            if (count == 5)
                            {
                                Crit = int.Parse(line);
                            }
                            if (count == 6)
                            {
                                Element = line;
                                Position = 2;
                                CurrentEncounter.Add(new Tuple<string, int, int, int, int, int, string, Tuple<int>>(Name, Hp, Atk, Def, Spd, Crit, Element, Tuple.Create<int>(Position)));
                            }
                            count++;
                        }
                    }
                }
                if (SelEncounters[Index].Item4 != null || SelEncounters[Index].Item4 !="None")
                {
                    using (StreamReader FileReader = new StreamReader("../../../CombatData/EnemyData/" + SelEncounters[Index].Item4 + ".txt"))
                    {
                        string line = "", Element = "", Name = "";
                        int count = 0, Hp = 0, Atk = 0, Def = 0, Spd = 0, Crit = 0, Position = 0;
                        while ((line = FileReader.ReadLine()) != null)
                        {
                            if (count == 0)
                            {
                                Name = line;
                            }
                            if (count == 1)
                            {
                                Hp = int.Parse(line);
                            }
                            if (count == 2)
                            {
                                Atk = int.Parse(line);
                            }
                            if (count == 3)
                            {
                                Def = int.Parse(line);
                            }
                            if (count == 4)
                            {
                                Spd = int.Parse(line);
                            }
                            if (count == 5)
                            {
                                Crit = int.Parse(line);
                            }
                            if (count == 6)
                            {
                                Element = line;
                                Position = 3;
                                CurrentEncounter.Add(new Tuple<string, int, int, int, int, int, string, Tuple<int>>(Name, Hp, Atk, Def, Spd, Crit, Element, Tuple.Create<int>(Position)));
                            }
                            count++;
                        }
                    }
                    
                    foreach (Tuple<string,int, int, int, int, int, string, Tuple<int>> tuple in CurrentEncounter)
                    {
                        Debug.WriteLine("Name:" + tuple.Item1);
                        Debug.WriteLine("Hp:"+tuple.Item2);
                        Debug.WriteLine("Atk:"+tuple.Item3);
                        Debug.WriteLine("Def:"+tuple.Item4);
                        Debug.WriteLine("Spd:"+tuple.Item5);
                        Debug.WriteLine("Crit:"+tuple.Item6);
                        Debug.WriteLine("ElementAtk:"+tuple.Item7);
                        Debug.WriteLine("Pos:"+tuple.Rest);
                    }
                }
                Infight = true;
            }
        }
    }
}
