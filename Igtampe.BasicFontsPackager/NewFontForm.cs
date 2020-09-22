using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Igtampe.BasicFontsPackager {
    public partial class NewFontForm:Form {
        private NewFontForm() {InitializeComponent(); DialogResult = DialogResult.Cancel; }

        private void OKBTN_Click(object sender,EventArgs e) {
            if(string.IsNullOrWhiteSpace(NameBox.Text)) { MessageBox.Show("Name cannot be empty","New Font Form",MessageBoxButtons.OK,MessageBoxIcon.Error); return; }
            if(string.IsNullOrWhiteSpace(AuthorBox.Text)) { MessageBox.Show("Author cannot be empty","New Font Form",MessageBoxButtons.OK,MessageBoxIcon.Error); return; }
            if(string.IsNullOrWhiteSpace(WidthBox.Text)) { MessageBox.Show("Width cannot be empty","New Font Form",MessageBoxButtons.OK,MessageBoxIcon.Error); return; }
            if(string.IsNullOrWhiteSpace(HeightBox.Text)) { MessageBox.Show("Height cannot be empty","New Font Form",MessageBoxButtons.OK,MessageBoxIcon.Error); return; }
            DialogResult = DialogResult.OK;
        }

        private void CANCELBTN_Click(object sender,EventArgs e) { Close(); }

        public static Dictionary<string,string> CreateNewFont() {

            Dictionary<string,string> NewFont = null;

            NewFontForm NFF = new NewFontForm();
            if(NFF.ShowDialog() == DialogResult.OK){
                NewFont = new Dictionary<string,string> {
                    { "Name",NFF.NameBox.Text },
                    { "Author",NFF.AuthorBox.Text },
                    { "CharWidth",NFF.WidthBox.Text },
                    { "CharHeight",NFF.HeightBox.Text }
                };
            }

            return NewFont;
        }

    }
}
