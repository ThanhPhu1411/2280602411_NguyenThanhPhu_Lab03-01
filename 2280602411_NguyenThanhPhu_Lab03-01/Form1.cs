using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2280602411_NguyenThanhPhu_Lab03_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var date = DateTime.Now.ToString("dd/MM/yy");
            var time = DateTime.Now.ToString("hh:mm:ss tt ");
            this.toolStripStatusLabel1.Text = string.Format($"Hôm nay là ngày : {date}- Bây giờ là {time}");

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tao hop thoai mo file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //loc hien thi cac loai file
            openFileDialog.Filter = "Video Files |*.mp4;*.avi;*.mkv;*.wmv;*.png;*.mp3";
            if(openFileDialog.ShowDialog() == DialogResult.OK )
            {
                //Mo video voi windows media Player 
                axWindowsMediaPlayer1.URL = openFileDialog.FileName;
            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult drl = MessageBox.Show("Thoat thiet ha?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(drl == DialogResult.No ) e.Cancel = true;
        }
    }
}
