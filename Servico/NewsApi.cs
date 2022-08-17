using Servico.Dominio;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;

namespace Servico
{
    public class NewsApi
    {
        private const string newsApiGoogle = "https://newsapi.org/v2/everything";
        private const string token = "a6b4a886693649f9ae4aa9f8653147df";
        private const string language = "pt";

        public async Task<Dominio.News> BuscarNoticiasTermo(string termo, DateTime dataInicial, DateTime dataFinal)
        {
            HttpClient client = new HttpClient();
            var endpoint = $"{newsApiGoogle}?q={termo}&language={language}&from={dataInicial.ToString("yyyy-MM-dd")}&apiKey={token}";
            //client.BaseAddress = new Uri(newsApiGoogle);
            var URI = new Uri(endpoint);

            var response = await client.GetAsync(URI,HttpCompletionOption.ResponseContentRead);
            if (response.IsSuccessStatusCode)
            {
                using var contentStream = response.Content.ReadAsStreamAsync().Result;
                var noticias = JsonSerializer.DeserializeAsync<Dominio.News>(contentStream).Result;
                GravarNoticiasBase(noticias.articles);
            }

            return null;
        }

        public static void BuscaNoticiasTermoPackage(string termo, DateTime dataInicial)
        {
            // init with your API key
            var newsApiClient = new NewsApiClient(token);
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = termo,
                SortBy = SortBys.Relevancy,
                Language = Languages.PT,
                From = dataInicial
            });
            if (articlesResponse.Status == Statuses.Ok)
            {
                // total results found
                Console.WriteLine(articlesResponse.TotalResults);

                try
                {
                    using (var context = new Contexto.Contexto())
                    {
                        foreach (var article in articlesResponse.Articles)
                        {
                            if (article.Title != null)
                            {
                                context.Noticias.Add(new Contexto.Noticias
                                {
                                    Autor = article.Author,
                                    Conteudo = article.Content.Substring(0, article.Content.Length > 350 ? 349 : article.Content.Length - 1),
                                    DataPublicacao = article.PublishedAt ?? DateTime.Now,
                                    Descricao = article.Description.Substring(0, article.Description.Length > 250 ? 249 : article.Description.Length - 1),
                                    Fonte = article.Source.Name,
                                    ImagemURL = article.UrlToImage,
                                    Titulo = article.Title,
                                    URL = article.Url

                                });
                            }
                        }

                        context.SaveChanges();
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine("Erro:" + ex.Message);
                }
            }
        }

        public void GravarNoticiasBase(IEnumerable<Articles> noticias)
        {
            using (var context = new Contexto.Contexto())
            {

                foreach (var noticia in noticias)
                {
                    context.Add(new Contexto.Noticias
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
