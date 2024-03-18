using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        //beach
        private PictureBox beach;

        //displays
        private PictureBox AchBut;
        private Label scoreDisplay;
        private PictureBox tooltip;
        private PictureBox tooltip2;

        //score
        public static int score = 0;
        public static int trash = 0;
        public static int pep = 0;

        //blocks
        private Parents blockX;
        private Parents blockMX;
        private Parents blockY;
        private Parents blockMY;
        private Parents fenceOne;
        private Parents fenceTwo;
        private Parents fenceTwo2;
        private Parents fenceTwo3;

        private Parents charge1;
        private Parents charge2;
        private Parents charge3;

        //lists
        private List<Parents> allParents = new List<Parents>();
        private List<Parents> allblocks = new List<Parents>();
        private List<trash> allTrash = new List<trash>();

        private List<Person> people = new List<Person>();

        //stand
        private PictureBox stand;
        private PictureBox stand2;
        private PictureBox chalullGuy;

        //points
        private Label trashPoints;

        //edge
        private bool isUpdate = false;
        public Form1()
        {
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(700, 600); //form size
            BackColor = Color.Wheat;//form color
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Load += Form1_Load;
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.FormClosing += Form1_FormClosing;
            Text = "המשחק";
            this.Icon = new Icon("./1234.ico");

            trashPoints = new Label();
            trashPoints.AutoSize = true;
            trashPoints.Font = new Font("Ariel", 8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            trashPoints.Text = "+10";
            trashPoints.ForeColor = Color.DarkGreen;
            trashPoints.Visible = false;
            

            scoreDisplay = new Label();
            scoreDisplay.AutoSize = true;
            scoreDisplay.Font = new Font("Ariel", 20F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            scoreDisplay.Location = new Point(50, 5); //location label
            scoreDisplay.Text = ": " + score.ToString() + "\n\n: " + trash.ToString();
            scoreDisplay.ForeColor = Color.Black;
            scoreDisplay.Visible = true;
            Controls.Add(scoreDisplay);


            tooltip2 = new PictureBox();
            tooltip2.Location = new Point(0, 0);
            tooltip2.Size = new Size(46, 107);
            tooltip2.Image = Image.FromFile("./StarAndT.png");
            tooltip2.Visible = true;
            Controls.Add(tooltip2);

            AchBut = new PictureBox();
            AchBut.Location = new Point(314, 545);
            AchBut.Size = new Size(62, 55);
            AchBut.Image = Image.FromFile("./AchievementButton.png");
            AchBut.Click += new EventHandler(Click_Key);
            AchBut.Visible = false;
            Controls.Add(AchBut);


            tooltip = new PictureBox();
            tooltip.Location = new Point(129, 535);
            tooltip.Size = new Size(441, 69);
            tooltip.Image = Image.FromFile("./UI.png");
            tooltip.Visible = true;
            Controls.Add(tooltip);


            people.Add(new Person(new Point(700, 100), new Size(50, 80), Image.FromFile("./manQ.jpg"), new Point(700, 100), new Size(50, 80), Image.FromFile("./manQ.jpg")));
            people.Add(new Person(new Point(100, 800), new Size(50, 80), Image.FromFile("./manQ.jpg"), new Point(100, 800), new Size(50, 80), Image.FromFile("./manQ.jpg")));
            people.Add(new Person(new Point(1000, 400), new Size(50, 80), Image.FromFile("./manQ.jpg"), new Point(1000, 400), new Size(50, 80), Image.FromFile("./manQ.jpg")));
            people.Add(new Person(new Point(800, 800), new Size(50, 80), Image.FromFile("./manQ.jpg"), new Point(800, 800), new Size(50, 80), Image.FromFile("./manQ.jpg")));
            people.Add(new Person(new Point(0, 1000), new Size(50, 80), Image.FromFile("./manQ.jpg"), new Point(0, 1000), new Size(50, 80), Image.FromFile("./manQ.jpg")));
            for (int i = 0; i < people.Count; i++)
            {
                Controls.Add(people[i].getlb());
                try
                {
                    TransparetBackground(people[i].getlb());
                }
                catch { }
                
            }
            
            


            StaticSave.name = new Label();
            StaticSave.name.AutoSize = true;
            
            StaticSave.name.Font = new Font("Ariel", 15F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            StaticSave.name.Location = new Point(300, 25); //location label
            StaticSave.name.Text = "OCB";
            StaticSave.name.ForeColor = Color.Black;
            StaticSave.name.Visible = true;
            Controls.Add(StaticSave.name);

            StaticSave.hat = new PictureBox();
            StaticSave.hat.Location = new Point(300, 0);
            StaticSave.hat.Size = new Size(62, 55);
            StaticSave.hat.Image = Image.FromFile("./Empty.png");
            StaticSave.hat.Visible = false;
            Controls.Add(StaticSave.hat);

            Controls.Add(trashPoints);

            StaticSave.man = new PictureBox();
            StaticSave.man.Location = new Point(300, 50);
            StaticSave.man.Size = new Size(50, 80);
            StaticSave.man.Image = Image.FromFile("./man.png");
            StaticSave.man.Visible = true;
            Controls.Add(StaticSave.man);

            stand = new PictureBox();
            stand.Location = new Point(50, 100);
            stand.Size = new Size(150, 110);
            stand.Image = Image.FromFile("./stand.png");
            Controls.Add(stand);

            

            for (int i = 0; i < people.Count; i++)
            {
                Controls.Add(people[i].getP1());
            }

            generate_Random_Trash_Part1(50);
            generate_Random_Table_Part1(10);

            { 
                blockX = new Parents(new Point(0, 0), new Size(25, 1799), Image.FromFile("./picnic3.png"), new Point(25, 600), new Size(115, 75), Image.FromFile("./picnic3.png"));
                allblocks.Add(blockX);
                Controls.Add(blockX.getP1());

                blockY = new Parents(new Point(0, 0), new Size(2100, 25), Image.FromFile("./picnic3.png"), new Point(600, 25), new Size(115, 75), Image.FromFile("./picnic3.png"));
                allblocks.Add(blockY);
                Controls.Add(blockY.getP1());

                blockMX = new Parents(new Point(2100, 0), new Size(25, 1799), Image.FromFile("./picnic3.png"), new Point(2100, 0), new Size(115, 75), Image.FromFile("./picnic3.png"));
                allblocks.Add(blockMX);
                Controls.Add(blockMX.getP1());

                blockMY = new Parents(new Point(0, 1299), new Size(2100, 25), Image.FromFile("./picnic3.png"), new Point(0, 1299), new Size(115, 75), Image.FromFile("./picnic3.png"));
                allblocks.Add(blockMY);
                Controls.Add(blockMY.getP1());

                fenceOne = new Parents(new Point(0, 375), new Size(500, 80), Image.FromFile("./picnic3.png"), new Point(0, 375), new Size(115, 75), Image.FromFile("./picnic3.png"));
                allblocks.Add(fenceOne);
                Controls.Add(fenceOne.getP1());

                fenceTwo = new Parents(new Point(475, 270), new Size(75, 105), Image.FromFile("./picnic3.png"), new Point(475, 270), new Size(1, 1), Image.FromFile("./picnic3.png"));
                allblocks.Add(fenceTwo);
                Controls.Add(fenceTwo.getP1());

                fenceTwo2 = new Parents(new Point(400, 330), new Size(75, 40), Image.FromFile("./picnic3.png"), new Point(400, 330), new Size(1, 1), Image.FromFile("./picnic3.png"));
                allblocks.Add(fenceTwo2);
                Controls.Add(fenceTwo2.getP1());
                
                fenceTwo3 = new Parents(new Point(550, 0), new Size(120, 400), Image.FromFile("./picnic3.png"), new Point(550, 0), new Size(1, 1), Image.FromFile("./picnic3.png"));
                allblocks.Add(fenceTwo3);
                Controls.Add(fenceTwo3.getP1());

                charge1 = new Parents(new Point(230, 50), new Size(45, 80), Image.FromFile("./picnic3.png"), new Point(230, 50), new Size(1, 1), Image.FromFile("./picnic3.png"));
                allblocks.Add(charge1);
                Controls.Add(charge1.getP1());

                charge2 = new Parents(new Point(375, 50), new Size(50, 80), Image.FromFile("./picnic3.png"), new Point(375, 50), new Size(1, 1), Image.FromFile("./picnic3.png"));
                allblocks.Add(charge2);
                Controls.Add(charge2.getP1());

                charge3 = new Parents(new Point(225, 0), new Size(150, 70), Image.FromFile("./picnic3.png"), new Point(225, 0), new Size(1, 1), Image.FromFile("./picnic3.png"));
                allblocks.Add(charge3);
                Controls.Add(charge3.getP1());

            }

            //1350  54
            beach = new PictureBox();
            beach.Location = new Point(1, 0);
            beach.Size = new Size(2100, 1799);
            beach.Image = Image.FromFile("./fullBeach2.png");

            beach.Visible = true;
            Controls.Add(beach);

            generate_Random_Table_Part2(10);
            for (int i = 0; i < people.Count; i++)
            {
                Controls.Add(people[i].getP2());
            }

            chalullGuy = new PictureBox();
            chalullGuy.Location = new Point(100, 123);
            chalullGuy.Size = new Size(50, 43);
            chalullGuy.Image = Image.FromFile("./guy.png");
            chalullGuy.Visible = true;
            

            stand2 = new PictureBox();
            stand2.Location = new Point(50, 100);
            stand2.Size = new Size(150, 110);
            stand2.Image = Image.FromFile("./stand2.png");
            Controls.Add(stand2);
            Controls.Add(chalullGuy);
            TransparetBackground(stand);


            generate_Random_Trash_Part2(50);

            check_for_trash_around();
            check_for_table_around();
            {
                Controls.Add(blockX.getP2());
                blockX.getP2().Visible = false;
                blockX.getP1().Visible = false;
                blockX.setBad(false);

                Controls.Add(blockY.getP2());
                blockY.getP2().Visible = false;
                blockY.getP1().Visible = false;
                blockY.setBad(false);

                Controls.Add(blockMX.getP2());
                blockMX.getP2().Visible = false;
                blockMX.getP1().Visible = false;
                blockMX.setBad(false);

                Controls.Add(blockMY.getP2());
                blockMY.getP2().Visible = false;
                blockMY.getP1().Visible = false;
                blockMY.setBad(false);

                Controls.Add(fenceOne.getP2());
                fenceOne.getP1().Visible = false;
                fenceOne.getP2().Visible = false;
                fenceOne.setBad(false);

                Controls.Add(fenceTwo.getP2());
                fenceTwo.getP1().Visible = false;
                fenceTwo.getP2().Visible = false;
                fenceTwo.setBad(false);

                Controls.Add(fenceTwo2.getP2());
                fenceTwo2.getP1().Visible = false;
                fenceTwo2.getP2().Visible = false;
                fenceTwo2.setBad(false);

                Controls.Add(fenceTwo3.getP2());
                fenceTwo3.getP1().Visible = false;
                fenceTwo3.getP2().Visible = false;
                fenceTwo3.setBad(false);

                Controls.Add(charge1.getP2());
                charge1.getP1().Visible = false;
                charge1.getP2().Visible = false;
                charge1.setBad(false);

                Controls.Add(charge2.getP2());
                charge2.getP1().Visible = false;
                charge2.getP2().Visible = false;
                charge2.setBad(false);

                Controls.Add(charge3.getP2());
                charge3.getP1().Visible = false;
                charge3.getP2().Visible = false;
                charge3.setBad(false);
            }

        }

        private int size = 25;
        private int sizeMap = 25;

        private void generate_Random_Trash_Part1(int index)
        {
            Random rnd = new Random();
            int numX = 0;
            int numY = 0;

            for (int i = 0; i < index; i++)
            {
                numX = rnd.Next(0, 2050);
                numY = rnd.Next(110, 1150);
                
                while (numX <= 500 && numY <= 600)
                {
                    numX = rnd.Next(0, 2050);
                    numY = rnd.Next(50, 1150);
                }

                trash t = new trash(new Point(numX, numY), new Size(20, 20), Image.FromFile("./trash.jpg"), new Point(numX, numY), new Size(20, 20), Image.FromFile("./trash.jpg"));

                while (is_something_blocking_the_way(t.getP1()))
                {
                    
                    numX = rnd.Next(0, 2050);
                    numY = rnd.Next(50, 1150);
                    while (numX <= 500 && numY <= 600)
                    {
                        numX = rnd.Next(0, 2050);
                        numY = rnd.Next(50, 1150);
                    }
                    
                    t = new trash(new Point(numX, numY), new Size(20, 20), Image.FromFile("./trash.jpg"), new Point(numX, numY), new Size(20, 20), Image.FromFile("./trash.jpg"));
                    
                }
                
                allTrash.Add(new trash(new Point(numX, numY), new Size(1, 1), Image.FromFile("./trash.jpg"), new Point(numX, numY), new Size(1, 1), Image.FromFile("./trash.jpg")));
                Controls.Add(allTrash[i].getP1());
            }
        }

        private void generate_Random_Table_Part1(int index)
        {
            Random rnd = new Random();
            int numX = 0;
            int numY = 0;

            for (int i = 0; i < index; i++)
            {
                numX = rnd.Next(100, 1900);
                numY = rnd.Next(100, 1150);

                while (numX <= 500 && numY <= 600)
                {
                    numX = rnd.Next(100, 1900);
                    numY = rnd.Next(100, 1150);
                }

                Parents t = new Parents(new Point(numX, numY), new Size(115, 75), Image.FromFile("./picnic3.png"), new Point(numX, numY), new Size(115, 75), Image.FromFile("./picnic3.png"));
                
                while (is_something_blocking_the_way(t.getP1()))
                {
                    numX = rnd.Next(100, 1900);
                    numY = rnd.Next(100, 1150);

                    while (numX <= 500 && numY <= 600)
                    {
                        numX = rnd.Next(100, 1900);
                        numY = rnd.Next(100, 1150);
                    }

                    t = new Parents(new Point(numX, numY), new Size(115, 75), Image.FromFile("./picnic3.png"), new Point(numX, numY), new Size(115, 75), Image.FromFile("./picnic3.png"));
                }
                allParents.Add(new Parents(new Point(numX, numY), new Size(1, 1), Image.FromFile("./picnic3.png"), new Point(numX, numY), new Size(1, 1), Image.FromFile("./picnic3.png")));
                Controls.Add(allParents[i].getP1());
                //MessageBox.Show("Done");
            }
        }

        private void generate_Random_Table_Part2(int index)
        {
            for (int i = 0; i < index; i++)
            {
                Controls.Add(allParents[i].getP2());

            }
        }
        private bool is_something_blocking_the_way(Control p)
        {
            int i, x2, y2, x, y;
            for (i = 0; i < people.Count; i++)
            {
                for (x2 = people[i].getP1().Location.X; x2 <= people[i].getP1().Location.X + people[i].getP1().Width; x2++)
                {
                    for (  y2 = people[i].getP1().Location.Y; y2 <= people[i].getP1().Location.Y + people[i].getP1().Height; y2++)
                    {
                        for (  x = p.Location.X; x <= p.Location.X + p.Width; x++)
                        {
                            for (  y = p.Location.Y; y <= p.Location.Y + p.Height; y++)
                            {
                                if (x == x2 && y == y2)
                                {
                                    return true;
                                }
                                
                            }
                        }
                        
                    }
                }
               
                   
            }
            for (  i = 0; i < allParents.Count; i++)
            {
                for (  x2 = allParents[i].getP1().Location.X; x2 <= allParents[i].getP1().Location.X + allParents[i].getP1().Width; x2++)
                {
                    for (  y2 = allParents[i].getP1().Location.Y; y2 <= allParents[i].getP1().Location.Y + allParents[i].getP1().Height; y2++)
                    {
                        for (  x = p.Location.X; x <= p.Location.X + p.Width; x++)
                        {
                            for (  y = p.Location.Y; y <= p.Location.Y + p.Height; y++)
                            {
                                if (x == x2 && y == y2)
                                {
                                    return true;
                                }
                                
                                
                            }
                        }
                    }
                }
            }
            for (  i = 0; i < allTrash.Count; i++)
            {
                for (  x2 = allTrash[i].getP1().Location.X; x2 <= allTrash[i].getP1().Location.X + allTrash[i].getP1().Width; x2++)
                {
                    for (  y2 = allTrash[i].getP1().Location.Y; y2 <= allTrash[i].getP1().Location.Y + allTrash[i].getP1().Height; y2++)
                    {
                        for (  x = p.Location.X; x <= p.Location.X + p.Width; x++)
                        {
                            for (  y = p.Location.Y; y <= p.Location.Y + p.Height; y++)
                            {
                                if (x == x2 && y == y2)
                                {
                                    return true;
                                }
                                
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void generate_Random_Trash_Part2(int index)
        {
            for (int i = 0; i < index; i++)
            {
                Controls.Add(allTrash[i].getP2());
               
            }
        }

        private void check_for_trash_around()
        {
            bool value = false;
            for (int i = 0; i < allTrash.Count; i++)
            {
                for (int x2 = 0; x2 < 700; x2++)
                {
                    for (int y2 = 0; y2 < 600; y2++)
                    {

                        if (allTrash[i].getP1().Location.X == x2 && allTrash[i].getP1().Location.Y == y2)
                        {
                            value = true;
                            allTrash[i].getP1().Size = new Size(20, 20);
                            allTrash[i].getP2().Size = new Size(20, 20);
                        }


                    }
                }
                if(!value)
                {
                    allTrash[i].getP1().Size = new Size(1, 1);
                    allTrash[i].getP2().Size = new Size(1, 1);
                }else
                {
                    value = false;
                }
            }
        }

        private void check_for_table_around()
        {
            bool value = false;
            for (int i = 0; i < allParents.Count; i++)
            {
                for (int x2 = 0; x2 < 700; x2++)
                {
                    for (int y2 = 0; y2 < 600; y2++)
                    {

                        if (allParents[i].getP1().Location.X == x2 && allParents[i].getP1().Location.Y == y2)
                        {
                            value = true;
                            allParents[i].getP1().Size = new Size(115, 75);
                            allParents[i].getP2().Size = new Size(115, 75);
                        }


                    }
                }
                if (!value)
                {
                    allParents[i].getP1().Size = new Size(1, 1);
                    allParents[i].getP2().Size = new Size(1, 1);
                }
                else
                {
                    value = false;
                }
            }
        }
        private void updateMap(bool isX, bool isUp)
        {
            int x = 0;
            int y = 0;
            if (isX)
            {
                if (isUp)
                {
                    for (int i = 0; i < allblocks.Count; i++)
                    {
                        x = allblocks[i].getP1().Location.X + sizeMap;
                        y = allblocks[i].getP1().Location.Y;

                        allblocks[i].getP1().Location = new Point(x, y);

                        x = allblocks[i].getP2().Location.X + sizeMap;
                        y = allblocks[i].getP2().Location.Y;

                        allblocks[i].getP2().Location = new Point(x, y);
                    }

                    for (int i = 0; i < allParents.Count; i++)
                    {
                        x = allParents[i].getP1().Location.X + sizeMap;
                        y = allParents[i].getP1().Location.Y;

                        allParents[i].getP1().Location = new Point(x, y);

                        x = allParents[i].getP2().Location.X + sizeMap;
                        y = allParents[i].getP2().Location.Y;

                        allParents[i].getP2().Location = new Point(x, y);
                    }
                    x = beach.Location.X + sizeMap;
                    y = beach.Location.Y;

                    beach.Location = new Point(x, y);

                    x = StaticSave.man.Location.X + sizeMap;
                    y = StaticSave.man.Location.Y;

                    StaticSave.man.Location = new Point(x, y);

                    x = StaticSave.name.Location.X + sizeMap;
                    y = StaticSave.name.Location.Y;
                    StaticSave.name.Location = new Point(x, y);

                    x = StaticSave.hat.Location.X + sizeMap;
                    y = StaticSave.hat.Location.Y;
                    StaticSave.hat.Location = new Point(x, y);

                    for (int i = 0; i < allTrash.Count; i++)
                    {
                        x = allTrash[i].getP1().Location.X + sizeMap;
                        y = allTrash[i].getP1().Location.Y;

                        allTrash[i].getP1().Location = new Point(x, y);

                        x = allTrash[i].getP2().Location.X + sizeMap;
                        y = allTrash[i].getP2().Location.Y;

                        allTrash[i].getP2().Location = new Point(x, y);
                    }

                    for (int i = 0; i < people.Count; i++)
                    {
                        
                        x = people[i].getP1().Location.X + sizeMap;
                        y = people[i].getP1().Location.Y;

                        people[i].getP1().Location = new Point(x, y);

                        x = people[i].getP2().Location.X + sizeMap;
                        y = people[i].getP2().Location.Y;

                        people[i].getP2().Location = new Point(x, y);

                        x = people[i].getlb().Location.X + sizeMap;
                        y = people[i].getlb().Location.Y;

                        people[i].getlb().Location = new Point(x, y);

                    }
                    x = stand.Location.X + sizeMap;
                    y = stand.Location.Y;

                    stand.Location = new Point(x, y);

                    x = stand2.Location.X + sizeMap;
                    y = stand2.Location.Y;

                    stand2.Location = new Point(x, y);

                    x = chalullGuy.Location.X + sizeMap;
                    y = chalullGuy.Location.Y;

                    chalullGuy.Location = new Point(x, y);

                }
                else
                {
                    for (int i = 0; i < allblocks.Count; i++)
                    {
                        x = allblocks[i].getP1().Location.X - sizeMap;
                        y = allblocks[i].getP1().Location.Y;

                        allblocks[i].getP1().Location = new Point(x, y);

                        x = allblocks[i].getP2().Location.X - sizeMap;
                        y = allblocks[i].getP2().Location.Y;

                        allblocks[i].getP2().Location = new Point(x, y);
                    }

                    for (int i = 0; i < allParents.Count; i++)
                    {
                        x = allParents[i].getP1().Location.X - sizeMap;
                        y = allParents[i].getP1().Location.Y;

                        allParents[i].getP1().Location = new Point(x, y);

                        x = allParents[i].getP2().Location.X - sizeMap;
                        y = allParents[i].getP2().Location.Y;

                        allParents[i].getP2().Location = new Point(x, y);
                    }
                    x = beach.Location.X - sizeMap;
                    y = beach.Location.Y;

                    beach.Location = new Point(x, y);
                    x = StaticSave.man.Location.X - sizeMap;
                    y = StaticSave.man.Location.Y;

                    StaticSave.man.Location = new Point(x, y);

                    x = StaticSave.name.Location.X - sizeMap;
                    y = StaticSave.name.Location.Y;
                    StaticSave.name.Location = new Point(x, y);

                    x = StaticSave.hat.Location.X - sizeMap;
                    y = StaticSave.hat.Location.Y;
                    StaticSave.hat.Location = new Point(x, y);

                    for (int i = 0; i < allTrash.Count; i++)
                    {
                        x = allTrash[i].getP1().Location.X - sizeMap;
                        y = allTrash[i].getP1().Location.Y;

                        allTrash[i].getP1().Location = new Point(x, y);

                        x = allTrash[i].getP2().Location.X - sizeMap;
                        y = allTrash[i].getP2().Location.Y;

                        allTrash[i].getP2().Location = new Point(x, y);
                    }


                    for (int i = 0; i < people.Count; i++)
                    {

                        x = people[i].getP1().Location.X - sizeMap;
                        y = people[i].getP1().Location.Y;

                        people[i].getP1().Location = new Point(x, y);

                        x = people[i].getP2().Location.X - sizeMap;
                        y = people[i].getP2().Location.Y;

                        people[i].getP2().Location = new Point(x, y);

                        x = people[i].getlb().Location.X - sizeMap;
                        y = people[i].getlb().Location.Y;

                        people[i].getlb().Location = new Point(x, y);

                    }
                    x = stand.Location.X - sizeMap;
                    y = stand.Location.Y;

                    stand.Location = new Point(x, y);

                    x = stand2.Location.X - sizeMap;
                    y = stand2.Location.Y;

                    stand2.Location = new Point(x, y);

                    x = chalullGuy.Location.X - sizeMap;
                    y = chalullGuy.Location.Y;

                    chalullGuy.Location = new Point(x, y);
                }
            }
            else
            {
                if (isUp)
                {

                    for (int i = 0; i < allblocks.Count; i++)
                    {
                        x = allblocks[i].getP1().Location.X;
                        y = allblocks[i].getP1().Location.Y + sizeMap;

                        allblocks[i].getP1().Location = new Point(x, y);

                        x = allblocks[i].getP2().Location.X;
                        y = allblocks[i].getP2().Location.Y + sizeMap;

                        allblocks[i].getP2().Location = new Point(x, y);
                    }

                    for (int i = 0; i < allParents.Count; i++)
                    {
                        x = allParents[i].getP1().Location.X;
                        y = allParents[i].getP1().Location.Y + sizeMap;

                        allParents[i].getP1().Location = new Point(x, y);

                        x = allParents[i].getP2().Location.X;
                        y = allParents[i].getP2().Location.Y + sizeMap;

                        allParents[i].getP2().Location = new Point(x, y);
                    }
                    x = beach.Location.X;
                    y = beach.Location.Y + sizeMap;

                    beach.Location = new Point(x, y);
                    x = StaticSave.man.Location.X ;
                    y = StaticSave.man.Location.Y + sizeMap;

                    StaticSave.man.Location = new Point(x, y);

                    x = StaticSave.name.Location.X;
                    y = StaticSave.name.Location.Y + sizeMap;
                    StaticSave.name.Location = new Point(x, y);

                    x = StaticSave.hat.Location.X;
                    y = StaticSave.hat.Location.Y + sizeMap;
                    StaticSave.hat.Location = new Point(x, y);

                    for (int i = 0; i < allTrash.Count; i++)
                    {
                        x = allTrash[i].getP1().Location.X;
                        y = allTrash[i].getP1().Location.Y + sizeMap;

                        allTrash[i].getP1().Location = new Point(x, y);

                        x = allTrash[i].getP2().Location.X;
                        y = allTrash[i].getP2().Location.Y + sizeMap;

                        allTrash[i].getP2().Location = new Point(x, y);
                    }

                    for (int i = 0; i < people.Count; i++)
                    {

                        x = people[i].getP1().Location.X;
                        y = people[i].getP1().Location.Y + sizeMap;

                        people[i].getP1().Location = new Point(x, y);

                        x = people[i].getP2().Location.X;
                        y = people[i].getP2().Location.Y + sizeMap;

                        people[i].getP2().Location = new Point(x, y);

                        x = people[i].getlb().Location.X;
                        y = people[i].getlb().Location.Y + sizeMap;

                        people[i].getlb().Location = new Point(x, y);

                    }
                    x = stand.Location.X;
                    y = stand.Location.Y + sizeMap;

                    stand.Location = new Point(x, y);

                    x = stand2.Location.X;
                    y = stand2.Location.Y + sizeMap;

                    stand2.Location = new Point(x, y);

                    x = chalullGuy.Location.X;
                    y = chalullGuy.Location.Y + sizeMap;

                    chalullGuy.Location = new Point(x, y);

                }
                else
                {
                    for (int i = 0; i < allblocks.Count; i++)
                    {
                        x = allblocks[i].getP1().Location.X;
                        y = allblocks[i].getP1().Location.Y - sizeMap;

                        allblocks[i].getP1().Location = new Point(x, y);

                        x = allblocks[i].getP2().Location.X;
                        y = allblocks[i].getP2().Location.Y - sizeMap;

                        allblocks[i].getP2().Location = new Point(x, y);
                    }

                    for (int i = 0; i < allParents.Count; i++)
                    {
                        x = allParents[i].getP1().Location.X;
                        y = allParents[i].getP1().Location.Y - sizeMap;

                        allParents[i].getP1().Location = new Point(x, y);

                        x = allParents[i].getP2().Location.X;
                        y = allParents[i].getP2().Location.Y - sizeMap;

                        allParents[i].getP2().Location = new Point(x, y);
                    }
                    x = beach.Location.X;
                    y = beach.Location.Y - sizeMap;

                    beach.Location = new Point(x, y);

                    x = StaticSave.man.Location.X;
                    y = StaticSave.man.Location.Y - sizeMap;

                    StaticSave.man.Location = new Point(x, y);

                    x = StaticSave.name.Location.X;
                    y = StaticSave.name.Location.Y - sizeMap;
                    StaticSave.name.Location = new Point(x, y);

                    x = StaticSave.hat.Location.X;
                    y = StaticSave.hat.Location.Y - sizeMap;
                    StaticSave.hat.Location = new Point(x, y);

                    for (int i = 0; i < allTrash.Count; i++)
                    {
                        x = allTrash[i].getP1().Location.X;
                        y = allTrash[i].getP1().Location.Y - sizeMap;

                        allTrash[i].getP1().Location = new Point(x, y);

                        x = allTrash[i].getP2().Location.X;
                        y = allTrash[i].getP2().Location.Y - sizeMap;

                        allTrash[i].getP2().Location = new Point(x, y);
                    }

                    for (int i = 0; i < people.Count; i++)
                    {

                        x = people[i].getP1().Location.X;
                        y = people[i].getP1().Location.Y - sizeMap;

                        people[i].getP1().Location = new Point(x, y);

                        x = people[i].getP2().Location.X;
                        y = people[i].getP2().Location.Y - sizeMap;

                        people[i].getP2().Location = new Point(x, y);

                        x = people[i].getlb().Location.X;
                        y = people[i].getlb().Location.Y - sizeMap;

                        people[i].getlb().Location = new Point(x, y);

                    }
                    x = stand.Location.X;
                    y = stand.Location.Y - sizeMap;

                    stand.Location = new Point(x, y);

                    x = stand2.Location.X;
                    y = stand2.Location.Y - sizeMap;

                    stand2.Location = new Point(x, y);

                    x = chalullGuy.Location.X;
                    y = chalullGuy.Location.Y - sizeMap;

                    chalullGuy.Location = new Point(x, y);

                }
            }
        }

        private void movement(bool isX, bool isUp)
        {
            int x = 0;
            int y = 0;
            
            if(isX)
            {
                if(isUp)
                {
                    x = StaticSave.man.Location.X - size;
                    y = StaticSave.man.Location.Y;

                    StaticSave.man.Location = new Point(x, y);

                    x = StaticSave.name.Location.X - size;
                    y = StaticSave.name.Location.Y;
                    StaticSave.name.Location = new Point(x, y);

                    x = StaticSave.hat.Location.X - size;
                    y = StaticSave.hat.Location.Y;
                    StaticSave.hat.Location = new Point(x, y);
                }
                else
                {
                    x = StaticSave.man.Location.X + size;
                    y = StaticSave.man.Location.Y;

                    StaticSave.man.Location = new Point(x, y);

                    x = StaticSave.name.Location.X + size;
                    y = StaticSave.name.Location.Y;
                    StaticSave.name.Location = new Point(x, y);

                    x = StaticSave.hat.Location.X + size;
                    y = StaticSave.hat.Location.Y;
                    StaticSave.hat.Location = new Point(x, y);
                }
            }else
            {
                if (isUp)
                {
                    x = StaticSave.man.Location.X;
                    y = StaticSave.man.Location.Y - size;

                    StaticSave.man.Location = new Point(x, y);

                    x = StaticSave.name.Location.X;
                    y = StaticSave.name.Location.Y - size;
                    StaticSave.name.Location = new Point(x, y);

                    x = StaticSave.hat.Location.X;
                    y = StaticSave.hat.Location.Y - size; ;
                    StaticSave.hat.Location = new Point(x, y);
                }
                else
                {
                    x = StaticSave.man.Location.X;
                    y = StaticSave.man.Location.Y + size;

                    StaticSave.man.Location = new Point(x, y);

                    x = StaticSave.name.Location.X;
                    y = StaticSave.name.Location.Y + size;
                    StaticSave.name.Location = new Point(x, y);

                    x = StaticSave.hat.Location.X;
                    y = StaticSave.hat.Location.Y + size; ;
                    StaticSave.hat.Location = new Point(x, y);
                }
            }
            for (int i = 0; i < people.Count; i++)
            {
                for (int x1 = 0; x <= 700; x++)
                {
                    for (int y1 = 0; y <= 600; y++)
                    {
                        if (people[i].getlb().Location.X == x1 && people[i].getlb().Location.Y == y1)
                        {
                            TransparetBackground(people[i].getlb());
                        }
                    }
                }
            }
        }

        private bool is_Something_in_way(Control c, Point point, int i)
        {
            bool value = false;
            for (int x2 = c.Location.X-25; x2 < c.Location.X + c.Width-25; x2++)
            { 
                for (int y2 = c.Location.Y-50; y2 < c.Location.Y + c.Height-25; y2++)
                {
                    if(point.X == x2 && point.Y == y2)
                    {
                        //MessageBox.Show(x2.ToString() + "," + y2.ToString() + "-" + point.X.ToString() + "," + point.Y.ToString());

                        allParents[i].setP1(Image.FromFile("./picnicgood.png"));
                        allParents[i].setP2(Image.FromFile("./picnicgood.png"));
                        if(allParents[i].getBad())
                        {
                            score += 50;
                            allParents[i].setBad(false);
                            scoreDisplay.Text = ": " + score.ToString() + "\n\n: " + trash.ToString();
                        }

                        value = true;
                    }
                }
            }


            return value;
        }
       
        private bool is_person_in_way(Person c, Point point)
        {
            bool value = false;
            for (int x2 = c.getP1().Location.X-25; x2 < c.getP1().Location.X + c.getP1().Width; x2++)
            {
                for (int y2 = c.getP1().Location.Y - 75; y2 < c.getP1().Location.Y + c.getP1().Height - 25; y2++)
                {
                    if (point.X == x2 && point.Y == y2)
                    {
                        //MessageBox.Show(x2.ToString() + "," + y2.ToString() + "-" + point.X.ToString() + "," + point.Y.ToString());

                        if(c.getBad())
                        {
                            if (trash - 25 >= 0)
                            {
                                c.setlb("✓");
                                c.getlb().Location = new Point(c.getlb().Location.X-5, c.getlb().Location.Y);
                                c.getlb().ForeColor = Color.ForestGreen;
                                trash -= 25;
                                score += 20;
                                pep++;
                                TransparetBackground(c.getlb());
                                scoreDisplay.Text = ": " + score.ToString() + "\n\n: " + trash.ToString();
                                MessageBox.Show("תודה רבה, שתיקנת לי הכלי עכשיו לא אצטרך לקנות חדש.");
                                c.setBad(false);
                            }
                            else
                            {
                                c.setlb("!");
                                TransparetBackground(c.getlb());
                                MessageBox.Show("אין מספיק חלקים לתקן את הכלי!");
                            }

                        }

                        value = true;
                    }
                }
            }


            return value;
        }
        private bool try_move(bool isX, bool isUp)
        {
            int x = 0;
            int y = 0;
            int index = -1;
            bool value = false;

            if(StaticSave.isTalked)
            {
                allblocks[7].getP1().Size = new Size(75, 70);
            }

            if (isX)
            {
                if (isUp)
                {
                    x = StaticSave.man.Location.X - size;
                    y = StaticSave.man.Location.Y;

                    for (int i = 0; i < allblocks.Count; i++)
                    {
                        for (int x2 = allblocks[i].getP1().Location.X - 25; x2 < allblocks[i].getP1().Location.X + allblocks[i].getP1().Width - 25; x2++)
                        {
                            for (int y2 = allblocks[i].getP1().Location.Y - 50; y2 < allblocks[i].getP1().Location.Y + allblocks[i].getP1().Height - 25; y2++)
                            {
                                if (x == x2 && y == y2)
                                {
                                  
                                    return false;
                                }
                            }
                        }
                    }


                    for (int i = 0; i < allParents.Count; i++)
                    {
                        for (int x2 = allParents[i].getP1().Location.X - 25; x2 < allParents[i].getP1().Location.X + allParents[i].getP1().Width - 25; x2++)
                        {
                            for (int y2 = allParents[i].getP1().Location.Y - 50; y2 < allParents[i].getP1().Location.Y + allParents[i].getP1().Height - 25; y2++)
                            {
                                if (x == x2 && y == y2)
                                {
                                    index = i;
                                }
                            }
                        }
                    }

                    for (int x2 = stand.Location.X-25; x2 < stand.Location.X + stand.Width-25; x2++)
                    {
                        for (int y2 = stand.Location.Y-50; y2 < stand.Location.Y + stand.Height-50; y2++)
                        {
                            if (x == x2 && y == y2)
                            {
                                AchBut.Visible = true;
                                dialog f = new dialog();
                                f.Show();
                                this.Enabled = false;
                                
                                return false;
                            }
                        }
                    }


                    if (index == -1 || !is_Something_in_way(allParents[index].getP1(), new Point(x, y), index))
                    {
                        value = true;
                        is_trash_in_way(x, y);

                        for (int i = 0; i < people.Count; i++)
                        {
                            if (is_person_in_way(people[i], new Point(x, y)))
                            {
                                return false;
                            }
                            
                        }
                        
                        
                    }
                    else
                    {
                        
                        value = false;
                    }

                    
                    


                }
                else
                {
                    x = StaticSave.man.Location.X + size;
                    y = StaticSave.man.Location.Y;

                    for (int i = 0; i < allblocks.Count; i++)
                    {
                        for (int x2 = allblocks[i].getP1().Location.X - 25; x2 < allblocks[i].getP1().Location.X + allblocks[i].getP1().Width - 25; x2++)
                        {
                            for (int y2 = allblocks[i].getP1().Location.Y - 50; y2 < allblocks[i].getP1().Location.Y + allblocks[i].getP1().Height - 25; y2++)
                            {
                                if (x == x2 && y == y2)
                                {
                                    if (i == 7 && !StaticSave.isTalked)
                                    {
                                        MessageBox.Show("על מנת לעבור הינך צריך אישור שניתן להשיג בדוכן צלול");
                                    }
                                    return false;
                                }
                            }
                        }
                    }

                    for (int i = 0; i < allParents.Count; i++)
                    {
                        for (int x2 = allParents[i].getP1().Location.X - 25; x2 < allParents[i].getP1().Location.X + allParents[i].getP1().Width - 25; x2++)
                        {
                            for (int y2 = allParents[i].getP1().Location.Y - 50; y2 < allParents[i].getP1().Location.Y + allParents[i].getP1().Height - 25; y2++)
                            {
                                if (x == x2 && y == y2)
                                {
                                    index = i;
                                }
                            }
                        }
                    }

                    for (int x2 = stand.Location.X - 25; x2 < stand.Location.X + stand.Width - 25; x2++)
                    {
                        for (int y2 = stand.Location.Y - 50; y2 < stand.Location.Y + stand.Height - 50; y2++)
                        {
                            if (x == x2 && y == y2)
                            {
                                AchBut.Visible = true;
                                dialog f = new dialog();
                                f.Show();
                                this.Enabled = false;
                                return false;
                            }
                        }
                    }

                    if (index == -1 || !is_Something_in_way(allParents[index].getP1(), new Point(x, y), index))
                    {
                        value = true;
                        is_trash_in_way(x, y);
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (is_person_in_way(people[i], new Point(x, y)))
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        value = false;
                    }

                    
                }
            }
            else
            {
                if (isUp)
                {
                    x = StaticSave.man.Location.X;
                    y = StaticSave.man.Location.Y - size;

                    for (int i = 0; i < allblocks.Count; i++)
                    {
                        for (int x2 = allblocks[i].getP1().Location.X - 25; x2 < allblocks[i].getP1().Location.X + allblocks[i].getP1().Width - 25; x2++)
                        {
                            for (int y2 = allblocks[i].getP1().Location.Y - 50; y2 < allblocks[i].getP1().Location.Y + allblocks[i].getP1().Height - 25; y2++)
                            {
                                if (x == x2 && y == y2)
                                {
                                    
                                    return false;
                                }
                            }
                        }
                    }

                    for (int i = 0; i < allParents.Count; i++)
                    {
                        for (int x2 = allParents[i].getP1().Location.X - 25; x2 < allParents[i].getP1().Location.X + allParents[i].getP1().Width - 25; x2++)
                        {
                            for (int y2 = allParents[i].getP1().Location.Y - 50; y2 < allParents[i].getP1().Location.Y + allParents[i].getP1().Height - 25; y2++)
                            {
                                if (x == x2 && y == y2)
                                {
                                    index = i;
                                }
                            }
                        }
                    }

                    for (int x2 = stand.Location.X - 25; x2 < stand.Location.X + stand.Width - 25; x2++)
                    {
                        for (int y2 = stand.Location.Y - 50; y2 < stand.Location.Y + stand.Height - 50; y2++)
                        {
                            if (x == x2 && y == y2)
                            {
                                AchBut.Visible = true;
                                dialog f = new dialog();
                                f.Show();
                                this.Enabled = false;
                                return false;
                            }
                        }
                    }

                    if (index == -1 || !is_Something_in_way(allParents[index].getP1(), new Point(x, y), index))
                    {
                        value = true;
                        is_trash_in_way(x, y);
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (is_person_in_way(people[i], new Point(x, y)))
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        value = false;
                    }

                    
                }
                else
                {
                    x = StaticSave.man.Location.X;
                    y = StaticSave.man.Location.Y + size;

                    for (int i = 0; i < allblocks.Count; i++)
                    {
                        for (int x2 = allblocks[i].getP1().Location.X - 25; x2 < allblocks[i].getP1().Location.X + allblocks[i].getP1().Width - 25; x2++)
                        {
                            for (int y2 = allblocks[i].getP1().Location.Y - 50; y2 < allblocks[i].getP1().Location.Y + allblocks[i].getP1().Height - 25; y2++)
                            {
                                if (x == x2 && y == y2)
                                {
                                    
                                    return false;
                                }
                            }
                        }
                    }

                    for (int i = 0; i < allParents.Count; i++)
                    {
                        for (int x2 = allParents[i].getP1().Location.X - 25; x2 < allParents[i].getP1().Location.X + allParents[i].getP1().Width - 25; x2++)
                        {
                            for (int y2 = allParents[i].getP1().Location.Y - 50; y2 < allParents[i].getP1().Location.Y + allParents[i].getP1().Height - 25; y2++)
                            {
                                if (x == x2 && y == y2)
                                {
                                    index = i;
                                }
                            }
                        }
                    }

                    for (int x2 = stand.Location.X - 25; x2 < stand.Location.X + stand.Width - 25; x2++)
                    {
                        for (int y2 = stand.Location.Y - 50; y2 < stand.Location.Y + stand.Height - 50; y2++)
                        {
                            if (x == x2 && y == y2)
                            {
                                AchBut.Visible = true;
                                dialog f = new dialog();
                                f.Show();
                                this.Enabled = false;
                                return false;
                            }
                        }
                    }

                    if (index == -1 || !is_Something_in_way(allParents[index].getP1(), new Point(x, y), index))
                    {
                        value = true;
                        is_trash_in_way(x, y);

                        for (int i = 0; i < people.Count; i++)
                        {
                            if (is_person_in_way(people[i], new Point(x, y)))
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        value = false;
                    }

                    
                }
            }
            
            return value;
        }

        private void is_trash_in_way(int x, int y)
        {
            for (int i = 0; i < allTrash.Count; i++)
            {
                for (int x2 = allTrash[i].getP1().Location.X; x2 < allTrash[i].getP1().Location.X + allTrash[i].getP1().Width; x2++)
                {
                    for (int y2 = allTrash[i].getP1().Location.Y; y2 < allTrash[i].getP1().Location.Y + allTrash[i].getP1().Height; y2++)
                    {
                        for (int x3 = x; x3 < x + StaticSave.man.Width; x3++)
                        {
                            for (int y3 = y; y3 < y + StaticSave.man.Height; y3++)
                            {
                                if (x3 == x2 && y3 == y2)
                                {
                                    
                                    if (!allTrash[i].getBad())
                                    {
                                        
                                        allTrash[i].setBad(true);
                                        //value = true;
                                        
                                        allTrash[i].getP1().Size = new Size(1, 1);
                                        allTrash[i].getP2().Size = new Size(1, 1);
                                        allTrash[i].getP1().Visible = false;
                                        allTrash[i].getP2().Visible = false;
                                        //MessageBox.Show(allTrash[i].getP2().Visible.ToString());
                                        trashPoints.Location = new Point(allTrash[i].getP1().Location.X, allTrash[i].getP1().Location.Y - 10);
                                        try { TransparetBackground(trashPoints); } catch (OutOfMemoryException exep) { }
                                        trashPoints.Visible = true;
                                        trash += 10;
                                        scoreDisplay.Text = ": " + score.ToString() + "\n\n: " + trash.ToString();

                                        
                                    }

                                }
                            }
                        }

                    }
                }
            }
        }

        private bool is_at_edge(bool isX, bool isUp)
        {
            bool value = false;
            if (isX)
            {
                if (isUp)
                {
                    if (StaticSave.man.Location.X == 0)
                    {
                        //StaticSave.man.Location = new Point(625, StaticSave.man.Location.Y);
                        for (int i = 0; i < 15; i++)
                        {
                            updateMap(true, true);
                        }
                        value = true;
                    }

                }
                else
                {
                   
                    if (StaticSave.man.Location.X == 625)
                    {
                        
                        for (int i = 0; i < 15; i++)
                        {
                            updateMap(true, false);
                        }
                        value = true;
                    }
                }
            }
            else
            {
                if (isUp)
                {

                    
                    if (StaticSave.man.Location.Y == 0)
                    {
                        
                        for (int i = 0; i < 15; i++)
                        {
                            updateMap(false, true);
                        }
                        value = true;
                    }
                }
                else
                {

                   
                    if (StaticSave.man.Location.Y == 525)
                    {
                       
                        for (int i = 0; i < 15; i++)
                        {
                            updateMap(false, false);
                        }
                        value = true;
                    }
                }
            }

            return value;
        }

        DateTime timeStamp;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((DateTime.Now - timeStamp).Ticks < 1500000) return;
            timeStamp = DateTime.Now;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    trashPoints.Visible = false;
                    if (try_move(false, true))
                    {
                       
                        if (is_at_edge(false, true))
                        {
                            check_for_trash_around();
                            check_for_table_around();
                            for (int i = 0; i < people.Count; i++)
                            {
                                try
                                {
                                    TransparetBackground(people[i].getlb());
                                }
                                catch { }

                            }
                            
                            //TransparetBackground(AchBut);

                            isUpdate = true;
                        }
                        else
                        {
                            //updateMap(false, true);
                            movement(false, true);
                        }
                        

                        try { TransparetBackground(StaticSave.name); } catch (OutOfMemoryException) { }
                        if (StaticSave.hat.Visible)
                        {
                            TransparetBackground(StaticSave.hat);
                        }

                        StaticSave.man.Image = Image.FromFile("./manB.png");

                        TransparetBackground2(StaticSave.man, allParents[0].getP2());
                        if(trashPoints.Visible)
                        {
                            try { TransparetBackground(trashPoints); } catch (OutOfMemoryException) { }
                        }

                        if(isUpdate)
                        {
                            TransparetBackground(tooltip);
                            TransparetBackground(tooltip2);
                            TransparetBackground(scoreDisplay);
                            isUpdate = false;
                        }

                    }

                    

                    break;
                case Keys.Left:
                    trashPoints.Visible = false;
                    if (try_move(true, true))
                    {
                        if (is_at_edge(true, true))
                        {
                            check_for_trash_around();
                            check_for_table_around();

                            for (int i = 0; i < people.Count; i++)
                            {
                                try
                                {
                                    TransparetBackground(people[i].getlb());
                                }
                                catch { }

                            }
                            //TransparetBackground(AchBut);
                            isUpdate = true;

                        }
                        else
                        {
                            //updateMap(true, true);
                            movement(true, true);
                        }

                        
                        try { TransparetBackground(StaticSave.name); } catch (OutOfMemoryException) { }
                        if (StaticSave.hat.Visible)
                        {
                            TransparetBackground(StaticSave.hat);
                        }

                        StaticSave.man.Image = Image.FromFile("./manL.png");
                        TransparetBackground2(StaticSave.man, allParents[0].getP2());
                        if (trashPoints.Visible)
                        {
                            try { TransparetBackground(trashPoints); } catch (OutOfMemoryException) { }
                        }

                        if (isUpdate)
                        {
                            TransparetBackground(tooltip);
                            TransparetBackground(tooltip2);
                            TransparetBackground(scoreDisplay);

                            
                            isUpdate = false;
                        }
                    }

                    break;
                case Keys.Right:
                    trashPoints.Visible = false;
                    if (try_move(true, false))
                    {
                        //MessageBox.Show(StaticSave.man.Location.X.ToString() + " " + StaticSave.man.Location.Y.ToString());
                        if(is_at_edge(true, false))
                        {
                            check_for_trash_around();
                            check_for_table_around();
                            for (int i = 0; i < people.Count; i++)
                            {
                                try
                                {
                                    TransparetBackground(people[i].getlb());
                                }
                                catch { }

                            }
                            //TransparetBackground(AchBut);
                            isUpdate = true;

                        }
                        else
                        {
                            //updateMap(true, false);
                            movement(true, false);
                        }

                        
                        
                        try { TransparetBackground(StaticSave.name); } catch (OutOfMemoryException) { }
                        if (StaticSave.hat.Visible)
                        {
                            TransparetBackground(StaticSave.hat);
                        }
                        StaticSave.man.Image = Image.FromFile("./manR.png");
                        TransparetBackground2(StaticSave.man, allParents[0].getP2());
                        if (trashPoints.Visible)
                        {
                            try { TransparetBackground(trashPoints); } catch (OutOfMemoryException) { }
                        }

                        if (isUpdate)
                        {
                            TransparetBackground(tooltip);
                            TransparetBackground(tooltip2);
                            TransparetBackground(scoreDisplay);

                            
                            isUpdate = false;
                        }
                    }
                    break;
                case Keys.Down:
                    trashPoints.Visible = false;
                    if (try_move(false, false))
                    {
                        //MessageBox.Show(StaticSave.man.Location.X.ToString() + " " + StaticSave.man.Location.Y.ToString());
                        if (is_at_edge(false, false))
                        {
                            check_for_trash_around();
                            check_for_table_around();
                            for (int i = 0; i < people.Count; i++)
                            {
                                try
                                {
                                    TransparetBackground(people[i].getlb());
                                }
                                catch { }

                            }
                            //TransparetBackground(AchBut);
                            isUpdate = true;

                        }
                        else
                        {
                            //updateMap(false, false);
                            movement(false, false);
                        }

                        

                        try { TransparetBackground(StaticSave.name); }catch (OutOfMemoryException){}

                        if (StaticSave.hat.Visible)
                        {
                            TransparetBackground(StaticSave.hat);
                        }
                        StaticSave.man.Image = Image.FromFile("./man.png");
                        TransparetBackground2(StaticSave.man, allParents[0].getP2());
                        if (trashPoints.Visible)
                        {
                            try { TransparetBackground(trashPoints); } catch (OutOfMemoryException) { }
                        }

                        if (isUpdate)
                        {
                            TransparetBackground(tooltip);
                            TransparetBackground(tooltip2);
                            TransparetBackground(scoreDisplay);

                            
                            isUpdate = false;
                        }
                    }

                    break;
               
                case Keys.Z:
                    TransparetBackground(tooltip);
                    TransparetBackground(tooltip2);
                    TransparetBackground(scoreDisplay);
                    
                    break;
                default:
                    break;
            }

        }

        private void Click_Key(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
        }

        void TransparetBackground2(Control C, Control A)
        {
            C.Visible = false;

            C.Refresh();
            A.Refresh();
            Application.DoEvents();


            Rectangle screenRectangle = RectangleToScreen(A.ClientRectangle);
            int titleHeight = screenRectangle.Top - this.Top;
            int Right = screenRectangle.Left - this.Left;

            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
            Bitmap bmpImage = new Bitmap(bmp);
            bmp = bmpImage.Clone(new Rectangle(C.Location.X + Right, C.Location.Y + titleHeight, C.Width, C.Height), bmpImage.PixelFormat);
            C.BackgroundImage = bmp;

            C.Visible = true;
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
        private void Form1_Load(object sender, EventArgs e)
        {
            
            TransparetBackground(stand);
            TransparetBackground(StaticSave.man);
            if(StaticSave.hat.Visible)
            {
                TransparetBackground(StaticSave.hat);
            }
            
            TransparetBackground(StaticSave.name);
            TransparetBackground(scoreDisplay);
            for (int i = 0; i < people.Count; i++)
            {
                for (int x = 0; x <= 700; x++)
                {
                    for (int y = 0; y <= 600; y++)
                    {
                        if(people[i].getlb().Location.X == x && people[i].getlb().Location.Y == y)
                        {
                            TransparetBackground(people[i].getlb());
                        }
                    }
                }
            }
            TransparetBackground(tooltip2);
            TransparetBackground(tooltip);

            //TransparetBackground(person.getP1());
            //TransparetBackground(trash1.getP2());

        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Prompt user to save his data
                StaticSave.form3.Close();
            }


            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                // Autosave and clear up ressources
            }

        }


    }
}
