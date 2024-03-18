using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form2 : Form
    {
        private Button btn;
        private Button btn2;
        private TextBox TextBox;
        private bool isClose = false;
        void createBtn(Button btn, int x, int y, int sizeX, int sizeY, Color color, Color backColor, Color borderColor, string name)
        {
            btn.Size = new Size(sizeX, sizeY);
            btn.Location = new Point(x, y);
            btn.Text = name;
            btn.BackColor = backColor; //black
            btn.ForeColor = color; // white
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = borderColor;
            btn.FlatAppearance.BorderSize = 0;
            Controls.Add(btn);
            //btn.Click += new EventHandler(click);
        }
        private int index = 1;

        private Button doneBtn;
        private PictureBox man;
        private List<string> array = new List<string>();

        private PictureBox back;
        private PictureBox back3;
        private PictureBox back2;
        public Form2()
        {
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(500, 400); //form size
            BackColor = Color.Gray;//form color
            Load += Form2_Load;
            this.Icon = new Icon("./1234.ico");
            Text = "מסך הבחירה";
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.FormClosing += Form2_FormClosing;

            array.Add("./man.png");
            array.Add("./man1.png");
            array.Add("./man2.png");
            array.Add("./man3.png");
            array.Add("./man4.png");
            array.Add("./man5.png");
            array.Add("./man6.png");
            array.Add("./man7.png");

            TextBox = new TextBox();
            TextBox.Location = new Point(52, 105);
            TextBox.Size = new Size(100, 20);
            TextBox.BackColor = Color.White;

            Controls.Add(TextBox);

            man = new PictureBox();
            man.Location = new Point(75, 155);
            man.Size = new Size(50, 80);
            man.Image = Image.FromFile("./man.png");
            //man.Click += (sender, EventArgs) => { mon_Click(sender, EventArgs, 0); };
            
            Controls.Add(man);
            

            btn = new Button();
            createBtn(btn, 2, 150, 50, 50, Color.Black, Color.White, Color.Black, "<");
            btn.Click += new EventHandler(left_click);

            btn2 = new Button();
            createBtn(btn2, 152, 150, 50, 50, Color.Black, Color.White, Color.Black, ">");
            btn2.Click += new EventHandler(right_click);

            doneBtn = new Button();
            createBtn(doneBtn, 77, 250, 50, 25, Color.Black, Color.White, Color.Black, "Done");
            doneBtn.Click += new EventHandler(done_click);

            Controls.Add(btn);
            Controls.Add(btn2);
            StaticSave.form.Hide();

            back = new PictureBox();
            back.Location = new Point(-10, 100);
            back.Size = new Size(220, 200);
            back.Image = Image.FromFile("./background.png");
            Controls.Add(back);

            back2 = new PictureBox();
            back2.Location = new Point(0, 0);
            back2.Size = new Size(500, 400);
            back2.Image = Image.FromFile("./Screen.png");
            Controls.Add(back2);

            back3 = new PictureBox();
            back3.Location = new Point(5, 100);
            back3.Size = new Size(200, 200);
            back3.Image = Image.FromFile("./background.png");
            Controls.Add(back3);

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

        void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if(!isClose)
                {
                    StaticSave.form3.Close();
                }
                
                
            }


            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
               
                StaticSave.form3.Close();
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            TransparetBackground(man);
            
        }

        private void right_click(object sender, EventArgs e)
        {
            if(index != 6)
            {
                index += 1;
            }
            else
            {
                index = 0;
            }
            man.Image = Image.FromFile(array[index]);
            StaticSave.man.Image = Image.FromFile(array[index]);
            TransparetBackground(man);
        }
        private void left_click(object sender, EventArgs e)
        {
            if(index != 0)
            {
                index -= 1;
            }else
            {
                index = 6;
            }
            man.Image = Image.FromFile(array[index]);
            StaticSave.man.Image = Image.FromFile(array[index]);
            TransparetBackground(man);
        }
        private void done_click(object sender, EventArgs e)
        {
            isClose = true;
            if (TextBox.Text.Length >= 10)
            {
                MessageBox.Show("Name must be shorter then 10 letters");
            }else
            {
                if (TextBox.Text == "")
                {
                    StaticSave.name.Text = "ROB-E";
                }
                else
                {
                    StaticSave.name.Text = TextBox.Text;

                    if (StaticSave.name.Text.Length >= 5)
                    {
                        StaticSave.name.Font = new Font("Ariel", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    }

                    if (StaticSave.name.Text.Length >= 7)
                    {
                        StaticSave.name.Font = new Font("Ariel", 7F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    }

                }


                StaticSave.form.Show();
                this.Close();
            }

           
        }
    }
}
