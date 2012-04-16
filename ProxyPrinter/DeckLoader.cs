using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Octgn.Data;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Media.Imaging;
using System.Collections;

namespace octgnPicTest
{
    public partial class DeckLoader : Form
    {
        public int GameIndex { get; set; }
        public List<ProxyList> guidList { get; set; }
        public Boolean cancelled = true;

        private Deck _deck;
        public Deck Deck
        {
            get { return _deck; }
            set
            {
                if (_deck == value) return;
                _deck = value;
            }
        }

        public class ProxyList
        {
            private string _GUID;
            private string _Quantity;

            public ProxyList(string GUID, string Quantity)
            {
                _GUID = GUID;
                _Quantity = Quantity;
            }

            public string GUID
            {
                get { return _GUID; }
                set { _GUID = value; }
            }

            public string Quantity
            {
                get { return _Quantity; }
                set { _Quantity = value; }
            }
        }     

        public DeckLoader()
        {
            InitializeComponent();
        }

        private void btnLoadDeck_Click(object sender, EventArgs e)
        {
            listDeckList.Items.Clear();
            GamesRepository proxy = new GamesRepository();
            Game mygame = proxy.Games[GameIndex];
            openFileDialog1.Filter = "OCTGN deck files (*.o8d) | *.o8d";
            openFileDialog1.InitialDirectory = mygame != null ? mygame.DefaultDecksPath : null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Deck newDeck;
                try
                {
                    newDeck = Deck.Load(openFileDialog1.FileName, proxy);
                }
                catch (DeckException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("OCTGN couldn't load the deck.\r\nDetails:\r\n\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                for (int I = 0; I < newDeck.Sections[0].Cards.Count; I++ )
                {
                    ListViewItem card = new ListViewItem();
                    card.Text = newDeck.Sections[0].Cards[I].Card.Name;
                    Set cardSet = newDeck.Sections[0].Cards[I].Card.Set;
                    card.SubItems.Add(cardSet.Name);
                    card.SubItems.Add(newDeck.Sections[0].Cards[I].Quantity.ToString());
                    card.SubItems.Add(newDeck.Sections[0].Cards[I].Card.Id.ToString());
                    listDeckList.Items.Add(card);
                }
                if (checkBox1.Checked == true)
                {
                    for (int I = 0; I < newDeck.Sections[1].Cards.Count; I++)
                    {
                        ListViewItem card = new ListViewItem();
                        card.Text = newDeck.Sections[1].Cards[I].Card.Name;
                        Set cardSet = newDeck.Sections[1].Cards[I].Card.Set;
                        card.SubItems.Add(cardSet.Name);
                        card.SubItems.Add(newDeck.Sections[1].Cards[I].Quantity.ToString());
                        card.SubItems.Add(newDeck.Sections[1].Cards[I].Card.Id.ToString());
                        listDeckList.Items.Add(card);
                    }
                }
            }
        }

        private void DeckLoader_Load(object sender, EventArgs e)
        {
            // Default Image
            GamesRepository proxy = new GamesRepository();
            Game mygame = proxy.Games[GameIndex];
            try
            {
                // Retrieve Card Image  
                System.Windows.Controls.Image CardImage = new System.Windows.Controls.Image();
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = mygame.GetCardBackUri();
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.EndInit();
                mtgPicture1.Image = SourceConvert.BitmapSourceToBitmap(src);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listDeckList_Click(object sender, EventArgs e)
        {
            // Selected Card Image
            GamesRepository proxy = new GamesRepository();
            Game mygame = proxy.Games[GameIndex];
            Guid card = Guid.Empty;
            string guid = listDeckList.Items[listDeckList.SelectedItems[0].Index].SubItems[3].Text;
            Guid.TryParse(guid, out card);
            try
            {
                BitmapImage img = new BitmapImage();
                System.Windows.Controls.Image CardImage = new System.Windows.Controls.Image();
                mtgPicture1.Image = SourceConvert.BitmapFromUri(img != null ? CardModel.GetPictureUri(mygame,
                    mygame.GetCardById(card).Set.Id, mygame.GetCardById(card).ImageUri) : mygame.GetCardBackUri());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listDeckList_KeyDown(object sender, KeyEventArgs e)
        {            
            if ((e.KeyCode == Keys.Subtract) || (e.KeyCode == Keys.OemMinus))
            {
                e.SuppressKeyPress = true;
                int count = Convert.ToInt16(listDeckList.Items[listDeckList.SelectedItems[0].Index].SubItems[2].Text);
                if (count > 0)
                {
                    count -= 1;
                    listDeckList.Items[listDeckList.SelectedItems[0].Index].SubItems[2].Text = count.ToString();
                    e.Handled = true;
                }
            }

            if ((e.KeyData == Keys.Oemplus) || (e.KeyCode == Keys.Add))
            {
                e.SuppressKeyPress = true;
                int count = Convert.ToInt16(listDeckList.Items[listDeckList.SelectedItems[0].Index].SubItems[2].Text);
                count += 1;
                listDeckList.Items[listDeckList.SelectedItems[0].Index].SubItems[2].Text = count.ToString();
                e.Handled = true;
            }

            if (e.KeyData == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                if (listDeckList.SelectedItems.Count > 0)
                    listDeckList.Items.Remove(listDeckList.SelectedItems[0]);
                e.Handled = true;
            }            
        }

        private void btnAddLayout_Click(object sender, EventArgs e)
        {
            // Need to store GUID, Quantity
            
            guidList = new List<ProxyList>();    
            foreach (ListViewItem item in listDeckList.Items)
            {
                guidList.Add(new ProxyList(item.SubItems[3].Text, item.SubItems[2].Text));
                //guidList.Add(item.SubItems[3].Text);
            }
            cancelled = false;
            this.Close();
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                MessageBox.Show("Please load a deck.");
            }
            else checkBox1.Checked = false;
        }

        private void listDeckList_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == Keys.Down) || (e.KeyData == Keys.Up))
            {
                // Selected Card Image
                GamesRepository proxy = new GamesRepository();
                Game mygame = proxy.Games[GameIndex];
                Guid card = Guid.Empty;
                string guid = listDeckList.Items[listDeckList.SelectedItems[0].Index].SubItems[3].Text;
                Guid.TryParse(guid, out card);
                try
                {
                    BitmapImage img = new BitmapImage();
                    System.Windows.Controls.Image CardImage = new System.Windows.Controls.Image();
                    mtgPicture1.Image = SourceConvert.BitmapFromUri(img != null ? CardModel.GetPictureUri(mygame,
                        mygame.GetCardById(card).Set.Id, mygame.GetCardById(card).ImageUri) : mygame.GetCardBackUri());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
