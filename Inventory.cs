using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;
namespace Grid_based_map
{
    class Inventory
    {   // The tuple is set up like this Name, Amount of item, Item type, Equipabble?, Tuple(Hp,Atk,Def,Spd,Crit,Element?)Note:Nested tuple!
        //                               string,  int,          string,    Bool,             Multiple ints,      String
        //^^^ this is planned result once everything is up and running
        public List<Tuple<string, int,string,bool,string, Tuple<int, int, int, int, int, string>>> InvData = new List<Tuple<string, int,string,bool,string,Tuple<int,int,int,int,int,string>>>();
        public List<Tuple<string, int, string, bool,string, Tuple<int, int, int, int, int, string>>> CategoryData = new List<Tuple<string, int, string, bool,string, Tuple<int, int, int, int, int, string>>>();
        public int CatergisedAmount;

        public void AddItem(string ItemName, int ItemAmount, string ItemType, bool Equipabble, string FileName)
        {
            //string ItemType , Equipabble, ;
           // using (StreamReader MapReader = new StreamReader("../../../Items/" + FileName + ".txt"))
           // {
           //     string line;
           //     int LineNum;
           //     while ((line = MapReader.ReadLine()) != null)
           //     {
           //    
           //     }
           // }
                int Index = 0, InvCount= InvData.Count;
            //Checking if the player doesn't have any items in their inventory.
            if (InvData.Count==0)
            {
                if (ItemAmount > 0)
                {
                    InvData.Add(new Tuple<string, int,string,bool,string, Tuple<int, int, int, int, int, string>> (ItemName, ItemAmount,ItemType,Equipabble,FileName,Tuple.Create(1,1,1,1,1,"fire")));
                }
            }
            else
            {
                //This checks all current items in the inventory and attempts to find if the item being added already exists
                //and instead increases it by the amount being added.
                foreach (Tuple<string, int,string,bool,string, Tuple<int, int, int, int, int, string>> tuple in InvData)
                {
                    if (tuple.Item1 == ItemName)
                    {
                        if (ItemAmount > 0)
                        {
                            InvData.Insert(Index, new Tuple<string, int,string,bool,string, Tuple<int, int, int, int, int, string>>(ItemName, ItemAmount + tuple.Item2,ItemType,Equipabble,FileName, Tuple.Create(1, 1, 1, 1, 1, "fire")));
                            //This just removes the leftover starting item entry from the inventory so only the new value shows.
                            InvData.RemoveAt(Index + 1);
                            break;
                        }
                    }
                    //if the item being added isn't already in the players inventory and the item amount isn't a negative number add it.
                    else if(Index==InvCount-1)
                    {
                        if (ItemAmount > 0)
                        {
                            InvData.Add(new Tuple<string, int,string,bool,string, Tuple<int, int, int, int, int, string>>(ItemName, ItemAmount,ItemType,Equipabble,FileName, Tuple.Create(1, 1, 1, 1, 1, "fire")));
                        }
                        break;
                    }
                    Index++;
                }
            }        
        }
        public void DelItem(string ItemName, int ItemAmount, string ItemType, bool Equipabble, string FileName)
        {
            int Index = 0;
            foreach (Tuple<string, int,string,bool,string, Tuple<int, int, int, int, int, string>> tuple in InvData)
            {
                if (tuple.Item1 == ItemName)
                {                    
                    if (ItemAmount > 0 && tuple.Item2-ItemAmount >= 0)
                    {
                        if (tuple.Item2 - ItemAmount == 0)
                        {
                            InvData.RemoveAt(Index);
                            break;
                        }
                        else
                        {
                            InvData.Insert(Index, new Tuple<string, int,string,bool,string, Tuple<int, int, int, int, int, string>>(ItemName, tuple.Item2 - ItemAmount,ItemType,Equipabble,FileName, Tuple.Create(1, 1, 1, 1, 1, "fire")));
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
            if(Category == "Gear")
            {
                foreach (Tuple<string, int, string, bool,string, Tuple<int, int, int, int, int, string>> tuple in InvData)
                {
                    if(tuple.Item3 == "Weapon" || tuple.Item3 == "Helmet" || tuple.Item3 == "Chestplate" || tuple.Item3 == "leggings"|| tuple.Item3 == "Boots")
                    {
                        CategoryData.Add(new Tuple<string, int, string, bool,string, Tuple<int, int, int, int, int, string>>(tuple.Item1,tuple.Item2,tuple.Item3,tuple.Item4,tuple.Item5,tuple.Item6));
                    }
                }
            }
            if(Category == "Item")
            {
                foreach (Tuple<string, int, string, bool,string, Tuple<int, int, int, int, int, string>> tuple in InvData)
                {
                    if (tuple.Item3 == "Item")
                    {
                        CategoryData.Add(new Tuple<string, int, string, bool,string, Tuple<int, int, int, int, int, string>>(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4,tuple.Item5,tuple.Item6));
                    }
                }
            }
            if (Category == "Key")
            {
                foreach (Tuple<string, int, string, bool, string, Tuple<int, int, int, int, int, string>> tuple in InvData)
                {
                    if (tuple.Item3 == "Key")
                    {
                        CategoryData.Add(new Tuple<string, int, string, bool, string, Tuple<int, int, int, int, int, string>>(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5,tuple.Item6));
                    }
                }
            }
        }
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
            foreach (Tuple<string, int,string,bool,string, Tuple<int, int, int, int, int, string>> tuple in InvData)
            {
                Debug.WriteLine("Name:"+tuple.Item1);
                Debug.WriteLine("Amount:" + tuple.Item2);
                Debug.WriteLine("Type:" + tuple.Item3);
                Debug.WriteLine("Equipabble:" + tuple.Item4);
            }
        }
    }
}
