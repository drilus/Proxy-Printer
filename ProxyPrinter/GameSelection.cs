using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace octgnPicTest
{
    public partial class GameSelection : Form
    {
        public string[] gameList { get; set; }
        public int GameIndex { get; set; }

        public GameSelection()
        {
            InitializeComponent();
        }

        private void GameSelection_Load(object sender, EventArgs e)
        {
            foreach (string s in gameList) { comboBox1.Items.Add(s); }
            comboBox1.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            GameIndex = comboBox1.SelectedIndex;
            this.Close();
        }
    }
}
