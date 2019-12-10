using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdversarialImage
{
    public partial class Form1 : Form
    {
        string mnist_test = @"C:\Users\kishor\Desktop\icsw\test\mnist\test"; //0
        string mnist_cw2 = @"C:\Users\kishor\Desktop\icsw\test\mnist\cw2";//1
        string mnist_deepfool = @"C:\Users\kishor\Desktop\icsw\test\mnist\df";//2
        string mnist_fsgm = @"C:\Users\kishor\Desktop\icsw\test\mnist\fsgm";//3
        string mnist_jsma = @"C:\Users\kishor\Desktop\icsw\test\mnist\jsma";//4
        string mnist_adv = @"C:\Users\kishor\Desktop\icsw\test\mnist\advgan";//5


        string cfiar_test = @"C:\Users\kishor\Desktop\icsw\test\cfiar\test";
        string cfiar_cw2 = @"C:\Users\kishor\Desktop\icsw\test\cfiar\cw2";
        string cfiar_deepfool = @"C:\Users\kishor\Desktop\icsw\test\cfiar\df";
        string cfiar_fsgm = @"C:\Users\kishor\Desktop\icsw\test\cfiar\fsgm";
        string cfiar_jsma = @"C:\Users\kishor\Desktop\icsw\test\cfiar\jsma";

        public static string clean = "";
        public static string adverse = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clean = mnist_test;
            adverse = mnist_fsgm;
            MainGA.ga();
        }
    }
}
