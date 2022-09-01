using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Drawing;

namespace Grid_based_map
{
    class MapData
    {
       //0= free movement 1= no movement 2= Cannot move left 3= Cannot move right 4= up 5= down
       //(x,0,0) is a visual indicator, (0,x,0) Repersents the player pos, (0,0,x) is the type of movemnt restriction the tile has.
       public double [,,] Tiles = new double[10, 10, 3];
       public int[,,] PlayerTiles = new int[10, 10, 2];
       public double[,,] ViewRange = new double[7, 7, 2];
       public int YLimit = 0, XLimit=0, LevelIndicator = 0;
       public List<Image> TileSprites = new List<Image>();
        public void LoadMap(string ReqMap)
        {
            TileSprites.Clear();
            try
            {
                int h = 0, w = 0;
                int LineNum = 0;
                // Read and display lines from the file until the end of the file is reached.
                using (StreamReader MapReader = new StreamReader("../../../Maps/"+ ReqMap + ".txt"))
                    {
                       string line;
                    while ((line = MapReader.ReadLine()) != null)
                    {
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
                        if (LineNum == 2)
                        {
                            LevelIndicator = int.Parse(line);
                        }
                        if (LineNum == 3)
                        {
                            for (int i = 1; i <= int.Parse(line); i++)
                            {
                                TileSprites.Add(Image.FromFile("../../../Maps/TileSprites/" + LevelIndicator + "_" +i+ ".png"));
                            }
                        }
                        if (LineNum >= 4)
                        {
                            if (line == "1")
                            {
                                Tiles[h, w, 0] = LevelIndicator + .1;
                                Tiles[h, w, 2] = 0;
                            }
                            if (line == "2")
                            {
                                Tiles[h, w, 0] = LevelIndicator + .2;
                                Tiles[h, w, 2] = 1;
                            }
                        }
                        if(LineNum>=4)
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
