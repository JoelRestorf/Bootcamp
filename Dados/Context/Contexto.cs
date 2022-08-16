using Dados.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Dados.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<Noticia> Noticias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Noticia>().HasKey(n => n.Id);
            modelBuilder.Entity<Noticia>().Property(n => n.Fonte).HasColumnType("varchar(100)").IsRequired(true);
            modelBuilder.Entity<Noticia>().Property(n => n.Autor).HasColumnType("varchar(100)").IsRequired(false);
            modelBuilder.Entity<Noticia>().Property(n => n.Titulo).HasColumnType("varchar(200)").IsRequired(true);
            modelBuilder.Entity<Noticia>().Property(n => n.Descricao).HasColumnType("varchar(250)").IsRequired(true);
            modelBuilder.Entity<Noticia>().Property(n => n.URL).HasColumnType("varchar(250)").IsRequired(true);
            modelBuilder.Entity<Noticia>().Property(n => n.ImagemURL).HasColumnType("varchar(250)").IsRequired(true);
            modelBuilder.Entity<Noticia>().Property(n => n.DataPublicacao).HasColumnType("DateTime").IsRequired(true);
            modelBuilder.Entity<Noticia>().Property(n => n.Conteudo).HasColumnType("varchar(300)").IsRequired(true);
            modelBuilder.Entity<Noticia>().Property(n => n.Positiva).HasColumnType("bit").IsRequired(true);
            modelBuilder.Entity<Noticia>().Property(n => n.Negativa).HasColumnType("bit").IsRequired(true);
            modelBuilder.Entity<Noticia>().Property(n => n.Neutra).HasColumnType("bit").IsRequired(true);
        }
    }
}

