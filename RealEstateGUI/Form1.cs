using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;




namespace RealEstateGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            MySqlConnection kapcs = new MySqlConnection("server = localhost; User ID = root; Database = ingatlan");
            kapcs.Open();
            MySqlCommand parancs = new MySqlCommand("select * from sellers order by name", kapcs);
            MySqlDataReader mrd = parancs.ExecuteReader();
            List<Seller> nevek = new List<Seller>();
            
            while (mrd.Read())
            {
                
                nevek.Add(new Seller(mrd.GetInt32("Id"),mrd["name"].ToString(),mrd["phone"].ToString()));
                
                
            }
            kapcs.Close();
            listBox1.DataSource = nevek;
            listBox1.DisplayMember = "Name";
            label2.DataBindings.Add(new Binding("Text",nevek,"Name"));
            label4.DataBindings.Add(new Binding("Text",nevek,"Phone"));
            
            
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            listBox1.Width = ClientSize.Width / 4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection kapcs = new MySqlConnection("server = localhost; User ID = root; Database = ingatlan");
                kapcs.Open();
                MySqlCommand parancs = new MySqlCommand("select COUNT(id) as darab from realestates WHERE sellerid = @selid", kapcs);
                int selid = (listBox1.SelectedItem as Seller).Id;
                parancs.Parameters.Add(new MySqlParameter("@selid",selid));
                MySqlDataReader mrd = parancs.ExecuteReader();

                mrd.Read();
                label6.Text = mrd.GetInt64("darab").ToString();
                kapcs.Close();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Hiba a hirdetések lekérdezésében!"+ex.Message);
            }

        }
    }
}
