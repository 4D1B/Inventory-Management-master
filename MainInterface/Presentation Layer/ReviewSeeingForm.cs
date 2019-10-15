using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainInterface.Logic;

namespace MainInterface.Presentation
{
    public partial class ReviewSeeingForm : Form
    {
        public ReviewSeeingForm()
        {
            InitializeComponent();
        }

        LogicWork l1 = new LogicWork();

        private void button2_Click(object sender, EventArgs e)
        {
            l1.ShowReviewOnGrid(comboBox1.SelectedItem.ToString(), dataGridView1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FirstInt().Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            


        }

        private void ReviewSeeingForm_Load(object sender, EventArgs e)
        {
            SqlDataReader dr;

            l1.GetItemFromLogic(comboBox1);
        }
    }
}
