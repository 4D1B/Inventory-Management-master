using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainInterface.Database
{
    class DatabaseWork
    {
        string datacon = @"Data Source=(localdb)\invman;Initial Catalog=mgmt;Integrated Security=True";

        void GridUpdate()
        {



            SqlConnection con;

            SqlCommand cmd;


            SqlDataReader dr;


            con = new SqlConnection(datacon);
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Product_Table";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                // comboBox1.Items.Add(dr["type"]);
            }
            con.Close();





        }

        public int CallAddItem_2(params string[] arg)
        {
            SqlConnection con = new SqlConnection(datacon);
            con.Open();
            string query = string.Format("INSERT INTO Product_Table(type,brandname,size,barcode) OUTPUT INSERTED.id VALUES('{0}','{1}' ,'{2}','{3}')", arg[0], arg[1], arg[2],arg[3]);

            SqlCommand cmd = new SqlCommand(query, con);


            int x = (int)cmd.ExecuteScalar();

            string query2 = string.Format("INSERT into Lot(lotid) VALUES({0})", x);
            cmd = new SqlCommand(query2, con);
            cmd.ExecuteNonQuery();

            return x;
            con.Close();

            //MessageBox.Show("Added Successfully...");
        }


        public DataTable databaselayerforcombo(string t)
        {
            SqlConnection con = new SqlConnection(datacon);
            con.Open();
            string query = string.Format("select type,lotid,brandname,size,Lot.quantity,selling_price,buying_price,sold,selectlot,profit from product_table,Lot where type='{0}' and Product_Table.id=Lot.lotid", t);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
            con.Close();
        }

        public SqlDataReader CallGetItemFromDB()
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;


            con = new SqlConnection(datacon);
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select type from product_table";
            dr = cmd.ExecuteReader();

            return dr;

            con.Close();
        }

        public SqlDataReader CallGetItemFromDBAgain()
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;


            con = new SqlConnection(datacon);
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select type,brandname,size from product_table";
            dr = cmd.ExecuteReader();

            return dr;
            con.Close();

        }

        public DataTable ShowReviewOnGrid_2(string s)
        {
            SqlConnection con = new SqlConnection(datacon);
            con.Open();
            string query = string.Format("select brandname,rating from product_table where type='{0}'", s);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            con.Close();
        }


        public void UpdateLot_2(int t,params string[] s)
        {
            SqlConnection con = new SqlConnection(datacon);
            con.Open();
            string query = string.Format("UPDATE Lot SET buying_price={0},quantity={1},selling_price={3},profit={4} where lotid={2}", s[1], s[2], s[0], s[3],t);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void AddCustomerInfo_2(string x, string y)
        {


        }

        //public int Lotselect_2(string s)
        //{
        //    int x = Convert.ToInt32(s);
        //    SqlConnection con = new SqlConnection(datacon);
        //    con.Open();
        //    string query = string.Format("select selectlot from product_table where id={0}", x);
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    //var userId = (Int32)cmd.ExecuteScalar();

        //    SqlDataReader rd = cmd.ExecuteReader();
        //    if (rd.HasRows)
        //    {
        //        rd.Read(); // read first row


        //        if (rd["selectlot"] == DBNull.Value)
        //        {

        //            return 0;
        //        }

        //        else if ((int)rd["selectlot"] == 1)
        //        {
        //            return 1;
        //        }
        //        else
        //        {
        //            return 5;
        //        }
        //    }



        //    else
        //    {
        //        return 0;
        //    }



        //}

        public SqlDataReader checkLot(string s)
        {
            int x = Convert.ToInt32(s);
            //List<string> type = new List<string>();
            //List<string> brandname = new List<string>();
            //List<string> size = new List<string>();

            string a="";
            string y="";
            string z = "";
            SqlConnection con = new SqlConnection(datacon);
            con.Open();
            string query = string.Format("select type,brandname,size from product_table where id={0}", x);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                a = dr["type"].ToString();
                y = dr["brandname"].ToString();
                z = dr["size"].ToString();

            }
            con.Close();
            int k = 0;
            SqlConnection con2 = new SqlConnection(datacon);
            con2.Open();
            string query2 = string.Format("select selectlot from product_table where type='{0}' AND brandname='{1}' AND size='{2}'", a,y,z);
            SqlCommand cmd2 = new SqlCommand(query2, con2); 
            SqlDataReader rd = cmd2.ExecuteReader();

            return rd;

            //if (rd.HasRows)
            //{
            //    rd.Read(); // read first row


            //    if (rd["selectlot"] == DBNull.Value /*|| (int)rd["selectlot"] == 0*/ )
            //    {

            //        k = 0;
            //    }

            //    else if ((int)rd["selectlot"] == 0)
            //    {
            //        k = 0;
            //    }
            //    else if ((int)rd["selectlot"] == 1)
            //    {
            //        k = 1;
            //        goto done;
            //    }
            //    else
            //    {
            //        k = 5;
            //    }
            //}



            //else
            //{
            //    k = 0;
            //}

            //done:
            //return k;


            con.Close();

        }


        public void selectlot(string s)
        {
            int x = Convert.ToInt32(s);
            SqlConnection con = new SqlConnection(datacon);
            con.Open();
            string query = string.Format("UPDATE product_table set selectlot={0} where id={1}", 1,x);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();



            con.Close();


        }

        public void lotUnsel_2(string s)
        {
            int x = Convert.ToInt32(s);
            SqlConnection con = new SqlConnection(datacon);
            con.Open();
            string query = string.Format("UPDATE product_table set selectlot={0} where id={1}", 0, x);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void LogicAuto_2(string x)
        {
            SqlConnection con = new SqlConnection(datacon);
            con.Open();
            string query = string.Format("SELECT product_table.ID,lot.profit FROM product_table,lot WHERE lot.profit = (SELECT MAX(profit) FROM lot where barcode='{0}')","8907");

            string s = "";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rd = cmd.ExecuteReader();

            if(rd.HasRows)
            {
                s = rd["id"].ToString();
            }

            MessageBox.Show(s);
            con.Close();

        }

        public DataTable send2db(string s)
        {
            SqlConnection con = new SqlConnection(datacon);
            con.Open();
            string query = string.Format("select type,brandname,size from product_table where type='{0}'", s);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
            con.Close();
        }
        int value,myValue = 0;string s, d, f;
        public void cus_rev2(string s,string d,string f)
        {
            SqlConnection con = new SqlConnection(datacon);
            con.Open();
            string query = string.Format("select rating from product_table,Lot where type='{0}' and brandname='{1}' and  size='{2}'", s,d,f);
            SqlCommand cmd = new SqlCommand(query, con);
            object nullableValue = cmd.ExecuteScalar();
            
            if (nullableValue == null || nullableValue == DBNull.Value)
            {
                myValue = -1;
            }
            else
            {
                int.TryParse((nullableValue).ToString(), out myValue);
            }

            s = s;d = d;f = f;

            con.Close();
        }
        
        public void sendval2(int x)
        {
            value = x;
            if(myValue>=0)
            {
                myValue = (myValue + value) / 2;
            }
            else
            {
                myValue = value;
            }
           

            SqlConnection con = new SqlConnection(datacon);
            con.Open();
            string query = string.Format("UPDATE product_table set rating='{0}' where  type='{1}' and brandname='{2}' and  size='{3}'",myValue, s, d, f);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }


        public  int callsavedb(params string[] arr)
        {
            SqlConnection con = new SqlConnection(datacon);
            con.Open();
            string query = string.Format("INSERT INTO admininfo(firstname,surname,email,mobile,password) VALUES('{0}','{1}' ,'{2}','{3}','{4}'); SELECT SCOPE_IDENTITY()", arr[0], arr[1], arr[2], arr[3],arr[4]);

            SqlCommand cmd = new SqlCommand(query, con);

            int x;
            object nullableValue = cmd.ExecuteScalar();     ///// exception handling korte hobe email id same dile message dekhabe

            if (nullableValue == null || nullableValue == DBNull.Value)
            {
                x = -1;
            }
            else
            {
                int.TryParse((nullableValue).ToString(), out x);
            }
            return x;
            con.Close();
        }


        public string getlogindb(string str)
        {
            SqlConnection con = new SqlConnection(datacon);
            con.Open();
            string query = string.Format("SELECT email FROM admininfo WHERE password='{0}'",str );
            
            SqlCommand cmd = new SqlCommand(query, con);
            var SavedString = (string)cmd.ExecuteScalar();




            MessageBox.Show(SavedString);

            return SavedString;
            con.Close();
        }


    }
}

