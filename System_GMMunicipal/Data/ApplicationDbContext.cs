using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System_GMMunicipal.Models;

namespace System_GMMunicipal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Provicia> Provicias { get; set; }

        public DbSet<Municipio> Municipios { get; set; }

        public DbSet<Condutor> Condutors { get; set; }

        public DbSet<Acidente> Acidentes { get; set; }

        public DbSet<EscolasCoducao> escolasCoducaos { get; set; }

        public DbSet<FiscalUtilizador> FiscalUtilizadors { get; set; }

        public DbSet<FormacaoReciclagem> FormacaoReciclagems { get; set; }

        public DbSet<Infracao> Infracaos { get; set; }

        public DbSet<Inspencao> Inspencaos { get; set; }

        public DbSet<Licenca> Licencas { get; set; }

        public DbSet<Motorizada> Motorizadas { get; set; }

        public DbSet<Pagamento> Pagamentos { get; set; }

        public DbSet<Receita> Receitas { get; set; }

        public DbSet<TiposInfracoe> TiposInfracoes { get; set; }

        public DbSet<Curso> Cursos { get; set; }


        protected override void OnModelCreating(
    ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Receita>()
                .HasOne(r => r.Municipio)
                .WithMany(m => m.Receitas)
                .HasForeignKey(r => r.MunicipioId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Acidente>()
                .HasOne(a => a.Motorizada)
                .WithMany(m => m.Acidentes)
                .HasForeignKey(a => a.MotorizadaId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Infracao>()
                .HasOne(i => i.FiscalUtilizador)
                .WithMany(f => f.Infracaos)
                .HasForeignKey(i => i.FiscalId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Infracao>()
                .HasOne(i => i.Motorizada)
                .WithMany(m => m.infracaos)
                .HasForeignKey(i => i.MotorizadaId)
                .OnDelete(DeleteBehavior.NoAction);

            // Desactivar cascata em todas as relações
            // de chave estrangeira do modelo.
            foreach (var foreignKey in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior =
                    DeleteBehavior.NoAction;
            }
        }
    }
}
