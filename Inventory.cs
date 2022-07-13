using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
namespace Grid_based_map
{
    class Inventory
    {
        public List<Tuple<string, int>> InvData = new List<Tuple<string, int>>();

        public void AddItem(string ItemName, int ItemAmount)
        {
            int Index = 0, InvCount= InvData.Count;
            Debug.WriteLine(InvData.Count);
            if (InvData.Count==0)
            {
                InvData.Add(new Tuple<string, int>(ItemName, ItemAmount));
            }
            else
            {
                foreach (Tuple<string, int> tuple in InvData)
                {
                    if (tuple.Item1 == ItemName)
                    {
                        InvData.Insert(Index, new Tuple<string, int>(ItemName, ItemAmount + tuple.Item2));
                        InvData.RemoveAt(Index + 1);
                        break;
                    }
                    else if(Index==InvCount-1)
                    {
                        if (ItemAmount! >= 0)
                        {
                           InvData.Add(new Tuple<string, int>(ItemName, ItemAmount));
                        }
                        break;
                    }
                    Index++;
                    Debug.WriteLine(Index);
                    
                }
            }        
        }
        public void Sort(string SortBy)
        {
            if (SortBy == "Amount")
            {
               InvData.Sort((x, y) => y.Item2.CompareTo(x.Item2));       
            }

            if (SortBy == "Alphebetical")
            {
                InvData.Sort();
            }
        }
        public void PrintInv()
        {
            foreach (Tuple<string, int> tuple in InvData)
            {
                Debug.WriteLine("Name:"+tuple.Item1);
                Debug.WriteLine("Amount:" + tuple.Item2);
            }
        }
    }
}
