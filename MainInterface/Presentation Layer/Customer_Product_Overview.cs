using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainInterface.Logic;

namespace MainInterface.Presentation
{
    public partial class Customer_Product_Overview : Form

    {
        public Customer_Product_Overview()
        {
            InitializeComponent();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 Form = new Form1();
            Form.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Customer_Review Form = new Customer_Review();
            Form.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Customer_Receipt Form = new Customer_Receipt();
            //Form.Show();
            //Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Barcode_Scanner Form = new Barcode_Scanner();
            //Form.Show();
            //Hide();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        LogicWork l1 = new LogicWork();
        private void Button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = l1.Customer_Product_Search(textBox1.Text);

            //  gets  specific product info based on textfield

        }

        private void Customer_Product_Overview_Load(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
