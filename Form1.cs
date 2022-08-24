using System;
using System.IO;
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
    { //Seting up all required variables/objects for the game to function
        Graphics g;
        Rectangle[] Tile = new Rectangle[49];
        Rectangle PlayerName = new Rectangle(88, 0, 250, 50),
                  PlayerLvl = new Rectangle(52, 40, 100, 50),
                  FilePlayTime = new Rectangle(255, 40, 150, 50),
                  Sec1 = new Rectangle(0, 0, 432, 100),
                  Sec2 = new Rectangle(0,100,432,125),
                  PlayerHp = new Rectangle(88,95,250,50),
                  PlayerAtk = new Rectangle(52,125,100,50),
                  PlayerDef = new Rectangle(52, 175, 100, 50),
                  PlayerSpd = new Rectangle(280, 125, 100, 50),
                  PlayerCrit = new Rectangle(280, 175, 100, 50),
                  Sec4 = new Rectangle(0,500,300,100),
                  ItemImage = new Rectangle(0,0,100,100),
                  ItemDesc = new Rectangle(100,0,258,195),
                  ItemStats = new Rectangle(0,101,100,100)

                                                               ;
        int TileID = 0, Selected_Item = -1;
        public int tileX = 3, tileY = 3;
        bool CharOnScrn, cameraControl;
        string SelectedCat, OldCat;
        Image Error_Image = Image.FromFile("../../../Items/Images/Error.png");
        Image Item_Image;
        //         Rec amount Rec Name  Name   Image   amount File    Stats                                 Equipped/Equippable/item type/Description
        List<Tuple<Rectangle,Rectangle,string,Rectangle,int,string, Tuple<int, int, int, int, int, string>,Tuple<bool,bool,string,string>>> Items = new List<Tuple<Rectangle,Rectangle,string,Rectangle,int,string, Tuple<int, int, int, int, int, string>,Tuple<bool,bool,string,string>>>();
        
        Player Character = new Player();
        MapData Map = new MapData();
        Inventory Inv = new Inventory();
        Brush Grass = Brushes.Green;
        Brush Water = Brushes.Blue;

        private void Save_Btn_Click(object sender, EventArgs e)
        {

        }

        private void Quit_Btn_Click(object sender, EventArgs e)
        {

        }      

        Font General = new Font(FontFamily.GenericMonospace,16 ,FontStyle.Regular);
        Font Item = new Font(FontFamily.GenericMonospace, 10, FontStyle.Regular);
        StringFormat Center = new StringFormat();
        StringFormat CenterTop = new StringFormat();
        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, Map_Pnl, new object[] { true });
            Map.LoadMap("TestMap");
            Inv.AddItem(1, "Chestplate",false);
            Inv.AddItem(1, "Chestplate1", false);
            Inv.AddItem(1, "Helmet",false);
            Inv.AddItem(1, "SwordBasic", false);
            Inv.AddItem(5, "Apple", false);
            Inv.AddItem(10, "Wallnut", false);
            Inv.PrintInv();
            DrawGrid();
            Center.Alignment = StringAlignment.Center;
            Center.LineAlignment = StringAlignment.Center;
            CenterTop.Alignment = StringAlignment.Center;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            cameraControl = false;
                //Movement of the camera
                if (e.KeyData == Keys.Left)
                {
                    if (tileX > 3)
                    {
                        tileX--;
                    }
                    cameraControl = true;
                }
                if (e.KeyData == Keys.Right)
                {
                    if (tileX < Map.XLimit - 4)
                    {
                        tileX++;
                    }
                    cameraControl = true;
                }
                if (e.KeyData == Keys.Up)
                {
                    if (tileY > 3)
                    {
                        tileY--;
                    }
                    cameraControl = true;
                }
                if (e.KeyData == Keys.Down)
                {
                    if (tileY < Map.YLimit - 4)
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
                        if (tileX > 3)
                        {
                            tileX--;
                        }
                    }
                    if (e.KeyData == Keys.D && Character.PlayerXPos < Map.XLimit - 1 && Map.Tiles[Character.PlayerYPos, Character.PlayerXPos + 1, 2] != 1 && Map.Tiles[Character.PlayerYPos, Character.PlayerXPos + 1, 2] != 3)
                    {
                        if (tileX < Map.XLimit - 4)
                        {                           
                            tileX++;
                        }
                        Character.PlayerXPos++;
                        cameraControl = false;                       
                    }
                    if (e.KeyData == Keys.W && Character.PlayerYPos > 0 && Map.Tiles[Character.PlayerYPos - 1, Character.PlayerXPos, 2] != 1 && Map.Tiles[Character.PlayerYPos - 1, Character.PlayerXPos, 2] != 4)
                    {
                        Character.PlayerYPos--;
                        cameraControl = false;
                        if (tileY > 3)
                        {
                            tileY--;
                        }
                    }
                    if (e.KeyData == Keys.S && Character.PlayerYPos < Map.YLimit - 1 && Map.Tiles[Character.PlayerYPos + 1, Character.PlayerXPos, 2] != 1 && Map.Tiles[Character.PlayerYPos + 1, Character.PlayerXPos, 2] != 5)
                    {
                        if (tileY < Map.YLimit - 3)
                        {
                            tileY++;                       
                        }
                        Character.PlayerYPos++;
                        cameraControl = false;                       
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

            if (e.KeyData == Keys.E)
            {
                Character.StatPrint();
            }
                //Call the DrawGrid method to refresh the players current view and update any tiles as needed
                Info_Pnl.Invalidate();
                DrawGrid();
        }
        public void DrawGrid()
        {
            //Remove the info for the player as it may not be needed
            Character.Char = Rectangle.Empty;
            //Updating current player position
            Map.Tiles[Character.PlayerYPos, Character.PlayerXPos, 1] = 1;
            //Removing all tiles currently on screen
            for (int i = 0; i < 49; i++)
            {
                Tile[i] = Rectangle.Empty;
            }
            TileID = 0;
            //setting up rectangles for grid
            for (int h = 0; h < 7; h++)
            {
                for (int w = 0; w < 7; w++)
                {
                    Tile[TileID] = new Rectangle(0 + (120 * w), 0 + (120 * h), 120, 120);
                    TileID++;
                }
            }
            //Storing all tile information that is in the cameras view range which is pulled from the Tiles array (The map info in other words)
            for (int Y = -3; Y < 4; Y++)
            {
                for (int X = -3; X < 4; X++)
                {
                    Map.ViewRange[X + 3, Y + 3, 0] = Map.Tiles[tileY + X, tileX + Y, 0];
                    Map.ViewRange[X + 3, Y + 3, 1] = Map.Tiles[tileY + X, tileX + Y, 1];
                }
            }
            //Refresh the panel to show changes
            Map_Pnl.Invalidate();
        }

        public void CameraSnap()
        {
            tileX = Character.PlayerXPos;
            tileY = Character.PlayerYPos;
            if (tileX > Map.XLimit-4)
            {
                tileX = Map.XLimit-4;
            }
            if (tileX < 3)
            {
                tileX = 3;
            }
            if (tileY > Map.YLimit - 4)
            {
                tileY = Map.YLimit - 4;
            }
            if (tileY < 3)
            {
                tileY = 3;
            }
        }
        
        private void Map_Pnl_Paint(object sender, PaintEventArgs e)
        { //removing the player from the screen so the position can be correctly updated
            Character.PlayerX = -1;
            Character.PlayerY = -1;
            CharOnScrn = false;
            g = e.Graphics;
            TileID = 0;
            //Colouring tiles based off their visual indicator
           for (int h = 0; h < 7; h++)
           {
               for (int w = 0; w < 7; w++)
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
        //
        //Info pannel(s) UI begins here!
        //
        private void Info_Pnl_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.FillRectangle(Brushes.SaddleBrown, Sec1);
            g.FillRectangle(Brushes.Brown, Sec2);
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
        }

        //
        // Inventory UI Begins Here!
        //
        private void Item_Pnl_Paint(object sender, PaintEventArgs e)
        {
            //usual shorting of e.grahpics down to g
            g = e.Graphics;
            //Displace all objects drawn on panel by the scroll amount
            g.TranslateTransform(Item_Pnl.AutoScrollPosition.X, Item_Pnl.AutoScrollPosition.Y);
            //Check every tuple in the Items list
            int count = 0;
            foreach (Tuple<Rectangle, Rectangle, string,Rectangle,int,string, Tuple<int, int, int, int, int, string>,Tuple<bool,bool,string,string>> tuple in Items)
            {

                //Draws the UI for each item
                if (count == Selected_Item)
                {
                    g.DrawRectangle(Pens.Blue, tuple.Item1);
                    g.DrawRectangle(Pens.Blue, tuple.Item2);
                    g.DrawRectangle(Pens.Blue, tuple.Item4);
                }
                else
                {
                    g.DrawRectangle(Pens.Black, tuple.Item1);
                    g.DrawRectangle(Pens.Black, tuple.Item2);
                    g.DrawRectangle(Pens.Black, tuple.Item4);
                }
                g.DrawString(tuple.Item3, General, Brushes.Black, tuple.Item2, Center);
                g.DrawString(tuple.Item5+"", General, Brushes.Black, tuple.Item4, Center);
                //Does this file path exist?
                bool FileExists = File.Exists("../../../Items/Images/" + tuple.Item6 + ".png");
                if(FileExists == true)
                {
                    //Draws image as intended with no errors
                    Item_Image = Image.FromFile("../../../Items/Images/" + tuple.Item6 + ".png");
                    g.DrawImage(Item_Image, tuple.Item1.X+1,tuple.Item1.Y+1);
                }
                else
                {
                    //Draws error image when the items image cannot be found
                    g.DrawImage(Error_Image, tuple.Item1.X + 1, tuple.Item1.Y + 1);
                }
                count++;
            }
            //Replace old category state with the new one for future referencing
            OldCat = SelectedCat;
        }
        private void Desc_Pnl_Paint(object sender, PaintEventArgs e)
        {
            Item_Image = null;
            g = e.Graphics;
            if (SelectedCat != OldCat)
            {
                g.Clear(Color.Gray);
            }
            else
            {
                int count = 0;
                foreach (Tuple<Rectangle, Rectangle, string, Rectangle, int, string, Tuple<int, int, int, int, int, string>, Tuple<bool, bool,string,string>> tuple in Items)
                {
                    if (count == Selected_Item)
                    {
                        bool FileExists = File.Exists("../../../Items/Images/" + tuple.Item6 + ".png");
                        if (FileExists == true)
                        {
                            Item_Image = Image.FromFile("../../../Items/Images/" + tuple.Item6 + ".png");
                            g.DrawImage(Item_Image, ItemImage);
                        }
                        else
                        {
                            g.DrawImage(Error_Image, ItemImage);
                        }
                        g.DrawString(tuple.Rest.Item4, Item, Brushes.Black, ItemDesc, CenterTop);
                        string ItemStat="",stat="";
                        for (int i = 0; i < 6; i++)
                        {
                            if(i == 0)
                            {
                                stat = "Hp";
                                ItemStat += stat + ":" + tuple.Item7.Item1 + Environment.NewLine;
                            }
                            if (i == 1)
                            {
                                stat = "Atk";
                                ItemStat += stat + ":" + tuple.Item7.Item2 + Environment.NewLine;
                            }
                            if (i == 2)
                            {
                                stat = "Def";
                                ItemStat += stat + ":" + tuple.Item7.Item3 + Environment.NewLine;
                            }
                            if (i == 3)
                            {
                                stat = "Spd";
                                ItemStat += stat + ":" + tuple.Item7.Item4 + Environment.NewLine;
                            }
                            if (i == 4)
                            {
                                stat = "Crit";
                                ItemStat += stat + ":" + tuple.Item7.Item5 + Environment.NewLine;
                            }
                            if (i == 5)
                            {
                                stat = "Type";
                                ItemStat += stat + ":" + tuple.Item7.Item6 + Environment.NewLine;
                            }
                        }
                        g.DrawString(ItemStat, Item, Brushes.Black, ItemStats);
                    }
                    count++;
                }
            }           
        }
        private void InventoryUISetUp()
        {
                int count = 0;
                if (SelectedCat != OldCat)
                {
                    Items.Clear();
                    Item_Pnl.Invalidate();
                    Desc_Pnl.Invalidate();
                }
                Inv.Categorise(SelectedCat);
                Map_Pnl.Focus();
                foreach (Tuple<Tuple<string, string>, int, string, bool, string, Tuple<int, int, int, int, int, string>, bool> tuple in Inv.CategoryData)
                {
                    //Sets up every rectangle and attaches a name for the item id in the list being drawn
                    bool Equipabble = tuple.Item4, Equipped = tuple.Item7;
                    Items.Add(new Tuple<Rectangle, Rectangle, string, Rectangle, int, string, Tuple<int, int, int, int, int, string>, Tuple<bool,bool,string,string>>(new Rectangle(0, 52 * count, 51, 51), new Rectangle(102, 52 * count, 329, 51), tuple.Item1.Item1, new Rectangle(51, 52 * count, 51, 51), tuple.Item2, tuple.Item5, tuple.Item6, new Tuple<bool, bool,string,string>(Equipped, Equipabble,tuple.Item3,tuple.Item1.Item2)));
                    count++;
                }
                //Scales the scroll bar with the amount of items present in selected category
                Item_Pnl.AutoScrollMinSize = new Size(0, 52 * count);
                //if the item count doesn't make the list go past 120px then the bar is hidden
                if (51.1 * count <= 400)
                {
                    Item_Pnl.VerticalScroll.Visible = false;
                }
                Item_Pnl.Invalidate();                     
        }

        private void Key_btn_Click(object sender, EventArgs e)
        {
            SelectedCat = "Key";
            Use_Btn.Text = "Use/Equip";
            Selected_Item = -1;
            InventoryUISetUp();
        }

        private void Item_btn_Click(object sender, EventArgs e)
        {
            SelectedCat = "Item";
            Use_Btn.Text = "Use/Equip";
            Selected_Item = -1;
            InventoryUISetUp();          
        }

        private void Gear_btn_Click(object sender, EventArgs e)
        {
            SelectedCat = "Gear";
            Use_Btn.Text = "Use/Equip";
            Selected_Item = -1;
            InventoryUISetUp();       
        }
        private void Equiped_Btn_Click(object sender, EventArgs e)
        {
            SelectedCat = "Equipped";
            Use_Btn.Text = "Unequip";
            Selected_Item = -1;
            InventoryUISetUp();
        }
        private void Item_Pnl_MouseDown(object sender, MouseEventArgs e)
        {
            int count=0;
            Point Mouse = new Point(e.X, e.Y - Item_Pnl.AutoScrollPosition.Y);
            foreach (Tuple<Rectangle, Rectangle, string, Rectangle, int,string, Tuple<int, int, int, int, int, string>, Tuple<bool,bool,string,string>> tuple in Items)
            {
                if (tuple.Item2.Contains(Mouse))
                {
                    Selected_Item = count;
                    Mouse = new Point();
                    Item_Pnl.Invalidate();
                    Desc_Pnl.Invalidate();
                }
                count++;
            }
        }
        private void Use_Btn_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (Tuple<Rectangle, Rectangle, string, Rectangle, int, string, Tuple<int, int, int, int, int, string>, Tuple<bool,bool,string,string>> tuple in Items)
            {
                if (tuple.Rest.Item1 == true && Selected_Item ==count)
                {
                    Character.MaxHp -= tuple.Item7.Item1;
                    Character.Atk -= tuple.Item7.Item2;
                    Character.Def -= tuple.Item7.Item3;
                    Character.Spd -= tuple.Item7.Item4;
                    Character.Crit -= tuple.Item7.Item5;
                    if (tuple.Rest.Item3 == "Weapon")
                    {
                        Character.AtkElement = "None";
                        Character.WeaponEquipped = false;
                    }
                    if (tuple.Rest.Item3 == "Helmet")
                    {
                        Character.HelmetEquipped = false;
                    }
                    if (tuple.Rest.Item3 == "Chestplate")
                    {
                        Character.ChestplateEquipped = false;
                    }
                    if (tuple.Rest.Item3 == "Leggings")
                    {
                        Character.LeggingsEquipped = false;
                    }
                    if (tuple.Rest.Item3 == "Boots")
                    {
                        Character.BootsEquipped = false;
                    }
                    Inv.AddItem(1, tuple.Item6, false);
                    Inv.DelItem(1, tuple.Item6, false);
                    Items.Clear();
                    Info_Pnl.Invalidate();
                    Desc_Pnl.Invalidate();
                    InventoryUISetUp();
                    break;
                }
                else if (tuple.Rest.Item1 == false && count == Selected_Item && tuple.Rest.Item2 == true)
                {
                    if (tuple.Rest.Item3 == "Weapon" && Character.WeaponEquipped==false)
                    {
                        Character.AtkElement = tuple.Item7.Item6;
                        Character.WeaponEquipped = true;
                        Inv.AddItem(1, tuple.Item6, true);
                        Inv.DelItem(1, tuple.Item6, true);
                        Character.MaxHp += tuple.Item7.Item1;
                        Character.Atk += tuple.Item7.Item2;
                        Character.Def += tuple.Item7.Item3;
                        Character.Spd += tuple.Item7.Item4;
                        Character.Crit += tuple.Item7.Item5;
                    }
                    if(tuple.Rest.Item3 == "Helmet" && Character.HelmetEquipped == false)
                    {
                        Character.HelmetEquipped = true;
                        Inv.AddItem(1, tuple.Item6, true);
                        Inv.DelItem(1, tuple.Item6, true);
                        Character.MaxHp += tuple.Item7.Item1;
                        Character.Atk += tuple.Item7.Item2;
                        Character.Def += tuple.Item7.Item3;
                        Character.Spd += tuple.Item7.Item4;
                        Character.Crit += tuple.Item7.Item5;
                    }
                    if (tuple.Rest.Item3 == "Chestplate" && Character.ChestplateEquipped == false)
                    {
                        Character.ChestplateEquipped = true;
                        Inv.AddItem(1, tuple.Item6, true);
                        Inv.DelItem(1, tuple.Item6, true);
                        Character.MaxHp += tuple.Item7.Item1;
                        Character.Atk += tuple.Item7.Item2;
                        Character.Def += tuple.Item7.Item3;
                        Character.Spd += tuple.Item7.Item4;
                        Character.Crit += tuple.Item7.Item5;
                    }
                    if (tuple.Rest.Item3 == "Leggings" && Character.LeggingsEquipped == false)
                    {
                        Character.LeggingsEquipped = true;
                        Inv.AddItem(1, tuple.Item6, true);
                        Inv.DelItem(1, tuple.Item6, true);
                        Character.MaxHp += tuple.Item7.Item1;
                        Character.Atk += tuple.Item7.Item2;
                        Character.Def += tuple.Item7.Item3;
                        Character.Spd += tuple.Item7.Item4;
                        Character.Crit += tuple.Item7.Item5;
                    }
                    if (tuple.Rest.Item3 == "Boots" && Character.BootsEquipped == false)
                    {
                        Character.BootsEquipped = true;
                        Inv.AddItem(1, tuple.Item6, true);
                        Inv.DelItem(1, tuple.Item6, true);
                        Character.MaxHp += tuple.Item7.Item1;
                        Character.Atk += tuple.Item7.Item2;
                        Character.Def += tuple.Item7.Item3;
                        Character.Spd += tuple.Item7.Item4;
                        Character.Crit += tuple.Item7.Item5;
                    }
                    Items.Clear();
                    Info_Pnl.Invalidate();
                    Desc_Pnl.Invalidate();
                    InventoryUISetUp();
                    break;
                }
                else if (count == Selected_Item && SelectedCat != "Key")
                {
                    Character.Hp = Character.Hp + tuple.Item7.Item1;
                    if (Character.Hp >= Character.MaxHp)
                    {
                        Character.Hp = Character.MaxHp;
                    }
                    Inv.DelItem(1, tuple.Item6, tuple.Rest.Item2);
                    Items.Clear();
                    Info_Pnl.Invalidate();
                    Desc_Pnl.Invalidate();
                    InventoryUISetUp();
                    break;
                }
                count++;
            }
        }
    }

}
