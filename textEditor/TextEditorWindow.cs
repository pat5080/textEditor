using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace textEditor
{

    /* This class contains all the functionality related to the richtextbox and the click events that trigger other methods and code blocks */
    public partial class TextEditorWindow : Form
    {
        MemoryStream userInput = new MemoryStream();

        bool flag_save = false;

        string filePath;

        string fileName;

        string userType;

        string accountName;


        public TextEditorWindow(string accountName, string userType)
        {
            InitializeComponent();
            Show();

            this.accountName = accountName;
            this.userType = userType;

            userToolStripLabel.Text = "User: " + accountName;

            if(userType == "View")
            {
                disable_buttons();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void about_Click(object sender, EventArgs e)
        {
            About about1 = new About();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            LoginScreen login1 = new LoginScreen();
            this.Hide();
        }

        private void new_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            saveas_Click(sender, e);
        }

        /* The function below disables button functionality depending on the user type */
        private void disable_buttons()
        {
            richTextBox1.ReadOnly = true;

            saveAsToolStripMenuItem.Enabled = false;
            toolStripButton3.Enabled = false;

            toolStripButton4.Enabled = false;
            saveToolStripMenuItem.Enabled = false;

            toolStripMenuItem4.Enabled = false;
            toolStripButton1.Enabled = false;

            cutToolStripMenuItem.Enabled = false;
            cutToolStripButton.Enabled = false;

            pasteToolStripButton.Enabled = false;
            pasteToolStripMenuItem.Enabled = false;
        }

        /* Open dialog box*/
        private void open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.Filter = "rtf files (*.rtf)|*.rtf";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                flag_save = true;
                //Get the path of specified file
                fileName = openFileDialog1.FileName;
                filePath = Path.GetDirectoryName(fileName);

                //Read the contents of the file into a stream
                //var fileStream = openFileDialog1.OpenFile();

                richTextBox1.LoadFile(fileName);

            }

        }
        /* Save dialog */
        private void save_Click(object sender, EventArgs e)
        {

            if (flag_save)
            {
                richTextBox1.SaveFile(userInput, RichTextBoxStreamType.RichText);
                userInput.WriteByte(13);

                Stream fileStream;

                fileStream = File.Open(fileName, FileMode.Open);
                userInput.Position = 0;
                userInput.WriteTo(fileStream);
                fileStream.Close();
            }
            else
            {
                saveas_Click(sender, e);
                flag_save = true;
            }
            
        }

        private void bold_Click(object sender, EventArgs e)
        {
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
        }

        private void italic_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Italic);
        }

        private void underline_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Underline);
        }

        private void size_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, float.Parse(sizeToolStripComboBox.SelectedItem.ToString()));
        }

        private void saveas_Click(object sender, EventArgs e)
        {
            flag_save = true;
            richTextBox1.SaveFile(userInput, RichTextBoxStreamType.RichText);
            userInput.WriteByte(13);

            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.CreatePrompt = true;
            SaveFileDialog1.OverwritePrompt = true;

            SaveFileDialog1.DefaultExt = "txt";
            SaveFileDialog1.Filter =
                "rtf files (*.rtf)|*.rtf";
            SaveFileDialog1.InitialDirectory =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            DialogResult result = SaveFileDialog1.ShowDialog();
            Stream fileStream;

            if (result == DialogResult.OK)
            {
                fileName = SaveFileDialog1.FileName;
                filePath = Path.GetDirectoryName(fileName);
                fileStream = SaveFileDialog1.OpenFile();
                userInput.Position = 0;
                userInput.WriteTo(fileStream);
                fileStream.Close();
            }
        }
    }
}
