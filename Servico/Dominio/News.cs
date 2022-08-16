using System;
using System.Collections.Generic;
using System.Text;

namespace Servico.Dominio
{
    public class News
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public IEnumerable<Articles> articles { get; set; }
    }
}
