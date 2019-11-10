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



        //update the grid of product info after every work
        void GridUpdate()
        {

            try
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

            catch (Exception e)
            {

            }



        }


        //add product to database
        public int AddToProduct_2(params string[] arg)
        {
            try
            {
                SqlConnection con = new SqlConnection(datacon);
                con.Open();
                string query = string.Format("INSERT INTO Product_Table(type,brandname,size,barcode) OUTPUT INSERTED.id VALUES('{0}','{1}' ,'{2}','{3}')", arg[0], arg[1], arg[2], arg[3]);

                SqlCommand cmd = new SqlCommand(query, con);


                int x = (int)cmd.ExecuteScalar();

                string query2 = string.Format("INSERT into Lot(lotid) VALUES({0})", x);
                cmd = new SqlCommand(query2, con);
                cmd.ExecuteNonQuery();

                return x;
                con.Close();
            }

            catch (Exception e)
            {
                return 0;
            }

            //MessageBox.Show("Added Successfully...");
        }




        //select product to grid
        public DataTable SelectProductInfo_2(string t)
        {
            try
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
            catch (Exception e)
            {
                return null;
            }
        }



        //load product to grid
        public SqlDataReader LoadProductInfo_2()
        {
            try
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
            catch (Exception e)
            {
                return null;
            }
        }



        //customer review bringing
        public SqlDataReader CustomerReviewMainSurface_2()
        {
            try
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
            catch (Exception e)
            {
                return null;
            }

        }



        //show info on grid
        public DataTable ShowReviewOnGrid_2(string s)
        {
            try
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
            catch (Exception e)
            {
                return null;
            }
        }



        //update lot info
        public void UpdateLot_2(int t, params string[] s)
        {
            try
            {
                SqlConnection con = new SqlConnection(datacon);
                con.Open();
                string query = string.Format("UPDATE Lot SET buying_price={0},quantity={1},selling_price={3},profit={4} where lotid={2}", s[1], s[2], s[0], s[3], t);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {

            }
        }

        public void AddCustomerInfo_2(string x, string y)
        {


        }


        //customer puts rating
        internal SqlDataReader CustomerRating_2(string s)
        {
            try

            {
                SqlConnection con;
                SqlCommand cmd;
                SqlDataReader rd;


                con = new SqlConnection(datacon);
                cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = string.Format("select brandname,size from product_table where type='{0}'", s);
                rd = cmd.ExecuteReader();

                return rd;
                con.Close();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            //  throw new NotImplementedException();
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



            //select lot
        public SqlDataReader Lotselect_2(string s)
        {
            try
            {
                int x = Convert.ToInt32(s);
                //List<string> type = new List<string>();
                //List<string> brandname = new List<string>();
                //List<string> size = new List<string>();

                string a = "";
                string y = "";
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
                string query2 = string.Format("select selectlot from product_table where type='{0}' AND brandname='{1}' AND size='{2}'", a, y, z);
                SqlCommand cmd2 = new SqlCommand(query2, con2);
                SqlDataReader rd = cmd2.ExecuteReader();

                return rd; con.Close();
            }
            catch (Exception e)
            {
                return null;
            }

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




        }



        //sellect lot

        public void selectlot(string s)
        {
            try
            {
                int x = Convert.ToInt32(s);
                SqlConnection con = new SqlConnection(datacon);
                con.Open();
                string query = string.Format("UPDATE product_table set selectlot={0} where id={1}", 1, x);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();



                con.Close();

            }
            catch (Exception e)
            {

            }

        }



        //unselectthe lot for selling
        public void lotUnsel_2(string s)
        {
            try
            {
                int x = Convert.ToInt32(s);
                SqlConnection con = new SqlConnection(datacon);
                con.Open();
                string query = string.Format("UPDATE product_table set selectlot={0} where id={1}", 0, x);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {

            }

        }



        //check lot
        public void LogicAuto_2(string x)
        {
            try
            {
                SqlConnection con = new SqlConnection(datacon);
                con.Open();
                string query = string.Format("SELECT product_table.ID,lot.profit FROM product_table,lot WHERE lot.profit = (SELECT MAX(profit) FROM lot where barcode='{0}')", "8907");

                string s = "";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    s = rd["id"].ToString();
                }

                MessageBox.Show(s);
                con.Close();
            }
            catch (Exception e)
            {

            }

        }


        //find product
        public DataTable Customer_Product_Search_2(string s)
        {
            try
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
            catch (Exception e)
            {
                return null;
            }
        }



        /// <summary>
        /// Finds the pre rating then calculates
        /// </summary>
        Double value, myValue = 0; string s, d, f;
        public void Customer_Rating_Select_2(string s, string d, string f)
        {
            try
            {


                SqlConnection con = new SqlConnection(datacon);
                con.Open();
                string query = string.Format("select rating from product_table,Lot where type='{0}' and brandname='{1}' and  size='{2}'", s, d, f);

                SqlCommand cmd = new SqlCommand(query, con);
                object nullableValue = cmd.ExecuteScalar();

                if (nullableValue == null || nullableValue == DBNull.Value)
                {

                    myValue = -1; //MessageBox.Show(myValue.ToString());
                }
                else
                {
                    Double.TryParse((nullableValue).ToString(), out myValue);
                }

                s = s; d = d; f = f;


                con.Close();
            }
            catch (Exception e)
            {

            }
        }



        /// <summary>
        /// rating information upadte
        /// </summary>
        /// <param name="x"></param>
        /// <param name="s"></param>
        /// <param name="d"></param>
        /// <param name="f"></param>
        public void Shoot_Rating_2(double x, string s, string d, string f)
        {
            try
            {
                value = x;
                if (myValue >= 0)
                {
                    myValue = (myValue + value) / 2;
                }
                else
                {
                    myValue = value;
                }


                SqlConnection con = new SqlConnection(datacon);
                con.Open();

                string query = string.Format("UPDATE product_table set rating='{0}' where  type='{1}' and brandname='{2}' and  size='{3}'", myValue, s, d, f);
                MessageBox.Show(s + d + f);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {

            }
        }



        //save reg info

        public int SaveRegistrationInfo_2(params string[] arr)
        {

            try
            {
                SqlConnection con = new SqlConnection(datacon);
                con.Open();

                //check if email exists


            

                string query = string.Format("select id from admininfo where email = '{0}'", arr[2]);
                SqlCommand cmd = new SqlCommand(query, con);

                int x=Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();///// exception handling korte hobe email id same dile message dekhabe

           //     MessageBox.Show(x.ToString());


                if (x == null || x==0)
                {
              //      MessageBox.Show("val");
                    try
                    {
                        SqlConnection con2 = new SqlConnection(datacon);
                        con2.Open();

                        //check if email exists




                        string query2 = string.Format("INSERT INTO admininfo(firstname,surname,email,mobile,password) VALUES('{0}','{1}' ,'{2}','{3}','{4}'); SELECT SCOPE_IDENTITY()", arr[0], arr[1], arr[2], arr[3], arr[4]);

                        SqlCommand cmd2 = new SqlCommand(query2, con2);

                        int y = 0;

                        Object nullableValue2 = new Object();
                        nullableValue2= cmd2.ExecuteScalar();     ///// exception handling korte hobe email id same dile message dekhabe

                        if (nullableValue2 == null || nullableValue2 == DBNull.Value)

                        {
                     //       MessageBox.Show(nullableValue2.ToString());
                            y = 0;
                        }
                        else

                        {
                         //   MessageBox.Show(nullableValue2.ToString());
                            // MessageBox.Show(y.ToString());
                            int.TryParse((nullableValue2).ToString(), out y);
                        }
                        return y;
                        con2.Close();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message + "vitore");
                        return 0;
                    }
                }
                else
                {
                    //MessageBox.Show("val" + nullableValue.ToString());
                    return 0;
                    // int.TryParse((nullableValue).ToString(), out x);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "baire");
                return 0;
            }

        }



        //check login info
        public string Admin_Login_Press_2(string str)
        {
            try
            {
                SqlConnection con = new SqlConnection(datacon);
                con.Open();
                string query = string.Format("SELECT email FROM admininfo WHERE password='{0}'", str);

                SqlCommand cmd = new SqlCommand(query, con);
                var SavedString = (string)cmd.ExecuteScalar();




                MessageBox.Show(SavedString);

                return SavedString;
                con.Close();
            }
            catch (Exception e)
            {
                return null;

            }
        }



    }
}

