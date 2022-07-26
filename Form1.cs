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
        Rectangle PlayerName = new Rectangle(25, 12, 250, 50),
        PlayerLvl = new Rectangle(0,25,250,50)    
            ;
        int TileID = 0;
        public int tileX = 2, tileY = 2;
        bool CharOnScrn, cameraControl,InMenu;
        Player Character = new Player();
        MapData Map = new MapData();
        Inventory Inv = new Inventory();
        Brush Grass = Brushes.Green;
        Brush Water = Brushes.Blue;
        Font General = new Font(FontFamily.GenericMonospace,16 ,FontStyle.Regular);
        StringFormat Center = new StringFormat();
        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, Map_Pnl, new object[] { true });
            Info_Pnl.Invalidate();
            Map.LoadMap("TestMap");
            Inv.PrintInv();
            DrawGrid();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!InMenu)
            {
                cameraControl = false;
                //Movement of the camera
                if (e.KeyData == Keys.Left)
                {
                    if (tileX > 2)
                    {
                        tileX--;
                    }
                    cameraControl = true;
                }
                if (e.KeyData == Keys.Right)
                {
                    if (tileX < Map.XLimit - 3)
                    {
                        tileX++;
                    }
                    cameraControl = true;
                }
                if (e.KeyData == Keys.Up)
                {
                    if (tileY > 2)
                    {
                        tileY--;
                    }
                    cameraControl = true;
                }
                if (e.KeyData == Keys.Down)
                {
                    if (tileY < Map.YLimit - 3)
                    {
                        tileY++;
                    }
                    cameraControl = true;
                }
                //Movement of the player
                Map.Tiles[Character.PlayerYPos, Character.PlayerXPos, 1] = 0;
                //0= free movement 1= no movement 2= Cannot move left 3= Cannot move right 4= up 5= down
                if (CharOnScrn == true)
                {
                    if (e.KeyData == Keys.A && Character.PlayerXPos > 0 && Map.Tiles[Character.PlayerYPos, Character.PlayerXPos - 1, 2] != 1 && Map.Tiles[Character.PlayerYPos, Character.PlayerXPos - 1, 2] != 2)
                    {
                        Character.PlayerXPos--;
                        cameraControl = false;
                        if (tileX > 2)
                        {
                            tileX--;
                        }
                    }
                    if (e.KeyData == Keys.D && Character.PlayerXPos < Map.XLimit - 1 && Map.Tiles[Character.PlayerYPos, Character.PlayerXPos + 1, 2] != 1 && Map.Tiles[Character.PlayerYPos, Character.PlayerXPos + 1, 2] != 3)
                    {
                        Character.PlayerXPos++;
                        cameraControl = false;
                        if (tileX < Map.XLimit - 3)
                        {
                            tileX++;
                        }
                    }
                    if (e.KeyData == Keys.W && Character.PlayerYPos > 0 && Map.Tiles[Character.PlayerYPos - 1, Character.PlayerXPos, 2] != 1 && Map.Tiles[Character.PlayerYPos - 1, Character.PlayerXPos, 2] != 4)
                    {
                        Character.PlayerYPos--;
                        cameraControl = false;
                        if (tileY > 2)
                        {
                            tileY--;
                        }
                    }
                    if (e.KeyData == Keys.S && Character.PlayerYPos < Map.YLimit - 1 && Map.Tiles[Character.PlayerYPos + 1, Character.PlayerXPos, 2] != 1 && Map.Tiles[Character.PlayerYPos + 1, Character.PlayerXPos, 2] != 5)
                    {
                        Character.PlayerYPos++;
                        cameraControl = false;
                        if (tileY < Map.YLimit - 3)
                        {
                            tileY++;
                        }
                    }
                }
                if (cameraControl == false)
                {
                    CameraSnap();
                }
                else if (e.KeyData == Keys.C)
                {
                    CameraSnap();
                }

                if (e.KeyData == Keys.B)
                {
                    Inv.Sort("Alphebetical");
                    Inv.PrintInv();
                    Character.Name = "B";
                }
                if (e.KeyData == Keys.N)
                {
                    Inv.Sort("Amount");
                    Inv.PrintInv();
                    Character.Name = "N";
                }
                //Call the DrawGrid method to refresh the players current view and update any tiles as needed
                Info_Pnl.Invalidate();
                DrawGrid();
            }
            else
            {

            }

        }
        public void DrawGrid()
        {
            //Remove the info for the player as it may not be needed
            Character.Char = Rectangle.Empty;
            //Updating current player position
            Map.Tiles[Character.PlayerYPos, Character.PlayerXPos, 1] = 1;
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
                    Map.ViewRange[X + 2, Y + 2, 0] = Map.Tiles[tileY + X, tileX + Y, 0];
                    Map.ViewRange[X + 2, Y + 2, 1] = Map.Tiles[tileY + X, tileX + Y, 1];
                }
            }
            //Refresh the panel to show changes
            Map_Pnl.Invalidate();
        }

        public void CameraSnap()
        {
            tileX = Character.PlayerXPos;
            tileY = Character.PlayerYPos;
            if (tileX > Map.XLimit-3)
            {
                tileX = Map.XLimit-3;
            }
            if (tileX < 2)
            {
                tileX = 2;
            }
            if (tileY > Map.YLimit - 3)
            {
                tileY = Map.YLimit - 3;
            }
            if (tileY < 2)
            {
                tileY = 2;
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        { //removing the player from the screen so the position can be correctly updated
            Character.PlayerX = -1;
            Character.PlayerY = -1;
            CharOnScrn = false;
            g = e.Graphics;
            TileID = 0;
            //Colouring tiles based off their visual indicator
           for (int h = 0; h < 5; h++)
           {
               for (int w = 0; w < 5; w++)
               {
                   if (Map.ViewRange[h,w,0]==1)
                   {
                       g.FillRectangle(Grass, Tile[TileID]);
                   }
                   else if (Map.ViewRange[h, w, 0] == 2)
                    {
                       g.FillRectangle(Water, Tile[TileID]);
                   }
                   //finding players position in relation to the cameras position
                   if(Map.ViewRange[h,w,1]==1)
                    {
                        Character.PlayerX = w;
                        Character.PlayerY = h;
                        Character.Char = new Rectangle(30 + 120 * Character.PlayerX, 30 + 120 * Character.PlayerY, 60, 60);
                        g.FillRectangle(Brushes.Red, Character.Char);
                        CharOnScrn = true;
                    }
                   g.DrawRectangle(Pens.Black, Tile[TileID]);
                   TileID++;
               }
           }
        }
        private void Info_Pnl_Paint(object sender, PaintEventArgs e)
        {
            Center.Alignment = StringAlignment.Center;
            Center.LineAlignment= StringAlignment.Center;
            g = e.Graphics;
            g.DrawString(Character.Name, General, Brushes.Black,PlayerName,Center);
            g.DrawString("LVL: 3", General, Brushes.Black, PlayerLvl, Center);
        }
    }
}
