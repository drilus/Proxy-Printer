namespace octgnPicTest
{
    partial class DeckLoader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeckLoader));
            this.listDeckList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnGUID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddLayout = new System.Windows.Forms.Button();
            this.btnLoadDeck = new System.Windows.Forms.Button();
            this.mtgPicture1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mtgPicture1)).BeginInit();
            this.SuspendLayout();
            // 
            // listDeckList
            // 
            this.listDeckList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnGUID});
            this.listDeckList.FullRowSelect = true;
            this.listDeckList.GridLines = true;
            this.listDeckList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listDeckList.Location = new System.Drawing.Point(12, 12);
            this.listDeckList.MultiSelect = false;
            this.listDeckList.Name = "listDeckList";
            this.listDeckList.Size = new System.Drawing.Size(425, 512);
            this.listDeckList.TabIndex = 1;
            this.listDeckList.UseCompatibleStateImageBehavior = false;
            this.listDeckList.View = System.Windows.Forms.View.Details;
            this.listDeckList.Click += new System.EventHandler(this.listDeckList_Click);
            this.listDeckList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listDeckList_KeyDown);
            this.listDeckList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listDeckList_KeyUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Set";
            this.columnHeader2.Width = 170;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Quantity";
            this.columnHeader3.Width = 51;
            // 
            // columnGUID
            // 
            this.columnGUID.Width = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(443, 434);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Include Sideboard";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(443, 290);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 138);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Command Keys:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(70, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Remove Selected";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(70, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Quantity -1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(70, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Quantity +1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Delete:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Minus:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Plus:";
            // 
            // btnAddLayout
            // 
            this.btnAddLayout.Image = global::octgnPicTest.Properties.Resources.tick_32;
            this.btnAddLayout.Location = new System.Drawing.Point(542, 457);
            this.btnAddLayout.Name = "btnAddLayout";
            this.btnAddLayout.Size = new System.Drawing.Size(90, 67);
            this.btnAddLayout.TabIndex = 4;
            this.btnAddLayout.Text = "Add to layout";
            this.btnAddLayout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddLayout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddLayout.UseVisualStyleBackColor = true;
            this.btnAddLayout.Click += new System.EventHandler(this.btnAddLayout_Click);
            // 
            // btnLoadDeck
            // 
            this.btnLoadDeck.Image = global::octgnPicTest.Properties.Resources.LoadDeck;
            this.btnLoadDeck.Location = new System.Drawing.Point(443, 457);
            this.btnLoadDeck.Name = "btnLoadDeck";
            this.btnLoadDeck.Size = new System.Drawing.Size(59, 67);
            this.btnLoadDeck.TabIndex = 2;
            this.btnLoadDeck.Text = "Load Deck";
            this.btnLoadDeck.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoadDeck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLoadDeck.UseVisualStyleBackColor = true;
            this.btnLoadDeck.Click += new System.EventHandler(this.btnLoadDeck_Click);
            // 
            // mtgPicture1
            // 
            this.mtgPicture1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mtgPicture1.Location = new System.Drawing.Point(443, 12);
            this.mtgPicture1.Name = "mtgPicture1";
            this.mtgPicture1.Size = new System.Drawing.Size(192, 272);
            this.mtgPicture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mtgPicture1.TabIndex = 0;
            this.mtgPicture1.TabStop = false;
            // 
            // DeckLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 536);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAddLayout);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnLoadDeck);
            this.Controls.Add(this.listDeckList);
            this.Controls.Add(this.mtgPicture1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeckLoader";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Print OCTGN deck files (.o8d)";
            this.Load += new System.EventHandler(this.DeckLoader_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mtgPicture1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mtgPicture1;
        private System.Windows.Forms.ListView listDeckList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnLoadDeck;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColumnHeader columnGUID;
        private System.Windows.Forms.Button btnAddLayout;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}