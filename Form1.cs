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

namespace Grid_based_map
{
    public partial class Form1 : Form
    {
        Graphics g;
        Rectangle[] Tile = new Rectangle[9];
        public Form1()
        {
            InitializeComponent();
            int tileX, tileY;
            Tile[0] = new Rectangle(0, 0, 200, 200);
            int[,,] Tiles = new int[5, 5, 2]
            {
                { {1,3},{2,3},{4, 5},{6,7},{25,10} },
                { {1,2},{7,2},{6,7},{17,8},{267,321} },
                { {6,4},{2,1},{12,2},{23,543},{134,6546} },
                { {2,6},{4,8},{4,9},{123,546},{234,234} },
                { {7,3},{1,2},{3,5},{1267,1254},{467,615} }
            };
            for (int h = 0; h < 3; h++)
            {
                for (int w = 0; w < 3; w++)
                {
                    Tile[w+h] = new Rectangle(0 + (200 * h), 0 +(200*w), 200, 200);
                    Debug.WriteLine(h);
                    Debug.WriteLine(w);
                }

            }
        }  

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            for (int i = 0; i < 9; i++)
            {
                g.FillRectangle(Brushes.Green, Tile[i]);
                g.DrawRectangle(Pens.Black, Tile[i]);
                Debug.WriteLine(Tile[i]);
            }
            
        }
    }
}
