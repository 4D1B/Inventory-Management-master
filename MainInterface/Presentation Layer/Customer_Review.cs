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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MainInterface.Logic;

namespace MainInterface.Presentation
{
    public partial class Customer_Review : Form
    {
        public Customer_Review()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer_Product_Overview Form = new Customer_Product_Overview();
            Form.Show();
            Hide();
        }
        public Double value = 0;

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            value = 1;
            //   MessageBox.Show("Bad");
            // DialogResult res = MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            value = 2;
            // MessageBox.Show("Good");
            // DialogResult res = MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            value = 3;
            //  MessageBox.Show("Sufficient");
            // DialogResult res = MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            value = 4;
            // MessageBox.Show("Excellent");
            //   DialogResult res = MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            value = 5;
            //  MessageBox.Show("Proficient");
            //   DialogResult res = MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Customer_Review_Load(object sender, EventArgs e)
        {

            SqlDataReader dr;

            l1.CustomerReviewMainSurface(comboBox1, comboBox2, comboBox3);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // SqlDataReader dr;
            // comboBox2 = ;
            // comboBox3 = ;
            l1.CustomerRating(comboBox1.SelectedItem.ToString(), comboBox2, comboBox3);
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        LogicWork l1 = new LogicWork();
        private void Button2_Click(object sender, EventArgs e)
        {
            l1.Customer_Rating_Select(comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), comboBox3.SelectedItem.ToString());
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            l1.Customer_Rating_Select(comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), comboBox3.SelectedItem.ToString());
            MessageBox.Show(value.ToString());
            l1.Shoot_Rating(value, comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), comboBox3.SelectedItem.ToString());
        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
