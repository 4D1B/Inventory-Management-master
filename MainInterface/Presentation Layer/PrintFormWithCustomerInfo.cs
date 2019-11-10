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
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using Microsoft.Win32;
using System.IO;
using System.Windows;


namespace MainInterface.Presentation
{
    public partial class PrintFormWithCustomerInfo : Form
    {

        public PrintFormWithCustomerInfo()
        {
            InitializeComponent();




        }

        LogicWork l1 = new LogicWork();
        string s;

        private void textBox5_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Statuschanged()
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        PrintFormWithCustomerInfo pc;

        private void button1_Click(object sender, EventArgs e)
        {
            Panel panel = new Panel();
            this.Controls.Add(panel);
            Graphics grp = panel.CreateGraphics();
            Size formSize = this.ClientSize;
            var height = this.Size.Height; //Gets the current Height of the Form.
            var width = this.Size.Width; //Gets the current Width of the Form.

            this.Size = new Size(1500, 2000);
            bitmap = new Bitmap(width, height, grp);
            grp = Graphics.FromImage(bitmap);
            Point panelLocation = PointToScreen(panel.Location);
            grp.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, formSize);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
        }

        Bitmap memoryImage;

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            bitmap = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(bitmap);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void button1_Click_(object sender, EventArgs e)
        {


            //Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            //PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Payment.pdf", FileMode.Create));
            //doc.Open();
            //Paragraph paragraph = new Paragraph("Confirm");
            //doc.Add(paragraph);
            //doc.Close();
        }

        private void PrintFormWithCustomerInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mgmtDataSet.Product_Table' table. You can move, or remove it, as needed.


        }

        private void dataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {


            textBox1.Text = l1.GetData(dataGridView1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FirstInt().Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            l1.AddCustomerInfo(textBox2.Text.ToString(), textBox3.Text.ToString());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Barcode_Scanner Form = new Barcode_Scanner();
            //Form.Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //  string barcode = textBox4.Text;

            // Bitmap bitmap = new Bitmap(barcode.Length * 40, 150);



        }

        private void button5_Click(object sender, EventArgs e)
        {
            // l1.GoToSold();
        }
        Bitmap bitmap;
        private void PrintDocument1_PrintPage_2(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
