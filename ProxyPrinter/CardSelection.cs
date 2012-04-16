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
    public partial class CardSelection : Form
    {
        public string[] CardList { get; set; }
        public string CardName { get; set; }

        public CardSelection()
        {
            InitializeComponent();
        }

        private void CardSelection_Load(object sender, EventArgs e)
        {
            List<string> unique = new List<string>();
            unique.AddRange(CardList.Distinct());
            foreach (string s in unique) { comboBox1.Items.Add(s); }
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CardName = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            this.Close();
        }
    }
}
