using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainInterface.Logic;

namespace MainInterface.Presentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Registration_Form Form = new Registration_Form();
            Form.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminView Form = new AdminView();
            Form.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            Customer_Product_Overview Form = new Customer_Product_Overview();
            Form.Show();
            Hide();
        }
    }
}
