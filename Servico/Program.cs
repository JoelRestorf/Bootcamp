using Servico.Dominio;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace Servico
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //var noticias = new NewsApi().BuscarNoticiasTermo("Curitiba", DateTime.Now.AddMonths(-1), DateTime.Now);
            NewsApi.BuscaNoticiasTermoPackage("Curitiba", DateTime.Now.AddMonths(-1));
        }

    }
}
