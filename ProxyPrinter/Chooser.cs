using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Octgn.Data;

namespace octgnPicTest
{
    public partial class Chooser : Form
    {
        public List<CardModel> SetList { get; set; }
        public string CardName { get; set; }
        public int GameIndex { get; set; }
        public Guid selectedCard { get; set; }

        public Chooser()
        {
            InitializeComponent();
        }

        private void Chooser_Load(object sender, EventArgs e)
        {
            //label2.Text = CardName;
            Guid card = Guid.Empty;
            string[] list = new string[SetList.Count];
            int i = 0;
            foreach (CardModel Card in SetList)
            {
                Set CardSet = Card.Set;
                list[i] = CardSet.Name;
                i++;                
            }
            List<string> unique = new List<string>();
            unique.AddRange(list.Distinct());
            comboChooser.Sorted = true;
            foreach (string setname in unique) { comboChooser.Items.Add(setname); }
            comboChooser.Text = comboChooser.Items[0].ToString();
            // Default Image
            GamesRepository proxy = new GamesRepository();
            Game mygame = proxy.Games[GameIndex];
            card = SetList[0].Id;
            label2.Text = SetList[0].Name;
            BitmapImage img = new BitmapImage();
            System.Windows.Controls.Image CardImage = new System.Windows.Controls.Image();
            mtgPicture1.Image = SourceConvert.BitmapFromUri(img != null ? CardModel.GetPictureUri(mygame,
                mygame.GetCardById(card).Set.Id, mygame.GetCardById(card).ImageUri) : mygame.GetCardBackUri());
            selectedCard = card;
        }

        private void comboChooser_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Look up picture for selected Set
            Guid card = Guid.Empty;
            string name = comboChooser.Items[comboChooser.SelectedIndex].ToString();
            foreach (CardModel Card in SetList)
            {
                if (name == Card.Set.Name) { card = Card.Id; }
            }
            GamesRepository proxy = new GamesRepository();
            Game mygame = proxy.Games[GameIndex];
            BitmapImage img = new BitmapImage();
            System.Windows.Controls.Image CardImage = new System.Windows.Controls.Image();
            mtgPicture1.Image = SourceConvert.BitmapFromUri(img != null ? CardModel.GetPictureUri(mygame,
                mygame.GetCardById(card).Set.Id, mygame.GetCardById(card).ImageUri) : mygame.GetCardBackUri());
            selectedCard = card;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();    
        }
    }
}
