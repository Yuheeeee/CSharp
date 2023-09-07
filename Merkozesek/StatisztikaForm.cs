using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Merkozesek
{

    
    public partial class StatisztikaForm : Form
    {

        public List<Merkozes> merkozesek { get;  set; }
        public StatisztikaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int stfordulo = int.Parse(textBox1.Text);
                if (stfordulo<1 || stfordulo>14)
                {
                    throw new Exception("Nem 1-14 közötti szám!");
                }
                List<Merkozes> stlista = new List<Merkozes>();
                merkozesek.ForEach(m =>
                {
                    if (m.Fordulo == stfordulo) stlista.Add(m);
                });
                textBox2.Text = stlista.Count.ToString();

                int hgy = 0;
                int vgy = 0;
                int golszumma = 0;
                stlista.ForEach(sm => {
                    if (sm.HazaiRugott > sm.VendegRugott) hgy++;
                    if (sm.HazaiRugott < sm.VendegRugott) vgy++;
                    golszumma += (sm.HazaiRugott + sm.VendegRugott);
                });
                textBox3.Text = hgy.ToString();
                textBox4.Text = vgy.ToString();
                
                foreach (var sm in stlista)
                {
                    double smgol = (sm.HazaiRugott + sm.VendegRugott);
                    double arany = (smgol / golszumma) * 100;
                    Label cscimke = new Label();
                    cscimke.AutoSize = true;
                    cscimke.Text = sm.ToString();
                    tableLayoutPanel1.Controls.Add(cscimke);
                    Label acimke = new Label();
                    acimke.AutoSize = true;
                    acimke.Text = arany.ToString("F2")+" %";
                    tableLayoutPanel1.Controls.Add(acimke);
                    

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Hiba a forduló számának megadásában!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
