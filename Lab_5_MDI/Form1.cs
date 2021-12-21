using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_5_MDI
{
    public partial class Form1 : Form
    {
        private blank frm;
        private int openDoc;

        public Form1()
        {
            InitializeComponent();
            saveToolStripMenuItem.Enabled = false;
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                blank frm = (blank)(this.ActiveMdiChild);
                frm.Save(saveFileDialog1.FileName); frm.MdiParent = this;
                frm.DocName = saveFileDialog1.FileName; frm.Text = frm.DocName;
            }
        }

            private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void aboutProgrammToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new blank();
            frm.DocName = "Документ " + ++openDoc;
            frm.Text = frm.DocName; frm.MdiParent = this;
            frm.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // задание доступных расширений файлов программно
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                blank frm = new blank(); frm.Open(openFileDialog1.FileName);
                frm.MdiParent = this; //Указываем родительскую форму 
                                      //Присваиваем переменной DocName имя открываемого файла
                frm.DocName = openFileDialog1.FileName;
                //Свойству Text формы присваиваем переменную DocName
                frm.Text = frm.DocName;
                frm.Show();
            }
        }

        private void arrageIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.Cut();
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.Copy();
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.SelectAll();
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.Paste();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.Delete();
        }
        private void arbatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.fonts("18thCentury");
        }

        private void arialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.fonts("Brandish");
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.colorfontred("");
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.colorfontblue("");
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.colorfontgreen("");
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            saveToolStripMenuItem.Enabled = true;
            // задание доступных расширений файлов программно
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                blank frm = new blank(); frm.Open(openFileDialog1.FileName);
                frm.MdiParent = this; //Указываем родительскую форму 
                                      //Присваиваем переменной DocName имя открываемого файла
                frm.DocName = openFileDialog1.FileName;
                //Свойству Text формы присваиваем переменную DocName
                frm.Text = frm.DocName;
                frm.Show();
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            frm.IsSaved = true;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem.Enabled = true;
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                blank frm = (blank)(this.ActiveMdiChild);
                frm.Save(saveFileDialog1.FileName); frm.MdiParent = this;
                frm.DocName = saveFileDialog1.FileName; frm.Text = frm.DocName;
                frm.IsSaved = true;
            }
        }
    }
}