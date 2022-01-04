using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace text1
{
    public partial class Binary : Form
    {
        public Binary()
        {
            InitializeComponent();
        }
        public bool flag = false;
        private void button1_Click(object sender, EventArgs e)
        {
            flag = true;
            this.Close();
        }

        private void trackBarBrightness_Scroll(object sender, EventArgs e)
        {
            txtEZ.Text = trackBarBrightness.Value.ToString();
        }
    }
}
