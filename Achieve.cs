using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    class Achieve
    {
        private bool isDone = false;
        private bool isCollect = false;

        private Label lblRequirement;
        private Label lblPrize;
        private Label lblMark;

        private PictureBox butttonPic;
        private PictureBox butttonPicBack;
        private PictureBox ItemPic;

        private string state;
        private string path;
        private int _exp;

        private string pPath;
        private Size pSize;
        public Achieve(Point mainPoint, string require, string prize, string prizePath, string statement, int exp, string personPrizePath, Size sizeofPrize)
        {
            state = statement;
            path = prizePath;
            _exp = exp;
            pPath = personPrizePath;
            pSize = sizeofPrize;

            butttonPic = new PictureBox();
            butttonPic.Location = mainPoint; //268, 12
            butttonPic.Size = new Size(315, 70);
            butttonPic.Image = Image.FromFile("./AchievementBut.png");
            butttonPic.Visible = true;
            //butttonPic.Click += new EventHandler(hat_Click);

            butttonPicBack = new PictureBox();
            butttonPicBack.Location = mainPoint;
            butttonPicBack.Size = new Size(315, 70);
            butttonPicBack.Image = Image.FromFile("./AchievementBut.png");

            lblMark = new Label();
            lblMark.AutoSize = true;
            lblMark.Font = new Font("Ariel", 15F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            lblMark.Location = new Point(mainPoint.X+82, mainPoint.Y+23); //location label 
            lblMark.Text = "X";
            lblMark.ForeColor = Color.Crimson;

            lblRequirement = new Label();
            lblRequirement.AutoSize = true;
            lblRequirement.Font = new Font("Ariel", 15F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            lblRequirement.Location = new Point(mainPoint.X + 148, mainPoint.Y +5); //location label
            lblRequirement.Text = require;
            lblRequirement.ForeColor = Color.White;

            lblPrize = new Label();
            lblPrize.AutoSize = true;
            lblPrize.Font = new Font("Ariel", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            lblPrize.Location = new Point(mainPoint.X + 132, mainPoint.Y + 38); //location label
            lblPrize.Text = prize;
            lblPrize.ForeColor = Color.Black;

            ItemPic = new PictureBox();
            ItemPic.Location = new Point(mainPoint.X + 7, mainPoint.Y +7);
            ItemPic.Size = new Size(62, 55);
            ItemPic.Image = Image.FromFile(prizePath);
            ItemPic.Visible = true;
            //ItemPic.Click += new EventHandler(hat_Click);
            
        }

        public bool isCompleted(int score, int trash, int pep)
        {
            //t-100+s-100
            string[] lines;
            string[] words1;
            string[] words2;
            bool value = false;

            if (state.Contains("+"))
            {
                lines = state.Split("+");

                words1 = lines[0].Split("-");
                words2 = lines[1].Split("-");
                if(trash >= int.Parse(words1[1]) && score >= int.Parse(words2[1]))
                {
                    //isDone = true;
                    value = true;
                }
            }else
            {
                words1 = state.Split("-");
                if(words1[0] == "t")
                {
                    if(trash >= int.Parse(words1[1]))
                    {
                        //isDone = true;
                        value = true;
                    }
                }else if(words1[0] == "p")
                {
                    if (pep >= int.Parse(words1[1]))
                    {
                        //isDone = true;
                        value = true;
                    }
                }
                else
                {
                    if (score >= int.Parse(words1[1]))
                    {
                        //isDone = true;
                        value = true;
                    }
                }
            }
            return value;
        }

        public Size GetSize()
        {
            return pSize;
        }

        public string GetPathP()
        {
            return pPath;
        }

        public int getExp()
        {
            return this._exp;
        }
        public string getPath()
        {
            return this.path;
        }

        public bool getDone()
        {
            return this.isDone;
        }

        public bool getCollected()
        {
            return this.isCollect;
        }

        public void setCollected(bool b)
        {
            this.isCollect = b;
        }

        public void setDone(bool b)
        {
            this.isDone = b;
        }

        public PictureBox GetPictureFront()
        {
            return this.butttonPic;
        }

        public PictureBox GetPictureBack()
        {
            return this.butttonPicBack;
        }

        public PictureBox GetItemPicture()
        {
            return this.ItemPic;
        }

        public Label GetLabelR()
        {
            return this.lblRequirement;
        }

        public Label GetLabelP()
        {
            return this.lblPrize;
        }

        public Label GetLabelM()
        {
            return this.lblMark;
        }
        public void SetLabelM(string line)
        {
            lblMark.Text = line;
        }

        public void setColorLabelM(Color color)
        {
            lblMark.ForeColor = color;
        }


    }
}
