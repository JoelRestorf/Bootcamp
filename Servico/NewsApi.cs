using Servico.Dominio;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace Servico
{
    public class NewsApi
    {
        private const string newsApiGoogle = "https://newsapi.org/v2/everything";
        private const string token = "a6b4a886693649f9ae4aa9f8653147df";
        private const string language = "pt";

        public Dominio.News BuscarNoticiasTermo(string termo, DateTime dataInicial, DateTime dataFinal)
        {
            HttpClient client = new HttpClient();
            var endpoint = $"{newsApiGoogle}?q={termo}&language={language}&from={dataInicial.ToString("yyyy-MM-dd")}&to={dataFinal.ToString("yyyy-MM-dd")}&apiKey={token}";
            client.BaseAddress = new Uri(newsApiGoogle);

            var response = client.GetAsync(endpoint).Result;
            if (response.IsSuccessStatusCode)
            {
                using var contentStream = response.Content.ReadAsStreamAsync().Result;
                var noticias = JsonSerializer.DeserializeAsync<Dominio.News>(contentStream).Result;
                GravarNoticiasBase(noticias.articles);
            }

            return null;
        }

        public void GravarNoticiasBase(IEnumerable<Articles> noticias)
        {
            using (var context = new Contexto.Contexto())
            {

                foreach (var noticia in noticias)
                {
                    context.Add(new Contexto.Noticia
                    {
                        Autor = noticia.author,
                        Conteudo = noticia.content,
                        DataPublicacao = noticia.publishedAt,
                        Descricao = noticia.description,
                        Fonte = noticia.source.name,
                        ImagemURL = noticia.urlToImage,
                        Titulo = noticia.title,
                        URL = noticia.url

                    });

                }

                context.SaveChanges();

            }
        }
    }
}
