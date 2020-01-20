namespace HabeshaBit.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;

    [Table("Album")]
    public partial class Album
    {
        private DataConnection dataConnections;
        public int id { get; set; }

        [StringLength(128)]
        public string Artist { get; set; }

        [StringLength(128)]
        public string Name { get; set; }

        public List<Album> GetAlbums(string artist)
        {
            List<Album> albums = new List<Album>();
            dataConnections = new DataConnection();
            dataConnections.Initalize();
            String cmd = "select * from [Album] where [Artist] = '" + artist + "'";
            // System.Windows.
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd, dataConnections.openCon());
            DataTable dataTable = new DataTable();
            sqlAdapter.Fill(dataTable);

            dataConnections.closeCon();
            foreach (DataRow row in dataTable.Rows)
            {
                albums.Add(
                    new Album
                    {
                        id = int.Parse(row["id"].ToString()),
                        Artist = row["Artist"].ToString(),
                        Name = row["Name"].ToString(),
                    }
                    );
            }
            return albums;
        }
        public Album findAlbum(int id)
        {

            dataConnections = new DataConnection();
            dataConnections.Initalize();
            String cmd = "select * from [Album] where [id] = '" + id + "'";
            // System.Windows.
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd, dataConnections.openCon());
            DataTable dataTable = new DataTable();
            sqlAdapter.Fill(dataTable);

            dataConnections.closeCon();

            return new Album
            {
                id = int.Parse(dataTable.Rows[0]["id"].ToString()),
                Artist = dataTable.Rows[0]["Artist"].ToString(),
                Name = dataTable.Rows[0]["Name"].ToString(),
            };



        }
        public void update()
        {
            dataConnections = new DataConnection();

            try
            {
                dataConnections.Initalize();
                String cmd = "UPDATE [dbo].[Album] SET Name '" + this.Name + "Where id='" + this.id + "'";

                SqlCommand sqlCommand = new SqlCommand(cmd, dataConnections.openCon());
                int succ = sqlCommand.ExecuteNonQuery();
                if (succ == 0)
                {
                    dataConnections.closeCon();

                }

            }
            catch
            {


                throw;
            }

            dataConnections.closeCon();

        }

    

    public bool saveAlbum() {

        dataConnections = new DataConnection();

            try
            {
                dataConnections.Initalize();
                String cmd = "INSERT INTO[dbo].[Album]( [Artist], [Name]) VALUES('" + this.Artist + "','" + this.Name + "')";

                SqlCommand sqlCommand = new SqlCommand(cmd, dataConnections.openCon());
                int succ = sqlCommand.ExecuteNonQuery();
                if (succ == 0)
                {
                    dataConnections.closeCon();
                    return false;
                }
            }



            catch
            {


                throw;
            }

        dataConnections.closeCon();
            return true;
    }
           
        }
    }
    

