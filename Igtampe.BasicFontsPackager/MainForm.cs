using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Igtampe.DictionaryOnDisk;
using Igtampe.BasicFonts;
using Igtampe.Henja3.Editors;
using System.Linq;
using System.Diagnostics;

namespace Igtampe.BasicFontsPackager {
    public partial class MainForm:Form {

        //-[Variables]------------------------------------------------------------------------------------------------

        /// <summary>Holds the font being built</summary>
        private Dictionary<String,String> FontBeingBuilt;

        /// <summary>Holds the filename where the font will be eventually saved to or loaded from</summary>
        private string Filename;

        //-[Constructors]------------------------------------------------------------------------------------------------

        /// <summary>Creates a Main Form</summary>
        public MainForm() {
            InitializeComponent();
            MainTableLayout.Enabled = false;
            openCharacterToolStripMenuItem.Enabled = false;
            deleteToolStripMenuItem.Enabled = false;
        }

        /// <summary>Creates a main form and loads the specified file.</summary>
        /// <param name="Filename"></param>
        public MainForm(String Filename):this() {LoadFont(Filename);}

        //-[MenuStrip Items]------------------------------------------------------------------------------------------------

        /// <summary>Creates a new Font</summary>
        private void NewToolStripMenuItem_Click(object sender,EventArgs e) {
            var PreBuilt = NewFontForm.CreateNewFont();
            if(PreBuilt != null) {
                FontBeingBuilt = PreBuilt;
                NameBox.Text = FontBeingBuilt["Name"];
                AuthorBox.Text = FontBeingBuilt["Author"];
                MainTableLayout.Enabled = true; 
            }
        }

        /// <summary>Creates the Preview Window and shows it</summary>
        private void PreviewToolStripMenuItem_Click(object sender,EventArgs e) {
            if(FontBeingBuilt == null) { return; }
            new PreviewForm(new BasicFont(FontBeingBuilt)).ShowDialog();
        }

        /// <summary>Shows an OpenFileDialog, and if OK, loads the file</summary>
        private void OpenToolStripMenuItem_Click(object sender,EventArgs e) {
            OpenFileDialog FileDialog = new OpenFileDialog {
                Title = "Open a Font",
                Filter = "Basic Font (*.bfnt)|*.bfnt",
                DefaultExt = ".bfnt",
                CheckFileExists = true,
                Multiselect = false
            };
            if(FileDialog.ShowDialog() == DialogResult.OK) { LoadFont(FileDialog.FileName); }
        }

        /// <summary>Saves the file to disk</summary>
        private void SaveToolStripMenuItem_Click(object sender,EventArgs e) {
            if(String.IsNullOrEmpty(Filename)) { SaveAsToolStripMenuItem_Click("Yes this is an object",null); return; }
            SaveFont();
        }

        /// <summary>Askss the user where to save the file to, then saves it</summary>
        private void SaveAsToolStripMenuItem_Click(object sender,EventArgs e) {
            SaveFileDialog FileDialog = new SaveFileDialog {
                Title = "Save a Font",
                Filter = "Basic Font (*.bfnt)|*.bfnt",
                DefaultExt = ".bfnt",
                AddExtension = true,
            };
            if(FileDialog.ShowDialog() == DialogResult.OK) { Filename = FileDialog.FileName; SaveFont(); }
        }

        /// <summary>Exits the program</summary>
        private void ExitToolStripMenuItem_Click(object sender,EventArgs e) { Close(); }

        /// <summary>Asks the user for a new character, and then generates it</summary>
        private void NewCharacterToolStripMenuItem_Click(object sender,EventArgs e) {
            if(FontBeingBuilt == null) { return; }

            Char NewChar = NewCharacterForm.GetNewCharacter(CharacterListBox.Items.Cast<string>());
            if(NewChar == ':') {
                if(FontBeingBuilt.ContainsKey("Char" + "Colon")) { MessageBox.Show("Character already exists!","New Character Form",MessageBoxButtons.OK,MessageBoxIcon.Error); return; }
                FontBeingBuilt.Add("CharColon",GenerateNewCharacterData());
                Searchbox.Text = "";
                LoadCharacters("");
                return;
            }

            if(NewChar != ' ') {
                if(FontBeingBuilt.ContainsKey("Char" + NewChar)) { MessageBox.Show("Character already exists!","New Character Form",MessageBoxButtons.OK,MessageBoxIcon.Error); return; }
                FontBeingBuilt.Add("Char" + NewChar,GenerateNewCharacterData());
                Searchbox.Text = "";
                LoadCharacters("");
                return;
            }
        }

        /// <summary>Makes sure we can open a character, then opens it for editing.</summary>
        private void OpenCharacterToolStripMenuItem1_Click(object sender,EventArgs e) {
            if(FontBeingBuilt == null) { return; }
            if(CharacterListBox.SelectedItem == null) { return; }
            OpenCharacter(CharacterListBox.SelectedItem.ToString()[0]);
        }

