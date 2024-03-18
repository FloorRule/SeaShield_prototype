using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(-100, -100);
            ClientSize = new Size(10, 10); //form size
            //BackColor = Color.Wheat;//form color
            Form1 f = new Form1();
            StaticSave.form = f;
            f.Show();
            
            startForm h = new startForm();
            h.Show();
        }

        [STAThread]
        static void Main()
        {
            Form3 f = new Form3();
            StaticSave.form3 = f;
            Application.EnableVisualStyles();
            Application.Run(f);
            f.Hide();
            
        }
    }
}
