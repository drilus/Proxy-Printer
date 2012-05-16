using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Octgn.Data;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;

namespace octgnPicTest
{
    public partial class Main : Form
    {
        int gameindex;
        int TotalPages = 0;
        public List<ProxyList> myList { get; set; }
        public GamesRepository proxy = new GamesRepository();

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            GamesRepository mygame = new Octgn.Data.GamesRepository();
            int gamecount = mygame.Games.Count;
            if (gamecount > 1)
            {
                GameSelection chooserForm = new GameSelection();
                chooserForm.gameList = new string[gamecount];
                for (int i = 0; i < gamecount; i++) { chooserForm.gameList[i] = mygame.Games[i].Name; }
                chooserForm.ShowDialog();
                gameindex = chooserForm.GameIndex;
            }
            
            Game octgnGame = proxy.Games[gameindex];
            try 
            {
                // Retrieve Card Image  
                System.Windows.Controls.Image CardImage = new System.Windows.Controls.Image();
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = octgnGame.GetCardBackUri();
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.EndInit();
                pictureBox1.Image = SourceConvert.BitmapSourceToBitmap(src);                               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }                      
            // Default Page Setups
            printDocument1.DefaultPageSettings.Landscape = true;
            Margins margins = new Margins(25,25,25,25); // 100ths of an inch. Ex. 25 = 0.25, 150 = 1.5            
            printDocument1.DefaultPageSettings.Margins = margins;
            groupBox2.Focus();
            txtSearch.Focus();
        }

