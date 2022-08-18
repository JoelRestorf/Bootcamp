using System;
using System.Collections.Generic;
using System.Text;

namespace FuncaoClipping.Dominio
{
    public class News
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public IEnumerable<Articles> articles { get; set; }
    }
}
