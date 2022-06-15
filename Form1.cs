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
    {
        Graphics g;
        Rectangle[] Tile = new Rectangle[9];
        int TileID = 0;
        int[,,] Tiles = new int[5, 5, 2]
            {
                { {2,3},{2,3},{2, 5},{2,7},{2,10} },
                { {2,2},{2,2},{1,7},{2,8},{2,321} },
                { {1,4},{2,1},{1,2},{2,543},{2,6546} },
                { {1,6},{1,8},{1,9},{1,546},{2,234} },
                { {1,3},{1,2},{1,5},{1,1254},{1,615} }
            };
        int[,] ViewRange = new int[3, 3];
        int tileX=2, tileY=2;
        Brush Grass = Brushes.Green;
        Brush Water = Brushes.Blue;
        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panel1, new object[] { true });
            DrawGrid();
        }

        public void DrawGrid()
        {
            for (int i = 0; i < 9; i++)
            {
                Tile[i] = Rectangle.Empty;
            }
            TileID = 0;
            //setting up rectangles for grid
            for (int h = 0; h < 3; h++)
            {
                for (int w = 0; w < 3; w++)
                {
                    Tile[TileID] = new Rectangle(0 + (200 * w), 0 + (200 * h), 200, 200);
                    TileID++;
                }
            }

            for (int Y = -1; Y < 2; Y++)
            {
                for (int X = -1; X < 2; X++)
                {
                    ViewRange[X+1, Y+1] = Tiles[tileY + X, tileX + Y, 0];
                }
            }
            panel1.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left && tileX>1)
            {
                tileX--;
            }
            if (e.KeyData == Keys.Right && tileX < 3)
            {
                tileX++;
            }
            if (e.KeyData == Keys.Up && tileY > 1)
            {
                tileY--;
            }
            if (e.KeyData == Keys.Down && tileY < 3)
            {
                tileY++;
            }
            DrawGrid();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            TileID = 0;
            for (int h = 0; h < 3; h++)
            {
                for (int w = 0; w < 3; w++)
                {
                    if (ViewRange[h,w]==1)
                    {
                        g.FillRectangle(Grass, Tile[TileID]);
                    }
                    else
                    {
                        g.FillRectangle(Water, Tile[TileID]);
                    }
                    g.DrawRectangle(Pens.Black, Tile[TileID]);
                    TileID++;
                }
            }
        }
    }
}
