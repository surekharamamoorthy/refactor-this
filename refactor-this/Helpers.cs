using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace refactor_this
{
    public class Helpers
    {
        //private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\refactor-this.mdf;Integrated Security=True;Connect Timeout=30";

        string conStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        


        public static SqlConnection NewConnection()
        {
            Helpers obj = new Helpers();
            return new SqlConnection(obj.conStr);
        }

   }
}