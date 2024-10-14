//using Microsoft.EntityFrameworkCore;
//using WebCurriculum.Entities;

//namespace YourNamespace.Data
//{
//    public class AppDbContext : DbContext
//    {
//        public DbSet<Curriculo> Curriculos { get; set; }
//        public DbSet<Arquivo> Arquivos { get; set; }
//        public DbSet<CurriculoArquivo> CurriculoArquivos { get; set; }

//        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
//        {
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            // Configuração da chave composta para a tabela de junção CurriculoArquivo
//            modelBuilder.Entity<CurriculoArquivo>()
//                .HasKey(ca => new { ca.CurriculoId, ca.ArquivoId });

//            // Configuração do relacionamento muitos-para-muitos entre Curriculo e CurriculoArquivo
//            modelBuilder.Entity<CurriculoArquivo>()
//                .HasOne(ca => ca.Curriculo)
//                .WithMany(c => c.CurriculoArquivos)
//                .HasForeignKey(ca => ca.CurriculoId);

//            // Configuração do relacionamento muitos-para-muitos entre Arquivo e CurriculoArquivo
//            modelBuilder.Entity<CurriculoArquivo>()
//                .HasOne(ca => ca.Arquivo)
//                .WithMany(a => a.CurriculoArquivos)
//                .HasForeignKey(ca => ca.ArquivoId);

//            // Configurações adicionais para as entidades Curriculo e Arquivo (se necessário)
//            // Exemplo: modelBuilder.Entity<Curriculo>().Property(c => c.Nome).IsRequired();

//            base.OnModelCreating(modelBuilder);
//        }
//    }
//}

using Microsoft.EntityFrameworkCore;

namespace WebCurriculum.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Curriculo> Curriculos { get; set; }
        public DbSet<Arquivo> Arquivos { get; set; }
        public DbSet<CurriculoArquivo> CurriculoArquivos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurriculoArquivo>()
                .HasKey(ca => new { ca.CurriculoId, ca.ArquivoId });

            modelBuilder.Entity<CurriculoArquivo>()
                .HasOne(ca => ca.Curriculo)
                .WithMany(c => c.CurriculoArquivos)
                .HasForeignKey(ca => ca.CurriculoId);

            modelBuilder.Entity<CurriculoArquivo>()
                .HasOne(ca => ca.Arquivo)
                .WithMany(a => a.CurriculoArquivos)
                .HasForeignKey(ca => ca.ArquivoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
