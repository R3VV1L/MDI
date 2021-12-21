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

namespace Lab_5_MDI
{
    public partial class blank : Form
    {
        public blank()
        {
            InitializeComponent();
        }
        public Image Photo // добавление фото
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }
        public bool IsSaved = false;
        public String DocName;
        private void blank_Load(object sender, EventArgs e)
        {

        }

        public void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void fonts(string fontnames)
        {
            richTextBox1.SelectionFont = new Font(fontnames, 14);
        }
        public void colorfontred(string colorname)
        {
            richTextBox1.SelectionColor = System.Drawing.Color.Red;
        }
        public void colorfontblue(string colorname)
        {
            richTextBox1.SelectionColor = System.Drawing.Color.Blue;
        }
        public void colorfontgreen(string colorname)
        {
            richTextBox1.SelectionColor = System.Drawing.Color.Green;
        }

        public void Cut()
        { // Вырезание текста
            this.BufferText = richTextBox1.SelectedText;
            richTextBox1.SelectedText = "";
        }
        public void Copy()
        { // Копирование текста
            this.BufferText = richTextBox1.SelectedText;
        }
        public void Paste()
        { // Вставка
            richTextBox1.SelectedText = this.BufferText;
        }
        // Выделение всего текста – используем свойство SelectAll элемента управления RichTextBox
        
        private string BufferText;

        public void SelectAll()
        {
            richTextBox1.SelectAll();
        }
        public void Delete()
        { // Удаление
            richTextBox1.SelectedText = "";
            this.BufferText = "";
        }
        private void cmnuCut_Click(object sender, EventArgs e)
        {
            Cut();
        }
        private void cmnuCopy_Click(object sender, EventArgs e)
        {
            Copy();
        }
        private void cmnuPaste_Click(object sender, EventArgs e)
        {
            Paste();
        }
        private void cmnuDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void cmnuSelectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }
        public void Open(String OpenFileName)
        {
            if (OpenFileName == null) { return; }
            else
            {
                StreamReader sr = new StreamReader(OpenFileName);
                richTextBox1.Text = sr.ReadToEnd(); sr.Close();
                DocName = OpenFileName;
            }
        }
        public void Save(String SaveFileName)
        {
            if (SaveFileName == null) { return; }
            else
            {
                StreamWriter sw = new StreamWriter(SaveFileName);
                sw.WriteLine(richTextBox1.Text); sw.Close(); //Устанавливаемимя документа
                DocName = SaveFileName;
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.Save(frm.DocName); 
        }
        private void blank_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            if (IsSaved == true)
                if (MessageBox.Show("Do you want save changes in " + this.DocName + "?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Save(this.DocName);
                }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) //name
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) //mail
        {

        }

        private void button1_Click(object sender, EventArgs e) //add photo
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)

                pictureBox1.Image = new Bitmap(ofd.FileName);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}