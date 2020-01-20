namespace HabeshaBit.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    public partial class MusicModel : DbContext
    {
        private DataConnection dataConnections;           
        public MusicModel()
            : base("name=MusicModel")
        {
        }
        public List<Music> getMusics() {
            dataConnections = new DataConnection();
            List<Music> listmusic = new List<Music>();
            dataConnections.Initalize();
            String cmd = "select * from [Music]";
            // System.Windows.
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd, dataConnections.openCon());
            DataTable dataTable = new DataTable();
            sqlAdapter.Fill(dataTable);
            dataConnections.closeCon();
            foreach (DataRow row in dataTable.Rows) {
                listmusic.Add(new Music
                {
                    musiID=int.Parse(row["musiID"].ToString()),
                    musicName = row["musicName"].ToString(),
                    musicPath = row["musicPath"].ToString(),
                    album = row["album"].ToString(),
                    artist = row["artist"].ToString(),
                    picPath=row["picPath"].ToString()
                });

            }
            return listmusic;

        }
        public List<Music> getMusicsByID(int id)
        {
            dataConnections = new DataConnection();
            List<Music> listmusic = new List<Music>();
            dataConnections.Initalize();
            String cmd = "select * from [Music] Where [musiID] between '"+(id-1)+"' and '"+(id+4)+"'";
            // System.Windows.
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd, dataConnections.openCon());
            DataTable dataTable = new DataTable();
            sqlAdapter.Fill(dataTable);
            dataConnections.closeCon();
            foreach (DataRow row in dataTable.Rows)
            {
                listmusic.Add(new Music
                {
                    musiID = int.Parse(row["musiID"].ToString()),
                    musicName = row["musicName"].ToString(),
                    musicPath = row["musicPath"].ToString(),
                    album = row["album"].ToString(),
                    artist = row["artist"].ToString(),
                    picPath = row["picPath"].ToString()
                });

            }
            return listmusic;

        }
        public virtual DbSet<Music> Musics { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Music>()
                .Property(e => e.musicName)
                .IsUnicode(false);

        modelBuilder.Entity<Music>()
                .Property(e => e.musicPath)
                .IsUnicode(false);

            modelBuilder.Entity<Music>()
                .Property(e => e.album)
                .IsUnicode(false);

            modelBuilder.Entity<Music>()
                .Property(e => e.artist)
                .IsUnicode(false);
        }
    }
}
