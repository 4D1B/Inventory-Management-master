using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainInterface.Presentation
{
    public partial class FirstInt : Form
    {
        public FirstInt()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new PrintFormWithCustomerInfo().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ProductList().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new ReviewSeeingForm().Show();
            this.Hide();
        }

        private void FirstInt_Load(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
    }
}
