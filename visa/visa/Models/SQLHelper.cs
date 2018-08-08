using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

    public class SQLHelper
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataAdapter da;

        #region Constructor
        public SQLHelper()
        {
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings ["dbcontext"].ConnectionString;
            con = new SqlConnection(constr);
            com = new SqlCommand();
            com.Connection = con;
            da = new SqlDataAdapter();
            da.SelectCommand = com;
        }

        public SQLHelper(string ConStr)
        {
            con = new SqlConnection(ConStr);
            com = new SqlCommand();
            com.Connection = con;
            da = new SqlDataAdapter();
            da.SelectCommand = com;
        }
        #endregion

     

        #region GetDataset
        public DataSet GetDataset(string qry)
        {
            com.CommandText = qry;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet GetDataset(SqlCommand com)
        {
            com.Connection = this.con;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        #endregion
        
        #region GetTable
        public DataTable GetTable(string qry)
        {
           // try
          //  {
                com.CommandText = qry;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
          //  }
          //  catch(Exception ex)
          //  {
          //      System.Web.HttpContext.Current.Response.Write(qry);

         //       System.Web.HttpContext.Current.Response.End();
          //      return new DataTable ();

          //  }
        }
        public DataTable GetTable(SqlCommand com)
        {
            com.Connection = this.con;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        #endregion

        #region GetSingleValue
        public object GetSingleValue(string qry)
        {
            con.Close();
            com.CommandText = qry;
            con.Open();
            object obj = com.ExecuteScalar();
            con.Close();
             return obj;
         }
        public object GetSingleValue(SqlCommand com)
        {
            com.Connection = this.con;
            con.Open();
            object obj = com.ExecuteScalar();
            con.Close();
            return obj;
        }
        #endregion

        #region ExecuteNonQuery
        public void ExecuteNonQuery(string qry)
        {
            //try
            //{
            con.Close();
                com.CommandText = qry;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
           // }
           // catch (Exception ex)
           // {
            //    System.Web.HttpContext.Current.Response.Write(qry);
           //     System.Web.HttpContext.Current.Response.End();

          //  }
        }

        public int ExecuteNonQuery1(string qry)
        {
            con.Close();
            com.CommandText = qry;
            con.Open();
          return  com.ExecuteNonQuery();
           
           
        }
        public void ExecuteNonQuery(SqlCommand com)
        {
            com.Connection = this.con;
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        #endregion
    }

    public class SQLHelper1
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataAdapter da;

        #region Constructor
        public  SQLHelper1()
        {
            string constr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString1"];
            con = new SqlConnection(constr);
            com = new SqlCommand();
            com.Connection = con;
            da = new SqlDataAdapter();
            da.SelectCommand = com;
        }

        public SQLHelper1(string ConStr1)
        {
            con = new SqlConnection(ConStr1);
            com = new SqlCommand();
            com.Connection = con;
            da = new SqlDataAdapter();
            da.SelectCommand = com;
        }
        #endregion



        #region GetDataset
        public DataSet GetDataset(string qry)
        {
            com.CommandText = qry;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet GetDataset(SqlCommand com)
        {
            com.Connection = this.con;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        #endregion

        #region GetTable
        public DataTable GetTable(string qry)
        {
            // try
            //  {
            com.CommandText = qry;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            //  }
            //  catch(Exception ex)
            //  {
            //      System.Web.HttpContext.Current.Response.Write(qry);

            //       System.Web.HttpContext.Current.Response.End();
            //      return new DataTable ();

            //  }
        }
        public DataTable GetTable(SqlCommand com)
        {
            com.Connection = this.con;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        #endregion

        #region GetSingleValue
        public object GetSingleValue(string qry)
        {
            con.Close();
            com.CommandText = qry;
            con.Open();
            object obj = com.ExecuteScalar();
            con.Close();
            return obj;
        }
        public object GetSingleValue(SqlCommand com)
        {
            com.Connection = this.con;
            con.Open();
            object obj = com.ExecuteScalar();
            con.Close();
            return obj;
        }
        #endregion

        #region ExecuteNonQuery
        public void ExecuteNonQuery(string qry)
        {
            //try
            //{
            con.Close();
            com.CommandText = qry;
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            // }
            // catch (Exception ex)
            // {
            //    System.Web.HttpContext.Current.Response.Write(qry);
            //     System.Web.HttpContext.Current.Response.End();

            //  }
        }

        public int ExecuteNonQuery1(string qry)
        {
            con.Close();
            com.CommandText = qry;
            con.Open();
            return com.ExecuteNonQuery();


        }
        public void ExecuteNonQuery(SqlCommand com)
        {
            com.Connection = this.con;
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        #endregion
    }
