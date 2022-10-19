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
        //(x,0,0,0,0) is a visual indicator, (0,x,0,0,0) Repersents the player pos, (0,0,x,0,0) is the type of movemnt restriction the tile has,
        //(0,0,0,x,0) is the id of the map the player will be moved to and (0,0,0,0,x) is where the player will be placed on that map.
        public double[,,] Tiles = new double[10, 10, 5];
        public int[,,] PlayerTiles = new int[10, 10, 2];
        public double[,,] ViewRange = new double[7, 7, 2];
        public int YLimit = 0, XLimit = 0, LevelIndicator = 0;
        public List<Image> TileSprites = new List<Image>();
        Random SpriteRandomizer = new Random();
        public void LoadMap(string ReqMap)
        {
            TileSprites.Clear();
            Array.Clear(Tiles, 0, Tiles.Length);
            try
            {
                int h = 0, w = 0;
                int LineNum = 0;              
                // Read and display lines from the file until the end of the file is reached.
                using (StreamReader MapReader = new StreamReader("../../../Maps/" + ReqMap + ".txt"))
                {
                    string line;
                    while ((line = MapReader.ReadLine()) != null)
                    {
                        if (LineNum == 0)
                        {
                            YLimit = int.Parse(line);
                        }
                        else if (LineNum == 1)
                        {
                            XLimit = int.Parse(line);
                            Tiles = new double[YLimit, XLimit, 5];
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
                                if (i == 1)
                                {
                                        TileSprites.Add(Image.FromFile("../../../Maps/TileSprites/" + LevelIndicator + "_1.png"));
                                        TileSprites.Add(Image.FromFile("../../../Maps/TileSprites/" + LevelIndicator + "_11.png"));
                                        TileSprites.Add(Image.FromFile("../../../Maps/TileSprites/" + LevelIndicator + "_12.png"));
                                        TileSprites.Add(Image.FromFile("../../../Maps/TileSprites/" + LevelIndicator + "_13.png"));
                                }
                                else
                                {
                                    try
                                    {
                                        TileSprites.Add(Image.FromFile("../../../Maps/TileSprites/" + LevelIndicator + "_" + i + ".png"));
                                    }
                                    catch (Exception)
                                    {
                                        TileSprites.Add(Image.FromFile("../../../Maps/TileSprites/ERROR_ERROR.png"));
                                    }
                                }
                            }
                        }
                        if (LineNum >= 4)
                        {
                            if (line == "1")
                            {
                                double Tileid = LevelIndicator + .1 + ((double)SpriteRandomizer.Next(0, 4) / (double)100);
                                Tiles[h, w, 0] = Math.Round(Tileid, 2);
                                Tiles[h, w, 2] = 0;
                            }
                            if (line == "2")
                            {
                                Tiles[h, w, 0] = LevelIndicator + .2;
                                Tiles[h, w, 2] = 1;
                            }
                            if (line == "3")
                            {
                                Tiles[h, w, 0] = LevelIndicator + .3;
                                Tiles[h, w, 2] = 1;
                            }
                            if (line == "4")
                            {
                                Tiles[h, w, 0] = LevelIndicator + .4;
                                Tiles[h, w, 2] = 0;
                            }
                            if (line == "5")
                            {
                                Tiles[h, w, 0] = LevelIndicator + .5;
                                Tiles[h, w, 2] = 0;
                            }
                            if (line.Contains("."))
                            {
                                //Sets up the required information for the tile to transport the player to another level or location
                                    string ZoneTransition = line.Substring(2, 3);
                                    string PlayerPlacement = line.Substring(5);
                                    Tiles[h, w, 0] = LevelIndicator + .4;
                                    Tiles[h, w, 2] = 0;
                                    Tiles[h, w, 3] = double.Parse(ZoneTransition);
                                    Tiles[h, w, 4] = double.Parse(PlayerPlacement);
                            }
                        }
                        if (LineNum >= 4)
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
            catch (Exception)
            {

            }
        }
    }
}
