using System;
using System.Collections.Generic;
using System.Text;

namespace Servico.Contexto
{
    public class Noticias
    {
        public int Id { get; set; }
        public string Fonte { get; set; }
        public string Autor { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string URL { get; set; }
        public string ImagemURL { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Conteudo { get; set; }
        public bool Positiva { get; set; }
        public bool Negativa { get; set; }
        public bool Neutra { get; set; }
    }
}
