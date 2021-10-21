using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace apifilmes.Models
{
    public partial class apiDBContext : DbContext
    {
        public apiDBContext()
        {
        }

        public apiDBContext(DbContextOptions<apiDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAtor> TbAtors { get; set; }
        public virtual DbSet<TbDiretor> TbDiretors { get; set; }
        public virtual DbSet<TbFilme> TbFilmes { get; set; }
        public virtual DbSet<TbFilmeAtor> TbFilmeAtors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user id=root;password=1234;database=apiDB", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<TbAtor>(entity =>
            {
                entity.HasKey(e => e.IdAtor)
                    .HasName("PRIMARY");

                entity.Property(e => e.VlAltura).HasPrecision(10, 2);
            });

            modelBuilder.Entity<TbDiretor>(entity =>
            {
                entity.HasKey(e => e.IdDiretor)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.IdFilmeNavigation)
                    .WithMany(p => p.TbDiretors)
                    .HasForeignKey(d => d.IdFilme)
                    .HasConstraintName("tb_diretor_ibfk_1");
            });

            modelBuilder.Entity<TbFilme>(entity =>
            {
                entity.HasKey(e => e.IdFilme)
                    .HasName("PRIMARY");

                entity.Property(e => e.VlAvaliacao).HasPrecision(10, 2);
            });

            modelBuilder.Entity<TbFilmeAtor>(entity =>
            {
                entity.HasKey(e => e.IdFilmeAtor)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.IdAtorNavigation)
                    .WithMany(p => p.TbFilmeAtors)
                    .HasForeignKey(d => d.IdAtor)
                    .HasConstraintName("tb_filme_ator_ibfk_2");

                entity.HasOne(d => d.IdFilmeNavigation)
                    .WithMany(p => p.TbFilmeAtors)
                    .HasForeignKey(d => d.IdFilme)
                    .HasConstraintName("tb_filme_ator_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
