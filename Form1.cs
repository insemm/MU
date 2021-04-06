using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String[] fileName;
        String[] filePath;
        String currentSong;

        private void Form1_Load(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileNames;

                    //Read the contents of the file into a stream
                    fileName = openFileDialog.SafeFileNames;
                }
            }
            currentSong = fileName[0];
            for (int i = 0; i < fileName.Length; i++)
            {
                Songlist.Items.Add(fileName[i]);
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            axWindowsMediaPlayer1.URL = currentSong;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSong = filePath[Songlist.SelectedIndex];
        }
    }
}
