namespace HabeshaBit.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.Spatial;
    using System.Web;
    using System.Data.SqlClient;
    using System.Data;
    using System.Web.Mvc;

    [Table("Music")]
    public partial class Music
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int musiID { get; set; }

        [Required]
        [StringLength(50)]
        public string musicName { get; set; }

        [StringLength(50)]
        public string album { get; set; }


        public string musicPath { get; set; }

        [Required]
        [StringLength(50)]
        public string artist { get; set; }

        public string picPath { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase musicFile { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase picFile { get; set; }

        public SelectList  albums{ get; set; }

        
        private DataConnection dataConnection;

        public bool saveMusic()
        {

            dataConnection = new DataConnection();

            try
            {
                dataConnection.Initalize();
                String cmd = "INSERT INTO[dbo].[Music]( [musicName], [musicPath], [album],[artist],[picPath]) VALUES('" + this.musicName + "','" + this.musicPath + "','" + this.album + "','" + this.artist + "','" + this.picPath + "')";

                SqlCommand sqlCommand = new SqlCommand(cmd, dataConnection.openCon());
                int succ = sqlCommand.ExecuteNonQuery();
                if (succ == 0)
                {
                    dataConnection.closeCon();
                    return false;
                }

            }
            catch
            {


                throw;
            }

            dataConnection.closeCon();

            return true;
        }
        public List<Music> getAlbumMusic(int id)
        {
            List<Music> albumsMusic = new List<Music>();

            dataConnection = new DataConnection();
            dataConnection.Initalize();
            String cmd = "select * from [Music] where [Album] = between '" + (id-1) + "'and '"+(id+10)+"'";
            // System.Windows.
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd, dataConnection.openCon());
            DataTable dataTable = new DataTable();
            sqlAdapter.Fill(dataTable);

            dataConnection.closeCon();
            foreach (DataRow row in dataTable.Rows)
            {
                albumsMusic.Add(
                    new Music
                    {

                    }
                    );
            }


            return albumsMusic;

        }
    }

    public partial class Search
    {
        public Search() {
            m = 0;
        }
        public string searchQuery { get; set; }
        public int m {get;set;}
        public  List<Music> results = new List<Music>();

       public List<Music> getMusic() {
            m = 1;
        DataConnection dataConnection= new DataConnection();
        dataConnection.Initalize();
            String cmd = "select * from [Music] where  [musicName] LIKE'%"+searchQuery+"%' OR [artist] LIKE '%"+searchQuery+"%'";
        
        SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd, dataConnection.openCon());
        DataTable dataTable = new DataTable();
        sqlAdapter.Fill(dataTable);

            dataConnection.closeCon();
            foreach (DataRow row in dataTable.Rows)
            {
                results.Add(
                    new Music
                    {
                        musiID=int.Parse(row["musiID"].ToString()),
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

