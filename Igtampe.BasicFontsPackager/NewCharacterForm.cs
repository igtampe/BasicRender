using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Igtampe.BasicFontsPackager {
    public partial class NewCharacterForm:Form {
        private readonly IEnumerable<String> ExistingCharacters;
        private NewCharacterForm(IEnumerable<string> ExistingCharacters) {
            InitializeComponent();
            this.ExistingCharacters = ExistingCharacters;
            DialogResult = DialogResult.Cancel;
        }

        private void CancelButton_Click(object sender,EventArgs e) {Close();}

        private void OKButton_Click(object sender,EventArgs e) {
            if(string.IsNullOrWhiteSpace(CharBox.Text)) { MessageBox.Show("Character cannot be empty","New Character Form",MessageBoxButtons.OK,MessageBoxIcon.Error); return; }
            if(ExistingCharacters.Contains(CharBox.Text)) { MessageBox.Show("Character already exists!","New Character Form",MessageBoxButtons.OK,MessageBoxIcon.Error); return; }
            DialogResult = DialogResult.OK;
            Close();
        }

        public static char GetNewCharacter(IEnumerable<string> ExistingCharacters) {
            NewCharacterForm NCF = new NewCharacterForm(ExistingCharacters);
            if(NCF.ShowDialog() == DialogResult.OK) {return NCF.CharBox.Text[0];}
            return ' ';
        }
    }
}
