using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainProject;

namespace TrainProject
{
    public partial class Map : Form
    {
        int x, y;
        Pair[] blocks;
        Bitmap buffer;
        public Map()
        {
            InitializeComponent();
            x = 55;
            y = 155;
            buffer = new Bitmap(mapPanel.Width, mapPanel.Height);
            //Paint += new PaintEventHandler(Map_Paint_Initial);
            //Paint += new PaintEventHandler(Map_Paint);
            blocks = new Pair[78];
            drawMap();
        }
        /*private void Map_Paint_Initial(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Red, 50, 150, 20, 20);
            blocks[77] = new Pair(50, 150);
            e.Graphics.FillRectangle(Brushes.Red, 65, 150, 20, 20);
            blocks[9] = new Pair(65, 150);
            e.Graphics.FillRectangle(Brushes.Red, 80, 150, 20, 20);
            blocks[8] = new Pair(80, 150);
            e.Graphics.FillRectangle(Brushes.Red, 95, 150, 20, 20);
            blocks[7] = new Pair(95, 150);
            e.Graphics.FillRectangle(Brushes.Red, 110, 150, 20, 20);
            blocks[6] = new Pair(110, 150);
            e.Graphics.FillRectangle(Brushes.Red, 125, 150, 20, 20);
            blocks[5] = new Pair(125, 150);
            e.Graphics.FillRectangle(Brushes.Red, 140, 150, 20, 20);
            blocks[4] = new Pair(140, 150);

        }
        private void Map_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Blue, x, y, 10, 10);
        }*/

        private void drawMap()
        {
            using (Graphics e = Graphics.FromImage(buffer))
            {
                e.DrawRectangle(Pens.Red, 50, 150, 20, 20);
                blocks[77] = new Pair(50, 150);
                e.DrawRectangle(Pens.Red, 65, 150, 20, 20);
                blocks[9] = new Pair(65, 150);
                e.DrawRectangle(Pens.Red, 80, 150, 20, 20);
                blocks[8] = new Pair(80, 150);
                e.DrawRectangle(Pens.Red, 95, 150, 20, 20);
                blocks[7] = new Pair(95, 150);
                e.DrawRectangle(Pens.Red, 110, 150, 20, 20);
                blocks[6] = new Pair(110, 150);
                e.DrawRectangle(Pens.Red, 125, 150, 20, 20);
                blocks[5] = new Pair(125, 150);
                e.DrawRectangle(Pens.Red, 140, 150, 20, 20);
                blocks[4] = new Pair(140, 150);

                e.DrawRectangle(Pens.Blue, x, y, 10, 10);
                mapPanel.BackgroundImage = buffer;
            }
        }

        public void updateBlock(int blockID)
        {
            x = blocks[blockID].x_ + 5;
            y = blocks[blockID].y_ + 5;
            //Paint += new PaintEventHandler(Map_Paint_Initial);
            //Paint += new PaintEventHandler(Map_Paint);
            Invalidate();
            drawMap();
            
        }
    }
}
