﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace Grid_based_map
{
    class EncounterHandler
    {
        List<string> EncounterTable = new List<string>();
        List<Tuple<double, string, string, string>> EncounterData = new List<Tuple<double, string, string, string>>();
        List<Tuple<double, string, string, string>> SelEncounters = new List<Tuple<double, string, string, string>>();
        //Tuple(Name,Hp,Atk,Def,Spd,Crit,Element,Position)
        public List<Tuple<string, int, int, int, int, int, string, Tuple<int>>> CurrentEncounter = new List<Tuple<string, int, int, int, int, int, string, Tuple<int>>>();
        Random Roll = new Random();
        public bool Infight;
        //Resets everything back to the default state
        public void Reset()
        {
            EncounterTable = new List<string>();
            EncounterData = new List<Tuple<double, string, string, string>>();
            SelEncounters = new List<Tuple<double, string, string, string>>();
            //Tuple(Name,Hp,Atk,Def,Spd,Crit,Element,Position)
            CurrentEncounter = new List<Tuple<string, int, int, int, int, int, string, Tuple<int>>>();
            Roll = new Random();
            Infight = false;
        }
        //This sets up all of the possible encounters for the level that is currently loaded
        public void EncounterListSetup(int LevelData)
        {
            EncounterTable.Clear();
            EncounterData.Clear();
            using (StreamReader FileReader = new StreamReader("../../../CombatData/EncounterTables/" + LevelData + ".txt"))
            {
                //Adds all lines from the file into a list to be read from to get encounter data from txt files
                string line;
                while ((line = FileReader.ReadLine()) != null)
                {
                    EncounterTable.Add(line);
                }
            }
            foreach (string FightData in EncounterTable)
            {
                //Reads txt files to find which enemies will be a part of the encounter
                using (StreamReader FileReader = new StreamReader("../../../CombatData/Encounters/" + FightData + ".txt"))
                {
                    string line, Foe1 = "", Foe2 = "", Foe3 = "";
                    int level = 0;
                    int count = 0;

                    while ((line = FileReader.ReadLine()) != null)
                    {
                        if (count == 0)
                        {
                            level = int.Parse(line);
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
                            EncounterData.Add(new Tuple<double, string, string, string>(level, Foe1, Foe2, Foe3));
                        }
                        count++;
                    }
                }
            }
        }
        //This method is to force a customised encounter
        public void SetEncounter(string Foe,string Foe2,string Foe3)
        {
            CurrentEncounter.Clear();
            Infight = true;
            if (Foe != null || Foe != "None")
            {
                using (StreamReader FileReader = new StreamReader("../../../CombatData/EnemyData/" + Foe + ".txt"))
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
            if (Foe2 != null || Foe2 != "None")
            {
                using (StreamReader FileReader = new StreamReader("../../../CombatData/EnemyData/" + Foe2 + ".txt"))
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
            if (Foe3 != null || Foe3 != "None")
            {
                using (StreamReader FileReader = new StreamReader("../../../CombatData/EnemyData/" + Foe3 + ".txt"))
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
        }
        public void EncounterRoll(int TileData)
        {
            //Resets the current encounter
            SelEncounters.Clear();
            if (Roll.Next(0, 101) >= 97)
            {
                foreach (Tuple<double, string, string, string> tuple in EncounterData)
                {
                    if (TileData == tuple.Item1)
                    {
                        SelEncounters.Add(new Tuple<double, string, string, string>(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4));
                    }
                }
                //Enemy data is read here from their files
                int Index = Roll.Next(0, SelEncounters.Count);
                //Tuple(Hp,Atk,Def,Spd,Crit,Element,Position)
                if ( SelEncounters[Index].Item2 != "None")
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
                if (SelEncounters[Index].Item3 != "None")
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
                if (SelEncounters[Index].Item4 != "None")
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
                    SelEncounters = new List<Tuple<double, string, string, string>>();
                }
                Infight = true;
            }
        }       
    }
}
