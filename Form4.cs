using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form4 : Form
    {
       
        private List<Achieve> achieves = new List<Achieve>();

        private PictureBox picture;

        private PictureBox man;
        private PictureBox hat;
        
        private Label lblExp;
        private Label lbllvl;

        private Label removeHat;

        public Form4()
        {
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(600, 400); //form size
            BackColor = Color.DarkGray;//form color
            Load += Form4_Load;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            this.Icon = new Icon("./1234.ico");
            Text = "יומן המשימות";
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            man = new PictureBox();
            man.Location = new Point(100, 100);
            man.Size = new Size(50, 80);
            man.Image = StaticSave.man.Image;
            //man.Click += (sender, EventArgs) => { mon_Click(sender, EventArgs, 0); };
           
            if(!StaticSave.isHat)
            {
                hat = new PictureBox();
                hat.Location = new Point(110, 40);
                hat.Size = new Size(StaticSave.hat.Image.Width, StaticSave.hat.Image.Height);
                hat.Image = StaticSave.hat.Image;
            }else
            {
                if(StaticSave.lastHat == 0)
                {
                    hat = new PictureBox();
                    hat.Location = new Point(man.Location.X + 7, man.Location.Y - 20);
                    hat.Size = new Size(StaticSave.hat.Image.Width, StaticSave.hat.Image.Height);
                    hat.Image = StaticSave.hat.Image;
                }
                else if(StaticSave.lastHat == 1)
                {
                    hat = new PictureBox();
                    hat.Location = new Point(man.Location.X + 12, man.Location.Y - 8);
                    hat.Size = new Size(StaticSave.hat.Image.Width, StaticSave.hat.Image.Height);
                    hat.Image = StaticSave.hat.Image;
                }
                

            }
            
            //man.Click += (sender, EventArgs) => { mon_Click(sender, EventArgs, 0); };

            Controls.Add(hat);
            Controls.Add(man);
            TransparetBackground(hat);
            TransparetBackground(man);

            int y = 12;
            achieves.Add(new Achieve(new Point(267, y), "להשיג 220 בניקוד", "פרס: 100 נקודות ניסיון + כובע", "./AchievementCap.png", "s-220", 100, "./AchievementCapU.png", new Size(36,33)));
            y += 75;
            achieves.Add(new Achieve(new Point(267, y), "לאסוף 50 אשפה", "פרס: 50 נקודות ניסיון + כובע", "./AchievementCap2.png", "t-50", 50, "./AchievementCapU24.png", new Size(26, 23)));
            y += 75;
            achieves.Add(new Achieve(new Point(267, y), "תעזור ל2 אנשים", "פרס: 100 נקודות ניסיון", "./AchievementCap3.png", "p-2", 100, "./AchievementCapU3.png", new Size(26, 23)));
            y += 75;
            achieves.Add(new Achieve(new Point(267, y), "תעזור ל4 אנשים", "פרס: 200 נקודות ניסיון", "./AchievementCap3.png", "p-4", 200, "./AchievementCapU3.png", new Size(26, 23)));
            y += 75;
            achieves.Add(new Achieve(new Point(267, y), "להשיג 600 בניקוד", "פרס: 500 נק'נ + תעודת מגן ים", "./AchievementCap3.png", "s-600", 500, "./AchievementCapU3.png", new Size(26, 23)));

            for (int i = 0; i < StaticSave.achievCompNotTaken.Count; i++)
            {
                for (int j = 0; j < achieves.Count; j++)
                {
                    if (StaticSave.achievCompNotTaken[i] == j)
                    {
                        achieves[j].setDone(true);
                    }
                }
            }
            StaticSave.achievCompNotTaken.Clear();
            for (int i = 0; i < achieves.Count; i++)
            {
                //MessageBox.Show(achieves[i].isCompleted(Form1.score, Form1.trash).ToString() + " " + achieves[i].getDone().ToString());
                if (achieves[i].isCompleted(Form1.score, Form1.trash, Form1.pep) || achieves[i].getDone())
                {
                    achieves[i].SetLabelM("✓");
                    achieves[i].setColorLabelM(Color.ForestGreen);
                    Controls.Add(achieves[i].GetLabelM());
                    achieves[i].setDone(true);

                    StaticSave.achievCompNotTaken.Add(i);
                }
                else
                {
                    achieves[i].SetLabelM("X");
                    achieves[i].setColorLabelM(Color.Crimson);
                    Controls.Add(achieves[i].GetLabelM());
                }



                Controls.Add(achieves[i].GetLabelR());
                Controls.Add(achieves[i].GetLabelP());
                if(i == 0)
                {
                    achieves[i].GetItemPicture().Click += (sender, EventArgs) => { hat_Click(sender, EventArgs, 0); };
                    achieves[i].GetPictureFront().Click += (sender, EventArgs) => { hat_Click(sender, EventArgs, 0); };
                }else if(i == 1)
                {
                    achieves[i].GetItemPicture().Click += (sender, EventArgs) => { hat_Click(sender, EventArgs, 1); };
                    achieves[i].GetPictureFront().Click += (sender, EventArgs) => { hat_Click(sender, EventArgs, 1); };
                }else if(i == 2)
                {
                    achieves[i].GetItemPicture().Click += (sender, EventArgs) => { hat_Click(sender, EventArgs, 2); };
                    achieves[i].GetPictureFront().Click += (sender, EventArgs) => { hat_Click(sender, EventArgs, 2); };
                }
                else if (i == 3)
                {
                    achieves[i].GetItemPicture().Click += (sender, EventArgs) => { hat_Click(sender, EventArgs, 3); };
                    achieves[i].GetPictureFront().Click += (sender, EventArgs) => { hat_Click(sender, EventArgs, 3); };
                }
                else if (i == 4)
                {
                    achieves[i].GetItemPicture().Click += (sender, EventArgs) => { hat_Click(sender, EventArgs, 4); };
                    achieves[i].GetPictureFront().Click += (sender, EventArgs) => { hat_Click(sender, EventArgs, 4); };
                }


                Controls.Add(achieves[i].GetItemPicture());

                
                Controls.Add(achieves[i].GetPictureFront());
            }
            


            lblExp = new Label();
            lblExp.AutoSize = true;
            lblExp.Font = new Font("Ariel", 13F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            lblExp.Location = new Point(15, 320); //location label
            lblExp.Text = StaticSave.exp.ToString() + " / "+ StaticSave.expMax + " " + ":נקודות ניסיון";
            lblExp.ForeColor = Color.Black;
            lblExp.Visible = true;
            Controls.Add(lblExp);

            lbllvl = new Label();
            lbllvl.AutoSize = true;
            lbllvl.Font = new Font("Ariel", 15F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            lbllvl.Location = new Point(170, 290); //location label
            lbllvl.Text = StaticSave.lvl+" :רמה";
            lbllvl.ForeColor = Color.Black;
            Controls.Add(lbllvl);


            removeHat = new Label();
            removeHat.AutoSize = true;
            removeHat.Font = new Font("Ariel", 35F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            removeHat.Location = new Point(190, 210); //location label
            removeHat.Text = "X";
            removeHat.ForeColor = Color.Crimson;
            removeHat.Click += new EventHandler(remove_hat_Click);
            Controls.Add(removeHat);

            picture = new PictureBox();
            picture.Location = new Point(0, 0);
            picture.Size = new Size(600, 400);
            picture.Image = Image.FromFile("./Achievement.png");
            picture.Visible = true;
            Controls.Add(picture);

            for (int i = 0; i < achieves.Count; i++)
            {
                Controls.Add(achieves[i].GetPictureBack());
            }


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

        private void Form4_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < achieves.Count; i++)
            {
                TransparetBackground(achieves[i].GetLabelP());
                TransparetBackground(achieves[i].GetLabelR());
                TransparetBackground(achieves[i].GetLabelM());
            }
            TransparetBackground(lblExp);
            TransparetBackground(lbllvl);
            TransparetBackground(removeHat);
        }

        private void remove_hat_Click(object sender, EventArgs e)
        {
            hat.Visible = false;
            StaticSave.hat.Visible = false;
            StaticSave.name.Location = new Point(StaticSave.man.Location.X, StaticSave.man.Location.Y -25);
            StaticSave.hat.Image = Image.FromFile("./Empty.png");
        }

        private void hat_Click(object sender, EventArgs e, int index)
        {
            bool isAlreadyClaimed = false;

            for (int i = 0; i < StaticSave.achievComp.Count; i++)
            {
                if(StaticSave.achievComp[i] == index)
                {
                    isAlreadyClaimed = true;
                }
            }

            if(achieves[index].getDone())
            {
                if(index == 0)
                {
                    hat.Location = new Point(man.Location.X + 7, man.Location.Y - 20);
                    StaticSave.hat.Location = new Point(StaticSave.man.Location.X + 7, StaticSave.man.Location.Y - 20);
                }
                else if(index == 1)
                {
                    hat.Location = new Point(man.Location.X + 12, man.Location.Y - 8);
                    StaticSave.hat.Location = new Point(StaticSave.man.Location.X + 12, StaticSave.man.Location.Y - 8);
                }
                if (index <= 1)
                {
                    hat.Size = achieves[index].GetSize();
                    hat.Image = Image.FromFile(achieves[index].GetPathP());
                    TransparetBackground(hat);

                    StaticSave.hat.Size = achieves[index].GetSize();
                    StaticSave.hat.Image = Image.FromFile(achieves[index].GetPathP());


                    StaticSave.hat.Visible = true;
                    StaticSave.isHat = true;

                    StaticSave.name.Location = new Point(StaticSave.man.Location.X, StaticSave.man.Location.Y + 80);
                }

                if(isAlreadyClaimed == false)
                {
                    StaticSave.exp += achieves[index].getExp();
                    while(StaticSave.exp >= StaticSave.expMax)
                    {
                        StaticSave.expMax = StaticSave.expMax * 2;
                        StaticSave.lvl += 1;
                        
                    }
                    TransparetBackground(lbllvl);
                }

                lbllvl.Text = StaticSave.lvl + " :רמה";
                lblExp.Text = StaticSave.exp.ToString() + " / " + StaticSave.expMax + " " + ":נקודות ניסיון";
                TransparetBackground(lblExp);
                achieves[index].setCollected(true);
                StaticSave.lastHat = index;
                StaticSave.achievComp.Add(index);

                if(index == 4)
                {
                    End f = new End();
                    f.Show();
                    StaticSave.form.Enabled = false;
                    this.Close();
                }
            }
            
        }
    }
}
