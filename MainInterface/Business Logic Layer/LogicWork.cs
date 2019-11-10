using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MainInterface.Database;
using System.Data.SqlClient;

namespace MainInterface.Logic
{
    public class LogicWork
    {


        DataGridView Datagridview1 = new DataGridView();
        DatabaseWork dw = new DatabaseWork();

        public string GetData(DataGridView dataGridView1)
        {
            double sum = 0;
            int k = 0; string s;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                double x, y, z = 0;
                x = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                y = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                z = x * y;
                sum += z;
                dataGridView1.Rows[i].Cells[3].Value = z.ToString();
                k = i;

            }

            dataGridView1.Rows[k].Cells[3].Value = sum.ToString();

            if (sum > 2000)
            {
                double x = sum / 50;
                s = x.ToString();
            }
            else
            {
                s = null;
            }

            return s;

        }

        public void UpdateLot(params string[] s)
        {
            int x = Convert.ToInt32(s[1]);
            int y = Convert.ToInt32(s[3]);

            int z = (y - x);
            dw.UpdateLot_2(z, s);
        }

        public DataTable SelectProductInfo(string combotext)
        {
            DataTable dt = new DataTable();
            dt = dw.SelectProductInfo_2(combotext);
            return dt;
        }

        public int AddToProduct(params string[] arg)
        {
            return (dw.AddToProduct_2(arg));
        }

        public void LoadproductInfo(ComboBox comboBox1)
        {
            try
            {
                SqlDataReader rd;
                rd = dw.LoadProductInfo_2();
                while (rd.Read())
                {
                    if ((!comboBox1.Items.Contains(rd["type"]) && (rd["type"] != "")))
                        comboBox1.Items.Add(rd["type"]);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }


        }

        public void CustomerReviewMainSurface(ComboBox comboBox1, ComboBox combobox2, ComboBox combobox3)
        {
            try
            {
                SqlDataReader rd;
                rd = dw.CustomerReviewMainSurface_2();
                while (rd.Read())
                {
                    if ((!comboBox1.Items.Contains(rd["type"]) && (rd["type"] != "")))
                        comboBox1.Items.Add(rd["type"]);

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }



        }

        public void ShowReviewOnGrid(string s, DataGridView dataGridView)
        {
            DataTable dr = dw.ShowReviewOnGrid_2(s);
            dataGridView.DataSource = dr;
            // dataGridView.Columns["Rating"].Visible = false;
        }


        public void AddCustomerInfo(string x, string y)
        {
            dw.AddCustomerInfo_2(x, y);
        }


        public string Lotselect(string s)
        {
            try
            {
                SqlDataReader rd = dw.Lotselect_2(s);

                int k = 0;
                if (rd.HasRows)
                {
                    rd.Read(); // read first row


                    if (rd["selectlot"] == DBNull.Value /*|| (int)rd["selectlot"] == 0*/ )
                    {

                        k = 0;
                    }

                    else if ((int)rd["selectlot"] == 0)
                    {
                        k = 0;
                    }
                    else if ((int)rd["selectlot"] == 1)
                    {
                        k = 1;
                        goto done;
                    }
                    else
                    {
                        k = 5;
                    }
                }



                else
                {
                    k = 0;
                }

            done:



                string str;
                if (k == 1)
                {
                    str = "not Select as main lot";
                }
                else if (k == 0)
                {
                    dw.selectlot(s);
                    str = "selected as main lot ";
                }

                else
                {
                    return "Can't complete precedure";
                }

                return str;
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }



        public void lotUnsel(string s)
        {
            dw.lotUnsel_2(s);
        }


        public void LogicAuto(string s)
        {
            dw.LogicAuto_2(s);

        }

        public DataTable Customer_Product_Search(string s)
        {
            try
            {
                DataTable dt =
                dw.Customer_Product_Search_2(s);
                return dt;
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;

            }
        }




        public void Customer_Rating_Select(string s, string d, string f)
        {
            dw.Customer_Rating_Select_2(s, d, f);
        }

        public void Shoot_Rating(double x, string s, string d, string f)
        {
            dw.Shoot_Rating_2(x, s, d, f);
        }



        /// <summary>
        ///check if every info is put or not
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int SaveRegistrationInfo(params string[] list)
        {
           
            try
            {
                 
                if (list[0] == "")
                {
                    MessageBox.Show("Put your first name");
                    return -1;

                }
                else if (list[1] == "")
                {
                    MessageBox.Show("Put your Sur name");
                    return -1;
                }
                else if ((list[2] == "") || (list[2].Contains("@") ==false) || (list[2].Contains(".") == false))
                {
                    MessageBox.Show("Put your Email");

                    return -1;

                }
                else if ((list[3] == "") || (list[3].All(char.IsDigit)==false) || list[3].Length<11 || list[3].Length >11)
                {
                    MessageBox.Show("Put your Mobile");
                    return -1;
                }
                else if ((list[4] == "" ) || (list[4].Any(char.IsDigit) == false) || (list[4].Any(char.IsLetter)==false) || list[4].Length < 8)
                {
                    MessageBox.Show("Put your password");
                    return -1;

                }
                else   
                {
                    return
                    dw.SaveRegistrationInfo_2(list);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
        }

        public string Admin_Login_Press(string s, string d)
        {
            try
            {
                string str = dw.Admin_Login_Press_2(d);

                if (str == s)
                {
                    return "Password matched,welcome";
                    //  new FirstInt().Show();

                }

                else
                {
                    return "try again!" + str + "  man ";
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }


        }


        public void CustomerRating(string s, ComboBox combobox2, ComboBox combobox3)
        {
            try
            {

                SqlDataReader dr;
                dr = dw.CustomerRating_2(s);
                combobox2.Items.Clear();
                combobox2.ResetText();

                combobox3.Items.Clear();
                combobox3.ResetText();

                while (dr.Read())
                {

                    if ((!combobox2.Items.Contains(dr["brandname"]) && (dr["brandname"] != "")))
                        combobox2.Items.Add(dr["brandname"]);
                    if ((!combobox3.Items.Contains(dr["size"]) && (dr["size"] != "")))
                        combobox3.Items.Add(dr["size"]);

                }
                combobox2 = null;

                combobox3 = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

    }
}
