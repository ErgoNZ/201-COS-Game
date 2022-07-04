using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Grid_based_map
{
    class MapData
    {
        //0= free movement 1= no movement 2= Cannot move left 3= Cannot move right 4= up 5= down
        //(x,0,0) is a visual indicator, (0,x,0) Repersents the player pos, (0,0,x) is the type of movemnt restriction the tile has.
       public int [,,] Tiles = new int[10, 10, 3];
       public int[,,] PlayerTiles = new int[10, 10, 2];
       public int[,,] ViewRange = new int[5, 5, 2];
       public int YLimit = 0, XLimit=0;
        public void LoadMap()
        {
            try
            {
                int h = 0, w = 0;
                int LineNum = 0;
                // Read and display lines from the file until the end of
                // the file is reached.
                using (StreamReader MapReader = new StreamReader("../../../TestMap.txt"))
                    {
                       string line;
                    while ((line = MapReader.ReadLine()) != null)
                    {
                        Debug.WriteLine(h+","+w);
                        if(LineNum == 0)
                        {
                            YLimit = int.Parse(line);
                        }
                        else if (LineNum == 1)
                        {
                           XLimit = int.Parse(line);
                        }
                        if (h == YLimit)
                        {
                            h = 0;
                            w++;
                        }
                        if (LineNum >= 3)
                        {
                            if (line == "1")
                            {
                                Tiles[h, w, 0] = 1;
                                Tiles[h, w, 2] = 0;
                            }
                            if (line == "2")
                            {
                                Tiles[h, w, 0] = 2;
                                Tiles[h, w, 2] = 1;
                            }
                        }
                        if(LineNum>2)
                        {
                            h++;
                        }
                        else
                        {
                            LineNum++;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex);            
            }
        }
    }
}
