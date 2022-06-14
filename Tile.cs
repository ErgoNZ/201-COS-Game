using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Grid_based_map
{
    class Tile
    {
        public Rectangle Tiles;
        
        public void DrawTile(Graphics g)
        {
            Tiles = new Rectangle(0, 0, 200, 200);
            g.FillRectangle(Brushes.Green,Tiles);
            g.DrawRectangle(Pens.Black, Tiles);
        }

    }
}
