using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadFond();
            loadSize();
            rtbVanBan.Font = new Font ("Tahoma",14,FontStyle.Regular);
        }
        private void loadFond()
        {
            foreach (FontFamily fontFamily in new InstalledFontCollection().Families)
            {
                cmbFont.Items.Add(fontFamily.Name);

            }
            cmbFont.SelectedItem = "Tahoma";
        }
        private void loadSize()
        {
            int[] sizeValues = new int[] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            cmbSize.ComboBox.DataSource = sizeValues;
            cmbSize.SelectedItem = 14;
        }

        private void mởVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rtbVanBan.Text))
            {
                var result = MessageBox.Show("Bạn có muốn lưu nội dung trước khi mở tệp tin mới?", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    lưuNộiDungVănBảnToolStripMenuItem_Click(sender, e); // Gọi hàm lưu nội dung
                }
                else if (result == DialogResult.Cancel)
                {
                    return; // Thoát nếu người dùng chọn Cancel
                }
            }

            // Mở hộp thoại chọn tệp
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"; // Bộ lọc loại tệp
                openFileDialog.Title = "Mở tệp văn bản";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Đọc nội dung tệp và hiển thị trong RichTextBox
                        string fileContent = File.ReadAllText(openFileDialog.FileName);
                        rtbVanBan.Text = fileContent;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi mở tệp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.Title = "Lưu Văn Bản";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Lưu nội dung của RichTextBox vào tệp
                    System.IO.File.WriteAllText(saveFileDialog.FileName, rtbVanBan.Text);
                    MessageBox.Show("Đã lưu văn bản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Thông báo lỗi nếu không thể lưu
                    MessageBox.Show("Đã xảy ra lỗi khi lưu tệp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbVanBan.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Filter = "Text files (*.txt)|*.txt|RichText files(*.rft)|*.rft";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog.FileName;
                try
                {
                    if (Path.GetExtension(selectedFileName).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        rtbVanBan.LoadFile(selectedFileName, RichTextBoxStreamType.PlainText);
                    }
                    else
                    {
                        rtbVanBan.LoadFile(selectedFileName, RichTextBoxStreamType.RichText);
                    }
                    MessageBox.Show("Tap tin da duoc mo thanh cong", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Da xay ra loi" + ex.Message, "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            rtbVanBan.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Filter = "Text files (*.txt)|*.txt|RichText files(*.rft)|*.rft";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog.FileName;
                try
                {
                    if (Path.GetExtension(selectedFileName).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        rtbVanBan.LoadFile(selectedFileName, RichTextBoxStreamType.PlainText);
                    }
                    else
                    {
                        rtbVanBan.LoadFile(selectedFileName, RichTextBoxStreamType.RichText);
                    }
                    MessageBox.Show("Tap tin da duoc mo thanh cong", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Da xay ra loi" + ex.Message, "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.Title = "Lưu Văn Bản";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Lưu nội dung của RichTextBox vào tệp
                    System.IO.File.WriteAllText(saveFileDialog.FileName, rtbVanBan.Text);
                    MessageBox.Show("Đã lưu văn bản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Thông báo lỗi nếu không thể lưu
                    MessageBox.Show("Đã xảy ra lỗi khi lưu tệp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if(rtbVanBan.SelectionFont != null)
            {
                FontStyle style = rtbVanBan.SelectionFont.Style;
                if (rtbVanBan.SelectionFont.Bold)
                {
                    //Neu van ban da dam xoa thuoc tinh bold ra khoi Fontstyle hien tai
                    style &= ~ FontStyle.Bold;
                }
                else
                {
                    //Nguoc lai
                    style |= FontStyle.Bold;
                }
                rtbVanBan.SelectionFont = new Font(rtbVanBan.SelectionFont,style);
            }

        }

        private void btnItalic_Click(object sender, EventArgs e)
        {

            if (rtbVanBan.SelectionFont != null)
            {
                FontStyle style = rtbVanBan.SelectionFont.Style;
                if (rtbVanBan.SelectionFont.Italic)
                {
                    //Neu van ban da dam xoa thuoc tinh bold ra khoi Fontstyle hien tai
                    style &= ~FontStyle.Italic;
                }
                else
                {
                    //Nguoc lai
                    style |= FontStyle.Italic;
                }
                rtbVanBan.SelectionFont = new Font(rtbVanBan.SelectionFont, style);
            }
        }

        private void btnUnderLine_Click(object sender, EventArgs e)
        {

            if (rtbVanBan.SelectionFont != null)
            {
                FontStyle style = rtbVanBan.SelectionFont.Style;
                if (rtbVanBan.SelectionFont.Underline)
                {
                    //Neu van ban da dam xoa thuoc tinh bold ra khoi Fontstyle hien tai
                    style &= ~FontStyle.Underline;
                }
                else
                {
                    //Nguoc lai
                    style |= FontStyle.Underline;
                }
                rtbVanBan.SelectionFont = new Font(rtbVanBan.SelectionFont, style);
            }
        }
    }
}