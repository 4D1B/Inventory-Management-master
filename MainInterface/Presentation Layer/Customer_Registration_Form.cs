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
    public partial class Registration_Form : Form
    {
        public Registration_Form()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminView Form = new AdminView();
            Form.Show();
            Hide();
        }

        private void Customer_Registration_Form_Load(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        LogicWork l1 = new LogicWork();
        private void Button1_Click(object sender, EventArgs e)
        {
            int x=
            l1.callsavelogic(textBox1.Text, textBox6.Text, textBox5.Text, textBox3.Text, textBox2.Text);

            MessageBox.Show("You are " + x + "th user of the system");
        }
    }
}
