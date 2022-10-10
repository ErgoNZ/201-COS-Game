using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Grid_based_map
{
    class LootHandler
    {
        //   ItemFile Lowest value/Highest value  Lowest amount/Highest amount
        //           When rolling for item chance/When rolling for how many of that item
        List<Tuple<string, int, int, int, int>> LootTableData = new List<Tuple<string, int, int, int, int>>();
        Random Roll = new Random();
        Random Amount = new Random();
        public int AmountGained, XPGained;
        public string Item;
        //Sorts all of the data from a txt file into a list that can be used as a proper LootTable
        public void GetLootTable(string LootTable)
        {
            int count = 0, ChanceMin = 0, ChanceMax = 0, AmountMin = 0, AmountMax = 0;
            string line, Filename = "";

            using (StreamReader LootReader = new StreamReader("../../../LootTables/" + LootTable + ".txt"))
            {
                while ((line = LootReader.ReadLine()) != null)
                {
                    if (count == 5)
                    {
                        count = 0;
                    }
                    if (count == 0)
                    {
                        Filename = line;
                    }
                    if (count == 1)
                    {
                        ChanceMin = int.Parse(line);
                    }
                    if (count == 2)
                    {
                        ChanceMax = int.Parse(line);
                    }
                    if (count == 3)
                    {
                        AmountMin = int.Parse(line);
                    }
                    if (count == 4)
                    {
                        AmountMax = int.Parse(line);
                        LootTableData.Add(new Tuple<string, int, int, int, int>(Filename, ChanceMin, ChanceMax, AmountMin, AmountMax));
                    }
                    count++;
                }
            }
        }
        //This rolls the table to see what item and how much the player will get of that item
        public void RollTable()
        {
            int Rolled = Roll.Next(0, 101);
            AmountGained = 0;
            Item = "";
            foreach (Tuple<string, int, int, int, int> tuple in LootTableData)
            {
                if (tuple.Item2 <= Rolled && tuple.Item3 >= Rolled && tuple.Item1 != "XP")
                {
                    Item = tuple.Item1;
                    AmountGained = Amount.Next(tuple.Item4, tuple.Item5 + 1);
                }
                else if (tuple.Item1 == "XP")
                {
                    XPGained = Amount.Next(tuple.Item4, tuple.Item5 + 1);
                }
            }
        }
        public void PrintLootTable()
        {
            foreach (Tuple<string, int, int, int, int> tuple in LootTableData)
            {
                Debug.WriteLine("FileName:" + tuple.Item1);
                Debug.WriteLine("MinChance:" + tuple.Item2);
                Debug.WriteLine("MaxChance:" + tuple.Item3);
                Debug.WriteLine("MinAmount:" + tuple.Item4);
                Debug.WriteLine("MaxAmount:" + tuple.Item5);
            }
        }
    }
}
