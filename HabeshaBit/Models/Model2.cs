namespace HabeshaBit.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
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
                .Property(e => e.picPath)
                .IsUnicode(false);
        }
    }
}
