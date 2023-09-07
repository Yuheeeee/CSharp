using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TekeVerseny;


namespace TekeVersenyGUI
{
    public partial class Form1 : Form
    {
        List<Eredmeny> eredmenyek;
        public Form1()
        {
            InitializeComponent();
        }

        private void megnyitásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                eredmenyek = Eredmeny.LoadFromCsv(openFileDialog1.FileName);
                listBox1.Items.AddRange(eredmenyek.ToArray());
                //vagy: listBox1.DataSource = eredmenyek;
            }
        }

        private void kliépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >=0)
            {
                listBox2.Items.Clear();
                Eredmeny kj = (Eredmeny)listBox1.SelectedItem;
                textBox1.Text = kj.Jatekos.Nev; 
                textBox2.Text = kj.Klub.Egynev;
                textBox3.Text = kj.Jatekos.Rajtszam.ToString();
                textBox4.Text = kj.Jatekos.Korcsop;
                textBox5.Text = kj.Osszespont.ToString();
                textBox6.Text = kj.Ures.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Eredmeny kj = (Eredmeny)listBox1.SelectedItem;
                listBox2.Items.Clear();
                foreach (var item in eredmenyek)
                {
                    if (item.Klub.Egynev == kj.Klub.Egynev && item != kj)
                    {
                        listBox2.Items.Add($"{item.Jatekos.Nev} ({item.Jatekos.Korcsop} korcsoport)");
                    }
                }
                if (listBox2.Items.Count == 0)
                {
                    listBox2.Items.Add("Ugyanebből a klubból nem indult más versenyző.");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Nincs kiválasztva versenyző!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }
    }
}
