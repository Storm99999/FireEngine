using FireEngine.GameForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireEngine.StartingScreen
{
    public partial class FirstScreen : Form
    {
        public FirstScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Game game = new Game();

        }

        private void FirstScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
