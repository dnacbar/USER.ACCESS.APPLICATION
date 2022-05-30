using Microsoft.EntityFrameworkCore;
using USER.ACCESS.COMMAND.DOMAIN.MODEL;

namespace USER.ACCESS.COMMAND.REPOSITORY.CONTEXT
{
    public partial class DBUSERCONTEXT : DbContext
    {
        public DBUSERCONTEXT() { }

        public DBUSERCONTEXT(DbContextOptions<DBUSERCONTEXT> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DOMAIN.MODEL.UserSystem>(entity =>
            {
                entity.HasKey(e => e.IdSystem);

                entity.ToTable("SYSTEM");

                entity.Property(e => e.IdSystem)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_SYSTEM");

                entity.Property(e => e.BoActive)
                    .IsRequired()
                    .HasColumnName("BO_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DsDescription)
                    .HasMaxLength(500)
                    .HasColumnName("DS_DESCRIPTION");

                entity.Property(e => e.DsSystem)
                    .HasMaxLength(50)
                    .HasColumnName("DS_SYSTEM");

                entity.Property(e => e.DtAtualization)
                    .HasPrecision(3)
                    .HasColumnName("DT_ATUALIZATION")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtCreation)
                    .HasPrecision(3)
                    .HasColumnName("DT_CREATION")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => new { e.IdSystem, e.DsLogin });

                entity.ToTable("USER");

                entity.Property(e => e.IdSystem).HasColumnName("ID_SYSTEM");

                entity.Property(e => e.DsLogin)
                    .HasMaxLength(50)
                    .HasColumnName("DS_LOGIN");

                entity.Property(e => e.BoActive)
                    .IsRequired()
                    .HasColumnName("BO_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DsEmail)
                    .HasMaxLength(50)
                    .HasColumnName("DS_EMAIL");

                entity.Property(e => e.DsPhone)
                    .HasMaxLength(20)
                    .HasColumnName("DS_PHONE");

                entity.Property(e => e.DsUser)
                    .HasMaxLength(50)
                    .HasColumnName("DS_USER");

                entity.Property(e => e.DtAtualization)
                    .HasPrecision(3)
                    .HasColumnName("DT_ATUALIZATION")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtCreation)
                    .HasPrecision(3)
                    .HasColumnName("DT_CREATION")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdSystemNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdSystem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERSYSTEM_SYSTEM");
            });

            modelBuilder.Entity<Userkey>(entity =>
            {
                entity.HasKey(e => new { e.IdSystem, e.DsLogin });

                entity.ToTable("USERKEY");

                entity.Property(e => e.IdSystem).HasColumnName("ID_SYSTEM");

                entity.Property(e => e.DsLogin)
                    .HasMaxLength(50)
                    .HasColumnName("DS_LOGIN");

                entity.Property(e => e.DsKey).HasColumnName("DS_KEY");

                entity.Property(e => e.DtAtualization)
                    .HasPrecision(3)
                    .HasColumnName("DT_ATUALIZATION")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtCreation)
                    .HasPrecision(3)
                    .HasColumnName("DT_CREATION")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Userkey)
                    .HasForeignKey<Userkey>(d => new { d.IdSystem, d.DsLogin })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERKEY_USER");

                entity.HasMany(d => d.IdUserkeytypes)
                    .WithMany(p => p.Userkeys)
                    .UsingEntity<Dictionary<string, object>>(
                        "Userkeytypejoin",
                        l => l.HasOne<Userkeytype>().WithMany().HasForeignKey("IdUserkeytype").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_USERKEYTYPEJOIN_USERKEYTYPE"),
                        r => r.HasOne<Userkey>().WithMany().HasForeignKey("IdSystem", "DsLogin").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_USERKEYTYPEJOIN_USERKEY"),
                        j =>
                        {
                            j.HasKey("IdSystem", "DsLogin", "IdUserkeytype");

                            j.ToTable("USERKEYTYPEJOIN");

                            j.IndexerProperty<Guid>("IdSystem").HasColumnName("ID_SYSTEM");

                            j.IndexerProperty<string>("DsLogin").HasMaxLength(50).HasColumnName("DS_LOGIN");

                            j.IndexerProperty<Guid>("IdUserkeytype").HasColumnName("ID_USERKEYTYPE");
                        });
            });

            modelBuilder.Entity<Userkeytype>(entity =>
            {
                entity.HasKey(e => e.IdUserkeytype);

                entity.ToTable("USERKEYTYPE");

                entity.Property(e => e.IdUserkeytype)
                    .HasColumnName("ID_USERKEYTYPE")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DsKeytype)
                    .HasMaxLength(20)
                    .HasColumnName("DS_KEYTYPE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
