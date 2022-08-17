using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servico.Contexto
{
    internal class Contexto : DbContext
    {
        public DbSet<Noticia> Noticia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP\\SQLEXPRESS;Database=Clipping;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }

    }
}
