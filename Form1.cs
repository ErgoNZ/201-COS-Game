using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grid_based_map
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int[,,] Tiles = new int[5, 5, 2]
            {
                { {1,3},{2,3},{4, 5},{6,7},{25,10} },
                { { 1, 2},{7,2},{6,7},{17,8},{267,321} },
                { { 6,4},{2,1},{12,2},{23,543},{134,6546} },
                { { 2,6},{4,8},{4,9},{123,546},{234,234} },
                { { 7,3},{1,2},{3,5},{1267,1254},{467,615} }
            };
        }

    }
}
