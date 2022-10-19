using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
                  Sec2 = new Rectangle(0, 100, 432, 125),
                  PlayerHp = new Rectangle(88, 95, 250, 50),
                  PlayerAtk = new Rectangle(52, 125, 100, 50),
                  PlayerDef = new Rectangle(52, 175, 100, 50),
                  PlayerSpd = new Rectangle(280, 125, 100, 50),
                  PlayerCrit = new Rectangle(280, 175, 100, 50),
                  Sec4 = new Rectangle(0, 500, 300, 100),
                  ItemImage = new Rectangle(0, 0, 100, 100),
                  ItemDesc = new Rectangle(100, 0, 258, 195),
                  ItemStats = new Rectangle(0, 101, 100, 100),
                  CombatStats = new Rectangle(898,0,372,296),
                  CombatPlayer = new Rectangle(100, 168, 150, 190),
                  CombatPlayerHp = new Rectangle(50, 418, 250, 100),
                  CombatPlayerHpBar = new Rectangle(50, 418, 250, 100),
                  CombatBox = new Rectangle(0, 0, 898, 297),
                  CombatItemDesc = new Rectangle(436,1,321,296)


                                                               ;
        Rectangle[] CombatMenu = new Rectangle[5];
        Rectangle[] CombatFoe = new Rectangle[3]{
            new Rectangle(800,30,150,190), 
            new Rectangle(800,300,150,190), 
            new Rectangle(1070,165,150,190)
        };
        Rectangle[] BasicHpFoe = new Rectangle[3]
        {
            new Rectangle(800,210,150,50),
            new Rectangle(800,480,150,50),
            new Rectangle(1070,345,150,50)
        };
        Rectangle[] BasicHpBarFoe = new Rectangle[3]
        {
            new Rectangle(800,210,150,50),
            new Rectangle(800,480,150,50),
            new Rectangle(1070,345,150,50)
        };
        Rectangle[] FoeSelection = new Rectangle[3]
        {
            new Rectangle(8,8,500,64),
            new Rectangle(8,116,500,64),
            new Rectangle(8,224,500,64)
        };
        Rectangle[] FoeName = new Rectangle[3]
        {
            new Rectangle(13,24,110,40),
            new Rectangle(13,132, 110, 40),
            new Rectangle(13, 240, 110, 40)
        };
        Rectangle[] FoeHpBar = new Rectangle[3]
        {
            new Rectangle(145,14,300,50),
            new Rectangle(145, 122, 300, 50),
            new Rectangle(145, 230, 300, 50)
        };
        Rectangle[] FoeHpFill = new Rectangle[3];
        int TileID = 0, Selected_Item = -1, Selected_Action= -1, Selected_Foe=-1,UnableToFight,Second=0,Minute=0,Hour=0;
        public int tileX = 10, tileY = 10;
        bool CharOnScrn, cameraControl, GameStart = false;
        string SelectedCat, OldCat, PlayerAction="None";
        Image Error_Image = Image.FromFile("../../../Items/Images/Error.png");
        Image Item_Image;
        //         Rec amount Rec Name  Name   Image   amount File    Stats                                 Equipped/Equippable/item type/Description
        List<Tuple<Rectangle, Rectangle, string, Rectangle, int, string, Tuple<int, int, int, int, int, string>, Tuple<bool, bool, string, string>>> Items = new List<Tuple<Rectangle, Rectangle, string, Rectangle, int, string, Tuple<int, int, int, int, int, string>, Tuple<bool, bool, string, string>>>();
        Player Character = new Player();
        MapData Map = new MapData();
        Inventory Inv = new Inventory();
        LootHandler Loot = new LootHandler();
        EncounterHandler Encounter = new EncounterHandler();
        Enemy[] Enemies = new Enemy[3];
        Pen Black = new Pen(Color.Black, 3);
        Pen Outliner = new Pen(Color.Black, 8);
        Random Flee = new Random();
        Random CritRoll = new Random();
        Random DmgMulti = new Random();

        private void Quit_Btn_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to quit back to the main menu?","Are you sure?", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Menu_Pnl.Show();
                Menu_Pnl.BringToFront();
                Menu_Pnl.Invalidate();
                GameStart = false;
            }
        }

        Font ComabtBack = new Font(FontFamily.GenericMonospace, 32, FontStyle.Regular);
        Font General = new Font(FontFamily.GenericMonospace, 16, FontStyle.Regular);
        Font Item = new Font(FontFamily.GenericMonospace, 14, FontStyle.Regular);
        Font Stats = new Font(FontFamily.GenericMonospace, 10, FontStyle.Regular);
        StringFormat Center = new StringFormat();
        StringFormat CenterTop = new StringFormat();
        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, Map_Pnl, new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, Info_Pnl, new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, Combat_Pnl, new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, Action_Pnl, new object[] { true });
            Map_Pnl.BringToFront();
            Info_Pnl.BringToFront();
            Menu_Pnl.BringToFront();        
            Center.Alignment = StringAlignment.Center;
            Center.LineAlignment = StringAlignment.Center;
            CenterTop.Alignment = StringAlignment.Center;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            cameraControl = false;
            if (GameStart)
            {
                if (Encounter.Infight != true)
                {
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
                            EncounterTick();
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
                            EncounterTick();
                        }
                        if (e.KeyData == Keys.W && Character.PlayerYPos > 0 && Map.Tiles[Character.PlayerYPos - 1, Character.PlayerXPos, 2] != 1 && Map.Tiles[Character.PlayerYPos - 1, Character.PlayerXPos, 2] != 4)
                        {
                            Character.PlayerYPos--;
                            cameraControl = false;
                            EncounterTick();
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
                            EncounterTick();
                        }
                    }
                    if (cameraControl == false)
                    {
                        CameraSnap();
                    }
                    if (e.KeyData == Keys.C)
                    {
                        CameraSnap();
                    }
                }
                //Call the DrawGrid method to refresh the players current view and update any tiles as needed
                Info_Pnl.Invalidate();
                DrawGrid();
            }          
        }

        private void CombatInfo_Txtbox_TextChanged(object sender, EventArgs e)
        {
            CombatInfo_Txtbox.SelectionStart = CombatInfo_Txtbox.Text.Length;
            CombatInfo_Txtbox.ScrollToCaret();
        }

        private void NameInsert_Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Instructions_Btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("How to play:\nThis game is about exploring a new land in hopes of taking down the Crystal Empress.\nTo get closer to her tower you will need to travel through underground" +
                " tunnels that are idicated by holes in the ground.\nYour stats and inventory are on the right-hand side of your screen, you can click on items to select them and get more detailed information on them." +
                " You can switch between item types by clicking on the buttons above the inventory. These are Equipped, Key, Item and Gear.\nWASD to move around the map. Arrow keys to move the camera around the map" +
                " and plan your routes if you so wish to.\nYour journey wont be easy as the wildlife under the Crystal Empress's control will impede your progress. Protect yourself and get items from them to heal and" +
                " become better equiped for your fight against her!\nMake sure to equip your sowrd and armour before venturing out into the world!");
        }

        private void Start_Pnl_Click(object sender, EventArgs e)
        {
            if(NameInsert_Txt.Text != "")
            {
                Inv.Reset();
                Character.Reset();
                Encounter.Reset();
                Character.Name = NameInsert_Txt.Text;
                Inv.AddItem(1, "Chestplate", false);
                Inv.AddItem(1, "Helmet", false);
                Inv.AddItem(1, "Leggings", false);
                Inv.AddItem(1, "Boots", false);
                Inv.AddItem(1, "SwordBasic", false);
                Inv.AddItem(5, "Apple", false);
                Inv.AddItem(10, "Walnut", false);
                Map.LoadMap("1.1");
                Second = 0;
                Minute = 0;
                Hour = 0;
                PlayTime_Tmr.Start();
                Encounter.EncounterListSetup(Map.LevelIndicator);
                GameStart = true;
                CameraSnap();
                DrawGrid();
                GC.Collect();
                Menu_Pnl.Hide();
            }
            else
            {
                MessageBox.Show("You need to enter in a name before you can start playing!");
            }
        }

        private void CombatInfo_Txtbox_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void PlayTime_Tmr_Tick(object sender, EventArgs e)
        {
            Second++;
            if(Second>= 60)
            {
                Minute++;
                Second = 0;
            }
            if(Minute >= 60)
            {
                Hour++;
                Minute = 0;
            }
            Info_Pnl.Invalidate();
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
            if (tileX > Map.XLimit - 4)
            {
                tileX = Map.XLimit - 4;
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
            g.Clear(Color.White);
            TileID = 0;
            //Colouring tiles based off their visual indicator
            for (int h = 0; h < 7; h++)
            {
                for (int w = 0; w < 7; w++)
                {
                    if (Map.ViewRange[h,w,0] == 0)
                    {
                        g.FillRectangle(Brushes.Black, Tile[TileID]);
                    }
                    if (Map.ViewRange[h, w, 0] == Map.LevelIndicator + .1)
                    {
                        g.DrawImage(Map.TileSprites.ElementAt(0), Tile[TileID]);
                    }
                    if (Map.ViewRange[h, w, 0] == Map.LevelIndicator + .11)
                    {
                        g.DrawImage(Map.TileSprites.ElementAt(1), Tile[TileID]);
                    }
                    if (Map.ViewRange[h, w, 0] == Map.LevelIndicator + .12)
                    {
                        g.DrawImage(Map.TileSprites.ElementAt(2), Tile[TileID]);
                    }
                    if (Map.ViewRange[h, w, 0] == Map.LevelIndicator + .13)
                    {
                        g.DrawImage(Map.TileSprites.ElementAt(3), Tile[TileID]);
                    }
                    if (Map.ViewRange[h, w, 0] == Map.LevelIndicator + .2)
                    {
                        g.DrawImage(Map.TileSprites.ElementAt(4), Tile[TileID]);
                    }
                    if (Map.ViewRange[h, w, 0] == Map.LevelIndicator + .3)
                    {
                        g.DrawImage(Map.TileSprites.ElementAt(5), Tile[TileID]);
                    }
                    if (Map.ViewRange[h, w, 0] == Map.LevelIndicator + .4)
                    {
                        g.DrawImage(Map.TileSprites.ElementAt(6), Tile[TileID]);
                    }
                    //finding players position in relation to the cameras position
                    if (Map.ViewRange[h, w, 1] == 1)
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
            g.DrawString(Character.Name, General, Brushes.Black, PlayerName, Center);
            g.DrawString("LVL:" + Character.Lvl +"\n XP:" + Character.Xp, General, Brushes.Black, PlayerLvl, Center);
            //Placeholder playtime display
            g.DrawString("PlayTime: " + Hour +":" +Minute +":"+Second, General, Brushes.Black, FilePlayTime, Center);
            g.DrawString("HP:" + Character.Hp + "/" + Character.MaxHp, General, Brushes.Black, PlayerHp, Center);
            g.DrawString("Atk:" + Character.Atk, General, Brushes.Black, PlayerAtk, Center);
            g.DrawString("Def:" + Character.TrueDef, General, Brushes.Black, PlayerDef, Center);
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
            foreach (Tuple<Rectangle, Rectangle, string, Rectangle, int, string, Tuple<int, int, int, int, int, string>, Tuple<bool, bool, string, string>> tuple in Items)
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
                g.DrawString(tuple.Item5 + "", General, Brushes.Black, tuple.Item4, Center);
                //Does this file path exist?
                bool FileExists = File.Exists("../../../Items/Images/" + tuple.Item6 + ".png");
                if (FileExists == true)
                {
                    //Draws image as intended with no errors
                    Item_Image = Image.FromFile("../../../Items/Images/" + tuple.Item6 + ".png");
                    g.DrawImage(Item_Image, tuple.Item1.X + 1, tuple.Item1.Y + 1);
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
                foreach (Tuple<Rectangle, Rectangle, string, Rectangle, int, string, Tuple<int, int, int, int, int, string>, Tuple<bool, bool, string, string>> tuple in Items)
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
                        string ItemStat = "", stat = "";
                        for (int i = 0; i < 6; i++)
                        {
                            if (i == 0)
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
                        g.DrawString(ItemStat, Stats, Brushes.Black, ItemStats);
                    }
                    count++;
                }
            }
        }
        private void InventoryUISetUp()
        {
            int count = 0;
            Items.Clear();
            if (SelectedCat != OldCat)
            {
                Item_Pnl.Invalidate();
                Desc_Pnl.Invalidate();
            }
            Inv.Categorise(SelectedCat);
            Map_Pnl.Focus();
            foreach (Tuple<Tuple<string, string>, int, string, bool, string, Tuple<int, int, int, int, int, string>, bool> tuple in Inv.CategoryData)
            {
                //Sets up every rectangle and attaches a name for the item id in the list being drawn
                bool Equipabble = tuple.Item4, Equipped = tuple.Item7;
                Items.Add(new Tuple<Rectangle, Rectangle, string, Rectangle, int, string, Tuple<int, int, int, int, int, string>, Tuple<bool, bool, string, string>>(new Rectangle(0, 52 * count, 51, 51), new Rectangle(102, 52 * count, 329, 51), tuple.Item1.Item1, new Rectangle(51, 52 * count, 51, 51), tuple.Item2, tuple.Item5, tuple.Item6, new Tuple<bool, bool, string, string>(Equipped, Equipabble, tuple.Item3, tuple.Item1.Item2)));
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
            int count = 0;
            Point Mouse = new Point(e.X, e.Y - Item_Pnl.AutoScrollPosition.Y);
            foreach (Tuple<Rectangle, Rectangle, string, Rectangle, int, string, Tuple<int, int, int, int, int, string>, Tuple<bool, bool, string, string>> tuple in Items)
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
            UseItem();
        }
        //
        //Comabt Stuff starts here!
        //
        private void UseItem()
        {
            int count = 0;
            foreach (Tuple<Rectangle, Rectangle, string, Rectangle, int, string, Tuple<int, int, int, int, int, string>, Tuple<bool, bool, string, string>> tuple in Items)
            {
                if (tuple.Rest.Item1 == true && Selected_Item == count)
                {
                    Character.MaxHp -= tuple.Item7.Item1;
                    Character.Atk -= tuple.Item7.Item2;
                    Character.TrueDef -= tuple.Item7.Item3;
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
                    Inv.DelItem(1, tuple.Item6, false);
                    Inv.AddItem(1, tuple.Item6, false);
                    Items.Clear();
                    Info_Pnl.Invalidate();
                    Desc_Pnl.Invalidate();
                    InventoryUISetUp();
                    break;
                }
                else if (tuple.Rest.Item1 == false && count == Selected_Item && tuple.Rest.Item2 == true)
                {
                    if (tuple.Rest.Item3 == "Weapon" && Character.WeaponEquipped == false)
                    {
                        Character.AtkElement = tuple.Item7.Item6;
                        Character.WeaponEquipped = true;
                        Inv.DelItem(1, tuple.Item6, true);
                        Inv.AddItem(1, tuple.Item6, true);
                        Character.MaxHp += tuple.Item7.Item1;
                        Character.Atk += tuple.Item7.Item2;
                        Character.TrueDef += tuple.Item7.Item3;
                        Character.Spd += tuple.Item7.Item4;
                        Character.Crit += tuple.Item7.Item5;
                    }
                    if (tuple.Rest.Item3 == "Helmet" && Character.HelmetEquipped == false)
                    {
                        Character.HelmetEquipped = true;
                        Inv.DelItem(1, tuple.Item6, true);
                        Inv.AddItem(1, tuple.Item6, true);
                        Character.MaxHp += tuple.Item7.Item1;
                        Character.Atk += tuple.Item7.Item2;
                        Character.TrueDef += tuple.Item7.Item3;
                        Character.Spd += tuple.Item7.Item4;
                        Character.Crit += tuple.Item7.Item5;
                    }
                    if (tuple.Rest.Item3 == "Chestplate" && Character.ChestplateEquipped == false)
                    {
                        Character.ChestplateEquipped = true;                       
                        Inv.DelItem(1, tuple.Item6, true);
                        Inv.AddItem(1, tuple.Item6, true);
                        Character.MaxHp += tuple.Item7.Item1;
                        Character.Atk += tuple.Item7.Item2;
                        Character.TrueDef += tuple.Item7.Item3;
                        Character.Spd += tuple.Item7.Item4;
                        Character.Crit += tuple.Item7.Item5;
                    }
                    if (tuple.Rest.Item3 == "Leggings" && Character.LeggingsEquipped == false)
                    {
                        Character.LeggingsEquipped = true;                        
                        Inv.DelItem(1, tuple.Item6, true);
                        Inv.AddItem(1, tuple.Item6, true);
                        Character.MaxHp += tuple.Item7.Item1;
                        Character.Atk += tuple.Item7.Item2;
                        Character.TrueDef += tuple.Item7.Item3;
                        Character.Spd += tuple.Item7.Item4;
                        Character.Crit += tuple.Item7.Item5;
                    }
                    if (tuple.Rest.Item3 == "Boots" && Character.BootsEquipped == false)
                    {
                        Character.BootsEquipped = true;                       
                        Inv.DelItem(1, tuple.Item6, true);
                        Inv.AddItem(1, tuple.Item6, true);
                        Character.MaxHp += tuple.Item7.Item1;
                        Character.Atk += tuple.Item7.Item2;
                        Character.TrueDef += tuple.Item7.Item3;
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
                    if (Encounter.Infight == true)
                    {
                        CombatInfo_Txtbox.Text += "\n-> You consumed the "+tuple.Item6 + " and regained " + tuple.Item7.Item1 +" Hp!";
                        EnemyTurn();
                    }
                    Inv.DelItem(1, tuple.Item6, tuple.Rest.Item2);
                    Items.Clear();
                    Info_Pnl.Invalidate();
                    Desc_Pnl.Invalidate();
                    Action_Pnl.Invalidate();
                    CombatItem_Pnl.Invalidate();
                    InventoryUISetUp();
                    break;
                }
               
                count++;
            }
        }
        private void EncounterTick()
        {
            if(Map.Tiles[Character.PlayerYPos, Character.PlayerXPos, 0] == Map.LevelIndicator + .5)
            {
                Map_Pnl.Hide();
                Info_Pnl.Hide();
                CombatUISetup();
                Combat_Pnl.Invalidate();
                Character.Def = Character.TrueDef;
                CombatInfo_Txtbox.Text = "Boss Fight!";
                Encounter.SetEncounter("CrystalServant","CrystalEmpress","CrystalServant");
                EnemySetup();
            }
            else if (Map.Tiles[Character.PlayerYPos, Character.PlayerXPos, 3] == 0)
            {
                Encounter.EncounterRoll(Map.LevelIndicator);
                if (Encounter.Infight == true)
                {
                    Map_Pnl.Hide();
                    Info_Pnl.Hide();
                    CombatUISetup();
                    Combat_Pnl.Invalidate();
                    Character.Def = Character.TrueDef;
                    CombatInfo_Txtbox.Text = "Combat Start!";
                    EnemySetup();
                }
            }
            else
            {
                string MapTransition = "" + Map.Tiles[Character.PlayerYPos, Character.PlayerXPos, 3];
                string PlayerPosition = "" + Map.Tiles[Character.PlayerYPos, Character.PlayerXPos, 4];
                string[] Positions = PlayerPosition.Split(".");
                Character.PlayerXPos = int.Parse(Positions[0]);
                try
                {
                    Character.PlayerYPos = int.Parse(Positions[1]);
                }
                catch (Exception)
                {
                    Character.PlayerYPos = 0;
                }
                Map.LoadMap(MapTransition);
                Encounter.EncounterListSetup(Map.LevelIndicator);
            }
        }
        private void EnemySetup()
        {
            string Element="", Name="";
            int Hp=0, Atk=0, Def=0, Spd=0, Crit=0, Pos=0;
            for (int i = 0; i < Encounter.CurrentEncounter.Count; i++)
            {
                //Tuple(Name,Hp,Atk,Def,Spd,Crit,Element,Position)
                Name = Encounter.CurrentEncounter[i].Item1;
                Hp = Encounter.CurrentEncounter[i].Item2;
                Atk = Encounter.CurrentEncounter[i].Item3;
                Def = Encounter.CurrentEncounter[i].Item4;
                Spd = Encounter.CurrentEncounter[i].Item5;
                Crit = Encounter.CurrentEncounter[i].Item6;
                Element = Encounter.CurrentEncounter[i].Item7;
                Pos = Encounter.CurrentEncounter[i].Rest.Item1;
                Enemies[i] = new Enemy(Name,Hp,Atk,Def,Spd,Crit,Element,Pos);
            }
        }
        private void EnemyTurn()
        {
            Combat_Pnl.Invalidate();
            UnableToFight = 0;
            for (int i = 0; i < Encounter.CurrentEncounter.Count; i++)
            {
                if (Enemies[i].Fled == false)
                {
                    if (Enemies[i].Defending == true)
                    {
                        Enemies[i].Def = Enemies[i].TrueDef;
                        Enemies[i].Defending = false;
                    }
                    int Ec, Dmg;                  
                    Ec = Enemies[i].EnemyDecision();
                    if (Ec >= 0 && Ec <= 80)
                    {
                        CombatInfo_Txtbox.Text += "\n->" + Enemies[i].Name + (i+1) + " attacked you!";
                        Dmg = (int)Math.Round((Enemies[i].Atk * (double)(DmgMulti.Next(8, 15) / 10)) - Character.Def/2);                       
                        int CritRolled = CritRoll.Next(0, 101);
                        if (CritRolled <= Enemies[i].Crit)
                        {
                            Dmg = Dmg * 2;
                            CombatInfo_Txtbox.Text += "\n->The enemy got a critical strike against you!";
                        }
                        if(Dmg <= 0)
                        {
                            Dmg = 1;
                        }
                        Character.Hp -= Dmg;
                        CombatInfo_Txtbox.Text += "\n->" +"And dealt " +Dmg+"!";
                        if(Character.Hp <= 0)
                        {
                            PlayerDead();
                            break;
                        }
                    }
                    if (Ec >= 81 && Ec <= 100)
                    {
                        Enemies[i].Def = (int)Math.Round(Enemies[i].Def * 1.2);
                        Enemies[i].Defending = true;
                        CombatInfo_Txtbox.Text += "\n->" + Enemies[i].Name + (i+1) + " prepares for your next attack!";
                    }                  
                }
                else
                {
                    UnableToFight++;
                    if(UnableToFight>= Encounter.CurrentEncounter.Count)
                    {
                        CombatEnd();
                    }
                }
               
            }
            Character.Def = Character.TrueDef;
            PlayerAction = "None";
            Action_Pnl.Invalidate();
        }
        private void PlayerTurn(string Action)
        {
            if (Action == "Fight")
            {
                int Dmg;
                CombatInfo_Txtbox.Text += "\n->You swung at "+Enemies[Selected_Foe].Name+"!";
                Dmg = (int)Math.Round((Character.Atk * (double)((double)DmgMulti.Next(8, 15) / (double)10)) - Enemies[Selected_Foe].Def / 2);
                if (Character.AtkElement == Enemies[Selected_Foe].Element && Character.AtkElement != "None")
                {
                    Dmg = Dmg / 2;
                }
                int CritRolled = CritRoll.Next(0, 101);
                if (CritRolled <= Character.Crit)
                {
                    Dmg = Dmg * 2;
                    CombatInfo_Txtbox.Text += "\n->You got a critical strike against the enemy!";
                }
                if (Dmg <= 0)
                {
                    Dmg = 1;
                }
                Enemies[Selected_Foe].Hp -= Dmg;
                CombatInfo_Txtbox.Text += "\n->" + "And delt " + Dmg + "!";
                if(Enemies[Selected_Foe].Hp <= 0)
                {
                    Enemies[Selected_Foe].Fled = true;
                    Enemies[Selected_Foe].Hp = 0;
                    CombatInfo_Txtbox.Text += "\n->The attack was fatal";
                }
                EnemyTurn();
            }
            
            if(Action == "Flee")
            {
                int EnemyTotSpd=0;
                for (int i = 0; i < Encounter.CurrentEncounter.Count; i++)
                {
                    EnemyTotSpd = EnemyTotSpd + Enemies[i].Spd;
                }
                int EscapeChance = Character.Spd / EnemyTotSpd * 100;
                if (EscapeChance <= Flee.Next(0, 101) || EscapeChance > 100)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        CombatMenu[i] = Rectangle.Empty;
                    }
                    Combat_Pnl.Hide();
                    Action_Pnl.Hide();
                    Map_Pnl.Show();
                    Info_Pnl.Show();
                    for (int i = 0; i < Encounter.CurrentEncounter.Count; i++)
                    {
                        Enemies[i] = null;
                    }
                    GC.Collect();
                    Encounter.CurrentEncounter.Clear();
                    Encounter.Infight = false;
                    PlayerAction = "None";
                }
                else
                {
                    CombatInfo_Txtbox.Text += "\n->You Attempted to flee but couldn't find an opening!";
                    EnemyTurn();
                }

            }
        }
        private void Action_Pnl_MouseDown(object sender, MouseEventArgs e)
        {
           Selected_Action = 0;
           Selected_Foe = 0;
           Point Mouse = new Point(e.X, e.Y);
           foreach (Rectangle Rec in CombatMenu)
           {
               if (Rec.Contains(Mouse))
               {
                   if (PlayerAction != "None" && Selected_Action == 4)
                   {
                       Mouse = new Point();
                       Selected_Item = -1;
                       Action(Selected_Action);
                   }
                   else if (PlayerAction == "None") 
                   {
                       Mouse = new Point();
                       Action(Selected_Action);
                   }                  
               }
               Selected_Action++;
           }
           if(PlayerAction == "Fight")
            {
                foreach (Rectangle Rec in FoeSelection)
                {
                    if (Rec.Contains(Mouse))
                    {
                        if (PlayerAction == "Fight")
                        {
                            Mouse = new Point();
                            PlayerTurn("Fight");
                        }
                    }
                    Selected_Foe++;
                }
            }      
        }
        private void CombatUISetup()
        {
            int RectCount = 0;
            if(Character.Hp>Character.MaxHp)
            {
                Character.Hp = Character.MaxHp;
            }
            for (int w = 0; w < 2; w++)
            {
                for (int h = 0; h < 2; h++)
                {
                    CombatMenu[RectCount] = new Rectangle(1 + (448 * w), 0 + (148 * h), 448, 148);
                    RectCount++;
                }
            }
            CombatMenu[4] = new Rectangle(898, 0, 372, 297);
            Map_Pnl.Hide();
            Info_Pnl.Hide();
            Combat_Pnl.Show();
            Action_Pnl.Show();
            SelectedCat = "Item";
            InventoryUISetUp();
        }
        private void Action_Pnl_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;         
            if (PlayerAction == "None")
            {
                CombatItem_Pnl.Hide();
                BattleUse_Btn.Hide();
                BattleUse_Btn.Enabled = false;
                g.FillRectangle(Brushes.Blue, CombatMenu[0]);
                g.DrawString("Attack", General, Brushes.Black, CombatMenu[0], Center);
                g.FillRectangle(Brushes.Green, CombatMenu[1]);
                g.DrawString("Defend", General, Brushes.Black, CombatMenu[1], Center);
                g.FillRectangle(Brushes.Yellow, CombatMenu[2]);
                g.DrawString("Items", General, Brushes.Black, CombatMenu[2], Center);
                g.FillRectangle(Brushes.Orange, CombatMenu[3]);
                g.DrawString("Flee", General, Brushes.Black, CombatMenu[3], Center);
                g.FillRectangle(Brushes.Pink, CombatStats);
                g.DrawRectangle(Black, CombatMenu[0]);
                g.DrawRectangle(Black, CombatMenu[1]);
                g.DrawRectangle(Black, CombatMenu[2]);
                g.DrawRectangle(Black, CombatMenu[3]);
                g.DrawRectangle(Black, CombatStats);
                CombatInfo_Txtbox.Show();
            }
            if(PlayerAction != "None")
            {
                g.FillRectangle(Brushes.WhiteSmoke, CombatMenu[4]);
                g.DrawRectangle(Outliner, CombatMenu[4]);
                g.DrawString("Back", ComabtBack, Brushes.Black, CombatMenu[4], Center);
            }
            if (PlayerAction == "Fight")
            {
                g.DrawRectangle(Outliner, CombatBox);
                for(int i = 0; i < Encounter.CurrentEncounter.Count; i++)
                {
                    g.DrawString(Enemies[i].Name, General, Brushes.Black, FoeName[i], Center);
                    FoeHpFill[i] = new Rectangle(145, 14 + (108 * i), (int)Math.Round((double)300 * ((double)Enemies[i].Hp / (double)Enemies[i].MaxHp)), 50);
                    g.FillRectangle(Brushes.Red, FoeHpFill[i]);
                    g.DrawRectangle(Black, FoeHpBar[i]);
                    g.DrawRectangle(Black, FoeSelection[i]);
                    g.DrawString(""+Enemies[i].Hp+"/"+Enemies[i].MaxHp, General, Brushes.Black, FoeHpBar[i], Center);
                }
                CombatInfo_Txtbox.Hide();
            }
            if (PlayerAction == "Item")
            {
                g.DrawRectangle(Outliner, CombatBox);
                g.DrawRectangle(Black, CombatItemDesc);
                CombatItem_Pnl.Show();
                BattleUse_Btn.Show();
                BattleUse_Btn.Enabled = true;
                InventoryUISetUp();
                CombatInfo_Txtbox.Hide();
                int count = 0;
                foreach (Tuple<Rectangle, Rectangle, string, Rectangle, int, string, Tuple<int, int, int, int, int, string>, Tuple<bool, bool, string, string>> tuple in Items)
                {
                    if (count == Selected_Item)
                    {
                        string ItemStat = "", stat = "";
                        for (int i = 0; i < 6; i++)
                        {
                            if (i == 0)
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
                        g.DrawString(ItemStat + "\n" + tuple.Rest.Item4, Item, Brushes.Black, CombatItemDesc);
                    }
                    count++;
                }
            }
        }
        private void Combat_Pnl_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawRectangle(Black, CombatPlayer);
            CombatPlayerHpBar = new Rectangle(50, 418, (int)Math.Round((double)250 * ((double)Character.Hp / (double)Character.MaxHp)), 100);
            g.FillRectangle(Brushes.Red, CombatPlayerHpBar);
            g.DrawRectangle(Black, CombatPlayerHp);
            g.DrawString("" + Character.Hp + "/" + Character.MaxHp, General, Brushes.Black, CombatPlayerHp, Center);
            for (int i = 0; i < Encounter.CurrentEncounter.Count; i++)
            {
                BasicHpBarFoe[i] = new Rectangle(BasicHpFoe[i].X,BasicHpFoe[i].Y, (int)Math.Round((double)150 * ((double)Enemies[i].Hp / (double)Enemies[i].MaxHp)),BasicHpFoe[i].Height);
                g.DrawImage(Enemies[i].Sprite, CombatFoe[i]);
                g.FillRectangle(Brushes.Red, BasicHpBarFoe[i]);
                g.DrawRectangle(Black, BasicHpFoe[i]);
            }
        }
        private void CombatItem_Pnl_Paint(object sender, PaintEventArgs e)
        {
            //usual shorting of e.grahpics down to g
            g = e.Graphics;
            g.Clear(Color.Gray);
            //Scales the scroll bar with the amount of items present in selected category
            CombatItem_Pnl.AutoScrollMinSize = new Size(0, 52 * Items.Count);
            //if the item count doesn't make the list go past 120px then the bar is hidden
            if (51.1 * Items.Count <= 400)
            {
                CombatItem_Pnl.VerticalScroll.Visible = false;
            }
            else
            {
                CombatItem_Pnl.VerticalScroll.Visible = true;
            }
            //Displace all objects drawn on panel by the scroll amount
            g.TranslateTransform(CombatItem_Pnl.AutoScrollPosition.X, CombatItem_Pnl.AutoScrollPosition.Y);
            //Check every tuple in the Items list
            int count = 0;
            foreach (Tuple<Rectangle, Rectangle, string, Rectangle, int, string, Tuple<int, int, int, int, int, string>, Tuple<bool, bool, string, string>> tuple in Items)
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
                g.DrawString(tuple.Item5 + "", General, Brushes.Black, tuple.Item4, Center);
                //Does this file path exist?
                bool FileExists = File.Exists("../../../Items/Images/" + tuple.Item6 + ".png");
                if (FileExists == true)
                {
                    //Draws image as intended with no errors
                    Item_Image = Image.FromFile("../../../Items/Images/" + tuple.Item6 + ".png");
                    g.DrawImage(Item_Image, tuple.Item1.X + 1, tuple.Item1.Y + 1);
                }
                else
                {
                    //Draws error image when the items image cannot be found
                    g.DrawImage(Error_Image, tuple.Item1.X + 1, tuple.Item1.Y + 1);
                }
                count++;
            }
        }
        private void CombatItem_Pnl_MouseDown(object sender, MouseEventArgs e)
        {
            int count = 0;
            Point Mouse = new Point(e.X, e.Y - CombatItem_Pnl.AutoScrollPosition.Y);
            foreach (Tuple<Rectangle, Rectangle, string, Rectangle, int, string, Tuple<int, int, int, int, int, string>, Tuple<bool, bool, string, string>> tuple in Items)
            {
                if (tuple.Item2.Contains(Mouse))
                {
                    Selected_Item = count;
                    Mouse = new Point();
                    CombatItem_Pnl.Invalidate();
                    Action_Pnl.Invalidate();
                }
                count++;
            }
        }
        private void BattleUse_Btn_Click(object sender, EventArgs e)
        {
            UseItem();
        }
        private void Action(int Act)
        {
            switch (Act)
            {
                //Fight action
                case 0:
                    PlayerAction = "Fight";
                    Action_Pnl.Invalidate();
                    break;
                //Defend
                case 1:
                    PlayerAction = "Defend";
                    CombatInfo_Txtbox.Text += "\n->You prepared to defend against enemy attacks!";
                    Character.Def = (int)Math.Round(Character.Def * 1.2);
                    EnemyTurn();
                    Action_Pnl.Invalidate();
                    break;
                //Item action
                case 2:
                    PlayerAction = "Item";
                    Action_Pnl.Invalidate();
                    break;
                //Flee action
                case 3:
                    PlayerAction = "Flee";
                    PlayerTurn("Flee");
                    Action_Pnl.Invalidate();
                    break;
                case 4:
                    PlayerAction = "None";
                    Action_Pnl.Invalidate();
                    break;
            }


        }
        private void CombatEnd()
        {
            int XPGainedTotal = 0;
            for (int i = 0; i < Encounter.CurrentEncounter.Count; i++)
            {
                Loot.GetLootTable(Enemies[i].Name);
                Loot.RollTable();
                if (Loot.Item != "")
                {
                    Inv.AddItem(Loot.AmountGained, Loot.Item, false);
                    CombatInfo_Txtbox.Text += "\n ->You found " + Loot.AmountGained + " " + Loot.Item + "!";
                    Items.Clear();
                    Info_Pnl.Invalidate();
                    Desc_Pnl.Invalidate();
                    InventoryUISetUp();
                }
                XPGainedTotal += Loot.XPGained;
                Character.Xp += Loot.XPGained;
            }
            CombatInfo_Txtbox.Text += "\n ->You Gained " + XPGainedTotal + " XP!";
            Character.XpCheck();
            Encounter.Infight = false;
            for (int i = 0; i < 5; i++)
            {
                CombatMenu[i] = Rectangle.Empty;
            }
            Combat_Pnl.Hide();
            Action_Pnl.Hide();
            Map_Pnl.Show();
            Info_Pnl.Show();
            for (int i = 0; i < Encounter.CurrentEncounter.Count; i++)
            {
                Enemies[i] = null;
            }
            GC.Collect();
            Encounter.CurrentEncounter.Clear();
            PlayerAction = "None";
        }
        private void PlayerDead()
        {
            PlayTime_Tmr.Stop();
            MessageBox.Show("You have perished! \nTo start a new game just hit the ok button and press start in the main menu.");
            Menu_Pnl.Show();
            Menu_Pnl.BringToFront();
            Menu_Pnl.Invalidate();
            GameStart = false;
            Encounter.Infight = false;
            for (int i = 0; i < 5; i++)
            {
                CombatMenu[i] = Rectangle.Empty;
            }
            Combat_Pnl.Hide();
            Action_Pnl.Hide();
            Map_Pnl.Show();
            Info_Pnl.Show();
            for (int i = 0; i < Encounter.CurrentEncounter.Count; i++)
            {
                Enemies[i] = null;
            }
            GC.Collect();
            Encounter.CurrentEncounter.Clear();
            PlayerAction = "None";
        }
    }

}