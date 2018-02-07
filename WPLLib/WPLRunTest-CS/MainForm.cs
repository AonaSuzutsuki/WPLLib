using System;
using System.Windows.Forms;
using WPLLib;


namespace WPLRunTest_CS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void SaveBT_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.FileName = "";
            sfd.InitialDirectory = @"C:\";
            sfd.Filter = "Windows Play List(*.wpl)|*.wpl|All Files(*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.Title = "Please select a file destination";
            sfd.RestoreDirectory = true;
            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;

            //Create WPL File.
            //First argument: Path of file to be saved
            //Second argument: ArrayList of the MediaList
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                WPLLib.Writer wplWrite = new Writer(sfd.FileName);
                foreach (string filePath in MusicList.Items)
                {
                    wplWrite.Add(filePath);
                }
                wplWrite.Write();
            }
        }
        private void LoadBT_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.FileName = "";
            ofd.InitialDirectory = @"C:\";
            ofd.Filter = "Windows Play List(*.wpl)|*.wpl|All Files(*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.Title = "Please select a file to open";
            ofd.RestoreDirectory = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                WPLLib.Reader wplReader = new Reader(ofd.FileName);
                wplReader.Read();
                WPLLib.MediaArray medias = wplReader.GetMediaArray();

                foreach (Media media in medias)
                {
                    MusicList.Items.Add(media.FilePath);
                }
            }
        }

        private void MusicList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void MusicList_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string filePath in filePaths)
            {
                MusicList.Items.Add(filePath);
            }
        }
    }
}
