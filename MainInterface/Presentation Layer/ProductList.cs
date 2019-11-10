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
    public partial class ProductList : Form
    {
        public ProductList()
        {
            InitializeComponent();



        }

        LogicWork l1 = new LogicWork();

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = l1.SelectProductInfo(comboBox1.SelectedItem.ToString());

        }

        //void gridupdate()
        //{



        //    sqlconnection con;

        //    sqlcommand cmd;


        //    sqldatareader dr;


        //    con = new sqlconnection(datacon);
        //    cmd = new sqlcommand();
        //    con.open();
        //    cmd.connection = con;
        //    cmd.commandtext = "select * from product_table";
        //    dr = cmd.executereader();

        //    while (dr.read())
        //    {
        //        combobox1.items.add(dr["type"]);
        //    }
        //    con.close();





        //}


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void ProductList_Load(object sender, EventArgs e)
        {



            SqlDataReader dr;

            l1.LoadproductInfo(comboBox1);


            //while (dr.Read())
            //{
            //    if ((!comboBox1.Items.Contains(dr["type"]) && (dr["type"] != "")))
            //        comboBox1.Items.Add(dr["type"]);

            //}

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {


            textBox4.Text = (l1.AddToProduct(textBox1.Text, textBox2.Text, textBox3.Text, textBox10.Text)).ToString();

            MessageBox.Show("Added Successfully...");

            SqlDataReader dr;

            l1.LoadproductInfo(comboBox1);


            dataGridView1.DataSource = l1.SelectProductInfo(comboBox1.SelectedItem.ToString());
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new FirstInt().Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            l1.UpdateLot((textBox7.Text), (textBox6.Text), (textBox5.Text), (textBox8.Text));

            SqlDataReader dr;

            l1.LoadproductInfo(comboBox1);

            dataGridView1.DataSource = l1.SelectProductInfo(comboBox1.SelectedItem.ToString());
        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string x; x = l1.Lotselect(textBox9.Text);
            MessageBox.Show(x.ToString());
            dataGridView1.DataSource = l1.SelectProductInfo(comboBox1.SelectedItem.ToString());

        }

        private void button6_Click(object sender, EventArgs e)
        {
            l1.lotUnsel(textBox9.Text);

            dataGridView1.DataSource = l1.SelectProductInfo(comboBox1.SelectedItem.ToString());
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            l1.LogicAuto(textBox11.Text);
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }
    }
}
