using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuncaoClipping.Contexto
{
    internal class Contexto : DbContext
    {
        public DbSet<Noticias> Noticias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:servidorbootcampici.database.windows.net,1433;Initial Catalog=Clipping;Persist Security Info=False;User ID=clipping;Password=@ICIBootcamp#17;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

    }
}
