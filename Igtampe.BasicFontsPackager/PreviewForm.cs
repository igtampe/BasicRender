using System;
using System.Windows.Forms;
using Igtampe.BasicFonts;

namespace Igtampe.BasicFontsPackager {
    public partial class PreviewForm:Form {
        
        public PreviewForm(BasicFont Font) {
            InitializeComponent();
            MyFont = Font;
        }

        public BasicFont MyFont;

        private void TextBox1_TextChanged(object sender,EventArgs e) {
            Console.Clear();
            //Console.SetBufferSize(Math.Max(CalcSize(textBox1.Text),30),Math.Max(MyFont.Height + 2,10));
            //Console.SetWindowSize(Math.Max(CalcSize(textBox1.Text),30),Math.Max(MyFont.Height + 2,10));

            MyFont.DrawText(textBox1.Text,0,0,ConsoleColor.White);
        }

        private int CalcSize(string Text) { return (Text.Length * (MyFont.Width+1))+2; }

    }
}
