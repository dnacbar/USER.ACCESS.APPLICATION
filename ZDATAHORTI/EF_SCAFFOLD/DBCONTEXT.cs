using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Z_DATAHORTI.EF_SCAFFOLD
{
    public partial class DBHORTIUSERCONTEXT : DbContext
    {
        public DBHORTIUSERCONTEXT()
        {
        }

        public DBHORTIUSERCONTEXT(DbContextOptions<DBHORTIUSERCONTEXT> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.DsLogin)
                    .HasName("PK_USERHORTI");

                entity.ToTable("USER");

                entity.Property(e => e.DsLogin)
                    .HasMaxLength(40)
                    .HasColumnName("DS_LOGIN");

                entity.Property(e => e.BoActive)
                    .IsRequired()
                    .HasColumnName("BO_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DsPassword)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("DS_PASSWORD");

                entity.Property(e => e.DtAtualization)
                    .HasPrecision(3)
                    .HasColumnName("DT_ATUALIZATION")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtCreation)
                    .HasPrecision(3)
                    .HasColumnName("DT_CREATION")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
