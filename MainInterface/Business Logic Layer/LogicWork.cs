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

            if(sum> 2000)
            {
                double x= sum/50;
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

            int z = (y-x);
            dw.UpdateLot_2(z,s);
        }

        public DataTable CallLogicLayer(string combotext)
        {
            DataTable dt = new DataTable();
            dt = dw.databaselayerforcombo(combotext);
            return dt;
        }

        public int CallAddItem(params string[] arg)
        {
            return (dw.CallAddItem_2(arg));
        }

        public void GetItemFromLogic(ComboBox comboBox1)
        {
            SqlDataReader rd;
            rd = dw.CallGetItemFromDB();
            while (rd.Read())
            {
                if ((!comboBox1.Items.Contains(rd["type"]) && (rd["type"] != "")))
                    comboBox1.Items.Add(rd["type"]);

            }


        }

        public void GetItemFromLogicAgain(ComboBox comboBox1,ComboBox combobox2, ComboBox combobox3)
        {
            SqlDataReader rd;
            rd = dw.CallGetItemFromDBAgain();
            while (rd.Read())
            {
                if ((!comboBox1.Items.Contains(rd["type"]) && (rd["type"] != "")))
                    comboBox1.Items.Add(rd["type"]);
                if ((!combobox2.Items.Contains(rd["brandname"]) && (rd["brandname"] != "") ))
                    combobox2.Items.Add(rd["brandname"]);
                if ((!combobox3.Items.Contains(rd["size"]) && (rd["size"] != "")))
                    combobox3.Items.Add(rd["size"]);

            }


        }

        public void ShowReviewOnGrid(string s,DataGridView dataGridView)
        {
            DataTable dr = dw.ShowReviewOnGrid_2(s);
            dataGridView.DataSource = dr;
           // dataGridView.Columns["Rating"].Visible = false;
        }


        public void AddCustomerInfo(string x,string y)
        {
            dw.AddCustomerInfo_2(x,y);
        }


        public string Lotselect(string s)
        {
            SqlDataReader rd= dw.checkLot(s);

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
            if(k==1)
            {
                str = "not Select as main lot";
            }
            else if(k==0)
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

        public void lotUnsel(string s)
        {
            dw.lotUnsel_2(s);
        }


        public void LogicAuto(string s)
        {
            dw.LogicAuto_2(s);

        }

        public DataTable sendtologic(string s)
        {
            DataTable dt=
            dw.send2db(s);
            return dt;
        }


        public void cus_rev(string s,string d,string f)
        {
            dw.cus_rev2(s, d, f);
        }

        public void sendval(int x)
        {
            dw.sendval2(x);
        }

        public int callsavelogic(params string[] list)
        {
            return 
            dw.callsavedb(list);
        }

        public string getlogin(string s,string d)
        {
            string str=dw.getlogindb(d);

            if(str==s   )
            {
                return "Password matched,welcome";
              //  new FirstInt().Show();

            }

            else
            {
                return "try again!" + str + "  man ";
            }


        }
    }
}
