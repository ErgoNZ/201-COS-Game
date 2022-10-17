using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;
namespace Grid_based_map
{
    class Inventory
    {   // The tuple is set up like this Name, Amount of item, Item type, Equipabble?, ItemFile, Tuple(Hp,Atk,Def,Spd,Crit,Element?)Note:Nested tuple!,Equipped?
        //                               string,  int,          string,    Bool,        string          Multiple ints,      String                      bool
        public List<Tuple<Tuple<string, string>, int, string, bool, string, Tuple<int, int, int, int, int, string>, bool>> InvData = new List<Tuple<Tuple<string, string>, int, string, bool, string, Tuple<int, int, int, int, int, string>, bool>>();
        public List<Tuple<Tuple<string, string>, int, string, bool, string, Tuple<int, int, int, int, int, string>, bool>> CategoryData = new List<Tuple<Tuple<string, string>, int, string, bool, string, Tuple<int, int, int, int, int, string>, bool>>();
        public int CatergisedAmount;

        public void AddItem(int ItemAmount, string FileName, bool Equipped)
        {
            // sets up variables needed
            string ItemName = "", ItemType = "", Element = "", Description = "";
            bool Equipabble = false;
            int Hp = 0, Atk = 0, Def = 0, Spd = 0, Crit = 0;
            //Reads Item file for item data
            using (StreamReader ItemReader = new StreamReader("../../../Items/" + FileName + ".txt"))
            {
                string line;
                int LineNum = 0;
                while ((line = ItemReader.ReadLine()) != null)
                {
                    if (LineNum == 0)
                    {
                        ItemName = line;
                    }

                    if (LineNum == 1)
                    {
                        ItemType = line;
                    }

                    if (LineNum == 2)
                    {
                        Equipabble = bool.Parse(line);
                    }

                    if (LineNum == 3)
                    {
                        Hp = int.Parse(line);
                    }

                    if (LineNum == 4)
                    {
                        Atk = int.Parse(line);
                    }

                    if (LineNum == 5)
                    {
                        Def = int.Parse(line);
                    }

                    if (LineNum == 6)
                    {
                        Spd = int.Parse(line);
                    }

                    if (LineNum == 7)
                    {
                        Crit = int.Parse(line);
                    }

                    if (LineNum == 8)
                    {
                        Element = line;
                    }
                    if (LineNum == 9)
                    {
                        Description = line;
                    }
                    LineNum++;
                }
            }
            int Index = 0, InvCount = InvData.Count;
            //Checking if the player doesn't have any items in their inventory.
            if (InvData.Count == 0)
            {
                if (ItemAmount > 0)
                {
                    InvData.Add(new Tuple<Tuple<string, string>, int, string, bool, string, Tuple<int, int, int, int, int, string>, bool>(Tuple.Create(ItemName, Description), ItemAmount, ItemType, Equipabble, FileName, Tuple.Create(Hp, Atk, Def, Spd, Crit, Element), Equipped));
                }
            }
            else
            {
                //This checks all current items in the inventory and attempts to find if the item being added already exists
                //and instead increases it by the amount being added.
                foreach (Tuple<Tuple<string, string>, int, string, bool, string, Tuple<int, int, int, int, int, string>, bool> tuple in InvData)
                {
                    if (tuple.Item1.Item1 == ItemName && tuple.Item1.Item2 =="Item")
                    {
                        if (ItemAmount > 0)
                        {
                            InvData.Insert(Index, new Tuple<Tuple<string, string>, int, string, bool, string, Tuple<int, int, int, int, int, string>, bool>(Tuple.Create(ItemName, Description), ItemAmount + tuple.Item2, ItemType, Equipabble, FileName, Tuple.Create(Hp, Atk, Def, Spd, Crit, Element), Equipped));
                            //This just removes the leftover starting item entry from the inventory so only the new value shows.
                            InvData.RemoveAt(Index + 1);
                            break;
                        }
                    }
                    //if the item being added isn't already in the players inventory and the item amount isn't a negative number add it.
                    else if (Index == InvCount - 1)
                    {
                        if (ItemAmount > 0)
                        {
                            InvData.Add(new Tuple<Tuple<string, string>, int, string, bool, string, Tuple<int, int, int, int, int, string>, bool>(Tuple.Create(ItemName, Description), ItemAmount, ItemType, Equipabble, FileName, Tuple.Create(Hp, Atk, Def, Spd, Crit, Element), Equipped));
                        }
                        break;
                    }
                    Index++;
                }
            }
        }
        public void DelItem(int ItemAmount, string FileName, bool equipped)
        {
            //Sets up variables
            int Index = 0;
            string ItemName = "", ItemType = "", Element = "", Description = "";
            bool Equipabble = false;
            int Hp = 0, Atk = 0, Def = 0, Spd = 0, Crit = 0;
            //Finds item data
            using (StreamReader MapReader = new StreamReader("../../../Items/" + FileName + ".txt"))
            {
                string line;
                int LineNum = 0;
                while ((line = MapReader.ReadLine()) != null)
                {
                    if (LineNum == 0)
                    {
                        ItemName = line;
                    }

                    if (LineNum == 1)
                    {
                        ItemType = line;
                    }

                    if (LineNum == 2)
                    {
                        Equipabble = bool.Parse(line);
                    }

                    if (LineNum == 3)
                    {
                        Hp = int.Parse(line);
                    }

                    if (LineNum == 4)
                    {
                        Atk = int.Parse(line);
                    }

                    if (LineNum == 5)
                    {
                        Def = int.Parse(line);
                    }

                    if (LineNum == 6)
                    {
                        Spd = int.Parse(line);
                    }

                    if (LineNum == 7)
                    {
                        Crit = int.Parse(line);
                    }

                    if (LineNum == 8)
                    {
                        Element = line;
                    }

                    if (LineNum == 9)
                    {
                        Description = line;
                    }
                    LineNum++;
                }
            }
            //Finds the file in the inventory and deletes that amount of items from the inventory (Also makes sure that it cannot delete more items than what exists)
            foreach (Tuple<Tuple<string, string>, int, string, bool, string, Tuple<int, int, int, int, int, string>, bool> tuple in InvData)
            {
                if (tuple.Item1.Item1 == ItemName)
                {
                    if (ItemAmount > 0 && tuple.Item2 - ItemAmount >= 0)
                    {
                        if (tuple.Item2 - ItemAmount == 0)
                        {
                            InvData.RemoveAt(Index);
                            break;
                        }
                        else
                        {
                            InvData.Insert(Index, new Tuple<Tuple<string, string>, int, string, bool, string, Tuple<int, int, int, int, int, string>, bool>(Tuple.Create(ItemName, Description), tuple.Item2 - ItemAmount, ItemType, Equipabble, FileName, Tuple.Create(Hp, Atk, Def, Spd, Crit, Element), equipped));
                            //This just removes the leftover starting item entry from the inventory so only the new value shows.
                            InvData.RemoveAt(Index + 1);
                            break;
                        }
                    }
                }
                else
                {
                    Index++;
                }
            }
        }

