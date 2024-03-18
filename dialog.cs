using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class dialog : Form
    {
        private PictureBox pic;
        private Label lbl;
        public dialog()
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(550, 50);
            ClientSize = new Size(500, 600);
            FormClosing += Form_Closing;
            Text = "מסך הסברה";
            this.Icon = new Icon("./1234.ico");
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            BackColor = Color.DarkSlateBlue;

            lbl = new Label();
            lbl.AutoSize = true;
            lbl.Font = new Font("Ariel", 20F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            if (StaticSave.name.Text.Length > 5)
            {
                lbl.Location = new Point(200, 20); //location label
            }
            else
            {
                lbl.Location = new Point(250, 20); //location label
            }
            lbl.Text = StaticSave.name.Text + "";
            lbl.ForeColor = Color.Black;
            lbl.Visible = true;
            Controls.Add(lbl);

            pic = new PictureBox();
            pic.Location = new Point(0, 0);
            pic.Size = new Size(500, 600);
            pic.Image = Image.FromFile("./dia.png");
            pic.Visible = true;
            Controls.Add(pic);

        }

        void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Prompt user to save his data
                StaticSave.form.Enabled = true;
                StaticSave.isTalked = true;

            }


            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                // Autosave and clear up ressources

                StaticSave.form3.Close();

            }

        }
    }
}
