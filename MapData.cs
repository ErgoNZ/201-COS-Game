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
        public int[,,] Tiles = new int[10, 10, 3]
            {
                { {1,0,0},{1,0,0},{2,0,1},{2,0,1},{2,0,1}, {2,0,1},{2,0,0},{2,0,1},{2,0,1},{2,0,1}  },
                { {1,0,0},{1,0,0},{1,0,0},{2,0,1},{2,0,1}, {2,0,0},{2,0,0},{1,0,0},{2,0,1},{2,0,1}  },
                { {1,0,0},{2,0,1},{1,0,0},{2,0,1},{2,0,1}, {1,0,0},{2,0,0},{1,0,0},{2,0,1},{2,0,1}  },
                { {1,0,0},{1,0,0},{1,0,0},{1,0,0},{2,0,1}, {1,0,0},{1,0,0},{1,0,0},{1,0,0},{2,0,1}  },
                { {1,0,0},{1,0,0},{1,0,0},{1,0,0},{1,0,0}, {1,0,0},{1,0,0},{1,0,0},{1,0,0},{1,0,0}  },
                { {2,0,1},{2,0,1},{2,0,1},{2,0,1},{1,0,0}, {2,0,1},{2,0,1},{2,0,1},{2,0,1},{2,0,1}  },
                { {2,0,1},{2,0,1},{1,0,0},{2,0,0},{1,0,0}, {2,0,1},{2,0,1},{1,0,0},{2,0,1},{2,0,1}  },
                { {1,0,0},{2,0,1},{1,0,0},{2,0,0},{1,0,0}, {1,0,0},{2,0,1},{1,0,0},{2,0,1},{2,0,1}  },
                { {1,0,0},{1,0,0},{1,0,0},{1,0,0},{1,0,0}, {1,0,0},{1,0,0},{1,0,0},{1,0,0},{2,0,1}  },
                { {1,0,0},{1,0,0},{1,0,0},{1,0,0},{1,0,0}, {1,0,0},{1,0,0},{1,0,0},{1,0,0},{1,0,0}  }
            };
       public int[,,] PlayerTiles = new int[10, 10, 2];
       public int[,,] ViewRange = new int[5, 5, 2];
        int TileID;

        public void LoadMap()
        {
            try
            {
                TileID = 0;
                int LineNum = 0;
                int Y, X;
                using (StreamReader MapReader = new StreamReader("TestMap.txt"))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = MapReader.ReadLine()) != null)
                    {
                        if(LineNum<1){
                            Y = int.Parse(line);
                            LineNum++;
                        }
                        else if (LineNum<2)
                        {
                            X = int.Parse(line);
                            LineNum++;
                        }
                        else
                        {
                            Tiles = new int[10, 10, 3];
                            for (int h = 0; h < 5; h++)
                            {
                                for (int w = 0; w < 5; w++)
                                {
                                    if (line == "1")
                                    {
                                        Tiles[h, w, 0] = 0;
                                        Tiles[h, w, 2] = 0;
                                    }
                                    if (line =="2")
                                    {
                                        Tiles[h, w, 0] = 1;
                                        Tiles[h, w, 2] = 1;
                                    }
                                    TileID++;
                                }
                            }

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
