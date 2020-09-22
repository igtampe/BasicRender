namespace Igtampe.BasicFontsPackager {
    partial class NewFontForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.FontInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.CANCELBTN = new System.Windows.Forms.Button();
            this.OKBTN = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.HeightBox = new System.Windows.Forms.MaskedTextBox();
            this.WidthBox = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AuthorBox = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FontInfoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // FontInfoGroupBox
            // 
            this.FontInfoGroupBox.Controls.Add(this.CANCELBTN);
            this.FontInfoGroupBox.Controls.Add(this.OKBTN);
            this.FontInfoGroupBox.Controls.Add(this.label5);
            this.FontInfoGroupBox.Controls.Add(this.label4);
            this.FontInfoGroupBox.Controls.Add(this.HeightBox);
            this.FontInfoGroupBox.Controls.Add(this.WidthBox);
            this.FontInfoGroupBox.Controls.Add(this.label3);
            this.FontInfoGroupBox.Controls.Add(this.AuthorBox);
            this.FontInfoGroupBox.Controls.Add(this.NameBox);
            this.FontInfoGroupBox.Controls.Add(this.label2);
            this.FontInfoGroupBox.Controls.Add(this.label1);
            this.FontInfoGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FontInfoGroupBox.Location = new System.Drawing.Point(0, 0);
            this.FontInfoGroupBox.Name = "FontInfoGroupBox";
            this.FontInfoGroupBox.Size = new System.Drawing.Size(528, 82);
            this.FontInfoGroupBox.TabIndex = 1;
            this.FontInfoGroupBox.TabStop = false;
            this.FontInfoGroupBox.Text = "Font Information";
            // 
            // CANCELBTN
            // 
            this.CANCELBTN.Location = new System.Drawing.Point(435, 44);
            this.CANCELBTN.Name = "CANCELBTN";
            this.CANCELBTN.Size = new System.Drawing.Size(75, 23);
            this.CANCELBTN.TabIndex = 9;
            this.CANCELBTN.Text = "Cancel";
            this.CANCELBTN.UseVisualStyleBackColor = true;
            this.CANCELBTN.Click += new System.EventHandler(this.CANCELBTN_Click);
            // 
            // OKBTN
            // 
            this.OKBTN.Location = new System.Drawing.Point(435, 17);
            this.OKBTN.Name = "OKBTN";
            this.OKBTN.Size = new System.Drawing.Size(75, 23);
            this.OKBTN.TabIndex = 8;
            this.OKBTN.Text = "OK";
            this.OKBTN.UseVisualStyleBackColor = true;
            this.OKBTN.Click += new System.EventHandler(this.OKBTN_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(357, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "x";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 26);
            this.label4.TabIndex = 6;
            this.label4.Text = "NOTE! \r\nYou can\'t change character size later\r\n";
            // 
            // HeightBox
            // 
            this.HeightBox.Location = new System.Drawing.Point(375, 19);
            this.HeightBox.Mask = "00";
            this.HeightBox.Name = "HeightBox";
            this.HeightBox.Size = new System.Drawing.Size(18, 20);
            this.HeightBox.TabIndex = 5;
            this.HeightBox.ValidatingType = typeof(int);
            // 
            // WidthBox
            // 
            this.WidthBox.Location = new System.Drawing.Point(333, 19);
            this.WidthBox.Mask = "00";
            this.WidthBox.Name = "WidthBox";
            this.WidthBox.Size = new System.Drawing.Size(18, 20);
            this.WidthBox.TabIndex = 4;
            this.WidthBox.ValidatingType = typeof(int);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Character Size";
            // 
            // AuthorBox
            // 
            this.AuthorBox.Location = new System.Drawing.Point(58, 45);
            this.AuthorBox.Name = "AuthorBox";
            this.AuthorBox.Size = new System.Drawing.Size(158, 20);
            this.AuthorBox.TabIndex = 2;
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(58, 19);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(158, 20);
            this.NameBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Author";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // NewFontForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 82);
            this.Controls.Add(this.FontInfoGroupBox);
            this.Name = "NewFontForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Font";
            this.FontInfoGroupBox.ResumeLayout(false);
            this.FontInfoGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox FontInfoGroupBox;
        private System.Windows.Forms.Button CANCELBTN;
        private System.Windows.Forms.Button OKBTN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox HeightBox;
        private System.Windows.Forms.MaskedTextBox WidthBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox AuthorBox;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}