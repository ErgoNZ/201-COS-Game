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
        Rectangle[] Tile = new Rectangle[25];
        int TileID = 0;
        int[,,] Tiles = new int[10, 10, 2]
            {
                { {1,3},{1,3},{2,5},{2,7},{2,1}, {2,3},{2,3},{2,5},{2,7},{2,1}  },
                { {1,2},{1,2},{1,7},{2,8},{2,6}, {2,2},{2,2},{1,7},{2,8},{2,6}  },
                { {1,4},{2,1},{1,2},{2,6},{2,3}, {1,4},{2,1},{1,2},{2,6},{2,3}  },
                { {1,6},{1,8},{1,9},{1,5},{2,7}, {1,6},{1,8},{1,9},{1,5},{2,7}  },
                { {1,3},{1,2},{1,5},{1,9},{1,5}, {1,3},{1,2},{1,5},{1,9},{1,5}  },
                { {2,3},{2,3},{2,5},{2,7},{2,1}, {2,3},{2,3},{2,5},{2,7},{2,1}  },
                { {2,2},{2,2},{1,7},{2,8},{2,6}, {2,2},{2,2},{1,7},{2,8},{2,6}  },
                { {1,4},{2,1},{1,2},{2,6},{2,3}, {1,4},{2,1},{1,2},{2,6},{2,3}  },
                { {1,6},{1,8},{1,9},{1,5},{2,7}, {1,6},{1,8},{1,9},{1,5},{2,7}  },
                { {1,3},{1,2},{1,5},{1,9},{1,5}, {1,3},{1,2},{1,5},{1,9},{1,5}  }
            };
        int[,] ViewRange = new int[5, 5];
        int tileX=5, tileY=5;
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

            for (int Y = -2; Y < 3; Y++)
            {
                for (int X = -2; X < 3; X++)
                {
                    ViewRange[X+2, Y+2] = Tiles[tileY + X, tileX + Y, 0];
                }
            }
            panel1.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left && tileX>2)
            {
                tileX--;
            }
            if (e.KeyData == Keys.Right && tileX < 7)
            {
                tileX++;
            }
            if (e.KeyData == Keys.Up && tileY > 2)
            {
                tileY--;
            }
            if (e.KeyData == Keys.Down && tileY < 7)
            {
                tileY++;
            }
            DrawGrid();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            TileID = 0;
            for (int h = 0; h < 5; h++)
            {
                for (int w = 0; w < 5; w++)
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
