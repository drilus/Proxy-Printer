namespace octgnPicTest
{
    partial class Chooser
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboChooser = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.mtgPicture1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mtgPicture1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Multiple Sets Found For Card :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CardName";
            // 
            // comboChooser
            // 
            this.comboChooser.FormattingEnabled = true;
            this.comboChooser.Location = new System.Drawing.Point(15, 95);
            this.comboChooser.Name = "comboChooser";
            this.comboChooser.Size = new System.Drawing.Size(237, 21);
            this.comboChooser.TabIndex = 3;
            this.comboChooser.SelectionChangeCommitted += new System.EventHandler(this.comboChooser_SelectionChangeCommitted);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(177, 261);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // mtgPicture1
            // 
            this.mtgPicture1.Location = new System.Drawing.Point(275, 12);
            this.mtgPicture1.Name = "mtgPicture1";
            this.mtgPicture1.Size = new System.Drawing.Size(192, 272);
            this.mtgPicture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mtgPicture1.TabIndex = 0;
            this.mtgPicture1.TabStop = false;
            // 
            // Chooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 295);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.comboChooser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mtgPicture1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Chooser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chooser";
            this.Load += new System.EventHandler(this.Chooser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mtgPicture1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mtgPicture1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboChooser;
        private System.Windows.Forms.Button btnOk;
    }
}