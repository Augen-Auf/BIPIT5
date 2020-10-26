using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace БИПиТ5
{
    public partial class Form1 : Form
    {
        readonly ServiceReference1.Service1Client wfc = new ServiceReference1.Service1Client();
        public Form1()
        {
            InitializeComponent();   
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (string[] rows in wfc.GetData())
                    dataGridView1.Rows.Add(rows);

                comboBox1.DataSource = new BindingSource(wfc.Clients(), null);
                comboBox1.DisplayMember = "Value";
                comboBox1.ValueMember = "Key";

                comboBox2.DataSource = new BindingSource(wfc.Services(), null);
                comboBox2.DisplayMember = "Value";
                comboBox2.ValueMember = "Key";
            }
            catch (EndpointNotFoundException exc)
            {
                MessageBox.Show("Host closed!".ToString());
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {   if (Convert.ToInt32(textBox1.Text) <= 0)
                    label6.Text = "Число должно быть положительным!";
                else
                {
                    wfc.NewRec(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedValue),
                    Convert.ToInt32(textBox1.Text), dateTimePicker1.Value);
                    dataGridView1.Rows.Clear();
                    label6.Text = "";
                    foreach (string[] rows in wfc.GetData())
                        dataGridView1.Rows.Add(rows);
                }
            }
            catch (EndpointNotFoundException exc)
            {
                MessageBox.Show("Host closed!".ToString());
            }
            catch (Exception exc)
            {
                label6.Text = "Входная строка(и) имела(и) неверный формат!";
            }
        }
    }
}