        public Guid GetSetId(string SetName)
        {
            Game mygame = proxy.Games[gameindex];
            Guid SetId = System.Guid.Empty;
            foreach (Set set in mygame.Sets)
            {
                if (set.Name == SetName) { SetId = set.Id; }
            }
            return SetId;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {                
                string CardName = txtSearch.Text.ToLower();
                Game mygame = proxy.Games[gameindex];

                // Search for Card
                Guid card = Guid.Empty;
                string[] cond = new string[1];
                cond[0] = "name = '" + CardName.Trim().Replace("'", "''") + "'"; // Equals
                string[] cond2 = new string[1];
                cond2[0] = "name like '%" + CardName.Trim().Replace("'", "''") + "%'"; // Contains
                List<CardModel> SetsWhereCardAppear = new List<CardModel>();                
                SetsWhereCardAppear.AddRange(mygame.SelectCardModels(cond));
                if (SetsWhereCardAppear.Count < 1)
                {   
                    // If incorrectly typed name try a "name contains" statement
                    SetsWhereCardAppear.AddRange(mygame.SelectCardModels(cond2));
                    if (SetsWhereCardAppear.Count > 0)
                    {
                        CardSelection cardForm = new CardSelection();
                        cardForm.CardList = new string[SetsWhereCardAppear.Count];
                        for (int i = 0; i < SetsWhereCardAppear.Count; i++)
                        {
                            cardForm.CardList[i] = SetsWhereCardAppear[i].Name;
                        }
                        cardForm.ShowDialog();
                        string[] fixedSearch = new string[1];
                        fixedSearch[0] = "name = '" + cardForm.CardName.Trim().Replace("'", "''") + "'"; // Equals
                        SetsWhereCardAppear.Clear();
                        SetsWhereCardAppear.AddRange(mygame.SelectCardModels(fixedSearch));
                        txtSearch.Text = cardForm.CardName;
                    }
                    else
                    {
                        MessageBox.Show("Could not find any matching cards for search term: " + txtSearch.Text);
                        txtSearch.Focus();
                        txtSearch.SelectAll();
                    }
                }
                // If multiple cards returned.
                if (SetsWhereCardAppear.Count > 1)
                {
                    Chooser chooser = new Chooser();
                    chooser.SetList = new List<CardModel>();
                    chooser.SetList = SetsWhereCardAppear;
                    chooser.CardName = CardName;
                    chooser.GameIndex = gameindex;
                    chooser.ShowDialog();
                    card = chooser.selectedCard;
                }
                else 
                {
                    if (SetsWhereCardAppear.Count == 1) { card = SetsWhereCardAppear[0].Id; }
                }
                if (SetsWhereCardAppear.Count != 0)
                {
                    // Retrieve Card Image                
                    BitmapImage img = new BitmapImage();
                    System.Windows.Controls.Image CardImage = new System.Windows.Controls.Image();
                    Uri picture = CardModel.GetPictureUri(mygame, mygame.GetCardById(card).Set.Id, 
                        mygame.GetCardById(card).ImageUri) ?? mygame.GetCardBackUri();
                    pictureBox1.Image = SourceConvert.BitmapFromUri(picture);
                    Uri alternate = new Uri(picture.ToString().Replace(".jpg", ".b.jpg"));
                    try
                    {
                        pictureBox2.Image = SourceConvert.BitmapFromUri(alternate);
                    }
                    catch
                    {
                        pictureBox2.Image = SourceConvert.BitmapFromUri(mygame.GetCardBackUri());
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            txtSearch.Focus();
            txtSearch.SelectAll();
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = false;
            // Resize image for mock layout
            Size mockSize = new Size();
            mockSize.Width = 384 / 3;
            mockSize.Height = 544 / 3;
            // Resize image for real layout
            Size realSize = new Size();
            realSize.Width = 240;
            realSize.Height = 335; // 340
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                if (pictureBox1.Image == null) { break; }
                Image pImage = pictureBox1.Image;
                if (!pictureBox1.Visible) pImage = pictureBox2.Image;
                // Mock Page
                Clipboard.SetImage(resizeImage(pImage, mockSize));
                richTextBox1.Paste();
                // Real Page
                Clipboard.SetImage(resizeImage(pImage, realSize));
                richTextBox2.Paste();
                richTextBox1.AppendText(" "); // Mock
                richTextBox2.AppendText(" "); // Real
            }                                

            Clipboard.Clear();
            txtSearch.Focus();
            txtSearch.SelectAll();
            richTextBox1.ReadOnly = true;
        }

        private static Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }

        private int checkPrint;

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            checkPrint = 0;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            TotalPages++;
            // Print the content of RichTextBox. Store the last character printed.
            checkPrint = richTextBox2.Print(checkPrint, richTextBox2.TextLength, e);

            // Check for more pages
            if (checkPrint < richTextBox2.TextLength)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
            if (TotalPages == 2) { printPreviewDialog1.PrintPreviewControl.Columns = 2; }
            if ((TotalPages >= 3) && (TotalPages < 5)) 
            { 
                printPreviewDialog1.PrintPreviewControl.Columns = 2;
                printPreviewDialog1.PrintPreviewControl.Rows = 2;
            }            
            if (TotalPages >= 5) 
            { 
                printPreviewDialog1.PrintPreviewControl.Columns = 3;
                printPreviewDialog1.PrintPreviewControl.Rows = 2;
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            TotalPages = 0;
            //printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.PrintPreviewControl.AutoZoom = true;
            ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;
            printPreviewDialog1.ShowDialog();
        }

        private void btnPageSetup_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            txtSearch.Text = "";
            txtSearch.Focus();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) { btnSearch.PerformClick(); }
        }

        private void btnLoadDeck_Click(object sender, EventArgs e)
        {
            DeckLoader LoadDeck = new DeckLoader();
            LoadDeck.GameIndex = gameindex;
            LoadDeck.ShowDialog();

            if (LoadDeck.cancelled == false)
            {
                richTextBox1.ReadOnly = false;
                PictureBox ProxyImage = new PictureBox();


                // Open database for image retrieval
                GamesRepository proxy = new GamesRepository();
                Game mygame = proxy.Games[gameindex];

                foreach (ProxyList myList in LoadDeck.guidList)
                {
                    // Resize image for mock layout
                    Size mockSize = new Size();
                    mockSize.Width = 384 / 3;
                    mockSize.Height = 544 / 3;
                    // Resize image for real layout
                    Size realSize = new Size();
                    realSize.Width = 240;
                    realSize.Height = 335; // 340

                    // Load Image
                    Guid CardID = Guid.Empty;
                    Guid.TryParse(myList.GUID, out CardID);
                    try
                    {
                        // Retrieve Card Image  
                        BitmapImage img = new BitmapImage();
                        System.Windows.Controls.Image CardImage = new System.Windows.Controls.Image();
                        ProxyImage.Image = SourceConvert.BitmapFromUri(CardModel.GetPictureUri(mygame,
                            mygame.GetCardById(CardID).Set.Id, mygame.GetCardById(CardID).ImageUri) 
                            ?? mygame.GetCardBackUri());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    for (int I = 0; I < Convert.ToInt16(myList.Quantity); I++)
                    {
                        // Mock Page
                        Clipboard.SetImage(resizeImage(ProxyImage.Image, mockSize));
                        richTextBox1.Paste();
                        // Real Page
                        Clipboard.SetImage(resizeImage(ProxyImage.Image, realSize));
                        richTextBox2.Paste();
                        // Add spacing
                        richTextBox1.AppendText(" "); // Mock
                        richTextBox2.AppendText(" "); // Real                                                
                    }
                }
                // Center all images
                richTextBox1.SelectAll();
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
                richTextBox1.Select(0, 0);
                richTextBox2.SelectAll();
                richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
                richTextBox2.Select(0, 0);
                
                Clipboard.Clear();
                txtSearch.Focus();
                txtSearch.SelectAll();

                //mygame.CloseDatabase();
                richTextBox1.ReadOnly = true;
            }
            // End
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
        }
    }
}
