using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
namespace Test
{
    class StaticSave
    {
        public static PictureBox man;
        public static Label name;
        public static PictureBox hat;
        public static bool isHat = false;
        public static int lastHat;
        public static int exp = 0;
        public static int expMax = 100;
        public static int lvl = 1;
        public static List<int> achievComp = new List<int>();
        public static List<int> achievCompNotTaken = new List<int>();
        public static bool isTalked = false;
        
        public static Form1 form;
        public static Form3 form3;
    }
}
