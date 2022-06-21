using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace Grid_based_map
{
    public partial class Form1 : Form
    { //Seting up all required variables for the game to function
        Graphics g;
        Rectangle[] Tile = new Rectangle[25];
        Rectangle Player;
        int TileID = 0;
        //0= free movement 1= no movement 2= Cannot move left 3= Cannot move right 4= up 5= down
        //(x,0,0) is a visual indicator, (0,x,0) Repersents the player pos, (0,0,x) is the type of movemnt restriction the tile has.
        int[,,] Tiles = new int[10, 10, 3]
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
        int[,,] PlayerTiles = new int[10, 10, 2];
        int[,,] ViewRange = new int[5, 5,2];
        int tileX=5, tileY=5;
        int PlayerX =-1, PlayerY=-1, PlayerXPos=0, PlayerYPos=0;
        bool CharOnScrn,cameraControl;
        Brush Grass = Brushes.Green;
        Brush Water = Brushes.Blue;
        Brush Unexplored = Brushes.DarkGray;
        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panel1, new object[] { true });
            DrawGrid();
        }

        public void DrawGrid()
        {
            //Remove the info for the player as it may not be needed
            Player = Rectangle.Empty;
            //Updating current player position
            Tiles[PlayerYPos, PlayerXPos, 1] = 1;
            //Removing all tiles currently on screen
            for (int i = 0; i < 25; i++)
            {
                Tile[i] = Rectangle.Empty;
            }
            TileID = 0;
            //setting up rectangles for grid
            for (int h = 0; h < 5; h++)
            {
                for (int w = 0; w < 5; w++)
                {
                    Tile[TileID] = new Rectangle(0 + (120 * w), 0 + (120 * h), 120, 120);
                    TileID++;
                }
            }
            //Storing all tile information that is in the cameras view range which is pulled from the Tiles array (The map info in other words)
            for (int Y = -2; Y < 3; Y++)
            {
                for (int X = -2; X < 3; X++)
                {
                    ViewRange[X+2, Y+2,0] = Tiles[tileY + X, tileX + Y, 0];
                    ViewRange[X + 2, Y + 2, 1] = Tiles[tileY + X, tileX + Y, 1];
                }
            }
            //Refresh the panel to show changes
            panel1.Invalidate();
        }

        public void CameraSnap()
        {
                tileX = PlayerXPos;
                tileY = PlayerYPos;
                if(tileX>7)
                {
                    tileX = 7;
                }
                if(tileX<2)
                {
                    tileX = 2;
                }
                if(tileY>7)
                {
                    tileY = 7;
                }
                if (tileY < 2)
                {
                    tileY = 2;
                }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            cameraControl = false;
            //Movement of the camera
            if (e.KeyData == Keys.Left && tileX>2)
            {
                tileX--;
                cameraControl = true;
            }
            if (e.KeyData == Keys.Right && tileX < 7)
            {
                tileX++;
                cameraControl = true;
            }
            if (e.KeyData == Keys.Up && tileY > 2)
            {
                tileY--;
                cameraControl = true;
            }
            if (e.KeyData == Keys.Down && tileY < 7)
            {
                tileY++;
                cameraControl = true;
            }
            //Movement of the player
            Tiles[PlayerYPos, PlayerXPos, 1] = 0;
            //0= free movement 1= no movement 2= Cannot move left 3= Cannot move right 4= up 5= down
            if(CharOnScrn== true)
            {
                if (e.KeyData == Keys.A && PlayerXPos > 0 && Tiles[PlayerYPos, PlayerXPos - 1, 2] != 1 && Tiles[PlayerYPos, PlayerXPos - 1, 2] != 2)
                {
                    PlayerXPos--;
                    cameraControl = false;
                    if (tileX > 2)
                    {
                        tileX--;
                    }
                }
                if (e.KeyData == Keys.D && PlayerXPos < 9 && Tiles[PlayerYPos, PlayerXPos + 1, 2] != 1 && Tiles[PlayerYPos, PlayerXPos + 1, 2] != 3)
                {
                    PlayerXPos++;
                    cameraControl = false;
                    if (tileX < 7)
                    {
                        tileX++;
                    }
                }
                if (e.KeyData == Keys.W && PlayerYPos > 0 && Tiles[PlayerYPos - 1, PlayerXPos, 2] != 1 && Tiles[PlayerYPos - 1, PlayerXPos, 2] != 4)
                {
                    PlayerYPos--;
                    cameraControl = false;
                    if (tileY > 2)
                    {
                        tileY--;
                    }
                }
                if (e.KeyData == Keys.S && PlayerYPos < 9 && Tiles[PlayerYPos + 1, PlayerXPos, 2] != 1 && Tiles[PlayerYPos + 1, PlayerXPos, 2] != 5)
                {
                    PlayerYPos++;
                    cameraControl = false;
                    if (tileY < 7)
                    {
                        tileY++;
                    }
                }
            }
            if (cameraControl == false)
            {
                CameraSnap();
            }
            else if(e.KeyData == Keys.C)
            {
                CameraSnap();
            }
            //Call the DrawGrid method to refresh the players current view and update any tiles as needed
            DrawGrid();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        { //removing the player from the screen so the position can be correctly updated
            PlayerX = -1;
            PlayerY = -1;
            CharOnScrn = false;
            g = e.Graphics;
            TileID = 0;
            //Colouring tiles based off their visual indicator
           for (int h = 0; h < 5; h++)
           {
               for (int w = 0; w < 5; w++)
               {
                   if (ViewRange[h,w,0]==1)
                   {
                       g.FillRectangle(Grass, Tile[TileID]);
                   }
                   else
                   {
                       g.FillRectangle(Water, Tile[TileID]);
                   }
                   //finding players position in relation to the cameras position
                   if(ViewRange[h,w,1]==1)
                    {
                        PlayerX = w;
                        PlayerY = h;
                        Player = new Rectangle(30 + 120 * PlayerX, 30 + 120 * PlayerY, 60, 60);
                        g.FillRectangle(Brushes.Red, Player);
                        CharOnScrn = true;
                    }
                   g.DrawRectangle(Pens.Black, Tile[TileID]);
                   TileID++;
               }
           }
        }
    }
}
