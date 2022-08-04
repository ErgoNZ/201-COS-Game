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
        Rectangle PlayerName = new Rectangle(25, 0, 250, 50),
                  PlayerLvl = new Rectangle(25, 40, 100, 50),
                  FilePlayTime = new Rectangle(150, 40, 150, 50),
                  vert = new Rectangle(150, 0, 1, 600),
                  Sec1 = new Rectangle(0, 0, 300, 100),
                  Sec2 = new Rectangle(0,100,300,125),
                  PlayerHp = new Rectangle(25,95,250,50),
                  PlayerAtk = new Rectangle(25,125,100,50),
                  PlayerDef = new Rectangle(25, 175, 100, 50),
                  PlayerSpd = new Rectangle(175, 125, 100, 50),
                  PlayerCrit = new Rectangle(175, 175, 100, 50),
                  Sec3 = new Rectangle(0,225,300,275),

                  Sec4 = new Rectangle(0,500,300,100)

                                                               ;
        int TileID = 0;
        public int tileX = 2, tileY = 2;
        bool CharOnScrn, cameraControl,InMenu;
        List<Tuple<Rectangle,Rectangle,string>> Items = new List<Tuple<Rectangle,Rectangle,string>>();

        Player Character = new Player();
        MapData Map = new MapData();
        Inventory Inv = new Inventory();
        Brush Grass = Brushes.Green;

        private void Item_Pnl_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            int count=0;
            foreach(Tuple<string, int, string, bool> tuple in Inv.CategoryData)
            {
                Items.Add(new Tuple<Rectangle,Rectangle,string>(new Rectangle (0,30*count,30,30), new Rectangle(30, 30 * count, 111, 30), tuple.Item1));
                count++;
            }
            foreach(Tuple<Rectangle,Rectangle,string> tuple in Items)
            {
                g.DrawRectangle(Pens.Black, tuple.Item1);
                g.DrawRectangle(Pens.Black, tuple.Item2);
                g.DrawString(tuple.Item3, General, Brushes.Black, tuple.Item2, Center);
              // Finish this! g.DrawImage(tuple.Item3 + ".png", tuple.Item1.X,tuple.Item1.Y);
            }
        }

        private void Key_btn_Click(object sender, EventArgs e)
        {
            Inv.Categorise("Key");
            Map_Pnl.Focus();
            Item_Pnl.Invalidate();
        }

        private void Item_btn_Click(object sender, EventArgs e)
        {
            Inv.Categorise("Item");
            Map_Pnl.Focus();
            Item_Pnl.Invalidate();
        }

        private void Gear_btn_Click(object sender, EventArgs e)
        {
            Inv.Categorise("Gear");
            Map_Pnl.Focus();
            Item_Pnl.Invalidate();
        }

        Brush Water = Brushes.Blue;
        Font General = new Font(FontFamily.GenericMonospace,16 ,FontStyle.Regular);
        StringFormat Center = new StringFormat();
        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, Map_Pnl, new object[] { true });
            Map.LoadMap("TestMap");
            Inv.AddItem("apple",6,"Item",false,"Apple");
            Inv.AddItem("appleX", 3, "Item", false,"Apple");
            Inv.DelItem("appleX", 3,"Item",false);
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
            g.FillRectangle(Brushes.SaddleBrown, Sec1);
            g.FillRectangle(Brushes.Brown, Sec2);
            g.FillRectangle(Brushes.RosyBrown, Sec3);
            g.FillRectangle(Brushes.SaddleBrown, Sec4);
            g.DrawString(Character.Name, General, Brushes.Black,PlayerName,Center);
            g.DrawString("LVL:" + Character.Lvl, General, Brushes.Black, PlayerLvl, Center);
            //Placeholder playtime display
            g.DrawString("PlayTime: 1:30:27" , General, Brushes.Black, FilePlayTime, Center);
            g.DrawString("Hp:"+Character.Hp+"/"+Character.MaxHp, General, Brushes.Black, PlayerHp, Center);
            g.DrawString("Atk:" + Character.Atk, General, Brushes.Black, PlayerAtk, Center);
            g.DrawString("Def:" + Character.Def, General, Brushes.Black, PlayerDef, Center);
            g.DrawString("Spd:" + Character.Spd, General, Brushes.Black, PlayerSpd, Center);
            g.DrawString("Crit:" + Character.Crit + "%", General, Brushes.Black, PlayerCrit, Center);
            g.FillRectangle(Grass, vert);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Map_Pnl.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Map_Pnl.Focus();
        }
    }
}
