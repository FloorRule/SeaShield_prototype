using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    class Person
    {

        private PictureBox part1;
        private PictureBox part2;
        private bool is_picked = true;
        private Label lbl;

        public Person(Point point, Size size, Image image, Point point2, Size size2, Image image2)
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

            lbl = new Label();
            lbl.AutoSize = true;
            lbl.Font = new Font("Ariel", 20F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            lbl.Location = new Point(point.X+15, point.Y-25); //location label
            lbl.Text = "!";
            lbl.ForeColor = Color.Crimson;
            lbl.Visible = true;
            
        }

        public Label getlb()
        {
            return lbl;
        }

        public void setlb(string name)
        {
            lbl.Text = name;
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
