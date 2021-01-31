using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheAirBlow.SteamInstalled.Test
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Main.IsGameInstalled(textBox1.Text)) MessageBox.Show("This game is installed!", "SteamInstalled Library Test");
            else MessageBox.Show("This game is NOT installed!", "SteamInstalled Library Test");
        }
    }
}