        public void Categorise(string Category)
        {
            CategoryData.Clear();
            CatergisedAmount = 0;
            //This is how the inventory system knows what to display to the player when the category the player is currently looking at has benn switched (For example the player hits gear category all of the items in the gear category are selected are displayed)
            if (Category == "Gear")
            {
                foreach (Tuple<Tuple<string, string>, int, string, bool, string, Tuple<int, int, int, int, int, string>, bool> tuple in InvData)
                {
                    if (tuple.Item3 == "Weapon" && tuple.Item7 == false || tuple.Item3 == "Helmet" && tuple.Item7 == false || tuple.Item3 == "Chestplate" && tuple.Item7 == false || tuple.Item3 == "leggings" && tuple.Item7 == false || tuple.Item3 == "Boots" && tuple.Item7 == false)
                    {
                        CategoryData.Add(new Tuple<Tuple<string, string>, int, string, bool, string, Tuple<int, int, int, int, int, string>, bool>(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7));
                    }
                }
            }
            if (Category == "Item")
            {
                foreach (Tuple<Tuple<string, string>, int, string, bool, string, Tuple<int, int, int, int, int, string>, bool> tuple in InvData)
                {
                    if (tuple.Item3 == "Item" && tuple.Item7 == false)
                    {
                        CategoryData.Add(new Tuple<Tuple<string, string>, int, string, bool, string, Tuple<int, int, int, int, int, string>, bool>(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7));
                    }
                }
            }
            if (Category == "Key")
            {
                foreach (Tuple<Tuple<string, string>, int, string, bool, string, Tuple<int, int, int, int, int, string>, bool> tuple in InvData)
                {
                    if (tuple.Item3 == "Key" && tuple.Item7 == false)
                    {
                        CategoryData.Add(new Tuple<Tuple<string, string>, int, string, bool, string, Tuple<int, int, int, int, int, string>, bool>(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7));
                    }
                }
            }
            if (Category == "Equipped")
            {
                foreach (Tuple<Tuple<string, string>, int, string, bool, string, Tuple<int, int, int, int, int, string>, bool> tuple in InvData)
                {
                    if (tuple.Item7 == true)
                    {
                        CategoryData.Add(new Tuple<Tuple<string, string>, int, string, bool, string, Tuple<int, int, int, int, int, string>, bool>(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7));
                    }
                }
            }
        }
        //This is meant for debug purposes REMOVE LATER
        public void Sort(string SortBy)
        {
            //Sorts by amount of items
            if (SortBy == "Amount")
            {
                InvData.Sort((x, y) => y.Item2.CompareTo(x.Item2));
            }
            //Sorts by Alphebetical order of item names
            if (SortBy == "Alphebetical")
            {
                InvData.Sort();
            }
        }
        public void PrintInv()
        {
            //Debugging method to check current inventory
            foreach (Tuple<Tuple<string, string>, int, string, bool, string, Tuple<int, int, int, int, int, string>, bool> tuple in InvData)
            {
                Debug.WriteLine("Name:" + tuple.Item1);
                Debug.WriteLine("Amount:" + tuple.Item2);
                Debug.WriteLine("Type:" + tuple.Item3);
                Debug.WriteLine("Equipabble:" + tuple.Item4);
                Debug.WriteLine("FileName:" + tuple.Item5);
                Debug.WriteLine("Stats:" + tuple.Item6);
                Debug.WriteLine("Equipped:" + tuple.Item7);
            }
        }

    }
}
