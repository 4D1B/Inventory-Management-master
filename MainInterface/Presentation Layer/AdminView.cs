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
    public partial class AdminView : Form
    {
        public AdminView()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Registration_Form Form = new Registration_Form();
            Form.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 Form = new Form1();
            Form.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdminView_Load(object sender, EventArgs e)
        {

        }
        LogicWork l1 = new LogicWork();
        private void Button1_Click(object sender, EventArgs e)
        {
            string str=l1.getlogin(textBox1.Text, textBox2.Text);
            MessageBox.Show(str);
            new FirstInt().Show();

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
