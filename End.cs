using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class End : Form
    {
        private PictureBox pic;
        private Label lbl;
        public End()
        {
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(500, 500);
            FormClosing += Form_Closing;
            Load += Form1_Load;
            this.Icon = new Icon("./1234.ico");
            Text = "מסך סיום";
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            BackColor = Color.DarkSlateBlue;

            lbl = new Label();
            lbl.AutoSize = true;
            lbl.Font = new Font("Ariel", 20F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            if(StaticSave.name.Text.Length > 5)
            {
                lbl.Location = new Point(200, 330); //location label
            }else
            {
                lbl.Location = new Point(250, 330); //location label
            }
            
            lbl.Text = StaticSave.name.Text + "";
            lbl.ForeColor = Color.Black;
            lbl.Visible = true;
            Controls.Add(lbl);

            pic = new PictureBox();
            pic.Location = new Point(0, 0);
            pic.Size = new Size(500, 500);
            pic.Image = Image.FromFile("./END.png");
            pic.Visible = true;
            Controls.Add(pic);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TransparetBackground(lbl);
        }

        void TransparetBackground(Control C)
        {
            C.Visible = false;

            C.Refresh();
            Application.DoEvents();


            Rectangle screenRectangle = RectangleToScreen(this.ClientRectangle);
            int titleHeight = screenRectangle.Top - this.Top;
            int Right = screenRectangle.Left - this.Left;

            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
            Bitmap bmpImage = new Bitmap(bmp);
            bmp = bmpImage.Clone(new Rectangle(C.Location.X + Right, C.Location.Y + titleHeight, C.Width, C.Height), bmpImage.PixelFormat);
            C.BackgroundImage = bmp;

            C.Visible = true;
        }

        void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Prompt user to save his data
                StaticSave.form3.Close();
            }


            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                // Autosave and clear up ressources
                StaticSave.form3.Close();
            }

        }
    }
}
