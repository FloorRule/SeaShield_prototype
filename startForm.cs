using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class startForm : Form
    {
        private Button playBut;
        private Button quitBut;
        private Button loadBut;
        private bool isClose = false;

        private PictureBox pic;
        public startForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(600, 500);
            FormClosing += FormStart_FormClosing;
            BackColor = Color.LightBlue;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Text = "מסך פתיחה";
            this.Icon = new Icon("./1234.ico");

            pic = new PictureBox();
            pic.Location = new Point(220, 0);
            pic.Size = new Size(150, 210);
            pic.Image = Image.FromFile("./Title.png");
            pic.Visible = true;
            Controls.Add(pic);

            playBut = new Button();
            playBut.Text = "Start New Game";
            playBut.Size = new Size(100, 40);
            playBut.Location = new Point(240, 220);
            playBut.ForeColor = Color.Black;
            playBut.BackColor = Color.AliceBlue;
            playBut.Click += new EventHandler(play_click);
            Controls.Add(playBut);

            quitBut = new Button();
            quitBut.Text = "Quit";
            quitBut.Size = new Size(100, 40);
            quitBut.Location = new Point(240, 330);
            quitBut.ForeColor = Color.Black;
            quitBut.BackColor = Color.AliceBlue;
            quitBut.Click += new EventHandler(quit_click);
            Controls.Add(quitBut);

            StaticSave.form.Hide();

        }

        private void quit_click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void play_click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            isClose = true;
            this.Close();
        }

        void FormStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Prompt user to save his data
                if(!isClose)
                {
                    StaticSave.form3.Close();
                }
               
            }


            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                // Autosave and clear up ressources
                
                StaticSave.form3.Close();
                
            }

        }
    }
}
