namespace HabeshaBit.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;

    [Table("PlayList")]
    public partial class PlayList
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string userID { get; set; }

        public int musicID { get; set; }

        public virtual Music Music { get; set; }
        public List<Music> results = new List<Music>();

        public bool save() {
            DataConnection dataConnection = new DataConnection();
            dataConnection.Initalize();
            String cmd = "INSERT INTO[dbo].[PlayList]( [userID], [musicID]) VALUES('" + this.userID + "','" + this.musicID + "')";

            SqlCommand sqlCommand = new SqlCommand(cmd, dataConnection.openCon());
            int succ = sqlCommand.ExecuteNonQuery();
            if (succ == 0)
            {
                dataConnection.closeCon();
                return false;
            } 



        
            dataConnection.closeCon();

            return true;
        }

        
    public List<Music> getMusic() {
            DataConnection dataConnection = new DataConnection();
            dataConnection.Initalize();
            String cmd = "select * from [Music] Inner JOIN   [PlayList]  ON Music.musiID=PlayList.musicID Where [userID] = '"+this.userID+ "'";

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd, dataConnection.openCon());
            DataTable dataTable = new DataTable();
            sqlAdapter.Fill(dataTable);

            dataConnection.closeCon();
            foreach (DataRow row in dataTable.Rows)
            {
                results.Add(
                    new Music
                    {
                        musiID = int.Parse(row["musiID"].ToString()),
                        musicName = row["musicName"].ToString(),
                        musicPath = row["musicPath"].ToString(),
                        album = row["album"].ToString(),
                        artist = row["artist"].ToString(),
                        picPath = row["picPath"].ToString()
                    }
                    );
            }

            return results;


        }

    }
    }

