﻿using System;
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
    public partial class TextEditorWindow : Form
    {
        AccountHandler accountLoad;

        MemoryStream userInput = new MemoryStream();

        bool flag_save = false;

        string filePath;

        string fileName;


        public TextEditorWindow(ref AccountHandler accountLoad)
        {
            InitializeComponent();
            this.accountLoad = accountLoad;
            Show();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

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

        }

        private void saveas_Click(object sender, EventArgs e)
        {
            flag_save = true;
            richTextBox1.SaveFile(userInput, RichTextBoxStreamType.RichText);
            userInput.WriteByte(13);
            // Set the properties on SaveFileDialog1 so the user is 
            // prompted to create the file if it doesn't exist 
            // or overwrite the file if it does exist.
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.CreatePrompt = true;
            SaveFileDialog1.OverwritePrompt = true;

            // Set the file name to myText.txt, set the type filter
            // to text files, and set the initial directory to the 
            // MyDocuments folder.
            // DefaultExt is only used when "All files" is selected from 
            // the filter box and no extension is specified by the user.
            SaveFileDialog1.DefaultExt = "txt";
            SaveFileDialog1.Filter =
                "rtf files (*.rtf)|*.rtf";
            SaveFileDialog1.InitialDirectory =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Call ShowDialog and check for a return value of DialogResult.OK,
            // which indicates that the file was saved. 
            DialogResult result = SaveFileDialog1.ShowDialog();
            Stream fileStream;

            if (result == DialogResult.OK)
            {
                // Open the file, copy the contents of memoryStream to fileStream,
                // and close fileStream. Set the memoryStream.Position value to 0 
                // to copy the entire stream. 
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
