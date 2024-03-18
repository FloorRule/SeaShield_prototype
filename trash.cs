using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    class trash
    {

        private PictureBox part1;
        private PictureBox part2;
        private bool is_picked = false;

        public trash(Point point, Size size, Image image, Point point2, Size size2, Image image2)
        {
            part1 = new PictureBox();
            part1.Location = new Point(point.X, point.Y);
            part1.Size = new Size(size.Width, size.Height);
            part1.Image = image;
            part1.Visible = true;

            part2 = new PictureBox();
            part2.Location = new Point(point2.X, point2.Y);
            part2.Size = new Size(size2.Width, size2.Height);
            part2.Image = image2;
            part2.Visible = true;
        }

        public PictureBox getP1()
        {
            return part1;
        }

        public PictureBox getP2()
        {
            return part2;
        }

        public void setP1(Image newer)
        {
            part1.Image = newer;
        }

        public void setP2(Image newer)
        {
            part2.Image = newer;
        }
        public void setBad(bool isbad)
        {
            is_picked = isbad;
        }

        public bool getBad()
        {
            return is_picked;
        }
    }
}