        /// <summary>Asks the user if they're sure they want to delete the item, then deletes it</summary>
        private void DeleteCharacterToolStripMenuItem_Click(object sender,EventArgs e) {
            if(FontBeingBuilt == null) { return; }
            if(CharacterListBox.SelectedItem == null) { return; }

            if(MessageBox.Show("Are you sure you want to delete " + CharacterListBox.SelectedItem + "?","Are you sure?",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) {
                if((string)CharacterListBox.SelectedItem == ":") { FontBeingBuilt.Remove("Char" + "Colon"); } else { FontBeingBuilt.Remove("Char" + CharacterListBox.SelectedItem); }
            }
        }

        /// <summary>Shows the about window</summary>
        private void AboutToolStripMenuItem_Click(object sender,EventArgs e) { new AboutForm().ShowDialog(); }

        //-[Text Changes]------------------------------------------------------------------------------------------------

        private void NameBox_TextChanged(object sender,EventArgs e) { FontBeingBuilt["Name"] = NameBox.Text; }
        private void AuthorBox_TextChanged(object sender,EventArgs e) { FontBeingBuilt["Author"] = AuthorBox.Text; }
        private void Searchbox_TextChanged(object sender,EventArgs e) { LoadCharacters(Searchbox.Text); }
        private void CharacterListBox_SelectedIndexChanged(object sender,EventArgs e) { newCharacterToolStripMenuItem.Enabled = true; }

        //-[Internal Functions]------------------------------------------------------------------------------------------------

        /// <summary>Loads a font from a filename</summary>
        /// <param name="Filename"></param>
        private void LoadFont(String Filename) {
            if(!File.Exists(Filename)) { MessageBox.Show("File Does not exist!","BasicFont Editor",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            FontBeingBuilt = DOD.Load(Filename);

            if(!FontBeingBuilt.ContainsKey("Name") |
                !FontBeingBuilt.ContainsKey("Author") |
                !FontBeingBuilt.ContainsKey("CharWidth") |
                !FontBeingBuilt.ContainsKey("CharHeight")) { 
                MessageBox.Show("Provided font file is corrupt. It's missing certain details.");
                FontBeingBuilt = null;
            }

            NameBox.Text = FontBeingBuilt["Name"];
            AuthorBox.Text = FontBeingBuilt["Author"];
            this.Filename = Filename;

            LoadCharacters("");
            MainTableLayout.Enabled = true;
        }

        /// <summary>Loads characters (And searches for them if necessary)</summary>
        /// <param name="SearchString"></param>
        private void LoadCharacters(String SearchString) {

            //Clear the listbox's items
            CharacterListBox.Items.Clear();

            //Go through the keys and find characters.
            foreach(String Key in FontBeingBuilt.Keys) {
                if(Key.StartsWith("Char")) {
                    String CharToAdd = Key.Replace("Char","").Replace("Colon",":");
                    if(CharToAdd!="Width" && CharToAdd!="Height" &&(String.IsNullOrWhiteSpace(SearchString) || CharToAdd.Contains(SearchString))) { CharacterListBox.Items.Add(CharToAdd); }
                }
            }
        }

        /// <summary>Handles the DictionaryOnDisk call to save the font to disk</summary>
        public void SaveFont() { DOD.Save(FontBeingBuilt,Filename);}

        /// <summary>Creates new character data by creating a temporary DFEditor from Henja3</summary>
        /// <returns>A blank square of spaces, the size to fit a character of this font.</returns>
        private string GenerateNewCharacterData() {return String.Join("\n",new DFEditor().GenerateNew(int.Parse(FontBeingBuilt["CharWidth"]),int.Parse(FontBeingBuilt["CharHeight"]))).Replace('F',' ');}

        /// <summary>Handles the openning, editing through Henja3 and saving of a character.</summary>
        /// <param name="character"></param>
        private void OpenCharacter(Char character) {
            //Get the characters contents
            String CharContents;
            if(character == ':') { CharContents = FontBeingBuilt["CharColon"];} else { CharContents = FontBeingBuilt["Char"+character]; }

            //Convert character contents to DF Data
            CharContents = CharContents.Replace(' ','F').Replace('#','0');

            //Save this to a temp file for Henja 3 to open.
            File.WriteAllText("TempFile.DF",CharContents);

            //Start HENJA3 and wait for it.
            Process Henja3 = new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = "Henja3.exe",
                    Arguments = "TempFile.DF",
                }
            };

            Henja3.Start();
            Henja3.WaitForExit();

            //Load back the contents from the DF.
            CharContents = File.ReadAllText("TempFile.DF");

            //Turn it back into CharacterData
            CharContents = CharContents.Replace('F',' ').Replace('0','#');

            //Save the contents to the font.
            if(character == ':') { FontBeingBuilt["CharColon"]= CharContents; } else { FontBeingBuilt["Char" + character]= CharContents; }

            //Delete the temp file
            File.Delete("TempFile.df");

        }

    }
}
