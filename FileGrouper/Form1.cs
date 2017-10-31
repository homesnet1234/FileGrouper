using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileGrouper
{
    public partial class fileGrouper : Form
    {
        public fileGrouper()
        {
            InitializeComponent();
        }

        private void group_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                return;

            string path = folderBrowserDialog.SelectedPath;

            foreach (string f in Directory.GetFiles(path))
            {
                Console.Out.WriteLine(f);
                string[] buffer = f.Split('.');
                string fileName = f.Substring(f.LastIndexOf('\\'));

                if (buffer.Length == 1)
                {
                    Directory.CreateDirectory(path + "\\Other");
                    File.Move(f, @"" + path + "\\Other\\" + fileName);
                }
                else
                {
                    Directory.CreateDirectory(path + "\\" + buffer[buffer.Length - 1]);
                    File.Move(f, @"" + path + "\\" + buffer[buffer.Length - 1] + "\\" + fileName);
                }
            }
        }
    }
}
