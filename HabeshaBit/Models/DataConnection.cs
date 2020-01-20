using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HabeshaBit.Models
{
    public class DataConnection
    {

        SqlConnection sqlconnection;
        public void Initalize()
        {

            sqlconnection = new SqlConnection(@"data source=eniyewababa\kiber;initial catalog=aspnet-HabeshaBit-20190127055942;integrated security=True;MultipleActiveResultSets=True ");



        }
        public SqlConnection openCon()
        {

            try
            {
                sqlconnection.Open();
            }
            catch (Exception)
            {
                throw;
            }
            return sqlconnection;
        }
        public void closeCon()
        {
            try
            {
                sqlconnection.Close();
            }
            catch
            {
                throw;
            }

        }
    }
}
