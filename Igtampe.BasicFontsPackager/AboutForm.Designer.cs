namespace Igtampe.BasicFontsPackager {
    partial class AboutForm {
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
            this.About = new System.Windows.Forms.Label();
            this.OKBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // About
            // 
            this.About.Location = new System.Drawing.Point(12, 9);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(189, 32);
            this.About.TabIndex = 0;
            this.About.Text = "BasicFonts Editor\r\n(C)2020 Igtampe, No Rights Reserved\r\n\r\n";
            this.About.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OKBTN
            // 
            this.OKBTN.Location = new System.Drawing.Point(67, 44);
            this.OKBTN.Name = "OKBTN";
            this.OKBTN.Size = new System.Drawing.Size(75, 23);
            this.OKBTN.TabIndex = 1;
            this.OKBTN.Text = "OK";
            this.OKBTN.UseVisualStyleBackColor = true;
            this.OKBTN.Click += new System.EventHandler(this.OKBTN_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 77);
            this.Controls.Add(this.OKBTN);
            this.Controls.Add(this.About);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label About;
        private System.Windows.Forms.Button OKBTN;
    }
}