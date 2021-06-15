using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LinkedIn.Models
{
    public class ConnectionManager
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        public ConnectionManager()
        {
            //con = new SqlConnection(@"Data Source=DESKTOP-TC2S995\SQLEXPRESS;Initial Catalog=LinkedIn;Integrated Security=True");
            con = new SqlConnection(@"workstation id=linkedinn.mssql.somee.com;packet size=4096;user id=sandeepk21_SQLLogin_1;pwd=pwnct42l7b;data source=linkedinn.mssql.somee.com;persist security info=False;initial catalog=linkedinn");
        }
        //this function are used to insert,delete,update commands
        public bool InsertUpdateDelete(String commond)
        {
            cmd = new SqlCommand(commond, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
                return true;
            else
                return false;
        }
        //this command for select query return data from database
        public DataTable Display_All_Records(String Commond)
        {
            cmd = new SqlCommand(Commond, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            return dt;
        }
        public int GetCount(String commond)
        {
            cmd = new SqlCommand(commond, con);
            int n = (Int32)cmd.ExecuteScalar();
            if (n > 0)
            {
                return n;
            }
            return n;
        }



        
    }
}