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

namespace Merkozesek
{
    public partial class Form1 : Form
    {

        private List<Merkozes> merkozesek;
        public Form1()
        {
            InitializeComponent();
            merkozesek = new List<Merkozes>();
        }

        private void megnyitásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                string fajl = openFileDialog1.FileName;
                string[] sorok = File.ReadAllLines(fajl);
                foreach (string sor in sorok)
                {
                    merkozesek.Add(new Merkozes(sor));
                }
                listBox1.Items.AddRange(merkozesek.ToArray());
            }
        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Merkozes m = (Merkozes)listBox1.SelectedItem;
            tboxCsapatok.Text = m.ToString();
            tboxFordulo.Text = m.Fordulo.ToString();
            tboxVege.Text = m.HazaiRugott + " - " + m.VendegRugott;
            tboxFelido.Text = m.HazaiRugottFelido + " - " + m.VendegRugottFelido;
            listBox2.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( listBox1.SelectedIndex>=0)
            {
                Merkozes kiv = (Merkozes)listBox1.SelectedItem;
                foreach (Merkozes meccs in merkozesek)
                {
                    if (meccs.Fordulo==kiv.Fordulo && meccs!=kiv)
                    {
                        listBox2.Items.Add($"{meccs.ToString()} ({meccs.HazaiRugott}-{meccs.VendegRugott})");
                    }
                }
            } else
            {
                MessageBox.Show("Nincs kiválasztva mérkőzés!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void statisztikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ( merkozesek.Count>0)
            {
                StatisztikaForm sf = new StatisztikaForm();
                sf.merkozesek = merkozesek;
                sf.ShowDialog();
            } else
            {
                MessageBox.Show("Nincsenek mérkőzések betöltve!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void fordítottakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (merkozesek.Count>0)
            {
                StreamWriter sw = new StreamWriter("forditottak.txt");
                merkozesek.ForEach(meccs => { 
                    if ( (meccs.HazaiRugottFelido-meccs.VendegRugottFelido)<0 && (meccs.HazaiRugott-meccs.VendegRugott)>0 )
                    {
                        sw.WriteLine($"{meccs.Fordulo} {meccs.Hazai}");
                    } else if ((meccs.HazaiRugottFelido - meccs.VendegRugottFelido) > 0 && (meccs.HazaiRugott - meccs.VendegRugott) < 0 )
                    {
                        sw.WriteLine($"{meccs.Fordulo} {meccs.Vendeg}");
                    }
                });
                sw.Close();
                MessageBox.Show("A forditottak.txt létrehozva!", "Infó", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
